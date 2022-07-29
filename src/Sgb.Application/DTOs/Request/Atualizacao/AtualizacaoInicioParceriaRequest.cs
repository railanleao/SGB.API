using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoInicioParceriaRequest
    {
        public Guid BoiId { get; set; }
        public string Lote { get; set; }
        public int Quantidade { get; set; }
        public decimal PesoBruto { get; set; }
        public string Origem { get; set; }
        public decimal Valor { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        public DateTime DataInicioParceria { get; set; }
        public Guid IdComprador { get; set; }
        public Guid IdAssociado { get; set; }
        public Classificacao Classificacao { get; set; }
        public CompraVenda CompraVenda { get; set; }
        [NotMapped]
        public List<SelectListItem>? Classificacoes { get; set; }
        [NotMapped]
        public List<SelectListItem>? CompraVendas { get; set; }

        public AtualizacaoInicioParceriaRequest(Guid boiId, string lote, int quantidade, decimal pesoBruto, string origem, decimal valor,
            decimal arroba, decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid idComprador, Guid idAssociado,
            Classificacao classificacao, CompraVenda compraVenda)
        {
            BoiId = boiId;
            Lote = lote;
            Quantidade = quantidade;
            PesoBruto = pesoBruto;
            Origem = origem;
            Valor = valor;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            DataInicioParceria = dataInicioParceria;
            IdComprador = idComprador;
            IdAssociado = idAssociado;
            Classificacao = classificacao;
            CompraVenda = compraVenda;
        }
        public static InicioParceria ConverterParaEntidade(AtualizacaoInicioParceriaRequest parceriaRequest)
        {
            return new InicioParceria
            (
                parceriaRequest.BoiId,
                parceriaRequest.Lote,
                parceriaRequest.Quantidade,
                parceriaRequest.PesoBruto,
                parceriaRequest.Valor,
                parceriaRequest.Origem,
                parceriaRequest.Arroba,
                parceriaRequest.RendimentoCarcaca,
                parceriaRequest.DataInicioParceria,
                parceriaRequest.IdComprador,
                parceriaRequest.IdAssociado,
                parceriaRequest.Classificacao,
                parceriaRequest.CompraVenda
                );
        }
        public AtualizacaoInicioParceriaRequest() { }
    }
}
