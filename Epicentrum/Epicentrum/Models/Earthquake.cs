using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;

namespace Epicentrum.Models
{
    public class Earthquake
    {
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }

        [JsonPropertyName("geometry")]
        public Epicentrum Epicentrum { get; set; }

        private const string ID = "id";
        private const string MAGNITUDE = "magnitude";

        public Feature ToFeature()
        {
            Point point = new Point(this.Epicentrum.Longitude, this.Epicentrum.Latitude);
            AttributesTable properties = new AttributesTable
            {
                { ID, this.Attributes.Id },
                { MAGNITUDE, this.Attributes.Magnitude }
            };
            return new Feature(point, properties);
        }
    }
}
