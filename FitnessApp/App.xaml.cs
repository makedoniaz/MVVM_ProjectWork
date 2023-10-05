using FitnessApp.ViewModels.Base;
using FitnessApp.ViewModels;
using System.Windows;
using SimpleInjector;

namespace FitnessApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static Container Container { get; set; } = new Container();

    protected override void OnStartup(StartupEventArgs e)
    {
        this.RegisterContainer();
        this.Start<HomeViewModel>();

        base.OnStartup(e);
    }

    private void Start<T>() where T : ViewModelBase
    {
        var mainView = new MainWindow();
        var mainViewModel = Container.GetInstance<MainViewModel>();
        mainViewModel.ActiveViewModel = Container.GetInstance<T>();

        mainView.DataContext = mainViewModel;

        mainView.ShowDialog();
    }

    private void RegisterContainer()
    {
        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<HomeViewModel>();
        Container.RegisterSingleton<UserInfoViewModel>();
        Container.Verify();
    }
}
