using FitnessApp.Commands.Base;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.ViewModels.Base;
using FitnessApp.Views.Authentication;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Windows;

namespace FitnessApp.ViewModels.Authentication;

public class AuthenticationChoiceViewModel : ViewModelBase
{
    #region Fields
    private IUserRepository _userRepository;


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


    private bool? isInvalidInput;
    public bool? IsInvalidInput
    {
        get => isInvalidInput;
        set => base.PropertyChangeMethod(out isInvalidInput, value);
    }

    private string? errorMessage;
    public string? ErrorMessage
    {
        get => errorMessage;
        set => base.PropertyChangeMethod(out errorMessage, value);
    }
    #endregion

    #region Commands
    private CommandBase? loginCommand;
    public CommandBase LoginCommand => this.loginCommand ??= new CommandBase(
            execute: () => {
                var user = AuthenticateUser();

                if (user == null)
                    return;

                Console.WriteLine(user);

                var window = new MainWindow();
                window.ShowDialog();
            },
            canExecute: () => true);
    #endregion


    public AuthenticationChoiceViewModel(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public void InputValidation()
    {
        bool isInvalidUserName;
        bool isInvalidPassword;

        if (isInvalidUserName = string.IsNullOrWhiteSpace(UsernameInput) || UsernameInput.Length > 100)
            this.ErrorMessage += "Invalid username!\n";

        if (isInvalidPassword = string.IsNullOrWhiteSpace(PasswordInput) || PasswordInput.Length > 100)
            this.ErrorMessage += "Invalid password!\n";

        IsInvalidInput = !(isInvalidUserName || isInvalidPassword);
    }

    public User? AuthenticateUser()
    {
        return _userRepository.GetAll().FirstOrDefault(u => u.Username == UsernameInput && u.Password == PasswordInput);
    }
}
