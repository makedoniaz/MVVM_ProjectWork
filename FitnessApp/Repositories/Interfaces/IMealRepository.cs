using FitnessApp.Models;
using System.Linq;

namespace FitnessApp.Repositories.Interfaces;

public interface IMealRepository
{
    IQueryable<Meal> GetAll();

    Meal? GetById(int id);

    IQueryable<Meal> GetByUserId(int userId);

    void Create(Meal product);
}
