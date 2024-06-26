﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllColor()
        {
            var result = _colorService.GetAll();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getcolorbyid/{id}")]
        public IActionResult GetColorByID(int id)
        {
            var result = _colorService.GetByID(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.Add(color);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteColor(Color color)
        {
            var result = _colorService.Delete(color);

            if (result.Success) return Ok(result);
            return Ok(result);
        }
    }
}
