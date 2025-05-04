using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.Regions;
using netflix.Navigate;
using System.Collections.ObjectModel;

namespace netflix.Login.ViewModels
{
    public partial class ProfileSelectionViewModel : ViewModelBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        private Profile _currentProfile;
        #endregion


        [ObservableProperty]
        public partial ObservableCollection<Profile> Profiles { get; set; }

        public ProfileSelectionViewModel(INavigationService navigationService, Profile profile)
        {
            _currentProfile = profile;
            _navigationService = navigationService;

            Profiles = new ObservableCollection<Profile>
            {
                new Profile("Profile 1", "/netflix;component/Assets/Images/profile1.png"),
                new Profile("Profile 2", "/netflix;component/Assets/Images/profile1.png"),
                new Profile("Profile 3", "/netflix;component/Assets/Images/profile1.png"),
                new Profile("Profile 4", "/netflix;component/Assets/Images/profile1.png"),
            };

        }

        [RelayCommand]
        private void SelectProfile(Profile selectedProfile)
        {
            _currentProfile = selectedProfile;
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);

            //_navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView, new Parameter.Parameters()
            //{
            //    { ParameterNames.Profile, selectedProfile },
            //});
        }
    }
}
