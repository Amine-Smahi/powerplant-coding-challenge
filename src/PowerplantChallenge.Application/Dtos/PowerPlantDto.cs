using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PowerplantChallenge.Application.Dtos
{
    public class PowerPlantDto
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PowerPlantTypeDto TypeDto { get; set; }

        public decimal Efficiency { get; set; }

        [JsonProperty("pmin")] public decimal PMin { get; set; }

        [JsonProperty("pmax")] public decimal PMax { get; set; }
    }
}