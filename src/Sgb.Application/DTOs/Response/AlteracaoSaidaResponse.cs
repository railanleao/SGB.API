using Sgb.Domain.Entities.CompradorAssociado;
using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sgb.Application.DTOs.Response
{
    public class AlteracaoSaidaResponse
    {
        public Guid BoiId { get; set; }
        public decimal? PesoMedioAlterado { get; set; }
        public int QtdadeSaida { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        [Display(Name = "Data da Saida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Saida { get; set; }
        public Guid CompradorId { get; set; }
        [JsonIgnore]
        public Comprador? Comprador { get; set; }
        public Guid AssociadoId { get; set; }
        [JsonIgnore]
        public Associado? Associado { get; set; }
        public Guid InicioParceriaId { get; set; }
        [JsonIgnore]
        public InicioParceria? InicioParceria { get; set; }
        [JsonIgnore]
        public CompradorResponse CompradorResponse { get; set; }
        [JsonIgnore]
        public AssociadoResponse AssociadoResponse { get; set; }
        public AlteracaoSaidaResponse(Guid boiId, decimal? pesoMedioAlterado, int qtdadeSaida, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca, 
            DateTime saida, Guid compradorId, Guid associadoId, Guid inicioParceriaId, CompradorResponse compradorResponse, 
            AssociadoResponse associadoResponse)
        {
            BoiId = boiId;
            PesoMedioAlterado = pesoMedioAlterado;
            QtdadeSaida = qtdadeSaida;
            PesoBruto = pesoBruto;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            Saida = saida;
            CompradorId = compradorId;
            AssociadoId = associadoId;
            InicioParceriaId = inicioParceriaId;
            this.CompradorResponse = compradorResponse;
            this.AssociadoResponse = associadoResponse;
        }
        public static AlteracaoSaidaResponse ConverteParaResponse(AlteracaoSaida alteracao)
        {
            return new AlteracaoSaidaResponse
                (
                alteracao.BoiId,
                alteracao.PesoMedioAlterado,
                alteracao.QtdadeSaida,
                alteracao.PesoBruto,
                alteracao.Arroba,
                alteracao.RendimentoCarcaca,
                alteracao.Saida,
                alteracao.CompradorId,
                alteracao.AssociadoId,
                alteracao.InicioParceriaId,
                new CompradorResponse(alteracao.Comprador.CadastroId, 
                alteracao.Comprador.Nome, alteracao.Comprador.CPF),
                new AssociadoResponse(alteracao.Associado.CadastroId, alteracao.Associado.CPF, alteracao.Associado.DataDaParceria, 
                alteracao.Associado.Fazenda, alteracao.Associado.Nome, alteracao.Associado.CompradorId,
                new CompradorResponse(alteracao.Comprador.CadastroId,
                alteracao.Comprador.Nome, alteracao.Comprador.CPF))
                );
        }
        public AlteracaoSaidaResponse() {  }
    }
}
