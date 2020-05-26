using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        Task<IEnumerable<User>> GetAllAsync();
    }
}
