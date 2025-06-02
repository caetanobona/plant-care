using System.Threading.Tasks;
using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
    Dictionary<string, bool> IsAvailable(string? email, string? username);
}