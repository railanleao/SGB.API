using Microsoft.EntityFrameworkCore;
using Sgb.Data.Data;
using Sgb.Data.Repositories.Shared;
using Sgb.Domain.Entities.Parceria;
using Sgb.Domain.Interfaces.Repositories;

namespace Sgb.Data.Repositories
{
    public class RepositoryInicioParceria : RepositoryBase<InicioParceria>, IRepositoryInicioParceria
    {
        public RepositoryInicioParceria(ContextBvs context) : base(context)
        {
        }
        public async override Task<IEnumerable<InicioParceria>> ObterTodosAsync()
        {
            return await _context.InicioParcerias
                .Include(i => i.Comprador)
                .Include(i => i.Associado)
                .AsSingleQuery()
                .ToListAsync();
        }
        public async override Task<InicioParceria?> ObterPorIdAsync(Guid id)
        {
            return await _context.InicioParcerias
                .Include(i => i.Comprador)
                .Include(i => i.Associado)
                .Where(i => i.BoiId == id)
                .AsSingleQuery()
                .FirstOrDefaultAsync();
        }
    }
}
