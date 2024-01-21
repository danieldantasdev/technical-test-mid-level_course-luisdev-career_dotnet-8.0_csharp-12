using Dapper;
using Jobs.CleanArchitecture.Core.Entities;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.Services.Interfaces;
using Microsoft.Data.SqlClient;


namespace Jobs.CleanArchitecture.Infra.Repositories.Implementations;

internal class JobRepository(ISqlConnectionFactoryService sqlConnectionFactoryService) : IJobRepository
{
    private readonly ISqlConnectionFactoryService _sqlConnectionFactoryService = sqlConnectionFactoryService;

    public async Task<int> Post(Job entity)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactoryService.CreateConnection();

            int result = await sqlConnection.ExecuteAsync(
                @"
                        INSERT INTO job 
                            (title, description, location, salary, id_status) 
                        VALUES 
                            (@Title, @Description, @Location, @Salary, @IdStatus);
                ",
                entity
            );

            return result;
        }
        catch (Exception exception)
        {
            throw new Exception("Error while query insert execution: " + exception.Message);
        }
    }

    public async Task<List<Job>> GetAll()
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactoryService.CreateConnection();

            IEnumerable<Job> jobs = await sqlConnection.QueryAsync<Job>(
                "SELECT j.id Id, j.title Title, j.description Description, j.location Location, j.salary Salary, j.id_status IdStatus FROM job j"
            );

            return jobs.AsList();
        }
        catch (Exception exception)
        {
            throw new Exception("Error while querying for all jobs: " + exception.Message);
        }
    }

    public async Task<Job?> GetById(int id)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactoryService.CreateConnection();

            Job? job = await sqlConnection.QueryFirstOrDefaultAsync<Job>(
                "SELECT j.id Id, j.title Title, j.description Description, j.location Location, j.salary Salary, j.id_status IdStatus FROM job j WHERE j.id = @Id",
                new { Id = id }
            );

            return job;
        }
        catch (Exception exception)
        {
            throw new Exception($"Error while querying for job with id {id}: " + exception.Message);
        }
    }

    public async Task<int> Update(Job entity)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactoryService.CreateConnection();

            int result = await sqlConnection.ExecuteAsync(
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
            throw new Exception("Error while updating job: " + exception.Message);
        }
    }

    public async Task<int> Delete(int id)
    {
        try
        {
            await using SqlConnection sqlConnection = _sqlConnectionFactoryService.CreateConnection();

            int result = await sqlConnection.ExecuteAsync(
                "DELETE FROM job WHERE id = @id",
                new { id }
            );

            return result;
        }
        catch (Exception exception)
        {
            throw new Exception("Error while deleting job: " + exception.Message);
        }
    }
}
