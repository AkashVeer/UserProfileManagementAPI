using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfileManagementAPI.Entities;

namespace UserProfileManagementAPI.Database.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid Id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
