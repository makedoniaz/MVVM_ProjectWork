using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

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

    public ObservableCollection<Goal> Goals { get; set; } = new ObservableCollection<Goal>();
    #endregion


    #region Constructor
    public GoalsViewModel(IMessenger messenger, IGoalRepository goalRepository)
    {
        _messenger = messenger;
        _goalRepository = goalRepository;

        _messenger.Subscribe<SetupGoalsViewModelMessage>((message) =>
        {
            if (message is SetupGoalsViewModelMessage navigationMessage)
            {
                RefreshAllGoals();
            }
        });
    }
    #endregion

    #region Commands

    private CommandBase? postGoalCommand;
    public CommandBase PostGoalCommand => this.postGoalCommand ??= new CommandBase(
            execute: () => {
                _goalRepository.Create(new Goal()
                {
                    Text = goalInputText,
                    UserId = App.Container.GetInstance<User>().Id
                });

                RefreshAllGoals();
            },
            canExecute: () => true);
    #endregion

    #region Methods
    public void RefreshAllGoals()
    {
        this.Goals.Clear();

        var userId = App.Container.GetInstance<User>().Id;
        var goalsList = _goalRepository.GetByUserId(userId).ToList();

        foreach (var goal in goalsList)
            Goals.Add(goal);
    }
    #endregion
}
