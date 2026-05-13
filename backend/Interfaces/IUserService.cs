using backend.Entities;

namespace backend.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<User> CreateUserAsync(User user);
}