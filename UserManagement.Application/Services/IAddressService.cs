using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services
{
    public interface IAddressService
    {
        bool CreateAddress(AddressDto addressDto);
        List<AddressDto> GetAddressInfo(long SociIdFK);
        bool EditAddress(AddressDto addressDto);
        bool RemoveAddress(long userId);
    }
}
