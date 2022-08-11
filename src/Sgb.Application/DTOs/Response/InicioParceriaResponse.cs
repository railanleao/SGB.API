using Sgb.Domain.Entities.CompradorAssociado;
using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sgb.Application.DTOs.Response
{
    public class InicioParceriaResponse
    {
        public Guid BoiId { get; set; }
        public string Lote { get; set; }
        public int QtdadeEntrada { get; set; }
        [Display(Name = "Inicio da Paceria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicioParceria { get; set; }
        public decimal PesoBruto { get; set; }
        public string? Origem { get; set; }
        public decimal Valor { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        public Guid CompradorId { get; set; }
        [JsonIgnore]
        public Comprador? Comprador { get; set; }
        public Guid AssociadoId { get; set; }
        [JsonIgnore]
        public Associado? Associado { get; set; }
        [JsonIgnore]
        public CompradorResponse CompradorResponse { get; set; }
        [JsonIgnore]
        public AssociadoResponse AssociadoResponse { get; set; }
        public InicioParceriaResponse(Guid boiId, string lote, int qtdadeEntrada, decimal pesoBruto, decimal valor, string? origem, decimal arroba, 
            decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid compradorId, Guid associadoId, CompradorResponse compradorResponse, 
            AssociadoResponse associadoResponse)
        {
            BoiId = boiId;
            Lote = lote;
            QtdadeEntrada = qtdadeEntrada;
            PesoBruto = pesoBruto;
            Valor = valor;
            Origem = origem;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            DataInicioParceria = dataInicioParceria;
            CompradorId = compradorId;
            AssociadoId = associadoId;
            this.CompradorResponse = compradorResponse;
            this.AssociadoResponse = associadoResponse;
        }
        public static InicioParceriaResponse ConverteParaResponse(InicioParceria inicioParceria)
        {
            return new InicioParceriaResponse
                (
                    inicioParceria.BoiId,
                    inicioParceria.Lote,
                    inicioParceria.QtdadeEntrada,
                    inicioParceria.PesoBruto,
                    inicioParceria.Valor,
                    inicioParceria.Origem,
                    inicioParceria.Arroba,
                    inicioParceria.RendimentoCarcaca,
                    inicioParceria.DataInicioParceria,
                    inicioParceria.CompradorId,
                    inicioParceria.AssociadoId,
                    new CompradorResponse(inicioParceria.Comprador.CadastroId,
                    inicioParceria.Comprador.Nome, inicioParceria.Comprador.CPF),
                    new AssociadoResponse (inicioParceria.Associado.CadastroId, inicioParceria.Associado.CPF, 
                    inicioParceria.Associado.DataDaParceria, inicioParceria.Associado.Fazenda, 
                    inicioParceria.Associado.Nome, inicioParceria.Associado.CompradorId,
                    new CompradorResponse(inicioParceria.Comprador.CadastroId,
                    inicioParceria.Comprador.Nome, inicioParceria.Comprador.CPF))
                );
        }
        public InicioParceriaResponse() {  }
    }
}
