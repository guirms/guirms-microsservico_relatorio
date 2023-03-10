using Application.Interfaces;
using Application.RabbitMQ;
using Application.Services;
using Infra.External.Repositories.EstacionaFacilRepository;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuting.Native_Injector
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IRabbitMqConfig, RabbitMqConfig>();
            services.AddScoped<IRelatorioService, RelatorioService>();
     //       services.AddScoped<IEstacionaFacilRepository, EstacionaFacilRepository>();
        }
    }
}