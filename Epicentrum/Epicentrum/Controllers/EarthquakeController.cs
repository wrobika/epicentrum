﻿using Epicentrum.Models;
using GeoAPI.Geometries;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            Task.Run(async () => { await DownloadData(); })
                .Wait();
        }

        public string GetEpicentrumsGeoJson()
        {
            FeatureCollection featureCollection = ToFeatureCollection(Earthquakes);

            var serializer = GeoJsonSerializer.Create();
            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, featureCollection);
            return stringWriter.ToString();
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
            Earthquakes = System.Text.Json.JsonSerializer
                .DeserializeAsync<ArcGisData>(responseStream)
                .Result
                .Earthquakes;
        }

        private FeatureCollection ToFeatureCollection(IList<Earthquake> earthquakes)
        {
            IEnumerable<Feature> features = earthquakes.Select(item => item.ToFeature());
            FeatureCollection featureCollection = new FeatureCollection();
            foreach (var item in features)
                featureCollection.Add(item);
            return featureCollection;
        }
    }
}