using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Epicentrum.Models
{
    public class DTO
    {
        [JsonProperty(PropertyName = "features")]
        public IList<FeatureDTO> Features { get; set; }
    }

    public class FeatureDTO
    {
        [JsonProperty(PropertyName = "attributes")]
        public AttributesDTO Attributes { get; set; }

        [JsonProperty(PropertyName = "geometry")]
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
        [JsonProperty(PropertyName = "OBJECTID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Location { get; set; }

        public double? Magnitude { get; set; }

        [JsonProperty(PropertyName = "Num_Deaths")]
        public int? Deaths { get; set; }

        [JsonProperty(PropertyName = "YYYYMMDD")]
        public string Date { get; set; }
    }

    public class GeometryDTO
    {
        [JsonProperty(PropertyName = "y")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "x")]
        public double Longitude { get; set; }
    }
}
