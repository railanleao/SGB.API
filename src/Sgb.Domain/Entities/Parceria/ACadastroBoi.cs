using System.ComponentModel.DataAnnotations;
using Sgb.Domain.Entities.Constants;

namespace Sgb.Domain.Entities.Parceria
{
    public class ACadastroBoi
    {
        public Guid BoiId { get; protected set; }

        [Display(Name = "Classificação")]
        public Classificacao? Classificacao { get; set; }

        [Display(Name = "Modelo de Negócio")]
        public ModeloDeNegocio? CompraVenda { get; set; }

        [Display(Name = "Peso Bruto")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal PesoBruto { get; protected set; }
        [Display(Name = "Rend. Carcaça")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal RendimentoCarcaca { get; protected set; }
        [Display(Name = "Arroba")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Arroba { get; protected set; }
    }
}
