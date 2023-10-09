using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Utilities.Pages;

public class FilterMealsByDateCommand
{
    public static IEnumerable<Meal> Filter(IQueryable<Meal> meals, DateTime from, DateTime to)
    {
        return meals.Where((m) => m.CreationDate >= from && m.CreationDate <= to).ToList();
    }
}
