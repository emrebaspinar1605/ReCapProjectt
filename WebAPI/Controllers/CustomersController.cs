using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllCustomer()
        {
            var result = _customerService.GetAll();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getcustomerbyid/{id}")]
        public IActionResult GetCustomerByID(int id)
        {
            var result = _customerService.GetByID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet("getcustomerdetails")]
        public IActionResult GetCustomerDetails()
        {
            var result = _customerService.GetCustomerDetail();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getcustomersbyuserid/{id}")]
        public IActionResult GetCustomerByUserId(int id)
        {
            var result = _customerService.GetByUserID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddCar(Customer customer)
        {
            var result = _customerService.Add(customer);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.Update(customer);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            var result = _customerService.Delete(customer);

            if (result.Success) return Ok(result);
            return Ok(result);
        }


    }
    
}
