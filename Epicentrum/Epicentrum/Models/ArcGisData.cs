using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class ArcGisData
    {
        [JsonPropertyName("features")]
        public IList<Earthquake> Earthquakes { get; set; }
    }
}
