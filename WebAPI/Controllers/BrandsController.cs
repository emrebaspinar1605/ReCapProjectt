using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllBrand()
        {
            var result = _brandService.GetAll();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getbrandbyid/{id}")]
        public IActionResult GetBrandByID(int id)
        {
            var result = _brandService.GetByID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.Add(brand);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.Update(brand);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteBrand(Brand brand)
        {
            var result = _brandService.Delete(brand);

            if (result.Success) return Ok(result);
            return Ok(result);
        }
    }
    
}
