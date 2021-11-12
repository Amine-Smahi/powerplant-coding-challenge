using System.Linq;
using PowerplantChallenge.Application.Dtos;
using PowerplantChallenge.Domain;

namespace PowerplantChallenge.Application.Mappers
{
    public static class PlanMapper
    {
        public static Plan Map(this PlanDto planDto)
        {
            return new()
            {
                Load = planDto.Load,
                Fuels = planDto.FuelsDto.Map(),
                Powerplants = planDto.Powerplants.Select(plant => plant.Map()).ToList()
            };
        }
    }
}