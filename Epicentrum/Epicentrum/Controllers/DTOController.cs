using Epicentrum.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epicentrum.Controllers
{
    internal class DTOController : Controller
    {
        private readonly string _dataFilePath;

        internal DTOController(IWebHostEnvironment webHostEnvironment)
        {
            _dataFilePath = webHostEnvironment.WebRootPath + "/earthquakes.json";
        }

        internal IDictionary<int, Earthquake> GetEarthquakes()
        {
            if (System.IO.File.Exists(_dataFilePath))
                return DeserializeData();
            else
                return new Dictionary<int, Earthquake>();
        }

        private IDictionary<int, Earthquake> DeserializeData()
        {
            string json = System.IO.File.ReadAllText(_dataFilePath);
            return JsonConvert
               .DeserializeObject<DTO>(json)
               .Features
               .ToDictionary(feature => feature.Attributes.Id, feature => feature.ToEarthquake()); ;
        }
    }
}
