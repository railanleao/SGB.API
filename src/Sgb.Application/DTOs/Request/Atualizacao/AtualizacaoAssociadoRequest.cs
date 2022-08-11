using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoAssociadoRequest
    {
        public Guid CadastroId { get; set; }
        public string Nome { get; set; }
        [RegularExpression(@"^([0-9]{3})([0-9]{3})([9-0]{3})([0-9]{3})([0-9]{2})$",
            ErrorMessage = "Cpf inválido!")]
        public string CPF { get; set; }
        public string Fazenda { get; set; }
        public DateTime DataDaParceria { get; set; }
        public Guid CompradorId { get; set; }
        public Comprador? Comprador { get; set; }
        public AtualizacaoAssociadoRequest(string cpf, DateTime dataDaParceria, string fazenda, Guid compradorId, string nome)
        {
            CPF = cpf;
            DataDaParceria = dataDaParceria;
            Fazenda = fazenda;
            CompradorId = compradorId;
            Nome = nome;
        }
        public static Associado ConverterParaEntidade(AtualizacaoAssociadoRequest associadoRequest)
        {
            return new Associado
                (
                associadoRequest.CadastroId,
                associadoRequest.CPF,
                associadoRequest.DataDaParceria,
                associadoRequest.Fazenda,
                associadoRequest.CompradorId,
                associadoRequest.Nome
                );
        }
        public AtualizacaoAssociadoRequest() { }
    }
}
