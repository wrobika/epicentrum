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

        public string GetEpicentrumsGeoJson()
        {
            FeatureCollection featureCollection = ToFeatureCollection(Earthquakes);

            var serializer = GeoJsonSerializer.Create();
            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            serializer.Serialize(jsonWriter, featureCollection);
            return stringWriter.ToString();
        }

        public Earthquake Details(int id)
        {
            return Earthquakes[id];
        }

        private FeatureCollection ToFeatureCollection(IDictionary<int,Earthquake> earthquakes)
        {
            IEnumerable<Feature> features = earthquakes.Values
                .Where(item => item.Magnitude.HasValue)
                .Select(item => item.ToFeature());
            FeatureCollection featureCollection = new FeatureCollection();
            foreach (var item in features)
                featureCollection.Add(item);
            return featureCollection;
        }
    }
}
