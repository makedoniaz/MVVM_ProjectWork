using FitnessApp.Models;
using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels.Pages;

public class HomeViewModel : ViewModelBase
{
    #region Fields
    UserInfo userInfo { get; set; }

    public double CaloriesToConsume { get; set; }

    public double CaloriesConsumed { get; set; }

    public double CaloriesResult { get; set; }
    #endregion

    public HomeViewModel() {

        // TEST
        userInfo = new UserInfo() { 
            CaloriesToConsume = 3000, User = new User() { 
                Username = "123",
                Password = "123"
            }
        };
        // TEST

        CaloriesToConsume = userInfo.CaloriesToConsume;
        CaloriesResult = CaloriesToConsume - CaloriesConsumed;
    }

}
