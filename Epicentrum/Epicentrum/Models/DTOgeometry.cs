using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class DTOgeometry
    {
        [JsonProperty(PropertyName = "y")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "x")]
        public double Longitude { get; set; }
    }
}
