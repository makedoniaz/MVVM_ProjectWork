using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Repositories.Interfaces;

public interface IGoalRepository
{
    IQueryable<Goal> GetAll();

    Goal? GetById(int id);

    IQueryable<Goal> GetByUserId(int userId);

    void Create(Goal goal);

    void DeleteById(int id);
}
