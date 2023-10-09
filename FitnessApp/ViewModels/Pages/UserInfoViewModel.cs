using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels.Pages;

public class UserInfoViewModel : ViewModelBase
{
    #region Fields
    private readonly IMessenger _messenger;
    private readonly IUserInfoRepository _userInfoRepository;


    public string? username;
    public string? Username
    {
        get => username;
        set => base.PropertyChangeMethod(out username, value);
    }

    public double? currentWeight;
    public double? CurrentWeight
    {
        get => currentWeight;
        set => base.PropertyChangeMethod(out currentWeight, value);
    }

    public double? targetWeight;
    public double? TargetWeight
    {
        get => targetWeight;
        set => base.PropertyChangeMethod(out targetWeight, value);
    }
    #endregion

    #region Constructor
    public UserInfoViewModel(IMessenger messenger, IUserInfoRepository userInfoRepository)
    {
        _messenger = messenger;
        _userInfoRepository = userInfoRepository;
    }
    #endregion

    #region Commands
    private CommandBase? editCommand;
    public CommandBase EditCommand => this.editCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<EditViewModel>()));
            },
            canExecute: () => true);

    #endregion


    #region Methods
    public override void RefreshViewModel()
    {
        var userId = App.Container.GetInstance<User>().Id;
        var userInfo = _userInfoRepository.GetByUserId(userId);

        this.Username = App.Container.GetInstance<User>().Username;
        this.CurrentWeight = userInfo.CurrentWeight;
        this.TargetWeight = userInfo.TargetWeight;
    }
    #endregion
}
