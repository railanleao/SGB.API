using Sgb.Domain.Entities.CompradorAssociado;

namespace Sgb.Application.DTOs.Request.Atualizacao
{
    public class AtualizacaoAssociadoRequest
    {
        public Guid CadastroId { get; set; }
        public string Nome { get; set; }
        public int CPF { get; set; }
        public string Fazenda { get; set; }
        public DateTime DataDaParceria { get; set; }
        public Guid IdComprador { get; set; }
        public Comprador? Comprador { get; set; }
        public AtualizacaoAssociadoRequest(Guid cadastroId, int cpf, DateTime dataDaParceria, string fazenda, Guid idComprador, string nome)
        {
            CadastroId = cadastroId;
            CPF = cpf;
            DataDaParceria = dataDaParceria;
            Fazenda = fazenda;
            IdComprador = idComprador;
            Nome = nome;
        }
        public static Associado ConverterParaEntidade(AtualizacaoAssociadoRequest associadoRequest)
        {
            return new Associado
                (
                associadoRequest.CadastroId,
                associadoRequest.CPF,
                associadoRequest.DataDaParceria,
                associadoRequest.Fazenda,
                associadoRequest.IdComprador,
                associadoRequest.Nome
                );
        }
        public AtualizacaoAssociadoRequest() { }
    }
}
