using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoAlteracaoSaidaRequest
    {
        public Guid BoiId { get; set; }
        public decimal? PesoMedioAlterado { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        public DateTime Saida { get; set; }
        public Guid IdComprador { get; set; }
        public Guid IdAssociado { get; set; }
        public Guid InicioParceriaId { get; set; }
        public Classificacao Classificacao { get; set; }
        public CompraVenda CompraVenda { get; set; }
        [NotMapped]
        public List<SelectListItem>? Classificacoes { get; set; }
        [NotMapped]
        public List<SelectListItem>? CompraVendas { get; set; }
        public AtualizacaoAlteracaoSaidaRequest(Guid boiId, decimal? pesoMedioAlterado, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca,
            DateTime saida, Guid idComprador, Guid idAssociado, Guid inicioParceriaId, Classificacao classificacao, CompraVenda compraVenda)
        {
            BoiId = boiId;
            PesoMedioAlterado = pesoMedioAlterado;
            PesoBruto = pesoBruto;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            Saida = saida;
            IdComprador = idComprador;
            IdAssociado = idAssociado;
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
                alteracaoSaidaRequest.PesoBruto,
                alteracaoSaidaRequest.Arroba,
                alteracaoSaidaRequest.RendimentoCarcaca,
                alteracaoSaidaRequest.Saida,
                alteracaoSaidaRequest.IdComprador,
                alteracaoSaidaRequest.IdAssociado,
                alteracaoSaidaRequest.InicioParceriaId,
                alteracaoSaidaRequest.Classificacao,
                alteracaoSaidaRequest.CompraVenda
                );
        }
        public AtualizacaoAlteracaoSaidaRequest() { }
    }
}
