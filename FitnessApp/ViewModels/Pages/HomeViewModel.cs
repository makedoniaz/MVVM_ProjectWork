using FitnessApp.Models;
using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels.Pages;

public class HomeViewModel : ViewModelBase
{
    #region Fields
    public UserInfo? UserInfo { get; set; }

    public double CaloriesToConsume { get; set; }

    public double CaloriesConsumed { get; set; }

    public double CaloriesResult { get; set; }
    #endregion
}
