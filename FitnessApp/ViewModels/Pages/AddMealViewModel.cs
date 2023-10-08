using FitnessApp.Commands.Base;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModels.Pages;

public class AddMealViewModel : ViewModelBase
{
    private readonly IMealRepository _mealRepository;

    private string? mealNameInput;
    public string? MealNameInput
    {
        get => mealNameInput;
        set => base.PropertyChangeMethod(out mealNameInput, value);
    }

    private double caloriesAmountInput;
    public double CaloriesAmountInput
    {
        get => caloriesAmountInput;
        set => base.PropertyChangeMethod(out caloriesAmountInput, value);
    }

    public AddMealViewModel(IMealRepository mealRepository)
    {
        _mealRepository = mealRepository;
    }


    private CommandBase? addMealCommand;
    public CommandBase AddMealCommand => this.addMealCommand ??= new CommandBase(
            execute: () => {
                _mealRepository.Create(new Meal()
                {
                    Name = MealNameInput,
                    CaloriesAmount = CaloriesAmountInput,
                    UserId = App.Container.GetInstance<User>().Id,
                    CreationDate = DateTime.Now
                });
            },
            canExecute: () => true);

}
