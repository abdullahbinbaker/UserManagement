using UserManagement.Domain.Data;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User? GetUser(long socialIdFK)
        {
            return _context.Users.FirstOrDefault(u => u.SocialIdFK == socialIdFK);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.SocialIdFK == user.SocialIdFK);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.BirthDate = user.BirthDate;
                existingUser.MobileNumber = user.MobileNumber;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }

        public void DeleteUser(long socialIdFK)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.SocialIdFK == socialIdFK);
            if (user == null)
            {
                return;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
