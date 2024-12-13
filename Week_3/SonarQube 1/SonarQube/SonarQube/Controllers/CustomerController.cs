     using Microsoft.AspNetCore.Mvc;
     using System.Collections.Generic;

     namespace InsuranceApi.Controllers
     {
         [ApiController]
         [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var data = GetCustomersList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var data = GetCustomer(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] string customer)
        {
            return CreatedAtAction(nameof(GetCustomerById), new { id = 1 }, customer);
        }

        // Private methods to handle common logic
        private List<string> GetCustomersList()
        {
            return new List<string> { "Customer1", "Customer2", "Customer3" };
        }

        private string GetCustomer(int id)
        {
            return $"Customer{id}";
        }
    }
     }
     