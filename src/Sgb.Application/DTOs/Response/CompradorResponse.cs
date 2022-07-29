using Sgb.Domain.Entities.CompradorAssociado;

namespace Sgb.Application.DTOs.Response
{
    public class CompradorResponse
    {
        public Guid CadastroId { get; set; }
        public string? Nome { get; set; }
        public int CPF { get; set; }
        public CompradorResponse(Guid cadastroId, string? nome, int cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public static CompradorResponse ConverteParaResponse(Comprador comprador)
        {
            return new CompradorResponse
            (
                comprador.CadastroId,
                comprador.Nome,
                comprador.CPF
             );
        }
        public CompradorResponse() { }
    }
}
