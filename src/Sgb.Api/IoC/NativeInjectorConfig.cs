using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sgb.Application.Service;
using Sgb.Data.Data;
using Sgb.Data.Repositories;
using Sgb.Domain.Interfaces.Repositories;
using Sgb.Domain.Interfaces.Service;
using Sgb.Domain.Services;
using Sgb.Identity.Data;
using Sgb.Identity.Service;

namespace Sgb.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddEntityFrameworkNpgsql().AddDbContextPool<ContextBvs>(opt => opt.UseNpgsql
        (configuration.GetConnectionString("BVS")));
            services.AddEntityFrameworkNpgsql().AddDbContextPool<IdentityDataContext>(opt => opt.UseNpgsql
            (configuration.GetConnectionString("BVS")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IServiceComprador, ServiceComprador>();
            services.AddScoped<IRepositoryComprador, RepositoryComprador>();

            services.AddScoped<IServiceAssociado, ServiceAssociado>();
            services.AddScoped<IRepositoryAssociado, RepositoryAssociado>();

            services.AddScoped<IServiceInicioParceria, ServiceInicioParceria>();
            services.AddScoped<IRepositoryInicioParceria, RepositoryInicioParceria>();

            services.AddScoped<IServiceAlteracaoSaida, ServiceAlteracaoSaida>();
            services.AddScoped<IRepositoryAlteracaoSaida, RepositoryAlteracaoSaida>();

            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
