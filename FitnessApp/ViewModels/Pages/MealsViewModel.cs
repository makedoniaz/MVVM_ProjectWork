using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModels.Pages;

public class MealsViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;

    public MealsViewModel(IMessenger messenger)
    {
        _messenger = messenger;
    }

    private CommandBase? addMealCommand;
    public CommandBase AddMealCommand => this.addMealCommand ??= new CommandBase(
            execute: () => {
                _messenger.Send(new NavigationMessage(App.Container.GetInstance<AddMealViewModel>()));
            },
            canExecute: () => true);
}
