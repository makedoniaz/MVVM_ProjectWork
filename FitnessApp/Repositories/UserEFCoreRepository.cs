using FitnessApp.Models;
using FitnessApp.Models.Context;
using FitnessApp.Repositories.Interfaces;
using System.Linq;

namespace FitnessApp.Repositories;

public class UserEFCoreRepository : IUserRepository
{
    private readonly FitnessContext _context;

    public UserEFCoreRepository() => _context = new FitnessContext();

    public IQueryable<User> GetAll()
    {
        return _context.Users;
    }

    public User? GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public int Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return user.Id;
    }
}
