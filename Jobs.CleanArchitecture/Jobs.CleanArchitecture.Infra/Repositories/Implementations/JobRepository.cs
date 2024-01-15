using Dapper;
using Jobs.CleanArchitecture.Core.Entities;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.Services.Interfaces;
using Microsoft.Data.SqlClient;


namespace Jobs.CleanArchitecture.Infra.Repositories.Implementations;

internal class JobRepository(ISqlConnectionFactoryService sqlConnectionFactory) : IJobRepository
{
    private readonly ISqlConnectionFactoryService _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));

    public async Task<int> Post(Job entity)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();

            var result = await sqlConnection.ExecuteAsync(
                @"
                        INSERT INTO job 
                            (title, description, location, salary, id_status) 
                        VALUES 
                            (@Title, @Description, @Location, @Salary, @IdStatus)
                    ",
                entity
            );

            return result;
        }
        catch (Exception exception)
        {
            throw new Exception("Error while query insert execution", exception);
        }
    }

    public async Task<List<Job>> GetAll()
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();

            var jobs = await sqlConnection.QueryAsync<Job>(
                "SELECT * FROM job"
            );

            return jobs.AsList();
        }
        catch (Exception exception)
        {
            throw new Exception("Error while querying for all jobs", exception);
        }
    }

    public async Task<Job> GetById(int id)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();

            var job = await sqlConnection.QueryFirstOrDefaultAsync<Job>(
                "SELECT * FROM job WHERE id = @Id",
                new { Id = id }
            );

            return job;
        }
        catch (Exception exception)
        {
            throw new Exception($"Error while querying for job with id {id}", exception);
        }
    }

    public async Task<int> Update(Job entity)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();

            var result = await sqlConnection.ExecuteAsync(
                @"
                        UPDATE job 
                        SET 
                            title = @Title,
                            description = @Description,
                            location = @Location,
                            salary = @Salary,
                            id_status = @IdStatus
                        WHERE 
                            id = @Id
                    ",
                entity
            );

            return result;
        }
        catch (Exception exception)
        {
            throw new Exception("Error while updating job", exception);
        }
    }

    public async Task<int> Delete(int id)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactory.CreateConnection();

            var result = await sqlConnection.ExecuteAsync(
                "DELETE FROM job WHERE id = @id",
                id
            );

            return result;
        }
        catch (Exception exception)
        {
            throw new Exception("Error while deleting job", exception);
        }
    }
}
