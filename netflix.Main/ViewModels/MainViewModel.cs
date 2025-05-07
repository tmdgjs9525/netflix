using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.Regions;
using netflix.ViewManager.Navigate;
using netflix.ViewManager.Parameter;
using System.Collections.ObjectModel;

namespace netflix.Main.ViewModels
{
    public partial class parentab : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private bool _isSelected;
    }
    public partial class b : parentab
    { 

    }

    public partial class a : parentab
    {

    }

    public partial class MainViewModel : ViewModelBase, INavigateAware
    {
        private readonly INavigationService _navigationService;
        private readonly AppState _appState;

        [ObservableProperty]
        private ObservableCollection<parentab> _as = new();


        [ObservableProperty]
        public partial Profile CurrentProfile { get; set; }

        public MainViewModel(INavigationService navigationService, AppState appState)
        {
            for (int i = 0; i < 5; i++)
            {
                As.Add(new a() { IsSelected = true, Name = "aaaaaaaa" });
                As.Add(new b() { IsSelected = true, Name = "bbbbbb" });
            }
           
            _navigationService = navigationService;

            _navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.MainContentView);
            _appState = appState;
            CurrentProfile = _appState.CurrentProfile!;
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

        [RelayCommand]
        private void ProfileSetting()
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.SettingView);
        }

        [RelayCommand]
        private void SelectProFile()
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.ProfileSelectionView);
        }

        [RelayCommand]
        private void Logout()
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.LoginView);
        }

        public void NavigateTo(Parameters parameters)
        {
            //if (parameters.ContainsKey(ParameterNames.Profile))
            //{
            //    CurrentProfile = parameters.GetValue<Profile>(ParameterNames.Profile);
            //}
        }
    }
}
