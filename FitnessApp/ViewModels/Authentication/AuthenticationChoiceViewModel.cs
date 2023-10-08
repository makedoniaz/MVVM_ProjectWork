using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Authentication;
using FitnessApp.Utilities.DatabaseInfo;
using FitnessApp.ViewModels.Base;
using FitnessApp.ViewModels.Pages;
using System.Linq;

namespace FitnessApp.ViewModels.Authentication;

public class AuthenticationChoiceViewModel : ViewModelBase
{
    #region Fields
    private readonly IUserRepository _userRepository;
    private readonly IMessenger _messenger;


    private string? userInput;
    public string? UsernameInput
    {
        get => userInput;
        set => base.PropertyChangeMethod(out userInput, value);
    }

    private string? passwordInput;
    public string? PasswordInput
    {
        get => passwordInput;
        set => base.PropertyChangeMethod(out passwordInput, value);
    }

    private string? errorMessage;
    public string? ErrorMessage
    {
        get => errorMessage;
        set => base.PropertyChangeMethod(out errorMessage, value);
    }
    #endregion


    #region Constructor
    public AuthenticationChoiceViewModel(IUserRepository userRepository, IMessenger messenger) {
        _userRepository = userRepository;
        _messenger = messenger;
    }
    #endregion


    #region Commands
    private CommandBase? loginCommand;
    public CommandBase LoginCommand => this.loginCommand ??= new CommandBase(
            execute: () => {
                this.ErrorMessage = string.Empty;

                if (!ValidationCommand.Validate(UsernameInput, PasswordInput))
                {
                    this.ErrorMessage = "Invalid credentials!";
                    return;
                }

                var user = AuthenticateUser();

                if (user == null)
                {
                    this.ErrorMessage = "Couldn't login in the system!";
                    return;
                }

                App.Container.GetInstance<User>().Username = user.Username;
                App.Container.GetInstance<User>().Password = user.Password;

                _messenger.Send(new AuthenticationMessage(true));
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<HomeViewModel>()));
            },
            canExecute: () => true);


    private CommandBase? signUpCommand;
    public CommandBase SignUpCommand => this.signUpCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<SignUpViewModel>()));
            },
            canExecute: () => true);
    #endregion


    #region Methods
    public User? AuthenticateUser()
    {
        return _userRepository.GetAll().FirstOrDefault(u => u.Username == UsernameInput && u.Password == PasswordInput);
    }
    #endregion
}
