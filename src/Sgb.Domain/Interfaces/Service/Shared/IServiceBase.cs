namespace Sgb.Domain.Interfaces.Service.Shared
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<TEntity?> ObterPorIdAsync(Guid id);
        Task<object> AdicionarAsync(TEntity objeto);
        Task AtualizarAsync(TEntity objeto);
        Task RemoverAsync(TEntity objeto);
        Task RemoverPorIdAsync(Guid id);
    }
}
