using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Pages;
using FitnessApp.ViewModels.Base;
using System;

namespace FitnessApp.ViewModels.Pages;

public class AddMealViewModel : ViewModelBase
{
    #region Fields
    private readonly IMealRepository _mealRepository;
    private readonly IMessenger _messenger;

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

    private string? errorMessage;
    public string? ErrorMessage
    {
        get => errorMessage;
        set => base.PropertyChangeMethod(out errorMessage, value);
    }
    #endregion


    #region Constructor
    public AddMealViewModel(IMealRepository mealRepository, IMessenger messenger)
    {
        _mealRepository = mealRepository;
        _messenger = messenger;
    }
    #endregion


    #region Commands
    private CommandBase? addMealCommand;
    public CommandBase AddMealCommand => this.addMealCommand ??= new CommandBase(
            execute: () => {

                if (!MealInputValidationCommand.ValidateMealInput(MealNameInput, CaloriesAmountInput))
                {
                    ErrorMessage = "Invalid meal info input!";
                    return;
                }

                _mealRepository.Create(new Meal()
                {
                    Name = MealNameInput,
                    CaloriesAmount = CaloriesAmountInput,
                    UserId = App.Container.GetInstance<User>().Id,
                    CreationDate = DateTime.Now
                });

                _messenger.Send(new NavigationMessage(App.Container.GetInstance<MealsViewModel>()));
            },
            canExecute: () => true);
    #endregion


    #region Methods
    public override void RefreshViewModel()
    {
        this.MealNameInput = string.Empty;
        this.CaloriesAmountInput = 0;
        this.ErrorMessage = string.Empty;
    }
    #endregion
}
