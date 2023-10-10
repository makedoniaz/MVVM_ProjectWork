using FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> GetAll();

    User? GetById(int id);

    int Create(User user);
}
