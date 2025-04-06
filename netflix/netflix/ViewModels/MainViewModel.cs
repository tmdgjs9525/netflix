using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Navigate;
using netflix.Regions;

namespace netflix.ViewModels
{
    internal partial class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.MainContentView);
        }

        [RelayCommand]
        private void GoHome()
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);
        }

        [RelayCommand]
        private void GoBookMarked()
        {
            _navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.BookMarkedView);
        }

        
    }
}
