using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfileManagementAPI.Entities;

namespace UserProfileManagementAPI.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> Create(User user, string password);
        Task Update(User user, string password = null);
        Task Delete(Guid id);
    }
}
