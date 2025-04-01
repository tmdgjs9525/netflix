using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Navigate;
using netflix.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace netflix.ViewModels
{
    internal partial class LoginViewModel : ViewModelBase
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
            Application.Current.Host.NavigationState = "/MainView";
            //_navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);
        }
    }
}
