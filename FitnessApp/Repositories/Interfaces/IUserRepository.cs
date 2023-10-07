using FitnessApp.Models;
using System.Collections.Generic;

namespace FitnessApp.Repositories.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAll();

    User GetById(int id);

    void Create(User user);
}
