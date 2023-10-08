using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModels.Authentication;

public class SignUpViewModel : ViewModelBase
{
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


    public SignUpViewModel(IUserRepository userRepository, IMessenger messenger)
    {
        _userRepository = userRepository;
        _messenger = messenger;
    }

    private CommandBase? signUpCommand;
    public CommandBase SignUpCommand => this.signUpCommand ??= new CommandBase(
            execute: () => {
                this.ErrorMessage = string.Empty;

                if (!InputValidation())
                {
                    this.ErrorMessage += "Invalid credentials!";
                    return;
                }
            },
            canExecute: () => true);

    public bool InputValidation()
    {
        bool isInvalidUserName = string.IsNullOrWhiteSpace(UsernameInput) || UsernameInput.Length > 100;
        bool isInvalidPassword = string.IsNullOrWhiteSpace(PasswordInput) || PasswordInput.Length > 100;

        return !(isInvalidUserName || isInvalidPassword);
    }
}
