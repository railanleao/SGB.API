using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sgb.Domain.Entities.Parceria
{
    public class InicioParceria : ACadastroBoi
    {
        public Guid CompradorId { get; private set; }
        [JsonIgnore]
        public Comprador? Comprador { get; private set; }
        public Guid AssociadoId { get; private set; }
        [JsonIgnore]
        public Associado? Associado { get; private set; }

        [Display(Name = "Inicio da Paceria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicioParceria { get; private set; }
        public int QtdadeEntrada { get; private set; }
        [Display(Name = "Origem")]
        public string Origem { get; private set; }
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; private set; }
        public string Lote { get; private set; }
        [JsonIgnore]
        public ICollection<AlteracaoSaida>? AlteracaoSaidas { get; set; }

        public InicioParceria(Guid boiId, string lote, int qtdadeEntrada, decimal pesoBruto, decimal valor, string origem, 
            decimal arroba, decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid compradorId, Guid associadoId, 
            Classificacao classificacao, CompraVenda compraVenda)
        {
            BoiId = boiId;
            Lote = lote;
            QtdadeEntrada = qtdadeEntrada;
            PesoBruto = pesoBruto;
            Valor = valor;
            Origem = origem;
            //PorcentoMes = porcentoMes;            
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            DataInicioParceria = DateTime.Now;
            CompradorId = compradorId;
            AssociadoId = associadoId;
            Classificacao = classificacao;
            CompraVenda = compraVenda;
        }

        public InicioParceria(string lote, int qtdadeEntrada, decimal pesoBruto, decimal valor, string origem, decimal arroba, 
            decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid compradorId, Guid associadoId, 
            Classificacao classificacao, CompraVenda compraVenda) : this(default, lote, qtdadeEntrada, pesoBruto, valor, 
                origem, arroba, rendimentoCarcaca, dataInicioParceria, compradorId, associadoId, classificacao, 
                compraVenda)
        {
        }
        public InicioParceria() { }
    }
}
