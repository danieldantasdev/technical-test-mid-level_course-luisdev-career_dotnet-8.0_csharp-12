using Jobs.CleanArchitecture.Core.Entities;

namespace Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;

public interface IUserRepository : IBaseRepository<User>
{
    Task<List<User>> GetAllFilterByName(string name);
    Task Active(uint id);
    Task Inactive(uint id);
}