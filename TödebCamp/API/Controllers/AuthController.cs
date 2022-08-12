using AutoMapper;
using Business.Abstract;
using DTO.Auth;
using DTO.Tokens;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    // Login işlemlerimizi bu endpointleri kullanarak yapıyoruz
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("VerifyPassword")]
        public IActionResult VerifyPassword(string email, string password)
        {
            var response = _authService.VerifyPassword(email, password);
            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var response = _authService.Login(loginDto.Email, loginDto.Password);
            
            return Ok(_mapper.Map<TokenDto>(response));
        }


    }
}
