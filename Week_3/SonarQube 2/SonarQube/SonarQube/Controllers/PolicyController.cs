     using Microsoft.AspNetCore.Mvc;
     using System.Collections.Generic;

     namespace InsuranceApi.Controllers
     {
         [ApiController]
         [Route("api/[controller]")]
    public class PolicyController : BaseController
    {
        [HttpGet]
        public IActionResult GetAllPolicies()
        {
            return GetAll("Policy");
        }

        [HttpGet("{id}")]
        public IActionResult GetPolicyById(int id)
        {
            return GetById(id, "Policy");
        }

        [HttpPost]
        public IActionResult CreatePolicy([FromBody] string policy)
        {
            return Create(policy, nameof(GetPolicyById));
        }
    }
     }
     