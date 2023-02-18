using Application.Interfaces;
using Application.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuting.Native_Injector
{
    public static class NativeInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMqConfig, RabbitMqConfig>();

            return services;
        }
    }
}