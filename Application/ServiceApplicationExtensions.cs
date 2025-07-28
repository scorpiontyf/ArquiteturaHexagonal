using Application.Services;
using Domain.Ports;
using Microsoft.Extensions.DependencyInjection;
public static class ServiceApplicationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioService, UsuarioService>();
        return services;
    }
}