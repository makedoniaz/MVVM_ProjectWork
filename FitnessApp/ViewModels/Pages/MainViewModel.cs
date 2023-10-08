using System;
using System.Windows;
using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels.Pages;

public class MainViewModel : ViewModelBase
{
    #region Fields
    private readonly IMessenger _messenger;

    private ViewModelBase activeViewModel;
    public ViewModelBase ActiveViewModel
    {
        get => activeViewModel;
        set => base.PropertyChangeMethod(out activeViewModel, value);
    }


    private bool isAuthenticated;
    public bool IsAuthenticated
    {
        get => isAuthenticated;
        set => base.PropertyChangeMethod(out isAuthenticated, value);
    }
    #endregion

    #region Commands
    private CommandBase? homeCommand;
    public CommandBase HomeCommand => this.homeCommand ??= new CommandBase(
            execute: () => {
                this.ActiveViewModel = App.Container.GetInstance<HomeViewModel>();
            },
            canExecute: () => true);


    private CommandBase? caloriesCommand;
    public CommandBase CaloriesCommand => this.caloriesCommand ??= new CommandBase(
            execute: () => {
                this.ActiveViewModel = App.Container.GetInstance<CaloriesViewModel>();
            },
            canExecute: () => true);


    private CommandBase? mealsCommand;
    public CommandBase MealsCommand => this.mealsCommand ??= new CommandBase(
            execute: () => {
                this.ActiveViewModel = App.Container.GetInstance<MealsViewModel>();
            },
            canExecute: () => true);


    private CommandBase? goalsCommand;
    public CommandBase GoalsCommand => this.goalsCommand ??= new CommandBase(
            execute: () => {
                this.ActiveViewModel = App.Container.GetInstance<GoalsViewModel>();
            },
            canExecute: () => true);


    private CommandBase? userInfoCommand;
    public CommandBase UserInfoCommand => this.userInfoCommand ??= new CommandBase(
            execute: () => {
                this.ActiveViewModel = App.Container.GetInstance<UserInfoViewModel>();
            },
            canExecute: () => true);

    #endregion

    public MainViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        this.isAuthenticated = false;

        _messenger.Subscribe<NavigationMessage>((message) =>
        {
            if (message is NavigationMessage navigationMessage)
            {
                this.ActiveViewModel = navigationMessage.DestinationViewModel;
            }
        });

        _messenger.Subscribe<AuthenticationMessage>((message) =>
        {
            if (message is AuthenticationMessage authenticationMessage)
            {
                this.IsAuthenticated = authenticationMessage.isAuthenticated;
            }
        });
    }
}
