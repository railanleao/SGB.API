using Sgb.Domain.Entities.Parceria;
using System.Text.Json.Serialization;

namespace Sgb.Domain.Entities.CompradorAssociado
{
    public class Comprador : ACadastro
    {
        public Comprador() { }
        
        [JsonIgnore]
        public virtual ICollection<Associado>? Associados { get; private set; }
        [JsonIgnore]
        public virtual ICollection<InicioParceria>? InicioParcerias { get; private set; }
        [JsonIgnore]
        public virtual ICollection<AlteracaoSaida>? AlteracaoSaidas { get; private set; }

        public Comprador(Guid cadastroId, string nome, string cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public Comprador(string nome, string cpf) : this(default, nome, cpf) { }
    }
}
