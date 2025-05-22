using System.Threading.Tasks;
using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUsername(string username);
}