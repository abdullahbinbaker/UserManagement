using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Services;

namespace UserManagement.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]

    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService address)
        {
            _addressService = address;
        }

        [HttpPost]
        public IActionResult CreateAddress(List<AddressDto> address)
        {
            var result = _addressService.CreateAddress(address);
            if (result == false)
            {
                return BadRequest("Address could not be created.");
            }
            return Ok("Address created successfully.");
        }
        [HttpGet("{socialIdFK}")]
        public IActionResult GetAddressInfo(long socialIdFK)
        {
            var address = _addressService.GetAddressInfo(socialIdFK);
            if (address == null)
            {
                return NotFound("Address not found.");
            }
            return Ok(address);
        }
        [HttpPut]
        public IActionResult EditAddress(EditAddressDto address)
        {
            var result = _addressService.EditAddress(address);
            if (result == false)
            {
                return BadRequest("Address could not be updated.");
            }
            return Ok("Address updated successfully.");
        }
        [HttpDelete("{socialIdFK}/{AddressId}")]
        public IActionResult DeleteAddress(long socialIdFK,int AddressId)
        {
            var result = _addressService.RemoveAddress(socialIdFK,AddressId );
            if (result == false)
            {
                return BadRequest("Address could not be deleted.");
            }
            return Ok("Address deleted successfully.");
        }
    }
}
