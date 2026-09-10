using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Application.DTOs
{
    public class UserDto
    {
        public long SocialIdFK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MobileNumber { get; set; }
    }
}
