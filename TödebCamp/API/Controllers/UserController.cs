using Business.Abstract;
using DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Authorize kontrolü yaparak ilgili endpointlere sadece Admin'in ulaşmabilmesini sağlıyoruz.
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        
        public IActionResult Register(CreateUserRegisterRequest register)
        {
            var response = _userService.Register(register);
            return Ok(response);

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _userService.GetAll();
            return Ok(data);
        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateUserRequest request)
        {
            var data = _userService.Update(request);
            return Ok(data);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(DeleteUserRequest request)
        {
            var data = _userService.Delete(request);
            return Ok(data);
        }
    }
}
