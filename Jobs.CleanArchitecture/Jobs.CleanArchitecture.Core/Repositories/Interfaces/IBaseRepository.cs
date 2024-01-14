namespace Jobs.CleanArchitecture.Core.Repositories.Interfaces;

internal interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(uint id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}