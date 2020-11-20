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
        public IList<DTOfeature> Features { get; set; }
    }
}
