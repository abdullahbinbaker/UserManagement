using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Data;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
        public List<Address> GetAddress(long socialIdFK)
        {
            var user = _context.Users.FirstOrDefault(u => u.SocialIdFK == socialIdFK);
            if(user ==null)
            {
                return new List<Address>();
            }
            return _context.Addresses
                .Where(a => a.UserId == user.Id)
                .ToList();
           // return user.Addresses.ToList();

            //return _context.Addresses.FirstOrDefault(a => a.UserId == user.Id);

        }

        public void UpdateAddress(Address address)
        {
            var existingUser = _context.Addresses.FirstOrDefault(u => u.Id == address.Id);
            if (existingUser != null)
            {
                existingUser.StreetName = address.StreetName;
                existingUser.City = address.City;
                existingUser.HouseNo = address.HouseNo;
                existingUser.Country = address.Country;
                // Update other properties as needed
                _context.SaveChanges();
            }
        }

        public void DeleteAddress(long socialIdFK)
        {
            var address = _context.Addresses
               .FirstOrDefault(a => a.Id == socialIdFK);
            if (address == null)
            {
                return;
            }
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

    }
}


