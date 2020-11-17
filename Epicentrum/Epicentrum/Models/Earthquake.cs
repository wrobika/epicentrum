using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Epicentrum.Models
{
    public class Earthquake
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }

        [JsonPropertyName("geometry")]
        public Epicentrum Epicentrum {get;set;}
    }
}
