using System.Net.Http.Json;
using System.Threading.Tasks;
using Business.Configuration.Auth;
using DTO.Auth;
using DTO.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class LoginController : BaseController
    {
        

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginDto model)
        {
            var response = await client.PostAsJsonAsync("Auth/Login", model);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<TokenDto>();
                HttpContext.Session.SetString("Authorization", content.Token);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Authorization").ToString()) ;
                var v = content.Token;
                return View(v);
            }
            

            return View();
        }
    }
}
