using Microsoft.EntityFrameworkCore;
using Sgb.Data.Data;
using Sgb.Domain.Interfaces.Repositories.Shared;

namespace Sgb.Data.Repositories.Shared
{
    public class RepositoryBase<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ContextBvs _context;

        public RepositoryBase(ContextBvs context)
        {
            _context = context;
        }

        public virtual async Task<object> AdicionarAsync(TEntity objeto)
        {
            _context.Add(objeto);
            await _context.SaveChangesAsync();
            return objeto;
        }

        public virtual async Task AtualizarAsync(TEntity objeto)
        {
            _context.Entry(objeto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public void Dispose() =>
            _context.Dispose();

        public virtual async Task<TEntity?> ObterPorIdAsync(Guid id) =>
            await _context.Set<TEntity>().FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync() =>
            await _context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

        public virtual async Task RemoverAsync(TEntity objeto)
        {
            _context.Set<TEntity>().Remove(objeto);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoverPorIdAsync(Guid id)
        {
            var objeto = await ObterPorIdAsync(id);
            if (objeto == null)
                throw new Exception("O registro não existe na base de dados!");
            await RemoverAsync(objeto);
        }
    }
}
