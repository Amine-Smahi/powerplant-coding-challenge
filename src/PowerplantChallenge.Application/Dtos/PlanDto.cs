using System.Collections.Generic;

namespace PowerplantChallenge.Application.Dtos
{
    public class PlanDto
    {
        public decimal Load { get; set; }

        public FuelDto FuelsDto { get; set; }

        public IList<PowerPlantDto> Powerplants { get; set; }
    }
}