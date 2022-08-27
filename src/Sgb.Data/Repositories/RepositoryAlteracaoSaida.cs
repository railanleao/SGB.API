using Microsoft.EntityFrameworkCore;
using Sgb.Data.Data;
using Sgb.Data.Repositories.Shared;
using Sgb.Domain.Entities.Parceria;
using Sgb.Domain.Interfaces.Repositories;

namespace Sgb.Data.Repositories
{
    public class RepositoryAlteracaoSaida : RepositoryBase<AlteracaoSaida>, IRepositoryAlteracaoSaida
    {
        public RepositoryAlteracaoSaida(ContextBvs context) : base(context)
        {
        }
        public async override Task<IEnumerable<AlteracaoSaida>> ObterTodosAsync()
        {
            return await _context.AlteracaoSaidas
                .Include(ats => ats.Comprador)
                .Include(ats => ats.Associado)
                .Include(ats => ats.InicioParceria)
                .AsSingleQuery()
                .ToListAsync();
        }
        public async override Task<AlteracaoSaida?> ObterPorIdAsync(Guid id)
        {
            return await _context.AlteracaoSaidas
                .Include(ats => ats.Comprador)
                .Include(ats => ats.Associado)
                .Include(ats => ats.InicioParceria)                
                .AsSingleQuery()
                .FirstOrDefaultAsync(a => a.Equals(id));
            //.Where(ats => ats.InicioParceriaId == id)
        }
    }
}
