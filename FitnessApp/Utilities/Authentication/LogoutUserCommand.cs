using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Utilities.Authentication;

public static class LogoutUserCommand
{
    public static void Logout()
    {
        App.Container.GetInstance<User>().Id = 0;
        App.Container.GetInstance<User>().Username = string.Empty;
        App.Container.GetInstance<User>().Password = string.Empty;
    }
}
