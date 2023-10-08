using FitnessApp.Commands.Base;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Messages;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessApp.ViewModels.Authentication;

public class AuthenticationViewModel : ViewModelBase
{
    private ViewModelBase activeViewModel;
    private IMessenger _messenger;

    public AuthenticationViewModel(IMessenger messenger)
    {
        _messenger = messenger;

        _messenger.Subscribe<NavigationMessage>((message) =>
        {
            if (message is NavigationMessage navigationMessage)
            {
                this.ActiveViewModel = navigationMessage.DestinationViewModel;
            }
        });
    }

    public ViewModelBase ActiveViewModel
    {
        get => activeViewModel;
        set => base.PropertyChangeMethod(out activeViewModel, value);
    }
}
