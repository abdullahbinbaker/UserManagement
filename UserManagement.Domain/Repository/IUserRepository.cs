using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUser(long socialIdFK);
        void UpdateUser(User user);
        void DeleteUser(long socialIdFK);
    }
}
