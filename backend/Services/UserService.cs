using backend.Data;
using backend.Entities;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }
}