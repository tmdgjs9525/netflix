using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Navigate;
using netflix.Regions;

namespace netflix.ViewModels
{
    internal partial class LoginViewModel : ViewModelBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        #endregion
        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        [RelayCommand]
        private void Login()
        {
            //App.Navigate(ViewNames.MainView);
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);
        }
    }
}
