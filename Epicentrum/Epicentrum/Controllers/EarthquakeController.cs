using Epicentrum.Models;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Features;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Epicentrum.Controllers
{
    public class EarthquakeController : Controller
    {
        public IDictionary<int, Earthquake> Earthquakes { get; private set; }

        public EarthquakeController(IWebHostEnvironment webHostEnvironment)
        {
            DTOController dtoController = new DTOController(webHostEnvironment);
            Earthquakes = dtoController.GetEarthquakes();
        }

        public string GetEpicentrums()
        {
            return ToGeoJson(Earthquakes);
        }

        public string GetEpicentrumsBy(int year, int deaths)
        {
            IEnumerable<KeyValuePair<int, Earthquake>> filteredEarthquakes = Earthquakes;
            if (year != 0)
                filteredEarthquakes = filteredEarthquakes.Where(item => item.Value.Date.Year == year);
            if (deaths != 0)
                filteredEarthquakes = filteredEarthquakes.Where(item => item.Value.Deaths == deaths);
            return ToGeoJson(filteredEarthquakes);
        }

        public Earthquake Details(int id)
        {
            return Earthquakes[id];
        }

        private string ToGeoJson(IEnumerable<KeyValuePair<int, Earthquake>> earthquakes)
        {
            FeatureCollection featureCollection = ToFeatureCollection(earthquakes);

            var serializer = GeoJsonSerializer.Create();
            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, featureCollection);
            return stringWriter.ToString();
        }
        private FeatureCollection ToFeatureCollection(IEnumerable<KeyValuePair<int,Earthquake>> earthquakes)
        {
            IEnumerable<Feature> features = earthquakes
                .Where(item => item.Value.Magnitude.HasValue)
                .Select(item => item.Value.ToFeature());
            FeatureCollection featureCollection = new FeatureCollection();
            foreach (var item in features)
                featureCollection.Add(item);
            return featureCollection;
        }
    }
}
