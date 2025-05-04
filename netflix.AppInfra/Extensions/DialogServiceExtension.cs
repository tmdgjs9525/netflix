using Microsoft.Extensions.DependencyInjection;
using netflix.AppInfra;
using netflix.Dialog;
using System.Windows.Controls;

namespace netflix.Extensions
{
    public static class DialogServiceExtensions
    {
        private static IDialogRegister _dialogRegister = null!;

        /// <summary>
        /// DialogService를 서비스 컬렉션에 등록합니다.
        /// </summary>
        /// <param name="services">서비스 컬렉션</param>
        /// <returns>서비스 컬렉션</returns>
        public static IServiceCollection AddDialogService(this IServiceCollection services)
        {
            DialogService dialogService = new DialogService();
            // DialogService를 싱글톤으로 등록
            services.AddSingleton<IDialogService>(dialogService);

            // 인터페이스들도 같은 인스턴스로 등록
            services.AddSingleton<IDialogService>(dialogService);
            services.AddSingleton<IDialogRegister>(dialogService);

            _dialogRegister = dialogService;

            return services;
        }

        /// <summary>
        /// View와 ViewModel을 Transient 다이얼로그로 등록합니다.
        /// </summary>
        /// <typeparam name="TView">다이얼로그 뷰 타입</typeparam>
        /// <typeparam name="TViewModel">다이얼로그 뷰모델 타입</typeparam>
        /// <param name="services">서비스 컬렉션</param>
        /// <param name="dialogRegister">다이얼로그 레지스터</param>
        /// <returns>서비스 컬렉션</returns>
        public static IServiceCollection AddTransientDialog<TView, TViewModel>(this IServiceCollection services)
            where TView : Control
            where TViewModel : class, IViewModelBase, IDialogAware
        {
            services.AddTransient<TView>();
            services.AddTransient<TViewModel>();

            _dialogRegister.AddTransientDialog<TView, TViewModel>();

            return services;
        }

        /// <summary>
        /// View와 ViewModel을 Singleton 다이얼로그로 등록합니다.
        /// </summary>
        /// <typeparam name="TView">다이얼로그 뷰 타입</typeparam>
        /// <typeparam name="TViewModel">다이얼로그 뷰모델 타입</typeparam>
        /// <param name="services">서비스 컬렉션</param>
        /// <param name="dialogRegister">다이얼로그 레지스터</param>
        /// <returns>서비스 컬렉션</returns>
        public static IServiceCollection AddSingletonDialog<TView, TViewModel>(this IServiceCollection services)
            where TView : Control
            where TViewModel : class, IViewModelBase, IDialogAware
        {
            services.AddSingleton<TView>();
            services.AddSingleton<TViewModel>();

            _dialogRegister.AddSingletonDialog<TView, TViewModel>();

            return services;
        }
    }
}