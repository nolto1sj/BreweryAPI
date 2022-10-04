using System;
using System.Collections.Generic;

namespace BreweryAPI
{
    public partial class Brewery
    {
        public int Id { get; set; }
        public string BreweryName { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? BrewId { get; set; }

        public virtual Brew? Brew { get; set; }
    }
}
