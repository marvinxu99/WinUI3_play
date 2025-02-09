using Microsoft.EntityFrameworkCore;
using MVVM_play.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVVM_play.Services;

public class UserService
{
    private readonly DatabaseContext _dbContext;

    public UserService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users.Include(u => u.UserProfile).ToListAsync();
    }

    public async Task AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {
        //var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
