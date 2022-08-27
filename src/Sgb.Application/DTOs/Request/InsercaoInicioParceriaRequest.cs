using Sgb.Domain.Entities.Constants;
using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;

namespace Sgb.Application.DTOs.Request
{
    public class InsercaoInicioParceriaRequest
    {
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
        public Classificacao Classificacao { get; set; }
        public ModeloDeNegocio CompraVenda { get; set; }
        public InsercaoInicioParceriaRequest(string lote, int qtdadeEntrada, decimal pesoBruto, string origem, decimal valor,
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
        public static InicioParceria ConverterParaEntidade(InsercaoInicioParceriaRequest inicioParceriaRequest)
        {
            return new InicioParceria
                (
                inicioParceriaRequest.Lote,
                inicioParceriaRequest.QtdadeEntrada,
                inicioParceriaRequest.PesoBruto,
                inicioParceriaRequest.Valor,
                inicioParceriaRequest.Origem,
                inicioParceriaRequest.Arroba,
                inicioParceriaRequest.RendimentoCarcaca,
                inicioParceriaRequest.DataInicioParceria,
                inicioParceriaRequest.CompradorId,
                inicioParceriaRequest.AssociadoId,
                inicioParceriaRequest.Classificacao,
                inicioParceriaRequest.CompraVenda
                );
        }
        public InsercaoInicioParceriaRequest() { }
    }
}
