using AutoMapper;
using CarDealership.Domain.Entities;
using CarDealership.Infrastructure.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealership.Api.StartUpConfiguration
{
    /// <summary>
    /// AutoMapper configuration
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Add automapper configuration. Para el automapeo de entidades
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }

    /// <summary>
    /// Create mapping maps. Perfil de mapeo de entidades Vehículo
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Create mapping maps constructor
        /// </summary>
        public MappingProfile()
        {            
            CreateMap<Vehicle, VehicleDto>();            
        }
    }
}
