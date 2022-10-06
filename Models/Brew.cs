using System;
using System.Collections.Generic;

namespace BreweryAPI
{
    public partial class Brew
    {
        public int Id { get; set; }
        public string BrewName { get; set; } = null!;
        public double Abv { get; set; }
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsAvailable { get; set; }
        public int? BreweryId { get; set; }

        public virtual Brewery? Brewery { get; set; }
    }
}
