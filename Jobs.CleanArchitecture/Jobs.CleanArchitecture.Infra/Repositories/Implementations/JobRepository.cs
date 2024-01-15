using Dapper;
using Jobs.CleanArchitecture.Core.Entities;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace Jobs.CleanArchitecture.Infra.Repositories.Implementations;

internal class JobRepository(ISqlConnectionFactoryService sqlConnectionFactory) : IJobRepository
{
    private readonly ISqlConnectionFactoryService _sqlConnectionFactory = sqlConnectionFactory;

    public async Task<int> Post(Job entity)
    {
        await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();
        var result = await sqlConnection.ExecuteAsync(
             @"
                INSERT INTO Job 
                    (title, description, location, salary, id_status) 
                VALUES 
                    (@Title, @Description, @Location, @Salary, @IdStatus)
            ",
                 entity
         );

        return result;
    }

    public async Task<List<Job>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Job> GetById(uint id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(Job entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Delete(Job entity)
    {
        throw new NotImplementedException();
    }
}
