using Sgb.Domain.Entities.Constants;
using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Web.Mvc;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoAlteracaoSaidaRequest
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
        public Guid AssociadoId { get; set; }
        public Guid InicioParceriaId { get; set; }
        public Classificacao Classificacao { get; set; }
        public ModeloDeNegocio CompraVenda { get; set; }
        public AtualizacaoAlteracaoSaidaRequest(decimal? pesoMedioAlterado, int qtdadeSaida, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca,
            DateTime saida, Guid compradorId, Guid associadoId, Guid inicioParceriaId, Classificacao classificacao, ModeloDeNegocio compraVenda)
        {
            PesoMedioAlterado = pesoMedioAlterado;
            QtdadeSaida = qtdadeSaida;
            PesoBruto = pesoBruto;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            Saida = saida;
            CompradorId = compradorId;
            AssociadoId = associadoId;
            InicioParceriaId = inicioParceriaId;
            Classificacao = classificacao;
            CompraVenda = compraVenda;
        }
        public static AlteracaoSaida ConverterParaEntidade(AtualizacaoAlteracaoSaidaRequest alteracaoSaidaRequest)
        {
            return new AlteracaoSaida
                (
                alteracaoSaidaRequest.BoiId,
                alteracaoSaidaRequest.PesoMedioAlterado,
                alteracaoSaidaRequest.QtdadeSaida,
                alteracaoSaidaRequest.PesoBruto,
                alteracaoSaidaRequest.Arroba,
                alteracaoSaidaRequest.RendimentoCarcaca,
                alteracaoSaidaRequest.Saida,
                alteracaoSaidaRequest.CompradorId,
                alteracaoSaidaRequest.AssociadoId,
                alteracaoSaidaRequest.InicioParceriaId,
                alteracaoSaidaRequest.Classificacao,
                alteracaoSaidaRequest.CompraVenda
                );
        }
        public AtualizacaoAlteracaoSaidaRequest() { }
    }
}
