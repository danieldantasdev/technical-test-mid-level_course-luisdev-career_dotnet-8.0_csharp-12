using Jobs.CleanArchitecture.Core.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Jobs.CleanArchitecture.Infra.Services.Implementations;

internal sealed class SqlConnectionFactoryService(IConfiguration configuration) : ISqlConnectionFactoryService
{
    private readonly IConfiguration _configuration = configuration;

    public SqlConnection CreateConnection()
    {
        try
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        }
        catch (Exception exception)
        {

            throw new Exception("Error while open connection: " + exception.Message);
        }
    }

    public void CloseConnection(SqlConnection connection)
    {
        try
        {
            if (connection is not null && connection.State is not ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        catch (Exception exception)
        {
            throw new Exception("Error while closing connection: " + exception.Message);
        }
    }
}
