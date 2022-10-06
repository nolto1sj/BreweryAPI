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
        [HttpPost("add")]
        public Brewery AddBrewery(int id ,string name, string city , string country)
        {
            Brewery b = new Brewery() {
                Id = id,
                BreweryName = name,
                City = city,
                Country = country
            };

            return b;
        }
    }
}
