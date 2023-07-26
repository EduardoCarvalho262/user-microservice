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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
    }
}
