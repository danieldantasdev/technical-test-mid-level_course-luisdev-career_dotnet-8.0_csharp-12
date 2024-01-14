namespace Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;

internal interface IBaseRepository<T> where T : class
{
    Task Post(T entity);
    Task<List<T>> GetAll();
    Task<T> GetById(uint id);
    Task Update(T entity);
    Task Delete(T entity);
}