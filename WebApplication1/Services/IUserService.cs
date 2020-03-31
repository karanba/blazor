using System;
using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
