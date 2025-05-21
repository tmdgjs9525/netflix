using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.Regions;
using netflix.Data.Interfaces;
using netflix.Data.Services;
using netflix.Helper;
using netflix.Login.ViewModels;
using netflix.Login.Views;
using netflix.Login.Views.Dialogs;
using netflix.Main.ViewModels;
using netflix.Main.ViewModels.Dialogs;
using netflix.Main.Views;
using netflix.Main.Views.Dialogs;
using netflix.Setting.ViewModels;
using netflix.ViewManager.Extensions;
using netflix.Setting.Views;
using netflix.ViewManager.Navigate;
using netflix.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Security;
using netflix.Login.Module;
using netflix.Main.Module;
using netflix.Setting.Module;

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

            var mainPage = provider.GetRequiredService<MainPage>();
            mainPage.DataContext = provider.GetRequiredService<MainPageViewModel>();

            Window.Current.Content = mainPage;

            Startup += App_Startup;
        }

        private async void App_Startup(object sender, StartupEventArgs e)
        {
            await LoadFonts();

            var user = Ioc.Default.GetRequiredService<User>();

            user.Profiles = await Ioc.Default.GetRequiredService<IUserService>().GetProfilesByUser(user);

            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.LoginView);
        }

        private IServiceProvider ServiceInitialize()
        {
            IServiceCollection services = new ServiceCollection();

            IServiceProvider provider = services.ConfigureViews()
                                                .ConfigureLoginViews()
                                                .ConfigureMainViews()
                                                .ConfigureSettingViews()
                                                .ConfigureServices()
                                                .ConfigureUser()
                                                .BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);

            return provider;
        }

        //App.xaml 리소스에 폰트를 등록하게 되면 페이지 로드후에 폰트가 적용되기 때문에 
        //미리 폰트를 로드합니다.
        private static async Task LoadFonts()
        {
            await FontHelper.LoadFont("/netflix;component/Assets/Fonts/GmarketSansTTFMedium.ttf#G마켓 산스 TTF Medium", fontName: "MainFont");
        }
    }


    internal static class Configure
    {
        public static IServiceCollection ConfigureViews(this IServiceCollection services)
        {
            services.AddNavigationService();
            services.AddDialogService();

            services.AddSingleton<MainPage>();
            services.AddSingleton<MainPageViewModel>();


            return services;
        }

        public static IServiceCollection ConfigureUser(this IServiceCollection services)
        {
            User loggedInUser = new User(name: "Me");
            services.AddSingleton<User>(loggedInUser);

            Profile profile = new Profile(name: "Profile1", imagePath: "/netflix;component/Assets/Images/profile1.png");
            services.AddSingleton<Profile>(profile);

            services.AddSingleton<AppState>(new AppState(loggedInUser));
            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserStubService>();
            services.AddTransient<IMediaInfoService, MediaInfoStubService>();

            return services;
        }
    }
}
