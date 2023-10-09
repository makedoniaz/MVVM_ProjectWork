using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.Repositories.Interfaces;

public interface IMealRepository
{
    IQueryable<Meal> GetAll();

    Meal? GetById(int id);

    public IQueryable<Meal> GetByUserId(int userId);

    void Create(Meal product);
}
