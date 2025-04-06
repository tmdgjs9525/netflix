using netflix.Core;
using netflix.Navigate;
using System;

namespace netflix.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        #endregion

        #region properties

        #endregion
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Console.WriteLine("mv");

            // _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.LoginView);
        }

        #region Commands

        #endregion
    }
}
