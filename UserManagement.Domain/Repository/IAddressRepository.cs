using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repository
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        List<Address> GetAddress(long socialIdFK);
        void UpdateAddress(Address address);
        void DeleteAddress(long addressId);
    }
}
