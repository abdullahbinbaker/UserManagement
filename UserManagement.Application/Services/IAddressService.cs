using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services
{
    public interface IAddressService
    {
        bool CreateAddress(List<AddressDto> addressDto);
        List<AddressDto> GetAddressInfo(long SociIdFK);
        bool EditAddress(EditAddressDto addressDto);
        bool RemoveAddress(long SociIdFK, int adddressId);
    }
}
