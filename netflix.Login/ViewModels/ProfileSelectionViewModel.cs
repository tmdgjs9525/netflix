using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.Regions;
using netflix.Data.Interfaces;
using netflix.Navigate;
using netflix.Parameter;
using System.Collections.ObjectModel;

namespace netflix.Login.ViewModels
{
    public partial class ProfileSelectionViewModel : ViewModelBase, INavigateAware
    {
        #region fields
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;
        private readonly AppState _appState;
        private Profile _currentProfile;
        #endregion


        [ObservableProperty]
        public partial ObservableCollection<Profile> Profiles { get; set; }

        public ProfileSelectionViewModel(INavigationService navigationService, IUserService userService, AppState appState)
        {
            _userService = userService;
            _navigationService = navigationService;
            _appState = appState;

        }

        [RelayCommand]
        private void SelectProfile(Profile selectedProfile)
        {
            _appState.CurrentProfile = selectedProfile;
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);

            //_navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView, new Parameter.Parameters()
            //{
            //    { ParameterNames.Profile, selectedProfile },
            //});
        }

        public async void NavigateTo(Parameters parameters)
        {
            Profiles = await _userService.GetUserProfilesAsync();
        }
    }
}
