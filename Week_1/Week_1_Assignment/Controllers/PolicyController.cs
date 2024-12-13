using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week_1_Assignment.Data;

namespace Week_1_Assignment.Controllers
{
    /// <summary>
    /// API controller for managing policies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Token-based authorization
    public class PolicyController : ControllerBase, IPolicyController
    {
        private readonly PolicyDbContext _context;
        private readonly ILogger<PolicyController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="logger">The logger instance.</param>
        public PolicyController(PolicyDbContext context, ILogger<PolicyController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets a paginated list of policies.
        /// </summary>
        /// <param name="pageNumber">The page number (default is 1).</param>
        /// <param name="pageSize">The page size (default is 10).</param>
        /// <returns>A list of policies.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var policies = await _context.Policies
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return Ok(policies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting policies.");
                return StatusCode(500, "An error occurred while getting policies.");
            }
        }

        /// <summary>
        /// Gets a specific policy by ID.
        /// </summary>
        /// <param name="id">The policy ID.</param>
        /// <returns>The policy with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid policy ID.");
            }

            try
            {
                var policy = await _context.Policies.FindAsync(id);

                if (policy == null)
                {
                    return NotFound();
                }

                return Ok(policy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the policy with ID {id}.");
                return StatusCode(500, "An error occurred while getting the policy.");
            }
        }

        /// <summary>
        /// Updates an existing policy.
        /// </summary>
        /// <param name="id">The policy ID.</param>
        /// <param name="policy">The policy to update.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, Policy policy)
        {
            if (id != policy.PolicyId)
            {
                return BadRequest("Policy ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PolicyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"A concurrency error occurred while updating the policy with ID {id}.");
                    return StatusCode(500, "A concurrency error occurred while updating the policy.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the policy with ID {id}.");
                return StatusCode(500, "An error occurred while updating the policy.");
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a new policy.
        /// </summary>
        /// <param name="policy">The policy to create.</param>
        /// <returns>The created policy.</returns>
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Policies.Add(policy);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPolicy", new { id = policy.PolicyId }, policy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new policy.");
                return StatusCode(500, "An error occurred while creating a new policy.");
            }
        }

        /// <summary>
        /// Deletes a specific policy by ID.
        /// </summary>
        /// <param name="id">The policy ID.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid policy ID.");
            }

            try
            {
                var policy = await _context.Policies.FindAsync(id);
                if (policy == null)
                {
                    return NotFound();
                }

                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the policy with ID {id}.");
                return StatusCode(500, "An error occurred while deleting the policy.");
            }
        }

        /// <summary>
        /// Checks if a policy with the specified ID exists.
        /// </summary>
        /// <param name="id">The policy ID.</param>
        /// <returns>True if the policy exists, otherwise false.</returns>
        private bool PolicyExists(int id)
        {
            try
            {
                return _context.Policies.Any(e => e.PolicyId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while checking if the policy with ID {id} exists.");
                return false;
            }
        }
    }
}
