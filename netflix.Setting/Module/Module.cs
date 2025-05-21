using Microsoft.Extensions.DependencyInjection;
using netflix.Setting.ViewModels;
using netflix.Setting.Views;
using netflix.ViewManager.Extensions;

namespace netflix.Setting.Module
{
    public static class Module
    {
        public static IServiceCollection ConfigureSettingViews(this IServiceCollection services)
        {
            services.AddTransientNavigation<SettingView, SettingViewModel>();

            return services;
        }
    }
}
