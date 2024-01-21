namespace Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;

public interface IBaseRepository<T> where T : class
{
    Task<int> Post(T entity);
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
}