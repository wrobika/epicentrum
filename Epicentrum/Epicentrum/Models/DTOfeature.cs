using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Epicentrum.Models
{
    public class DTOfeature
    {
        [JsonProperty(PropertyName = "attributes")]
        public DTOattributes Attributes { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public DTOgeometry Geolocation { get; set; }

        public Earthquake ToEarthquake()
        {
            return new Earthquake
            {
                Id = Attributes.Id,
                Location = LocationToTitleCase(),
                Magnitude = RoundMagnitude(),
                Deaths = Attributes.Deaths,
                Latitude = Geolocation.Latitude,
                Longitude = Geolocation.Longitude,
                Date = DateTime.ParseExact(Attributes.Date, "yyyyMMdd", CultureInfo.InvariantCulture)
            };
        }

        private string LocationToTitleCase()
        {
            string location = Attributes.Location.ToLower();
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(location);
        }

        private double? RoundMagnitude()
        {
            double? magnitude = Attributes.Magnitude;
            if (magnitude.HasValue)
                magnitude = Math.Round(Attributes.Magnitude.Value, 2);
            return magnitude;
        }
    }
}
