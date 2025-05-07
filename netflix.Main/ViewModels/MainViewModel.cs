using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.Regions;
using netflix.Navigate;
using netflix.Parameter;
using System.Collections.ObjectModel;

namespace netflix.Main.ViewModels
{
    public partial class b : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private bool _isSelected;
    }
    public partial class a : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private bool _isSelected;

        partial void OnIsSelectedChanged(bool value)
        {

        }

        [ObservableProperty]
        private ObservableCollection<b> _bs = new();
    }

    public partial class MainViewModel : ViewModelBase, INavigateAware
    {
        private readonly INavigationService _navigationService;
        private readonly AppState _appState;

        [ObservableProperty]
        private ObservableCollection<a> _as = new();

        [ObservableProperty]
        private a _a;

        [ObservableProperty]
        private b _b;

        [ObservableProperty]
        public partial Profile CurrentProfile { get; set; }

        public MainViewModel(INavigationService navigationService, AppState appState)
        {


            A = new a() { IsSelected = true, Name = "aaaaaaaa" };
            B = new b() { IsSelected = true, Name = "bbbbbb" };

            for (int i = 0; i < 10; i++)
            {
                As.Add(new a()
                {
                    Bs = new ObservableCollection<b>()
                    {
                        new b()
                        {
                            Name = "Test"+1,
                        },
                        new b()
                        {
                            Name = "Test"+2,
                        },
                        new b()
                        {
                            Name = "Test"+3,
                        },
                        new b()
                        {
                            Name = "Test"+4,
                        },
                    }
                });
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
