using Sgb.Domain.Entities.CompradorAssociado;

namespace Sgb.Application.DTOs.Request
{
    public class InsercaoCompradorRequest
    {
        public Guid CadastroId { get; set; }
        public string Nome { get; set; }
        public int CPF { get; set; }
        public InsercaoCompradorRequest(Guid cadastroId, string nome, int cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public static Comprador ConverterParaEntidade(InsercaoCompradorRequest compradorRequest)
        {
            return new Comprador
                (
                compradorRequest.CadastroId,
                compradorRequest.Nome,
                compradorRequest.CPF
                );
        }
        public InsercaoCompradorRequest() { }
    }
}
