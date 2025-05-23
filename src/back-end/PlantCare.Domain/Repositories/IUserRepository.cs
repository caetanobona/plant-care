using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    User GetByUsername(string username);
}