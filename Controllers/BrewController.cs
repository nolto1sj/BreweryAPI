using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewController : ControllerBase
    {
        BreweryDBContext _db = new BreweryDBContext();

        [HttpPost("add")]
        public void AddBrew(string brewName, double abv, string category,
        string description, bool isAvailable, string breweryName)
        {
            Brewery brewery = _db.Breweries.FirstOrDefault(b => b.BreweryName == breweryName);
            Brew b = new Brew()
            {
                BrewName = brewName,
                Abv = abv,
                Category = category,
                Description = description,
                IsAvailable = isAvailable,
                BreweryId = brewery.Id
            };
            _db.Brews.Add(b);
            _db.SaveChanges();
        }

        [HttpGet]
        public List<Brew> GetAllBrews()
        {
            List<Brew> brews = _db.Brews.ToList();
            return brews;
        }

        [HttpGet("{brewName}")]
        public Brew GetSingleBrew(string brewName)
        {
            return _db.Brews.FirstOrDefault(b => b.BrewName == brewName);
        }

        [HttpPut("update")]

        public void UpdateBrew(string brewName, double abv, string category, string description, bool isAvailable, string breweryName)
        {
            Brew b = _db.Brews.FirstOrDefault(b => b.BrewName == brewName);

            b.BrewName = brewName;
            b.Abv = abv;
            b.Category = category;
            b.Description = description;
            b.IsAvailable = isAvailable;
            b.BreweryId = _db.Breweries.FirstOrDefault(b => b.BreweryName == breweryName).Id;

            _db.Update(b);
            _db.SaveChanges();



        }


    }
}
