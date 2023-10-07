using System.Windows;
using SimpleInjector;
using FitnessApp.ViewModels.Base;
using FitnessApp.ViewModels.Authentication;
using FitnessApp.ViewModels.Pages;
using FitnessApp.Views.Authentication;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Repositories;
using FitnessApp.Mediator.Interfaces;
using FitnessApp.Mediator;
using FitnessApp.Messages;

namespace FitnessApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private Messenger messenger = new Messenger();

    public static Container Container { get; set; } = new Container();

    private Window mainWindow = new AuthenticationWindow();

    protected override void OnStartup(StartupEventArgs e)
    {
        this.RegisterContainer();
        this.Start<AuthenticationChoiceViewModel>();

        this.messenger.Subscribe<ChangeToMainWindowMessage>((message) =>
        {
            if (message is ChangeToMainWindowMessage navigationMessage)
            {
                this.mainWindow.Close();
                this.mainWindow = new MainWindow();

                var mainViewModel = Container.GetInstance<MainViewModel>();
                mainViewModel.ActiveViewModel = Container.GetInstance<HomeViewModel>();
                this.mainWindow.DataContext = mainViewModel;

                this.mainWindow.ShowDialog();
            }
        });

        base.OnStartup(e);
    }

    private void Start<T>() where T : ViewModelBase
    {
        var mainViewModel = Container.GetInstance<AuthenticationViewModel>();
        mainViewModel.ActiveViewModel = Container.GetInstance<T>();

        this.mainWindow.DataContext = mainViewModel;
        this.mainWindow.ShowDialog();
    }

    private void RegisterContainer()
    {
        Container.RegisterSingleton<IUserRepository, UserDapperRepository>();
        Container.RegisterSingleton<IMessenger, Messenger>();

        Container.RegisterSingleton<AuthenticationViewModel>();
        Container.RegisterSingleton<AuthenticationChoiceViewModel>();

        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<HomeViewModel>();
        Container.RegisterSingleton<UserInfoViewModel>();


        Container.Verify();
    }
}
