using FitnessApp.Messages.Interfaces;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Messages;

public class NavigationMessage : IMessage
{
    public readonly ViewModelBase DestinationViewModel;

    public NavigationMessage(ViewModelBase destinationViewModel)
    {
        this.DestinationViewModel = destinationViewModel;
    }
}
