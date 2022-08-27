using Sgb.Domain.Entities.Constants;
using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Web.Mvc;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoInicioParceriaRequest
    {
        public Guid BoiId { get; set; }
        public string Lote { get; set; }
        public int QtdadeEntrada { get; set; }
        public decimal PesoBruto { get; set; }
        public string Origem { get; set; }
        public decimal Valor { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        [Display(Name = "Inicio da Paceria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicioParceria { get; set; }
        public Guid CompradorId { get; set; }
        public Guid AssociadoId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Classificacao Classificacao { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ModeloDeNegocio CompraVenda { get; set; }
        public AtualizacaoInicioParceriaRequest(string lote, int qtdadeEntrada, decimal pesoBruto, string origem, decimal valor,
            decimal arroba, decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid compradorId, Guid associadoId,
            Classificacao classificacao, ModeloDeNegocio compraVenda)
        {
            Lote = lote;
            QtdadeEntrada = qtdadeEntrada;
            PesoBruto = pesoBruto;
            Origem = origem;
            Valor = valor;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            DataInicioParceria = dataInicioParceria;
            CompradorId = compradorId;
            AssociadoId = associadoId;
            Classificacao = classificacao;
            CompraVenda = compraVenda;
        }
        public static InicioParceria ConverterParaEntidade(AtualizacaoInicioParceriaRequest parceriaRequest)
        {
            return new InicioParceria
            (
                parceriaRequest.BoiId,
                parceriaRequest.Lote,
                parceriaRequest.QtdadeEntrada,
                parceriaRequest.PesoBruto,
                parceriaRequest.Valor,
                parceriaRequest.Origem,
                parceriaRequest.Arroba,
                parceriaRequest.RendimentoCarcaca,
                parceriaRequest.DataInicioParceria,
                parceriaRequest.CompradorId,
                parceriaRequest.AssociadoId,
                parceriaRequest.Classificacao,
                parceriaRequest.CompraVenda
                );
        }
        public AtualizacaoInicioParceriaRequest() { }
    }
}
