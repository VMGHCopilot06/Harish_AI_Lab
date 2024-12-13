     using Microsoft.AspNetCore.Mvc;
     using System.Collections.Generic;

     namespace InsuranceApi.Controllers
     {
         [ApiController]
         [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPolicies()
        {
            var data = GetPoliciesList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetPolicyById(int id)
        {
            var data = GetPolicy(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreatePolicy([FromBody] string policy)
        {
            return CreatedAtAction(nameof(GetPolicyById), new { id = 1 }, policy);
        }

        // Private methods to handle common logic
        private List<string> GetPoliciesList()
        {
            return new List<string> { "Policy1", "Policy2", "Policy3" };
        }

        private string GetPolicy(int id)
        {
            return $"Policy{id}";
        }
    }
     }
     