using Another.Wpf.Container.Extensions;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using netflix.Core.Regions;
using netflix.Extensions;
using netflix.Login.ViewModels;
using netflix.Login.Views;
using netflix.Main.ViewModels;
using netflix.Main.ViewModels.Dialogs;
using netflix.Main.Views;
using netflix.Main.Views.Dialogs;
using netflix.Navigate;
using netflix.ViewModels;
using System;
using System.Windows;

namespace netflix
{
    public sealed partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public App()
        {
            this.InitializeComponent();

            IServiceProvider provider = ServiceInitialize();

            _navigationService = provider.GetRequiredService<INavigationService>();

            var mainView = provider.GetRequiredService<MainPage>();
            mainView.DataContext = provider.GetRequiredService<MainPageViewModel>();

            Window.Current.Content = mainView;

            Startup += App_Startup;

        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.LoginView);
        }

        private IServiceProvider ServiceInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            IServiceProvider provider = Configure.ConfigureService(services);

            Ioc.Default.ConfigureServices(provider);

            return provider;
        }
    }


    internal static class Configure
    {
        public static IServiceProvider ConfigureService(this IServiceCollection services)
        {
            services.AddNavigationService();
            services.AddDialogService();

            services.AddSingleton<MainPage>();
            services.AddSingleton<MainPageViewModel>();

            services.AddSingletonNavigation<LoginView      , LoginViewModel>();
            services.AddSingletonNavigation<MainView       , MainViewModel>();
            services.AddSingletonNavigation<MainContentView, MainContentViewModel>();
            services.AddSingletonNavigation<BookMarkedView , BookMarkedViewModel>();

            services.AddSingletonDialog<DetailMediaInfoDialogView, DetailMediaInfoDialogViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
