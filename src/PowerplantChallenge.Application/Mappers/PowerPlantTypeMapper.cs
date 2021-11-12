using PowerplantChallenge.Application.Dtos;
using PowerplantChallenge.Domain;

namespace PowerplantChallenge.Application.Mappers
{
    public static class PowerPlantTypeMapper
    {
        public static PowerPlantType Map(this PowerPlantTypeDto typeDto)
        {
            return (PowerPlantType) (int) typeDto;
        }
    }
}