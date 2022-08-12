using System.Linq;
using Business.Abstract;
using DAL.Abstract;
using DTO.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;


        public MessageController(IMessageService messageService, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _messageService = messageService;
            _userRepository = userRepository;
        }

        // Authorize kontrolü yaparak ilgili endpointlere sadece hesabına giriş yapan yetki sahibi userların
        // ulaşmabilmesini sağlıyoruz.

        [Authorize]

        [HttpPost("CreateMessage")]
        public IActionResult Create(CreateMessageRequest request)
        {
            
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value);
            var user = _userRepository.Get(x => x.Id == userId);
            string email = user.Email;
            var response = _messageService.Create(request, userId, email);
            return Ok(response);

        }

        [Authorize(Roles = "Admin")]

        [HttpPost("CreateNotice")]
        public IActionResult CreateNotice(CreateMessageRequest request)
        {

            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value);
            var user = _userRepository.Get(x => x.Id == userId);
            string email = user.Email;
            var response = _messageService.CreateNotice(request, userId, email);
            return Ok(response);

        }



        [Authorize(Roles = "Admin")]

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _messageService.GetAll();
            return Ok(data);
        }

        [Authorize(Roles = "User")]

        [HttpGet("GetMessages")]
        public IActionResult Get()
        {
            int userId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value);
            var data = _messageService.Get(userId);
           return Ok(data);

        }

        [Authorize(Roles = "User")]

        [HttpGet("GetNotices")]
        public IActionResult GetNotices()
        {
            
            var data = _messageService.GetNotices();
            return Ok(data);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public IActionResult Delete(DeleteMessageRequest request)
        {
            var data = _messageService.Delete(request);
            return Ok(data);
        }



    }
}
