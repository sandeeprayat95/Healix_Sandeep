using Healix_WebApp.Interfaces;
using Healix_WebApp.Models;

namespace Healix_WebApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _userRepository.GetUserById(userId);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task<int> CreateUser(User user)
    {
        return await _userRepository.CreateUser(user);
    }

    public async Task UpdateUser(User user)
    {
        await _userRepository.UpdateUser(user);
    }

    public async Task DeleteUser(int userId)
    {
        await _userRepository.DeleteUser(userId);
    }
}
