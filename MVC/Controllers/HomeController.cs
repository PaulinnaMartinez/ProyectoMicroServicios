using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        PetAPI _api = new PetAPI();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<User> pets = new List<User>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/pet");

            var results = res.Content.ReadAsStringAsync().Result;
            pets = JsonConvert.DeserializeObject<List<User>>(results);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
