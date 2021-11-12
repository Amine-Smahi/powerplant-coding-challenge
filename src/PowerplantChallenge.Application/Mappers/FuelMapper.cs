using PowerplantChallenge.Application.Dtos;
using PowerplantChallenge.Domain;

namespace PowerplantChallenge.Application.Mappers
{
    public static class FuelMapper
    {
        public static Fuel Map(this FuelDto fuelDto)
        {
            return new()
            {
                Gas = fuelDto.Gas,
                Kerosene = fuelDto.Kerosene,
                Co2 = fuelDto.Co2,
                Wind = fuelDto.Wind
            };
        }
    }
}