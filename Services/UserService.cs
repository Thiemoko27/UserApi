using UserApi.Data;
using UserApi.Models;
using Microsoft.EntityFrameworkCore;

namespace UserApi.Services;

public class UserService : IUserService
{
    private readonly DataBaseContext _context;

    public UserService(DataBaseContext context) {
        _context = context;
    }

    public User? GetUser(int id) {
        return _context.Users.Find(id);
    }

    public IEnumerable<User> GetAllUsers() {
        return _context.Users.ToList();
    }

    public void AddUser(User user) {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(User user) {
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteUser(int id) {
        var user = _context.Users.Find(id);

        if(user != null) {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}