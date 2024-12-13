     using Microsoft.AspNetCore.Mvc;
     using System.Collections.Generic;

     namespace InsuranceApi.Controllers
     {
         [ApiController]
         [Route("api/[controller]")]
    public class ClaimsController : BaseController
    {
        [HttpGet]
        public IActionResult GetAllClaims()
        {
            return GetAll("Claim");
        }

        [HttpGet("{id}")]
        public IActionResult GetClaimById(int id)
        {
            return GetById(id, "Claim");
        }

        [HttpPost]
        public IActionResult CreateClaim([FromBody] string claim)
        {
            return Create(claim, nameof(GetClaimById));
        }
    }
     }
     