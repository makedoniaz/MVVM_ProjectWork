using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.Pages;
using FitnessApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace FitnessApp.ViewModels.Pages;

public class GoalsViewModel : ViewModelBase
{
    #region Fields
    private readonly IMessenger _messenger;
    private readonly IGoalRepository _goalRepository;

    private string goalInputText = string.Empty;
    public string GoalInputText
    {
        get => goalInputText;
        set => base.PropertyChangeMethod(out goalInputText, value);
    }

    private string? errorMessage;
    public string? ErrorMessage
    {
        get => errorMessage;
        set => base.PropertyChangeMethod(out errorMessage, value);
    }

    public ObservableCollection<Goal> Goals { get; set; } = new ObservableCollection<Goal>();
    #endregion


    #region Constructor
    public GoalsViewModel(IMessenger messenger, IGoalRepository goalRepository)
    {
        _messenger = messenger;
        _goalRepository = goalRepository;
    }
    #endregion


    #region Commands
    private CommandBase? postGoalCommand;
    public CommandBase PostGoalCommand => this.postGoalCommand ??= new CommandBase(
            execute: () => {
                if (!GoalInputValidationCommand.ValidateGoalInput(this.GoalInputText))
                {
                    this.ErrorMessage = "Invalid goal input!";
                    return;
                }

                _goalRepository.Create(new Goal()
                {
                    Text = goalInputText,
                    UserId = App.Container.GetInstance<User>().Id
                });

                _messenger.Send(new NavigationMessage(App.Container.GetInstance<GoalsViewModel>()));
            },
            canExecute: () => true);
    #endregion


    #region Methods
    public override void RefreshViewModel()
    {
        this.GoalInputText = string.Empty;
        this.ErrorMessage = string.Empty;
        this.Goals.Clear();

        var userId = App.Container.GetInstance<User>().Id;
        var goalsList = _goalRepository.GetByUserId(userId).ToList();

        foreach (var goal in goalsList)
            Goals.Add(goal);
    }
    #endregion
}
