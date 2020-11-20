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
    public class DTOController : Controller
    {
        private readonly string _dataFilePath;

        public DTOController(IWebHostEnvironment webHostEnvironment)
        {
            _dataFilePath = webHostEnvironment.WebRootPath + "/earthquakes.json";
        }

        public IDictionary<int, Earthquake> GetEarthquakes()
        {
            if (System.IO.File.Exists(_dataFilePath))
                return DeserializeData();
            else
                return new Dictionary<int, Earthquake>();
        }

        private IDictionary<int, Earthquake> DeserializeData()
        {
            return JsonConvert
               .DeserializeObject<DTO>(System.IO.File.ReadAllText(_dataFilePath))
               .Features
               .ToDictionary(feature => feature.Attributes.Id, feature => feature.ToEarthquake()); ;
        }
    }
}
