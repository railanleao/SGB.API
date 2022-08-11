using Sgb.Domain.Entities.Parceria;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sgb.Domain.Entities.CompradorAssociado
{
    public class Associado : ACadastro
    {
        public Associado() { }

        public Associado(string cpf, DateTime dataDaParceria, string? fazenda, Guid compradorId, string? nome) :
        this(default, cpf, dataDaParceria, fazenda, compradorId, nome)
        {
        }

        public Associado(Guid cadastroId, string cpf, DateTime dataDaParceria, string? fazenda, Guid compradorId, string? nome)
        {
            CadastroId = cadastroId;
            CPF = cpf;
            DataDaParceria = dataDaParceria;
            Fazenda = fazenda;
            CompradorId = compradorId;
            Nome = nome;

        }

        public string? Fazenda { get; set; }
        [Display(Name = "Data Início da Parceria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataDaParceria { get; private set; }
        public Guid CompradorId { get; private set; }
        [JsonIgnore]
        public Comprador? Comprador { get; set; }
        [JsonIgnore]
        public virtual ICollection<InicioParceria>? InicioParcerias { get; private set; }
        [JsonIgnore]
        public virtual ICollection<AlteracaoSaida>? AlteracaoSaidas { get; private set; }
    }
}
