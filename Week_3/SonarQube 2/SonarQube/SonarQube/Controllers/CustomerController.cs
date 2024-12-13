using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers
{
    public class CustomerController : BaseController
    {
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return GetAll("Customer");
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return GetById(id, "Customer");
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] string customer)
        {
            return Create(customer, nameof(GetCustomerById));
        }
    }
}
