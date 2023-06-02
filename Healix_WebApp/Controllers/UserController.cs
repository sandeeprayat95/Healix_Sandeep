using Healix_WebApp.Dto;
using Healix_WebApp.Interfaces;
using Healix_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserById(userId);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto userDto)
    {
        var user = new User
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            MobileCountryCode = userDto.MobileCountryCode,
            MobileNumber = userDto.MobileNumber,
            Status = userDto.Status
        };

        var createdUserId = await _userService.CreateUser(user);
        return Ok(createdUserId);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, UserDto userDto)
    {
        var existingUser = await _userService.GetUserById(userId);
        if (existingUser == null)
            return NotFound();

        existingUser.FirstName = userDto.FirstName;
        existingUser.LastName = userDto.LastName;
        existingUser.Email = userDto.Email;
        existingUser.MobileCountryCode = userDto.MobileCountryCode;
        existingUser.MobileNumber = userDto.MobileNumber;
        existingUser.Status = userDto.Status;

        await _userService.UpdateUser(existingUser);
        return NoContent();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        await _userService.DeleteUser(userId);
        return NoContent();
    }
}
