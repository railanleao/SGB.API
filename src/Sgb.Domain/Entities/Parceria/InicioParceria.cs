using Sgb.Domain.Entities.CompradorAssociado;
using System.ComponentModel.DataAnnotations;

namespace Sgb.Domain.Entities.Parceria
{
    public class InicioParceria : ACadastroBoi
    {
        public Guid IdComprador { get; private set; }
        public Comprador? Comprador { get; private set; }
        public Guid IdAssociado { get; private set; }
        public Associado? Associado { get; private set; }

        [Display(Name = "Inicio da Paceria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicioParceria { get; private set; }
        public int Quantidade { get; private set; }
        [Display(Name = "Origem")]
        public string Origem { get; private set; }
        //[DisplayName("Porcentagem do Mês")]
        //public decimal PorcentoMes { get; private set; }
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; private set; }
        public string Lote { get; private set; }
        public ICollection<AlteracaoSaida>? AlteracaoSaidas { get; set; }

        public InicioParceria(Guid boiId, string lote, int quantidade, decimal pesoBruto, decimal valor, string origem, 
            decimal arroba, decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid idComprador, Guid idAssociado, 
            Classificacao classificacao, CompraVenda compraVenda)
        {
            BoiId = boiId;
            Lote = lote;
            Quantidade = quantidade;
            PesoBruto = pesoBruto;
            Valor = valor;
            Origem = origem;
            //PorcentoMes = porcentoMes;            
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            DataInicioParceria = DateTime.Now;
            IdComprador = idComprador;
            IdAssociado = idAssociado;
            Classificacao = classificacao;
            CompraVenda = compraVenda;
        }

        public InicioParceria(string lote, int quantidade, decimal pesoBruto, decimal valor, string origem, decimal arroba, 
            decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid idComprador, Guid idAssociado, 
            Classificacao classificacao, CompraVenda compraVenda) : this(default, lote, quantidade, pesoBruto, valor, 
                origem, arroba, rendimentoCarcaca, dataInicioParceria, idComprador, idAssociado, classificacao, 
                compraVenda)
        {
        }
        public InicioParceria() { }
    }
}
