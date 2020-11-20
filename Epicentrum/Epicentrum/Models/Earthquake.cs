using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Models
{
    public class Earthquake
    { 
        [DisplayName("Number of deaths")]
        public int? Deaths { get; set; }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public double? Magnitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Feature ToFeature()
        {
            Point point = new Point(Longitude, Latitude);
            AttributesTable properties = new AttributesTable
            {
                { "id", Id },
                { "color", EpicentrumColor.FromMagnitude(Magnitude) }
            };
            return new Feature(point, properties);
        }
    }
}
