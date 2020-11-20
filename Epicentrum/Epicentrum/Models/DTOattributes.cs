using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class DTOattributes
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
}
