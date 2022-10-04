using System;
using System.Collections.Generic;

namespace BreweryAPI
{
    public partial class Brew
    {
        public Brew()
        {
            Breweries = new HashSet<Brewery>();
        }

        public int Id { get; set; }
        public string BrewName { get; set; } = null!;
        public double Abv { get; set; }
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsAvailable { get; set; }

        public virtual ICollection<Brewery> Breweries { get; set; }
    }
}
