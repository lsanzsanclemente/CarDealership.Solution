using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarDealership.Api.StartUpConfiguration
{
    /// <summary>
    /// Swagger authentication configuration
    /// </summary>
    public static class SwaggerAuthenticationConfiguration
    {
        /// <summary>
        /// Añadir validación ApiKey para Swagger
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static SwaggerGenOptions AddApiKeyHeader(this SwaggerGenOptions options)
        {            
            var securityScheme = new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Name = "Apikey",
                Description = "Apikey for requests",
                Type = SecuritySchemeType.ApiKey
            };

            options.AddSecurityDefinition("Apikey", securityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Apikey" }
                    },
                    new string[] { }
                }
            });

            return options;
        }
    }
}
