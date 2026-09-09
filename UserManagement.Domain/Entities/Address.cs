using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string Country { get; set; }

        public long SocialIdFK { get; set; }
        public User User { get; set; }
    }
}
