using System.ComponentModel.DataAnnotations;

namespace Sgb.Domain.Entities.CompradorAssociado
{
    public class ACadastro
    {
        public Guid CadastroId { get; protected set; }
        public string? Nome { get; protected set; }
        [RegularExpression(@"(^[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2})$",
            ErrorMessage = "Cpf inválido!")]
        public string? CPF { get; protected set; }
    }
}
