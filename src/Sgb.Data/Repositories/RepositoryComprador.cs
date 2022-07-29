using Sgb.Data.Data;
using Sgb.Data.Repositories.Shared;
using Sgb.Domain.Entities.CompradorAssociado;
using Sgb.Domain.Interfaces.Repositories;

namespace Sgb.Data.Repositories
{
    public class RepositoryComprador : RepositoryBase<Comprador>, IRepositoryComprador
    {
        public RepositoryComprador(ContextBvs context) : base(context)
        {

        }

    }
}
