using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Authentication;
using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels.Authentication;

public class SignUpViewModel : ViewModelBase
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
    public SignUpViewModel(IUserRepository userRepository, IMessenger messenger)
    {
        _userRepository = userRepository;
        _messenger = messenger;
    }
    #endregion


    #region Command
    private CommandBase? signUpCommand;
    public CommandBase SignUpCommand => this.signUpCommand ??= new CommandBase(
            execute: () => {
                this.ErrorMessage = string.Empty;

                if (!ValidationCommand.Validate(UsernameInput, PasswordInput))
                {
                    this.ErrorMessage += "Invalid credentials!";
                    return;
                }
            },
            canExecute: () => true);
    #endregion
}
