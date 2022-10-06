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
    public class BreweryController : ControllerBase
    {
        BreweryDBContext _db = new BreweryDBContext();

        [HttpPost("add")]
        public Brewery AddBrewery(string name, string city , string country)
        {
            Brewery b = new Brewery() {
                BreweryName = name,
                City = city,
                Country = country
            };
            _db.Breweries.Add(b);
            _db.SaveChanges();

            return b;
        }
    }
}
