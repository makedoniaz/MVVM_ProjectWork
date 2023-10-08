using FitnessApp.Commands.Base;
using FitnessApp.Mediator;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.ViewModels.Base;
using FitnessApp.Views.Authentication;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
                this.ErrorMessage = string.Empty;

                if (!InputValidation())
                {
                    this.ErrorMessage += "Invalid credentials!";
                    return;
                }

                var user = AuthenticateUser();

                if (user == null)
                {
                    this.ErrorMessage = "Couldn't login in the system!";
                    return;
                }

                //App.Container.RegisterSingleton<User>();

                App.Container.GetInstance<User>().Username = user.Username;
                App.Container.GetInstance<User>().Password = user.Password;


                Console.WriteLine(App.Container.GetInstance<User>());


                // ?? 
            },
            canExecute: () => true);


    private CommandBase? signUpCommand;
    public CommandBase SignUpCommand => this.signUpCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<SignUpViewModel>()));

            },
            canExecute: () => true);
    #endregion


    public AuthenticationChoiceViewModel(IUserRepository userRepository, IMessenger messenger) {
        _userRepository = userRepository;
        _messenger = messenger;
    }

    public bool InputValidation()
    {
        bool isInvalidUserName = string.IsNullOrWhiteSpace(UsernameInput) || UsernameInput.Length > 100;
        bool isInvalidPassword = string.IsNullOrWhiteSpace(PasswordInput) || PasswordInput.Length > 100;

        return !(isInvalidUserName || isInvalidPassword);
    }

    public User? AuthenticateUser()
    {
        return _userRepository.GetAll().FirstOrDefault(u => u.Username == UsernameInput && u.Password == PasswordInput);
    }
}
