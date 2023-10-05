using FitnessApp.ViewModels.Base;

namespace FitnessApp.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Fields
    private ViewModelBase activeViewModel;

    public ViewModelBase ActiveViewModel
    {
        get => activeViewModel;
        set => base.PropertyChangeMethod(out activeViewModel, value);
    }
    #endregion
}
