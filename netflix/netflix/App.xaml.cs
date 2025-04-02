using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using netflix.Core;
using netflix.Core.Navigate;
using netflix.Regions;
using netflix.ViewModels;
using netflix.Views;
using netflix.Views.BookMark;
using netflix.Views.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Interop;

namespace netflix
{
    public sealed partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public App()
        {
            this.InitializeComponent();

            IServiceProvider provider = serviceInitialize();

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

        private IServiceProvider serviceInitialize()
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
            services.AddSingleton<MainPage>();
            services.AddSingleton<MainPageViewModel>();

            Container container = new Container(services);

            container.AddSingletonNavigation<LoginView, LoginViewModel>();
            container.AddSingletonNavigation<MainView, MainViewModel>();
            container.AddSingletonNavigation<MainContentView, MainContentViewModel>();
            container.AddSingletonNavigation<BookMarkedView, BookMarkedViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
