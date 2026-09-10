using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string Country { get; set; }

        public long SocialIdFK { get; set; }
        
    }
}

