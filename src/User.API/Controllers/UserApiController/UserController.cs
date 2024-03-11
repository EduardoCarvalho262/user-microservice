using Microsoft.AspNetCore.Mvc;
using User.API.Interfaces;
using User.API.Models;

namespace User.API.Controllers.UserApiController
{
    [ApiController]
    [Route("api/v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTService _jwtService;

        public UserController(IUserService userService, IJWTService jWTService)
        {
            _userService = userService;
            _jwtService = jWTService;
        }

        [HttpGet("users")]
        public List<UserModel> GetAllUsers()
        {
            var response = _userService.GetAll();
            return response;
        }

        [HttpGet("user/{id:guid}")]
        public UserModel GetById(Guid id)
        {
            var response = _userService.GetById(id);
            return response;
        }


        [HttpPost("user")]
        public ActionResult<UserModel> CreateUser([FromBody]UserModel user)
        {
            if (user is null)
                return NotFound();

            var response = _userService.CreateUser(user);

            if (response is null)
                return BadRequest("Ocorreu um erro");

            return Ok(user);
        }

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            var response = _jwtService.CreateToken(user);

            if (response.Contains("Invalid"))
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpGet("validateToken")]
        public IActionResult ValidateToken(string token)
        {
            var response = _jwtService.ValidateToken(token);

            if (response is false)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
