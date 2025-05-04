using Microsoft.Extensions.DependencyInjection;
using netflix.AppInfra;
using netflix.Navigate;
using System.Windows.Controls;

namespace Another.Wpf.Container.Extensions
{
    public static class NavigationServiceExtensions
    {
        private static INavigationRegister _navigationRegister = null!;
        public static IServiceCollection AddNavigationService(this IServiceCollection services)
        {
            NavigationService navigationService = new NavigationService();

            // NavigationService를 싱글톤으로 등록
            services.AddSingleton<INavigationService>(navigationService);

            // 인터페이스들도 같은 인스턴스로 등록
            services.AddSingleton<INavigationService>(navigationService);
            services.AddSingleton<INavigationRegister>(navigationService);
            services.AddSingleton<IRegionRegister>(navigationService);

            _navigationRegister = navigationService;

            return services;
        }

        // View와 ViewModel을 Transient로 등록하는 확장 메서드
        public static IServiceCollection AddTransientNavigation<TView, TViewModel>(this IServiceCollection services)
            where TView : Control
            where TViewModel : class, IViewModelBase
        {
            services.AddTransient<TView>();
            services.AddTransient<TViewModel>();

            _navigationRegister.AddTransientNavigation<TView, TViewModel>();

            return services;
        }

        // View와 ViewModel을 Singleton으로 등록하는 확장 메서드
        public static IServiceCollection AddSingletonNavigation<TView, TViewModel>(this IServiceCollection services)
            where TView : Control
            where TViewModel : class, IViewModelBase
        {
            services.AddSingleton<TView>();
            services.AddTransient<TViewModel>();

            _navigationRegister.AddSingletonNavigation<TView, TViewModel>();

            return services;
        }

        // 인터페이스를 통해 View와 ViewModel을 Singleton으로 등록하는 확장 메서드
        public static IServiceCollection AddSingletonNavigation<TInterface, TImplementationView, TViewModel>(this IServiceCollection services)
            where TInterface : class
            where TImplementationView : Control, TInterface
            where TViewModel : class, IViewModelBase
        {
            services.AddSingleton<TInterface, TImplementationView>();
            services.AddSingleton<TViewModel>();

            _navigationRegister.AddSingletonNavigation<TInterface, TImplementationView, TViewModel>();

            return services;
        }

        // 인터페이스를 통해 View와 ViewModel을 Transient로 등록하는 확장 메서드
        public static IServiceCollection AddTransientNavigation<TInterface, TImplementationView, TViewModel>(this IServiceCollection services)
            where TInterface : class
            where TImplementationView : Control, TInterface
            where TViewModel : class, IViewModelBase
        {
            services.AddTransient<TInterface, TImplementationView>();
            services.AddTransient<TViewModel>();

            _navigationRegister.AddTransientNavigation<TInterface, TImplementationView, TViewModel>();

            return services;
        }
    }
}
