using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;

namespace Sgb.Domain.Entities.CompradorAssociado
{
    public class Associado : ACadastro
    {
        public Associado() { }

        public Associado(int cpf, DateTime dataDaParceria, string? fazenda, Guid idComprador, string? nome) :
        this(default, cpf, dataDaParceria, fazenda, idComprador, nome)
        {
        }

        public Associado(Guid cadastroId, int cpf, DateTime dataDaParceria, string? fazenda, Guid idComprador, string? nome)
        {
            CadastroId = cadastroId;
            CPF = cpf;
            DataDaParceria = dataDaParceria;
            Fazenda = fazenda;
            IdComprador = idComprador;
            Nome = nome;

        }

        public string? Fazenda { get; set; }
        [Display(Name = "Data Início da Parceria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataDaParceria { get; private set; }
        public Guid IdComprador { get; private set; }
        public Comprador? Comprador { get; set; }
        public virtual ICollection<InicioParceria>? InicioParcerias { get; private set; }
        public virtual ICollection<AlteracaoSaida>? AlteracaoSaidas { get; private set; }
    }
}
