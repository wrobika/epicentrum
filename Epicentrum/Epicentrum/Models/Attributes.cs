using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class Attributes
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
}
