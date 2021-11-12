using System.Collections.Generic;

namespace PowerplantChallenge.Domain
{
    public class Plan
    {
        public decimal Load { get; set; }
        public Fuel Fuels { get; set; }
        public IList<PowerPlant> Powerplants { get; set; }
    }
}