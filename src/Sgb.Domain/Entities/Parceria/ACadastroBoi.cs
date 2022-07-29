using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Sgb.Domain.Entities.Parceria
{
    public enum Classificacao
    {
        Boi,
        Bezerro,
    }
    public enum CompraVenda
    {
        Compra,
        Venda,
    }
    public class ACadastroBoi
    {
        public Guid BoiId { get; protected set; }

        [Display(Name = "Classificação")]
        public Classificacao? Classificacao { get; set; }


        [Display(Name = "Modelo")]
        public CompraVenda? CompraVenda { get; set; }

        [Display(Name = "Peso Bruto")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal PesoBruto { get; protected set; }
        [Display(Name = "Rend. Carcaça")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal RendimentoCarcaca { get; protected set; }
        [Display(Name = "Arroba")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Arroba { get; protected set; }

        [NotMapped]
        public List<SelectListItem>? Classificacoes { get; set; }
        [NotMapped]
        public List<SelectListItem>? CompraVendas { get; set; }
    }
}
