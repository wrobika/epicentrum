using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class EarthquakeViewModel
    {
        [DisplayName("Number of deaths")]
        public int? Deaths { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string Place { get; set; }
        public double? Magnitude { get; set; }
    }
}
