using Microsoft.EntityFrameworkCore;
using Sgb.Data.Data;
using Sgb.Data.Repositories.Shared;
using Sgb.Domain.Entities.CompradorAssociado;
using Sgb.Domain.Interfaces.Repositories;

namespace Sgb.Data.Repositories
{
    public class RepositoryAssociado : RepositoryBase<Associado>, IRepositoryAssociado
    {
        public RepositoryAssociado(ContextBvs context) : base(context)
        {
        }
        public async override Task<IEnumerable<Associado>> ObterTodosAsync()
        {
            return await _context.Associados
                .Include(a => a.Comprador)
                .AsSingleQuery()
                .ToListAsync();
        }
        public async override Task<Associado?> ObterPorIdAsync(Guid id)
        {
            return await _context.Associados
                .Include(a => a.Comprador)
                .Where(a => a.CadastroId == id)
                .AsSingleQuery()
                .FirstOrDefaultAsync();
            //     .FirstOrDefaultAsync(a => a.Equals(id));
        }
    }
}
