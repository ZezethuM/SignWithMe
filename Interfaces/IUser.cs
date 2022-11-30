using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignWithMe.Models;

namespace SignWithMe.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers();
        User UserbyName(string username);
        void AddUser(User user);
        bool AuthUser(User  user);
    }
}