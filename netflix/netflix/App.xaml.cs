using Another.Wpf.Container.Extensions;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using netflix.Core.Regions;
using netflix.Extensions;
using netflix.Helper;
using netflix.Login.ViewModels;
using netflix.Login.Views;
using netflix.Main.ViewModels;
using netflix.Main.ViewModels.Dialogs;
using netflix.Main.Views;
using netflix.Main.Views.Dialogs;
using netflix.Navigate;
using netflix.ViewModels;
using System;
using System.Threading.Tasks;
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

        private async void App_Startup(object sender, StartupEventArgs e)
        {
            //await LoadFonts();

            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.LoginView);
        }

        private IServiceProvider ServiceInitialize()
        {
            ServiceCollection services = new ServiceCollection();

            IServiceProvider provider = Configure.ConfigureService(services);

            Ioc.Default.ConfigureServices(provider);

            return provider;
        }

        //App.xaml 리소스에 폰트를 등록하게 되면 페이지 로드후에 폰트가 적용되기 때문에 
        //미리 폰트를 로드합니다.
        private static async Task LoadFonts()
        {
            await FontHelper.LoadFont("/netflix;component/Assets/Fonts/GmarketSansTTFMedium.ttf#G마켓 산스 TTF Medium", "MainFont");
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

            services.AddTransientNavigation<BookMarkedView , BookMarkedViewModel>();
            services.AddTransientNavigation<MoviePlayerView, MoviePlayerViewModel>();

            services.AddSingletonDialog<DetailMediaInfoDialogView, DetailMediaInfoDialogViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
