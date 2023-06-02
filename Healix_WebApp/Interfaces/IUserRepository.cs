using Healix_WebApp.Models;

namespace Healix_WebApp.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<int> CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
