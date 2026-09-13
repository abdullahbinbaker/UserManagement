using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.Repository;

namespace UserManagement.Application.Services
{
    internal class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepository,IUserRepository userRepository ,IMapper mapper)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool CreateAddress(AddressDto addressDto)
        {
            var user = _userRepository.GetUser(addressDto.SocialIdFK);
            if (user == null)
            {
                return false;
            }
            var address = _mapper.Map<Address>(addressDto);
            address.UserId = user.Id;
            _addressRepository.AddAddress(address);
            return true;
        }

        public List<AddressDto> GetAddressInfo(long socialIdFK)
        {
            var addresses = _addressRepository.GetAddress(socialIdFK);

            return _mapper.Map<List<AddressDto>>(addresses);
        }

        public bool EditAddress(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _addressRepository.UpdateAddress(address);
            return true;
        }

        public bool RemoveAddress(long socialIdFK)
        {
            _addressRepository.DeleteAddress(socialIdFK);
            return true;
        }
    }
}
