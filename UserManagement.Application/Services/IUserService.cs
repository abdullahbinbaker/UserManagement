using UserManagement.Domain.Entities;

namespace UserManagement.Application.Services
{
    public interface IUserService
    {
        bool CreateUser(User user);
        User? GetUserInfo(long socialIdFK);
        bool EditUser(User user);
        bool RemoveUser(long socialIdFK);
    }
}
