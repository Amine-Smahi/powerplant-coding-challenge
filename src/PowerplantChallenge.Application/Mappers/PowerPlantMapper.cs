using PowerplantChallenge.Application.Dtos;
using PowerplantChallenge.Domain;

namespace PowerplantChallenge.Application.Mappers
{
    public static class PowerPlantMapper
    {
        public static PowerPlant Map(this PowerPlantDto plantDto)
        {
            return new()
            {
                Name = plantDto.Name,
                Type = plantDto.TypeDto.Map(),
                Efficiency = plantDto.Efficiency,
                PMax = plantDto.PMax,
                PMin = plantDto.PMin
            };
        }
    }
}