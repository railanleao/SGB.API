using Sgb.Domain.Entities.Parceria;
using Sgb.Domain.Interfaces.Repositories;
using Sgb.Domain.Interfaces.Service;
using Sgb.Domain.Services.Shared;

namespace Sgb.Domain.Services
{
    public class ServiceInicioParceria : ServiceBase<InicioParceria>, IServiceInicioParceria
    {
        public ServiceInicioParceria(IRepositoryInicioParceria repositoryInicioParceria) : base(repositoryInicioParceria)
        {
        }
        
    }
}
