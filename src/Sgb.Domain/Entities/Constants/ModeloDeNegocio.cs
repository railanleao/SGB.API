using System.Runtime.Serialization;

namespace Sgb.Domain.Entities.Constants
{
    public enum ModeloDeNegocio
    {
        [EnumMember(Value = "Compra")]
        COMPRA,
        [EnumMember(Value = "Venda")]
        VENDA,
    }
}
