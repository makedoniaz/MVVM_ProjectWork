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
using FitnessApp.Messages.Interfaces;
using System;
using FitnessApp.Models;

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
        this.Start<AuthenticationChoiceViewModel>();

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
        Container.RegisterSingleton<IUserRepository, UserDapperRepository>();
        Container.RegisterSingleton<IMessenger, Messenger>();

        Container.RegisterSingleton<AuthenticationViewModel>();
        Container.RegisterSingleton<AuthenticationChoiceViewModel>();
        Container.RegisterSingleton<SignUpViewModel>();

        Container.RegisterSingleton<User>();

        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<HomeViewModel>();
        Container.RegisterSingleton<CaloriesViewModel>();
        Container.RegisterSingleton<MealsViewModel>();
        Container.RegisterSingleton<GoalsViewModel>();
        Container.RegisterSingleton<UserInfoViewModel>();


        Container.Verify();
    }
}
