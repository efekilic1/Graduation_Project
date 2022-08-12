using Microsoft.AspNetCore.Mvc;
using Bussines.Abstract;
using Models.Document;
using MongoDB.Bson;
using DTO.Voucher;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _service;

        public VoucherController(IVoucherService service)
        {
            _service = service;
        }



        
        [HttpPost]
      
        

        public IActionResult Post(CreateVoucherRequest request)
        {
            var response = _service.Create(request);
            return Ok(response);
        }



    }
}