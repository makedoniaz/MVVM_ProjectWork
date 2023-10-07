using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels;

public class HomeViewModel : ViewModelBase
{
    #region Fields
    public double CaloriesToConsume { get; set; }

    public double CaloriesConsumed { get; set; }

    public double CaloriesResult { get; set; }
    #endregion

    public HomeViewModel() {
        CaloriesResult = CaloriesToConsume - CaloriesConsumed;
    }

}
