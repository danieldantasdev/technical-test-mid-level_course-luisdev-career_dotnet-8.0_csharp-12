using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.Services.Interfaces;
using Jobs.CleanArchitecture.Infra.Repositories.Implementations;
using Jobs.CleanArchitecture.Infra.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Jobs.CleanArchitecture.Infra.Extensions;

public static class InfrastrutureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISqlConnectionFactoryService, SqlConnectionFactoryService>();
        services.AddScoped<IJobRepository, JobRepository>();
        return services;
    }
}
