using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Utilities.Authentication;
using FitnessApp.ViewModels.Authentication;
using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels.Pages;

public class MainViewModel : ViewModelBase
{
    #region Fields
    private readonly IMessenger _messenger;

    private ViewModelBase? activeViewModel;
    public ViewModelBase? ActiveViewModel
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

    #region Constructor
    public MainViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        this.IsAuthenticated = false;

        _messenger.Subscribe<NavigationMessage>((message) =>
        {
            if (message is NavigationMessage navigationMessage)
            {
                this.ActiveViewModel = navigationMessage.DestinationViewModel;
                this.ActiveViewModel.RefreshViewModel();
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
    #endregion

    #region Commands
    private CommandBase? homeCommand;
    public CommandBase HomeCommand => this.homeCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<HomeViewModel>()));
            },
            canExecute: () => true);

    private CommandBase? mealsCommand;
    public CommandBase MealsCommand => this.mealsCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<MealsViewModel>()));
            },
            canExecute: () => true);


    private CommandBase? goalsCommand;
    public CommandBase GoalsCommand => this.goalsCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<GoalsViewModel>()));
            },
            canExecute: () => true);


    private CommandBase? userInfoCommand;
    public CommandBase UserInfoCommand => this.userInfoCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<UserInfoViewModel>()));
            },
            canExecute: () => true);

    private CommandBase? logoutCommand;
    public CommandBase LogoutCommand => this.logoutCommand ??= new CommandBase(
            execute: () => {
                LogoutUserCommand.Logout();
                _messenger.Send(new AuthenticationMessage(false));
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<AuthenticationChoiceViewModel>()));
            },
            canExecute: () => true);
    #endregion
}
