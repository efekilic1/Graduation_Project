using Business.Abstract;
using DTO.Apartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Authorize kontrolü yaparak ilgili endpointlere sadece Admin'in ulaşmabilmesini sağlıyoruz.
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class ApartmentController : ControllerBase
    {

        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateApartmentRequest request)
        {
            var response = _apartmentService.Create(request);
            return Ok(response);

        }

        [HttpPut("Update")]
        public IActionResult Update(UpdateApartmentRequest request)
        {
            var response = _apartmentService.Update(request);
            return Ok(response);

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _apartmentService.GetAll();
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteApartmentRequest request)
        {
            var response = _apartmentService.Delete(request);
            return Ok(response);
        }


    }
}
