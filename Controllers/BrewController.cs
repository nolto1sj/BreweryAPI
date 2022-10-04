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
        string description, bool isAvailable)
        {
            Brew b = new Brew() 
            { 
                BrewName = brewName,
                Abv = abv,
                Category = category,
                Description = description,
                IsAvailable = isAvailable
            };
            _db.Brews.Add(b);
            _db.SaveChanges();
        }

    }
}
