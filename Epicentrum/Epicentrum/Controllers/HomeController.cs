using Epicentrum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Epicentrum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EarthquakeController _earthquakeController;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _earthquakeController = new EarthquakeController(clientFactory);
        }

        public IActionResult Index()
        {
            ViewBag.Text = _earthquakeController.Earthquakes.LastOrDefault().Epicentrum.Longitude.ToString();
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
