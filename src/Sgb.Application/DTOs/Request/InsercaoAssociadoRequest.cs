using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sgb.Application.DTOs.Request
{
    public class InsercaoAssociadoRequest
    {
        //public Guid CadastroId { get; set; }
        public string Nome { get; set; }
        [RegularExpression(@"(^[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2})$", 
            ErrorMessage = "Cpf inválido!")]
        public string CPF { get; set; }
        public string Fazenda { get; set; }
        [Display(Name = "Início da Parceria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataDaParceria { get; set; }
        public Guid CompradorId { get; set; }
        [JsonIgnore]
        public Comprador? Comprador { get; set; }
        public InsercaoAssociadoRequest(string cpf, DateTime dataDaParceria, string fazenda, Guid compradorId, string nome)
        {
            CPF = cpf;
            DataDaParceria = dataDaParceria;
            Fazenda = fazenda;
            CompradorId = compradorId;
            Nome = nome;

        }
        public static Associado ConverterParaEntidade(InsercaoAssociadoRequest associadoRequest)
        {
            return new Associado
                (
                associadoRequest.CPF,
                associadoRequest.DataDaParceria,
                associadoRequest.Fazenda,
                associadoRequest.CompradorId,
                associadoRequest.Nome
                );
        }
        public InsercaoAssociadoRequest() { }
    }
}
