using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Epicentrum.Models;

namespace Epicentrum.Models
{
    public class DTO
    {
        [JsonPropertyName("features")]
        public IList<FeatureDTO> Features { get; set; }
    }

    public class FeatureDTO
    {
        [JsonPropertyName("attributes")]
        public AttributesDTO Attributes { get; set; }

        [JsonPropertyName("geometry")]
        public GeometryDTO Geolocation { get; set; }

        public Earthquake ToEarthquake()
        {
            return new Earthquake
            {
                Id = Attributes.Id,
                Location = Attributes.Location,
                Magnitude = Attributes.Magnitude,
                Deaths = Attributes.Deaths,
                Latitude = Geolocation.Latitude,
                Longitude = Geolocation.Longitude,
                Date = DateTime.ParseExact(Attributes.Date, "yyyyMMdd", CultureInfo.InvariantCulture)
                    .ToShortDateString()
            };
        }
    }

    public class AttributesDTO
    {
        [JsonPropertyName("OBJECTID")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Location { get; set; }

        public double? Magnitude { get; set; }

        [JsonPropertyName("Num_Deaths")]
        public int? Deaths { get; set; }

        [JsonPropertyName("YYYYMMDD")]
        public string Date { get; set; }
    }

    public class GeometryDTO
    {
        [JsonPropertyName("y")]
        public double Latitude { get; set; }

        [JsonPropertyName("x")]
        public double Longitude { get; set; }
    }
}
