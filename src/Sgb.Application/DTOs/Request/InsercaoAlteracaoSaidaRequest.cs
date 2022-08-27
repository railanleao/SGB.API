using Sgb.Domain.Entities.Constants;
using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;

namespace Sgb.Application.DTOs.Request
{
    public class InsercaoAlteracaoSaidaRequest
    {
        
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
        public InsercaoAlteracaoSaidaRequest(decimal? pesoMedioAlterado, int qtdadeSaida, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca,
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
        public static AlteracaoSaida ConverterParaEntidade(InsercaoAlteracaoSaidaRequest insercao)
        {
            return new AlteracaoSaida
                (                
                insercao.PesoMedioAlterado,
                insercao.QtdadeSaida,
                insercao.PesoBruto,
                insercao.Arroba,
                insercao.RendimentoCarcaca,
                insercao.Saida,
                insercao.CompradorId,
                insercao.AssociadoId,
                insercao.InicioParceriaId,
                insercao.Classificacao,
                insercao.CompraVenda
                );
        }
        public InsercaoAlteracaoSaidaRequest() { }
    }
}
