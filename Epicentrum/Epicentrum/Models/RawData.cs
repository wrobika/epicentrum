using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class RawData
    {
        [JsonPropertyName("features")]
        public IList<Earthquake> Earthquakes { get; set; }
    }
}
