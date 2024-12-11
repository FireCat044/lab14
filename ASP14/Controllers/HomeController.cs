using ASP14.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP14.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("api/custom")]
        public IActionResult CustomEndpoint()
        {
            var activity = System.Diagnostics.Activity.Current;
            if (activity != null)
            {
                activity.SetTag("endpoint.name", "CustomEndpoint");
                activity.SetTag("operation.status", "success");
            }

            return Ok("Hello, OpenTelemetry!");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
