using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class Geometry
    {
        [JsonPropertyName("y")]
        public double Latitude { get; set; }

        [JsonPropertyName("x")]
        public double Longitude { get; set; }
    }
}
