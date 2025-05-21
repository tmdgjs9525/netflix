using Microsoft.Extensions.DependencyInjection;
using netflix.Main.ViewModels;
using netflix.Main.ViewModels.Dialogs;
using netflix.Main.Views;
using netflix.Main.Views.Dialogs;
using netflix.ViewManager.Extensions;
using netflix.ViewModels;

namespace netflix.Main.Module
{
    public static class Module
    {
        public static IServiceCollection ConfigureMainViews(this IServiceCollection services)
        {
            services.AddTransientNavigation<HtmlPresenterView, HtmlPresenterViewModel>();
            services.AddTransientNavigation<AiTestView, AiTestViewModel>();

            services.AddSingletonNavigation<MainView, MainViewModel>();
            services.AddSingletonNavigation<MainContentView, MainContentViewModel>();
            services.AddTransientNavigation<ContentControlView, ContentControlViewModel>();
            services.AddTransientNavigation<BookMarkedView, BookMarkedViewModel>();

            services.AddTransientNavigation<MoviePlayerView, MoviePlayerViewModel>();

            services.AddTransientDialog<DetailMediaInfoDialogView, DetailMediaInfoDialogViewModel>();

            return services;
        }
    }
}
