using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Regions;
using netflix.ViewManager.Navigate;

namespace netflix.Login.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
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
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.ProfileSelectionView);
        }
    }
}
