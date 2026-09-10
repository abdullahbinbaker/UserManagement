using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services
{
    public interface IUserService
    {
        bool CreateUser(UserDto userDto);
        UserDto? GetUserInfo(long socialIdFK);
        bool EditUser(UserDto userDto);
        bool RemoveUser(long socialIdFK);
    }
}
