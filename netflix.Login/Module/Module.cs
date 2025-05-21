using Microsoft.Extensions.DependencyInjection;
using netflix.Login.ViewModels;
using netflix.Login.Views;
using netflix.Login.Views.Dialogs;
using netflix.ViewManager.Extensions;

namespace netflix.Login.Module
{
    public static class Module
    {
        public static IServiceCollection ConfigureLoginViews(this IServiceCollection services)
        {
            services.AddTransientNavigation<LoginView, LoginViewModel>();
            services.AddTransientNavigation<ProfileSelectionView, ProfileSelectionViewModel>();
            services.AddTransientDialog<AddProfileDialogView, AddProfileDialogViewModel>();

            return services;
        }
    }
}
