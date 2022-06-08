using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarDealership.Api.StartUpConfiguration
{
    /// <summary>
    /// MediatR configuration
    /// </summary>
    public static class MediatRConfiguration
    {
        /// <summary>
        /// Añadir MediatR configuration. Para usarse en las peticiones de datos siguiendo el patrón CQRS
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("CarDealership.Domain.Commands"));
            services.AddMediatR(Assembly.Load("CarDealership.Domain.Queries"));

            return services;
        }
    }
}
