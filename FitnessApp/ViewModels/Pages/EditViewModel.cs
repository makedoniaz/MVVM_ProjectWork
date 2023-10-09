using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Authentication;
using FitnessApp.Utilities.Pages;
using FitnessApp.ViewModels.Base;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModels.Pages;

public class EditViewModel : ViewModelBase
{
    #region Fields
    private readonly IMessenger _messenger;
    private readonly IUserInfoRepository _userInfoRepository;

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
    public EditViewModel(IMessenger messenger, IUserInfoRepository userInfoRepository)
    {
        _messenger = messenger;
        _userInfoRepository = userInfoRepository;
    }
    #endregion

    #region Commands
    private CommandBase? goBackCommand;
    public CommandBase GoBackCommand => this.goBackCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<UserInfoViewModel>()));
            },
            canExecute: () => true);

    private CommandBase? saveChangesCommand;
    public CommandBase SaveChangesCommand => this.saveChangesCommand ??= new CommandBase(
            execute: () => {
                var userId = App.Container.GetInstance<User>().Id;
                this.ErrorMessage = string.Empty;

                bool isInvalidInput = !UserInfoValidationCommand.ValidateUserInfo(CurrentWeightInput, TargetWeightInput);

                if (isInvalidInput)
                {
                    this.ErrorMessage = "Invalid input!";
                    return;
                }

                var newUserInfo = new UserInfo()
                {
                    CurrentWeight = CurrentWeightInput,
                    TargetWeight = TargetWeightInput,
                };

                _userInfoRepository.Update(newUserInfo, userId);

                _messenger.Send(new NavigationMessage(App.Container.GetInstance<UserInfoViewModel>()));
            },
            canExecute: () => true);
    #endregion


    #region Methods
    public override void RefreshViewModel()
    {
        this.CurrentWeightInput = 0;
        this.TargetWeightInput = 0;
        this.ErrorMessage = string.Empty;
    }
    #endregion
}
