using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.ViewModels.Base;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace FitnessApp.ViewModels.Pages;

public class HomeViewModel : ViewModelBase
{
    #region Fields
    private readonly IMessenger _messenger;
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IMealRepository _mealRepository;
    private readonly IGoalRepository _goalRepository;

    public ObservableCollection<Goal> Goals { get; set; } = new ObservableCollection<Goal>();
    public ObservableCollection<Meal> Meals { get; set; } = new ObservableCollection<Meal>();

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
    public HomeViewModel(IMessenger messenger, IUserInfoRepository userInfoRepository, IGoalRepository goalRepository, IMealRepository mealRepository)
    {
        _messenger = messenger;
        _userInfoRepository = userInfoRepository;
        _goalRepository = goalRepository;
        _mealRepository = mealRepository;
    }
    #endregion


    #region Methods
    public override void RefreshViewModel()
    {
        var userId = App.Container.GetInstance<User>().Id;
        RefreshUserCalorieInfo(userId);
        RefreshAllGoals(userId);
        RefreshMeals(userId);
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
        this.CaloriesResult = this.CaloriesToConsume - this.CaloriesConsumed;
    }

    public void RefreshMeals(int userId)
    {
        this.Meals.Clear();

        var mealsList = _mealRepository.GetByUserId(userId).ToList();

        foreach (var meal in mealsList)
            Meals.Add(meal);
    }
    #endregion
}
