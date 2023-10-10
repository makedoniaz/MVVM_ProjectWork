using FitnessApp.Mediator.Interfaces;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Pages;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FitnessApp.ViewModels.Pages;

public class HomeViewModel : ViewModelBase
{
    #region Fields
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IMealRepository _mealRepository;
    private readonly IGoalRepository _goalRepository;

    public ObservableCollection<Goal> Goals { get; set; } = new ObservableCollection<Goal>();

    public ObservableCollection<Meal> TodayMeals { get; set; } = new ObservableCollection<Meal>();

    private double caloriesToConsume;
    public double CaloriesToConsume
    {
        get => caloriesToConsume;
        set => base.PropertyChangeMethod(out caloriesToConsume, value);
    }

    private double caloriesConsumed;
    public double CaloriesConsumed
    {
        get => caloriesConsumed;
        set => base.PropertyChangeMethod(out caloriesConsumed, value);
    }

    private double caloriesResult;
    public double CaloriesResult
    {
        get => caloriesResult;
        set => base.PropertyChangeMethod(out caloriesResult, value);
    }
    #endregion


    #region Constructor
    public HomeViewModel(IUserInfoRepository userInfoRepository, IGoalRepository goalRepository, IMealRepository mealRepository)
    {
        _userInfoRepository = userInfoRepository;
        _goalRepository = goalRepository;
        _mealRepository = mealRepository;
    }
    #endregion


    #region Methods
    public override void RefreshViewModel()
    {
        var userId = App.Container.GetInstance<User>().Id;
        RefreshMeals(userId);
        RefreshUserCalorieInfo(userId);
        RefreshAllGoals(userId);
    }

    public void RefreshAllGoals(int userId)
    {
        this.Goals.Clear();
        var goalsList = _goalRepository.GetByUserId(userId).ToList();

        foreach (var goal in goalsList)
            Goals.Add(goal);
    }

    public void RefreshUserCalorieInfo(int userId)
    {
        var userInfo = _userInfoRepository.GetByUserId(userId);
        this.CaloriesToConsume = userInfo.CaloriesToConsume;

        double caloriesSum = 0;

        foreach (var meal in this.TodayMeals)
            caloriesSum += meal.CaloriesAmount;

        this.CaloriesConsumed = caloriesSum;
        this.CaloriesResult = this.CaloriesToConsume - this.CaloriesConsumed;
    }

    public void RefreshMeals(int userId)
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
