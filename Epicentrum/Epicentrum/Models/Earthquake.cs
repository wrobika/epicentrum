using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using NetTopologySuite.Features;
using Point = NetTopologySuite.Geometries.Point;
using System.Drawing;

namespace Epicentrum.Models
{
    public class Earthquake
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }

        [JsonPropertyName("geometry")]
        public Geolocation Epicentrum { get; set; }

        private const string ID = "id";
        private const string COLOR = "color";

        public Feature ToFeature()
        {
            Point point = new Point(this.Epicentrum.Longitude, this.Epicentrum.Latitude);
            AttributesTable properties = new AttributesTable
            {
                { ID, Attributes.Id },
                { COLOR, EpicentrumColor.FromMagnitude(Attributes.Magnitude) }
            };
            return new Feature(point, properties);
        }
    }
}
