using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(User user)
        {
            _userRepository.AddUser(user);
            return true;
        }

        public User? GetUserInfo(long socialIdFK)
        {
            var user = _userRepository.GetUser(socialIdFK);
            return user ?? null;
        }

        public bool EditUser(User user)
        {
            _userRepository.UpdateUser(user);
            return true;
        }

        public bool RemoveUser(long socialIdFK)
        {
            _userRepository.DeleteUser(socialIdFK);
            return true;
        }
    }
}