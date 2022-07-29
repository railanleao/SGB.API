using Sgb.Domain.Entities.CompradorAssociado;
using Sgb.Domain.Interfaces.Repositories;
using Sgb.Domain.Interfaces.Service;
using Sgb.Domain.Services.Shared;

namespace Sgb.Domain.Services
{
    public class ServiceAssociado : ServiceBase<Associado>, IServiceAssociado
    {
        public ServiceAssociado(IRepositoryAssociado repositoryAssociado) : base(repositoryAssociado)
        {
        }
    }
}
