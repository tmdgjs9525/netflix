using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Regions;
using netflix.Navigate;

namespace netflix.Main.ViewModels
{
    public partial class MoviePlayerViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MoviePlayerViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void GoHome()
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);
        }

    }
}
