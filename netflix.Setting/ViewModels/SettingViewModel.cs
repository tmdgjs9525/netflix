using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.ParameterNames;
using netflix.Core.Regions;
using netflix.Navigate;
using netflix.Parameter;

namespace netflix.Setting.ViewModels
{
    public partial class SettingViewModel : ViewModelBase, INavigateAware
    {
        private readonly INavigationService _navigationService;
        private readonly AppState _appState;

        [ObservableProperty]
        public partial Profile CurrentProfile { get; set; }

        public SettingViewModel(INavigationService navigationService,AppState appState)
        {
            _appState = appState;
            _navigationService = navigationService;

            CurrentProfile = _appState.CurrentProfile;
        }

        [RelayCommand]
        private void GoHome()
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);
        }

        public void NavigateTo(Parameters parameters)
        {
            if (parameters.ContainsKey(ParameterNames.Profile))
            {
                CurrentProfile = parameters.GetValue<Profile>(ParameterNames.Profile);
            }
        }
    }
}
