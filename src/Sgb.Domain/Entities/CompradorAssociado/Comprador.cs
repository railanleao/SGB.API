using Sgb.Domain.Entities.Parceria;

namespace Sgb.Domain.Entities.CompradorAssociado
{
    public class Comprador : ACadastro
    {
        public Comprador() { }

        public virtual ICollection<Associado>? Associados { get; private set; }
        public virtual ICollection<InicioParceria>? InicioParcerias { get; private set; }
        public virtual ICollection<AlteracaoSaida>? AlteracaoSaidas { get; private set; }

        public Comprador(Guid cadastroId, string? nome, int cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public Comprador(string? nome, int cpf) : this(default, nome, cpf) {  }
    }
}
