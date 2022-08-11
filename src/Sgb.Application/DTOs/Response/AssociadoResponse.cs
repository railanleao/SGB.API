using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sgb.Application.DTOs.Response
{
    public class AssociadoResponse
    {
        public Guid CadastroId { get; set; }
        public string? Nome { get; set; }
        [RegularExpression(@"^([0-9]{3})([0-9]{3})([9-0]{3})([0-9]{3})([0-9]{2})$",
            ErrorMessage = "Cpf inválido!")]
        public string? CPF { get; set; }
        public string? Fazenda { get; set; }
        public DateTime DataDaParceria { get; set; }
        public Guid CompradorId { get; set; }
        [JsonIgnore]
        public Comprador? Comprador { get; set; }
        [JsonIgnore]
        public CompradorResponse? CompradorResponse { get; set; }
        public AssociadoResponse(Guid cadastroId, string? cpf, DateTime dataDaParceria, string? fazenda, string? nome,   
             Guid compradorId, CompradorResponse compradorResponse)
        {
            CadastroId = cadastroId;
            Fazenda = fazenda;
            DataDaParceria = dataDaParceria;
            Nome = nome;
            CPF = cpf;
            CompradorId = compradorId;
            this.CompradorResponse = compradorResponse;
        }
        public static AssociadoResponse ConverteParaResponse(Associado associado)
        {
            return new AssociadoResponse
                (
                associado.CadastroId,
                associado.CPF,
                associado.DataDaParceria,
                associado.Fazenda,               
                associado.Nome,
                associado.CompradorId,
                new CompradorResponse (associado.Comprador.CadastroId, 
                associado.Comprador.Nome, associado.Comprador.CPF)
                );
        }
        public AssociadoResponse() { }
    }
}
