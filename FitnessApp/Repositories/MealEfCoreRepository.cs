using FitnessApp.Models;
using FitnessApp.Models.Context;
using FitnessApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.Repositories;

public class MealEfCoreRepository : IMealRepository
{
    private readonly FitnessContext _context;

    public MealEfCoreRepository() => _context = new FitnessContext();

    public IQueryable<Meal> GetAll()
    {
        return _context.Meals;
    }

    public Meal? GetById(int id)
    {
        return _context.Meals.FirstOrDefault(m => m.Id == id);
    }

    public IQueryable<Meal> GetByUserId(int userId)
    {
        return _context.Meals.Where(m => m.UserId == userId);
    }

    public void Create(Meal meal)
    {
        _context.Meals.Add(meal);
        _context.SaveChanges();
    }
}
