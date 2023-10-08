using FitnessApp.Messages.Interfaces;
using FitnessApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Messages;

public class AuthenticationMessage : IMessage
{
    public readonly bool isAuthenticated;

    public AuthenticationMessage(bool isAuthenticated)
    {
        this.isAuthenticated = isAuthenticated;
    }
}
