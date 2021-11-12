using System.Runtime.Serialization;

namespace PowerplantChallenge.Application.Dtos
{
    public enum PowerPlantTypeDto
    {
        [EnumMember(Value = "gasfired")] GasFired,
        [EnumMember(Value = "turbojet")] Turbojet,
        [EnumMember(Value = "wind")] WindTurbine
    }
}