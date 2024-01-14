using Microsoft.Data.SqlClient;

namespace Jobs.CleanArchitecture.Core.Services.Interfaces;

public interface ISqlConnectionFactoryService
{
    SqlConnection CreateConnection();
}
