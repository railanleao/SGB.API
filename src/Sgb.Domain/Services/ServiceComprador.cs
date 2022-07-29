using Sgb.Domain.Entities.CompradorAssociado;
using Sgb.Domain.Interfaces.Repositories;
using Sgb.Domain.Interfaces.Service;
using Sgb.Domain.Services.Shared;

namespace Sgb.Domain.Services
{
    public class ServiceComprador : ServiceBase<Comprador>, IServiceComprador
    {
        public ServiceComprador(IRepositoryComprador repositoryComprador) : base(repositoryComprador)
        {
        }
    }
}
