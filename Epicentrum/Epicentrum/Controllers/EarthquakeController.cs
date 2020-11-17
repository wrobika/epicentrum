using Epicentrum.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Epicentrum.Controllers
{
    public class EarthquakeController : Controller
    {
        public IList<Earthquake> Earthquakes { get; private set; }
        private readonly IHttpClientFactory _clientFactory;

        public EarthquakeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            var task = Task.Run(async () => { await DownloadData(); });
            task.Wait();
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
                Earthquakes = Array.Empty<Earthquake>();
        }

        private async Task DeserializeData(HttpResponseMessage response)
        {
            using var responseStream = await response.Content
                .ReadAsStreamAsync();
            Earthquakes = JsonSerializer
                .DeserializeAsync<ArcGisData>(responseStream)
                .Result
                .Earthquakes;
        }
    }
}
