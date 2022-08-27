using System.Runtime.Serialization;

namespace Sgb.Domain.Entities.Constants
{
    public enum Classificacao
    {
        [EnumMember(Value = "Boi")]
        BOI,
        [EnumMember(Value = "Bezerro")]
        BEZERO
    }
}
