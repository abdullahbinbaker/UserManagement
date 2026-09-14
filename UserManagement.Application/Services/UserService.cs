using AutoMapper;
using Microsoft.Extensions.Logging;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool CreateUser(UserDto userDto)
        {
           
            var user = _mapper.Map<User>(userDto); 
            _userRepository.AddUser(user);
           
            return true;
        }

        public UserDto? GetUserInfo(long socialIdFK)
        {
            var user = _userRepository.GetUser(socialIdFK);
            if (user == null)
            {
                return null;
            }
            
            return _mapper.Map<UserDto>(user);
        }

        public bool EditUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
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