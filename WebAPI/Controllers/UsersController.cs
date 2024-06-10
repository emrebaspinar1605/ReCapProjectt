using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllUser()
        {
            var result = _userService.GetAll();

            if (result.Success) return Ok(result);
            return Ok(result);

        }

        [HttpGet("getuserbyid/{id}")]
        public IActionResult GetUserByID(int id)
        {
            var result = _userService.GetById(id);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.Add(user);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateUser(User user)
        {
            var result = _userService.Update(user);

            if (result.Success) return Ok(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteUser(User user)
        {
            var result = _userService.Delete(user);

            if (result.Success) return Ok(result);
            return Ok(result);
        }
    }
    
}
