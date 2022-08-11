using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;

namespace Sgb.Application.DTOs.Response
{
    public class CompradorResponse
    {
        public Guid CadastroId { get; set; }
        public string? Nome { get; set; }
        [RegularExpression(@"^([0-9]{3})([0-9]{3})([9-0]{3})([0-9]{3})([0-9]{2})$",
            ErrorMessage = "Cpf inválido!")]
        public string? CPF { get; set; }
        public CompradorResponse(Guid cadastroId, string? nome, string? cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public static CompradorResponse ConverteParaResponse(Comprador comprador)
        {
            return new CompradorResponse
            (
                comprador.CadastroId,
                comprador.Nome,
                comprador.CPF
             );
        }
        public CompradorResponse() { }
    }
}
