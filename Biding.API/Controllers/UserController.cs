using Microsoft.AspNetCore.Mvc;
using Biding.Application.DTOs;
using Biding.Domain.Models;

namespace Biding.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public async Task<ActionResult>GetUser()
        {
            var Result = UserService.GetUser();
            return Ok(true);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>>GetUserByID(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var Result = UserService.GetUserByID(userId);
            if (Result == null)
            {
                return NotFound($"User With ID : {userId} Not Found ");
            }
            return Ok(true);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> RegisterUser([FromBody] RegisterDTO user)
        {
            UserService.RegisterUser(user);
            return Ok(true);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<bool>> LoginUser([FromBody] LoginDTO user)
        {
            var result = UserService.LoginUser(user)
            if (result == null)
                return BadRequest("Invalid");
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int userId, UserDTO user)
        {
            var result = UserService.UpdateUser(userId, user);

            if (result == null)
                return NotFound($"user With ID : {userId} Not Found");
            else
                return result;
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<ResetPasswordDTO>> UpdatePassword(int userId, ResetPasswordDTO password)
        {
            var result = UserService.UpdatePassword(userId, password);

            if (result == null)
                return NotFound($"user With ID : {userId} Not Found");
            else
                return result;
        }

        [HttpDelete("{userId}")]
        public async void DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid ID");
            }
            UserService.DeleteUser(userId);
        }
    }
}
