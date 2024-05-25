using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public  async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7293");

            var response = await client.GetStringAsync($"/api/Animal?searchString=Parrot");

            List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(response);
            ViewBag.SearchQuery = $"Displaying animals with search results: Parrot";

            return View(animals);
        }

        [HttpPost]
        public async Task<ActionResult> Index(string name)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7293");

            var response = await client.GetStringAsync($"/api/Animal?searchString={name}");

            List<Animal> animals = JsonConvert.DeserializeObject<List<Animal>>(response);
            ViewBag.SearchQuery = $"Displaying animals with search results: {name}";

            return View(animals);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}