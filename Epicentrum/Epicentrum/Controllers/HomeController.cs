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
        public ArcGisData EarthquakesData { get; private set; }
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            await DownloadData();
            ViewBag.Text = EarthquakesData.Features.FirstOrDefault().Geometry.Longitude.ToString();
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

        private async Task DownloadData()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           "https://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Earthquakes/Since_1970/MapServer/0/query?where=1%3D1&outFields=*&f=json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                await DeserializeData(response);
            else
                EarthquakesData.Features = Array.Empty<Feature>();
        }

        private async Task DeserializeData(HttpResponseMessage response)
        {
            using var responseStream = await response.Content.ReadAsStreamAsync();
            EarthquakesData = await JsonSerializer.DeserializeAsync
                <ArcGisData>(responseStream);
        }
    }
}
