using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace MVC.Controllers
{
    public class BaseController : Controller
    {
        protected Uri baseAdress = new Uri("http://localhost:5000/api/");
        protected HttpClient client;

        public BaseController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAdress;
            client.Timeout = TimeSpan.FromMinutes(10);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
