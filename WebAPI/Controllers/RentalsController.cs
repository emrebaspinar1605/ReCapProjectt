using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllRental()
        {
            var result = _rentalService.GetAll();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getrentalbyid/{id}")]
        public IActionResult GetRentalByID(int id)
        {
            var result = _rentalService.GetRentalByID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateRental(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteRental(Rental rental)
        {
            var result = _rentalService.Delete(rental);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet("getrentalsbycarid/{id}")]
        public IActionResult GetRentalByCarID(int id)
        {
            var result = _rentalService.GetRentalByCarID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet("getrentalsbycustomerid/{id}")]
        public IActionResult GetRentalByCustomerID(int id)
        {
            var result = _rentalService.GetRentalByCustomerID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _rentalService.GetRentalDetails();

            if (result.Success) return Ok(result);
            return Ok(result);
        }


    }
    
}
