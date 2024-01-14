using Jobs.CleanArchitecture.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Jobs.CleanArchitecture.Infra.Extensions
{
    public static class InfrastrutureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISqlConnectionFactoryService, ISqlConnectionFactoryService>();
            return services;
        }
    }
}
