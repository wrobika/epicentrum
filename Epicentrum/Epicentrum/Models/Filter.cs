using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class Filter
    {
        [Range(1970, 2020)]
        public int Year { get; set; }

        [Range(0, int.MaxValue)]
        public int Deaths { get; set; }
    }
}
