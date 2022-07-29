using Sgb.Domain.Entities.CompradorAssociado;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoCompradorRequest
    {
        public Guid CadastroId { get; set; }
        public string Nome { get; set; }
        public int CPF { get; set; }
        public AtualizacaoCompradorRequest(Guid cadastroId, string nome, int cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public static Comprador ConverterParaEntidade(AtualizacaoCompradorRequest compradorRequest)
        {
            return new Comprador
                (
                compradorRequest.CadastroId,
                compradorRequest.Nome,
                compradorRequest.CPF
                );
        }
        public AtualizacaoCompradorRequest() {      }
    }
}
