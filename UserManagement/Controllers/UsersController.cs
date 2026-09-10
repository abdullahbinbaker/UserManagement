using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Services;
namespace UserManagement.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userS)
    {
        _userService = userS;
    }

    [HttpPost]
    public IActionResult CreateUser(UserDto user)
    {
        var result = _userService.CreateUser(user);
        if (result == false)
        {
            return BadRequest("User could not be created.");
        }
        return Ok("User created successfully.");
    }
    [HttpGet("{socialIdFK}")]
    public IActionResult GetUserInfo(long socialIdFK)
    {
        var user = _userService.GetUserInfo(socialIdFK);
        if (user == null)
        {
            return NotFound("User not found.");
        }
        return Ok(user);
    }
    [HttpPut]
    public IActionResult EditUser(UserDto user)
    {
        var result = _userService.EditUser(user);
        if (result == false)
        {
            return BadRequest("User could not be updated.");
        }
        return Ok("User updated successfully.");
    }
    [HttpDelete("{socialIdFK}")]
    public IActionResult DeleteUser(long socialIdFK)
    {
        var result = _userService.RemoveUser(socialIdFK);
        if (result == false)
        {
            return BadRequest("User could not be deleted.");
        }
        return Ok("User deleted successfully.");
    }
}
