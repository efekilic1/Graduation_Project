using Business.Abstract;
using DTO.Bill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        // Authorize kontrolü yaparak ilgili endpointlere sadece Admin'in ulaşmabilmesini sağlıyoruz.

        [Authorize(Roles = "Admin")]

        [HttpPost("Create")]
            public IActionResult Create(CreateBillRequest request)
            {
                var response = _billService.Create(request);
                return Ok(response);

            }

        [Authorize(Roles = "Admin")]

        [HttpGet("GetAll")]
             public IActionResult GetAll()
             {
            var data = _billService.GetAll();
            return Ok(data);
             }
        // Authorize kontrolü yaparak ilgili endpointlere sadece hesabına giriş yapan yetki sahibi userların
        // ulaşmabilmesini sağlıyoruz.

        [Authorize]
        [HttpGet("GetBills")]
        public IActionResult Get()
        {
            var data = _billService.Get();
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public IActionResult Update(UpdateBillRequest request)
        {
            var data = _billService.Update(request);
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public IActionResult Delete(DeleteBillRequest request)
        {
            var data = _billService.Delete(request);
            return Ok(data);
        }






    }
    
}
