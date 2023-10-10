using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.Utilities.Pages;

public class FilterMealsByDateCommand
{
    public static IEnumerable<Meal> Filter(IQueryable<Meal> meals, DateTime from, DateTime to)
    {
        return meals.Where((m) => m.CreationDate >= from && m.CreationDate <= to).ToList();
    }
}
