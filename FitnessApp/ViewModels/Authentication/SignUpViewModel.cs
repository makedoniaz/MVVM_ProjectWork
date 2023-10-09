﻿using System;
using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Authentication;
using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels.Authentication;

public class SignUpViewModel : ViewModelBase
{
    #region Fields
    private readonly IUserRepository _userRepository;
    private readonly IUserInfoRepository _userInfoRepository;
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

    private double currentWeightInput;
    public double CurrentWeightInput
    {
        get => currentWeightInput;
        set => base.PropertyChangeMethod(out currentWeightInput, value);
    }

    private double targetWeightInput;
    public double TargetWeightInput
    {
        get => targetWeightInput;
        set => base.PropertyChangeMethod(out targetWeightInput, value);
    }

    private string? errorMessage;
    public string? ErrorMessage
    {
        get => errorMessage;
        set => base.PropertyChangeMethod(out errorMessage, value);
    }
    #endregion


    #region Constructor
    public SignUpViewModel(IUserRepository userRepository, IMessenger messenger, IUserInfoRepository userInfoRepository)
    {
        _userRepository = userRepository;
        _messenger = messenger;
        _userInfoRepository = userInfoRepository;
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

                int userId = _userRepository.Create(new User()
                {
                    Username = UsernameInput,
                    Password = PasswordInput
                });

                _userInfoRepository.Create(new UserInfo()
                {
                    CurrentWeight = this.CurrentWeightInput,
                    TargetWeight = this.TargetWeightInput,
                    CaloriesToConsume = 3000,
                    UserId = userId
                });

                _messenger.Send(new NavigationMessage(App.Container.GetInstance<AuthenticationChoiceViewModel>()));
            },
            canExecute: () => true);
    #endregion
}
