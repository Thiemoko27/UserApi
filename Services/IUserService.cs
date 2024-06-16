using UserApi.Models;

namespace UserApi.Services;

public interface IUserService
{
    User? GetUser(int id);
    IEnumerable<User> GetAllUsers();
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
}