namespace Sgb.Domain.Entities.CompradorAssociado
{
    public class ACadastro
    {
        public Guid CadastroId { get; protected set; }
        public string? Nome { get; protected set; }
        public int CPF { get; protected set; }
    }
}
