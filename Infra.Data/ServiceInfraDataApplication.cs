using Infra.Data.Repository;
using Infra.Data.Repository.Interface;
using Infra.Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data
{
    public static class ServiceInfraDataApplication
    {
        public static IServiceCollection AddServiceInfraDataApplication(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            return services;
        }
    }

}
