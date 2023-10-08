using FitnessApp.Models;
using FitnessApp.Models.Context;
using FitnessApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Repositories;

public class GoalsEFCoreRepository : IGoalRepository
{
    private readonly FitnessContext _context;

    public GoalsEFCoreRepository() => _context = new FitnessContext();

    public IQueryable<Goal> GetAll()
    {
        return _context.Goals;
    }

    public Goal? GetById(int id)
    {
        return _context.Goals.FirstOrDefault(g => g.Id == id);
    }

    public IQueryable<Goal> GetByUserId(int userId)
    {
        return _context.Goals.Where(g => g.UserId == userId);
    }

    public void Create(Goal goal)
    {
        _context.Goals.Add(goal);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var goal = GetById(id);

        if (goal == null)
            return;

        _context.Goals.Remove(goal);
        _context.SaveChanges();
    }
}
