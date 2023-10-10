using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Pages;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FitnessApp.ViewModels.Pages;

public class MealsViewModel : ViewModelBase
{
    #region Fields
    private readonly IMessenger _messenger;
    private readonly IMealRepository _mealRepository;

    public ObservableCollection<Meal> Meals { get; set; } = new ObservableCollection<Meal>();

    public ObservableCollection<Meal> TodayMeals { get; set; } = new ObservableCollection<Meal>();
    #endregion


    #region Constructor
    public MealsViewModel(IMessenger messenger, IMealRepository mealRepository)
    {
        _messenger = messenger;
        _mealRepository = mealRepository;
    }
    #endregion


    #region Commands
    private CommandBase? addMealCommand;
    public CommandBase AddMealCommand => this.addMealCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<AddMealViewModel>()));
            },
            canExecute: () => true);
    #endregion


    #region Methods
    public override void RefreshViewModel()
    {
        var userId = App.Container.GetInstance<User>().Id;
        RefreshMeals(userId);
        RefreshTodaysMeals(userId);
    }

    public void RefreshMeals(int userId)
    {
        this.Meals.Clear();
        var mealsList = _mealRepository.GetByUserId(userId).ToList();

        foreach (var meal in mealsList)
            Meals.Add(meal);
    }

    public void RefreshTodaysMeals(int userId)
    {
        this.TodayMeals.Clear();

        var from = DateTime.Today;
        var to = DateTime.Today.AddDays(1);

        var mealsList = FilterMealsByDateCommand.Filter(_mealRepository.GetByUserId(userId), from, to);

        foreach (var meal in mealsList)
            TodayMeals.Add(meal);
    }
    #endregion
}
