using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfileManagementAPI.Entities;

namespace UserProfileManagementAPI.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
        public async Task CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
