using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using netflix.Core;
using netflix.Core.Navigate;
using netflix.Regions;
using netflix.ViewModels;
using netflix.Views;
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
        public App()
        {
            this.InitializeComponent();

            IServiceProvider provider = serviceInitialize();

            var mainView = provider.GetRequiredService<MainPage>();
            mainView.DataContext = provider.GetRequiredService<MainPageViewModel>();

            Window.Current.Content = mainView;

            Startup += App_Startup;

        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            Application.Current.Host.NavigationStateChanged += Host_NavigationStateChanged;
            Application.Current.Host.NavigationState = "/LoginView";
            Host_NavigationStateChanged(this, new System.Windows.Interop.NavigationStateChangedEventArgs("", "/LoginView"));

        }

        private void Host_NavigationStateChanged(object sender, System.Windows.Interop.NavigationStateChangedEventArgs e)
        {
            Console.WriteLine("ev");

            HandleNavigation(e.NewNavigationState);
        }

        private void HandleNavigation(string newUrl)
        {
            var navigationRegister = Ioc.Default.GetRequiredService<INavigationRegister>();
            var viewDictionary = navigationRegister.GetViewDictionary();

            // URL에서 페이지 이름 추출
            string pageName = newUrl.Trim('/');

            var control = Ioc.Default.GetRequiredService(viewDictionary[pageName].Item1) as UserControl;
            control.DataContext = Ioc.Default.GetRequiredService(viewDictionary[pageName].Item2);

            var rootVisual = Application.Current.RootVisual as Page; 

            // 루트 그리드에 페이지 추가
            if (rootVisual.Content is TransitioningContentControl contentControl)
            {
                contentControl.Content = control;
            }
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

            return services.BuildServiceProvider();
        }
    }
}
