using Sgb.Domain.Entities.Parceria;
using Sgb.Domain.Interfaces.Repositories;
using Sgb.Domain.Interfaces.Service;
using Sgb.Domain.Services.Shared;

namespace Sgb.Domain.Services
{
    public class ServiceAlteracaoSaida : ServiceBase<AlteracaoSaida>, IServiceAlteracaoSaida
    {
        public ServiceAlteracaoSaida(IRepositoryAlteracaoSaida repositoryAlteracaoSaida) : base(repositoryAlteracaoSaida)
        {
        }
    }
}
