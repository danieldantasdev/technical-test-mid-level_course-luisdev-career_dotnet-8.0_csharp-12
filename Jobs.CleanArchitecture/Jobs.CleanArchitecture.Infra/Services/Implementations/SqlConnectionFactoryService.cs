using Jobs.CleanArchitecture.Core.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Jobs.CleanArchitecture.Infra.Services.Implementations;

internal sealed class SqlConnectionFactoryService(IConfiguration configuration) : ISqlConnectionFactoryService
{
    private readonly IConfiguration _configuration = configuration;

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
