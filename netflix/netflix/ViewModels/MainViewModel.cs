using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Navigate;
using netflix.Models;
using netflix.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
