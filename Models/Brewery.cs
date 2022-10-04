using System;
using System.Collections.Generic;

namespace BreweryAPI
{
    public partial class Brewery
    {
        public Brewery()
        {
            Brews = new HashSet<Brew>();
        }

        public int Id { get; set; }
        public string BreweryName { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Brew> Brews { get; set; }
    }
}
