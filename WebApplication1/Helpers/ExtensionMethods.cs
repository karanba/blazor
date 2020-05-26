using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Entities;

namespace WebApplication1.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}
