using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.Regions;
using netflix.Navigate;
using System.Collections.ObjectModel;

namespace netflix.Main.ViewModels
{
    public partial class b : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private bool _isSelected;
    }
    public partial class a : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private bool _isSelected;

        partial void OnIsSelectedChanged(bool value)
        {

        }

        [ObservableProperty]
        private ObservableCollection<b> _bs = new();
    }

    public partial class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        public partial User LoggedInUser { get; set; }

        [ObservableProperty]
        private ObservableCollection<a> _as = new();

        [ObservableProperty]
        private a _a;

        [ObservableProperty]
        private b _b;

        public MainViewModel(INavigationService navigationService, User loggedInUser)
        {
            LoggedInUser = loggedInUser;

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
