using FitnessApp.Models;

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
