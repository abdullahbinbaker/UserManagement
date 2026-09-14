using AutoMapper;
using Microsoft.Extensions.Logging;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.Repository;

namespace UserManagement.Application.Services
{
    internal class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger <AddressService>_logger; 
        public AddressService(IAddressRepository addressRepository, IUserRepository userRepository, IMapper mapper, ILogger<AddressService> logger)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public bool CreateAddress(List<AddressDto> addressDto)
        {
            try
            {
                var socialId = addressDto.First().SocialIdFK;
                _logger.LogInformation("Createing address for SocialIdFK: {SocialIdFK}",socialId);

                var user = _userRepository.GetUser(socialId);
                if (user == null)
                {
                    _logger.LogWarning("User with SocialIdFK: {SocialIdFK} not found", socialId);
                    return false;
                }
                var addressList = _mapper.Map<List<Address>>(addressDto);

                foreach (var address in addressList)
                {
                    address.UserId = user.Id;
                    _addressRepository.AddAddress(address);
                }
                _logger.LogInformation("Address created successfully for SocialIdFK: {SocialIdFK}", socialId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating addresses");
                return false;
            }

        }

        public List<AddressDto> GetAddressInfo(long socialIdFK)
        {
                _logger.LogInformation("Getting addresses for SocialIdFK: {SocialIdFK", socialIdFK);
            
            var addresses = _addressRepository.GetAddress(socialIdFK);

            if(addresses == null || addresses.Count == 0)
            {
                _logger.LogWarning("No addresses found for SocialIdFK: {SocialIdFK}", socialIdFK);
                return new List<AddressDto>();
            }
            _logger.LogInformation("addresses retrieved successfully for SocialIdFK: {SocialIdFK", socialIdFK);
            return _mapper.Map<List<AddressDto>>(addresses);
        }

        public bool EditAddress(EditAddressDto addressDto)
        {
            _logger.LogInformation("Updating Address Id: {AddressId}", addressDto.Id);
            var address = _mapper.Map<Address>(addressDto);
            _addressRepository.UpdateAddress(address);
            _logger.LogInformation("Address Id {AddressId} updated successfully", addressDto.Id);
            return true;
        }

        public bool RemoveAddress(long socialIdFK, int AddressId)
        {
            _logger.LogInformation("Deleting Address Id: {AddressId} for SocialIdFK: {SocialIdFK}", AddressId,socialIdFK);

            _addressRepository.DeleteAddress(AddressId);

            _logger.LogInformation("Address Id {AddressId} deleted successfully ", AddressId);

            return true;
        }
        
    }
}
