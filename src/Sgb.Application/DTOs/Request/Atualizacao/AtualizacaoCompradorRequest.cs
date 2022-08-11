using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoCompradorRequest
    {
        public Guid CadastroId { get; set; }
        public string Nome { get; set; }
        [RegularExpression(@"^([0-9]{3})([0-9]{3})([9-0]{3})([0-9]{3})([0-9]{2})$",
            ErrorMessage = "Cpf inválido!")]
        public string CPF { get; set; }
        public AtualizacaoCompradorRequest(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
        public static Comprador ConverterParaEntidade(AtualizacaoCompradorRequest compradorRequest)
        {
            return new Comprador
                (
                compradorRequest.CadastroId,
                compradorRequest.Nome,
                compradorRequest.CPF
                );
        }
        public AtualizacaoCompradorRequest() {      }
    }
}
