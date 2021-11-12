using Newtonsoft.Json;

namespace PowerplantChallenge.Application.Dtos
{
    public class FuelDto
    {
        [JsonProperty("gas(euro/MWh)")] public decimal Gas { get; set; }

        [JsonProperty("kerosine(euro/MWh)")] public decimal Kerosene { get; set; }

        [JsonProperty("co2(euro/ton)")] public decimal Co2 { get; set; }

        [JsonProperty("wind(%)")] public decimal Wind { get; set; }
    }
}