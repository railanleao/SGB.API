using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sgb.Domain.Entities.Parceria
{
    public class AlteracaoSaida : ACadastroBoi
    {
        [Display(Name = "Peso Médio Alterado")]
        public decimal? PesoMedioAlterado { get; private set; }
        public int QtdadeSaida { get; private set; }
        [Display(Name = "Data da Saida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Saida { get; private set; }
        public Guid CompradorId { get; private set; }
        [JsonIgnore]
        public Comprador? Comprador { get; private set; }
        public Guid AssociadoId { get; private set; }
        [JsonIgnore]
        public Associado? Associado { get; private set; }
        public Guid InicioParceriaId { get; private set; }
        [JsonIgnore]
        public InicioParceria? InicioParceria { get; set; }

        public AlteracaoSaida(Guid boiId, decimal? pesoMedioAlterado, int qtdadeSaida, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca, DateTime saida,
            Guid compradorId, Guid associadoId, Guid inicioParceriaId, Classificacao classificacao, CompraVenda compraVenda)
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
            Classificacao = classificacao;
            CompraVenda = compraVenda;
        }

        public AlteracaoSaida(decimal? pesoMedioAlterado, int qtdadeSaida, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca, 
            DateTime saida, Guid compradorId, Guid associadoId, Guid inicioParceriaId, Classificacao classificacao, 
            CompraVenda compraVenda) : this(default, pesoMedioAlterado, qtdadeSaida, pesoBruto, arroba, rendimentoCarcaca, saida, 
                compradorId, associadoId, inicioParceriaId, classificacao, compraVenda) { }
        public AlteracaoSaida() { }
    }
}
