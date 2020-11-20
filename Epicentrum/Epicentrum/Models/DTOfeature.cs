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
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            return new Earthquake
            {
                Id = Attributes.Id,
                Location = textInfo.ToTitleCase(Attributes.Location.ToLower()),
                Magnitude = Math.Round(Attributes.Magnitude.GetValueOrDefault(), 2),
                Deaths = Attributes.Deaths,
                Latitude = Geolocation.Latitude,
                Longitude = Geolocation.Longitude,
                Date = DateTime.ParseExact(Attributes.Date, "yyyyMMdd", CultureInfo.InvariantCulture)
            };
        }
    }
}
