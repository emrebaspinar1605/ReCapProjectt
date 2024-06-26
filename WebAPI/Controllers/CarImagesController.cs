using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carIService;
        public CarImagesController(ICarImageService carIService)
        {
            _carIService = carIService;
        }

        [HttpGet("getall")]
        public IActionResult GetALL()
        {
            var result = _carIService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);

        }

        [HttpGet("getbycarid/{carid}")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carIService.GetByCarID(carId);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyimageid/{imageId}")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = _carIService.GetByImageID(imageId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult AddImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carIService.Add(file, carImage);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carIService.Update(file, carImage);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteImage(int carImageId)
        {
            var carDeleteImage = _carIService.GetByImageID(carImageId).Data;
            var result = _carIService.Delete(carDeleteImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

    }
}
