using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllCar()
        {
            var result = _carService.GetAll();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getcarbyid/{id}")]
        public IActionResult GetCarByID(int id)
        {
            var result = _carService.GetCarByID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getcarsbybrandid/{id}")]
        public IActionResult GetCarByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }
        
        [HttpGet("getcarsbycolorid/{id}")]
        public IActionResult GetCarByColorId(int id)
        {
            var result = _carService.GetCarsByColorID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddCar(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success) return Ok(result);
            return Ok(result);
        }


    }

}
