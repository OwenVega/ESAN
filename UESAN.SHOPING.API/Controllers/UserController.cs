using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using   UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Interfaces;
namespace UESAN.SHOPING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("signin")]
        public async Task<ActionResult<LoginDTO>> SignIn(SignInDTO signInDTO)
        {
            var result = await _userService.SignIn(signInDTO);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }


        [HttpPost("signup")]
        public async Task<ActionResult<int>> SignUp(UserCreateDTO userCreateDTO)
        {
            var userId = await _userService.SignUp(userCreateDTO);
            return Ok(userId);
        }



    }
}