using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GitCopilotDemo.Controllers
{
    // DbContext class
    public class PolicyDbContext : DbContext
    {
        public DbSet<Policy> Policies { get; set; }

    }

    // Command and Query Interfaces
    public interface ICommand { }
    public interface IQuery<TResult> { }

    // Command Handlers
    public class CreatePolicyCommand : ICommand
    {
        public required Policy Policy { get; set; }
    }

    public class UpdatePolicyCommand : ICommand
    {
        public required Policy Policy { get; set; }
    }

    public class DeletePolicyCommand : ICommand
    {
        public required string PolicyNumber { get; set; }
    }

    public class CreatePolicyHandler
    {
        private readonly PolicyDbContext _context;

        public CreatePolicyHandler(PolicyDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreatePolicyCommand command)
        {
            await _context.Policies.AddAsync(command.Policy);
            await _context.SaveChangesAsync();
        }
    }

    public class UpdatePolicyHandler
    {
        private readonly PolicyDbContext _context;

        public UpdatePolicyHandler(PolicyDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdatePolicyCommand command)
        {
            _context.Policies.Update(command.Policy);
            await _context.SaveChangesAsync();
        }
    }

    public class DeletePolicyHandler
    {
        private readonly PolicyDbContext _context;

        public DeletePolicyHandler(PolicyDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeletePolicyCommand command)
        {
            var policy = await _context.Policies.FirstOrDefaultAsync(p => p.PolicyNumber == command.PolicyNumber);
            if (policy != null)
            {
                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();
            }
        }
    }

    // Query Handlers
    public class GetPolicyByNumberQuery : IQuery<Policy>
    {
        public required string PolicyNumber { get; set; }
    }

    public class GetAllPoliciesQuery : IQuery<List<Policy>> { }

    public class GetPolicyByNumberHandler
    {
        private readonly PolicyDbContext _context;

        public GetPolicyByNumberHandler(PolicyDbContext context)
        {
            _context = context;
        }

        public async Task<Policy?> Handle(GetPolicyByNumberQuery query)
        {
            return await _context.Policies.AsNoTracking().FirstOrDefaultAsync(p => p.PolicyNumber == query.PolicyNumber);
        }
    }

    public class GetAllPoliciesHandler
    {
        private readonly PolicyDbContext _context;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "AllPolicies";

        public GetAllPoliciesHandler(PolicyDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<Policy>> Handle(GetAllPoliciesQuery query)
        {
            if (!_cache.TryGetValue(CacheKey, out List<Policy>? policies))
            {
                policies = await _context.Policies.AsNoTracking().ToListAsync() ?? new List<Policy>();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set(CacheKey, policies, cacheEntryOptions);
            }

            return policies;
        }
    }

    // Controller
    [ApiController]
    [Route("api/[controller]")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly CreatePolicyHandler _createHandler;
        private readonly UpdatePolicyHandler _updateHandler;
        private readonly DeletePolicyHandler _deleteHandler;
        private readonly GetPolicyByNumberHandler _getByNumberHandler;
        private readonly GetAllPoliciesHandler _getAllHandler;
        private readonly ILogger<InsurancePolicyController> _logger;

        public InsurancePolicyController(
            CreatePolicyHandler createHandler,
            UpdatePolicyHandler updateHandler,
            DeletePolicyHandler deleteHandler,
            GetPolicyByNumberHandler getByNumberHandler,
            GetAllPoliciesHandler getAllHandler,
            ILogger<InsurancePolicyController> logger)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getByNumberHandler = getByNumberHandler;
            _getAllHandler = getAllHandler;
            _logger = logger;
        }

        private async Task<IActionResult> HandleRequestAsync<TCommand>(Func<TCommand, Task> handler, TCommand command, Func<IActionResult> onSuccess)
        {
            try
            {
                await handler(command);
                return onSuccess();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "A database error occurred while processing the request.");
                return StatusCode(500, "Database error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creates a new policy.
        /// </summary>
        /// <param name="policy">The policy to create.</param>
        [HttpPost]
        public Task<IActionResult> CreatePolicy([FromBody] Policy policy)
        {
            return HandleRequestAsync(
                _createHandler.Handle,
                new CreatePolicyCommand { Policy = policy },
                () => CreatedAtAction(nameof(GetPolicyByNumber), new { policyNumber = policy.PolicyNumber }, policy)
            );
        }

        /// <summary>
        /// Updates an existing policy.
        /// </summary>
        /// <param name="policy">The policy to update.</param>
        [HttpPut]
        public Task<IActionResult> UpdatePolicy([FromBody] Policy policy)
        {
            return HandleRequestAsync(
                _updateHandler.Handle,
                new UpdatePolicyCommand { Policy = policy },
                () => Ok(policy)
            );
        }

        /// <summary>
        /// Deletes a policy by policy number.
        /// </summary>
        /// <param name="policyNumber">The policy number of the policy to delete.</param>
        [HttpDelete("{policyNumber}")]
        public Task<IActionResult> DeletePolicy(string policyNumber)
        {
            return HandleRequestAsync(
                _deleteHandler.Handle,
                new DeletePolicyCommand { PolicyNumber = policyNumber },
                () => NoContent()
            );
        }

        /// <summary>
        /// Gets a policy by policy number.
        /// </summary>
        /// <param name="policyNumber">The policy number of the policy to retrieve.</param>
        [HttpGet("{policyNumber}")]
        public async Task<IActionResult> GetPolicyByNumber(string policyNumber)
        {
            try
            {
                var policy = await _getByNumberHandler.Handle(new GetPolicyByNumberQuery { PolicyNumber = policyNumber });
                if (policy == null)
                {
                    return NotFound();
                }
                return Ok(policy);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the policy.");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets all policies.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPolicies()
        {
            try
            {
                var policies = await _getAllHandler.Handle(new GetAllPoliciesQuery());
                return Ok(policies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all policies.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}