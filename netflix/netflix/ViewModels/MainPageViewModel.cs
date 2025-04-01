using netflix.Core;
using netflix.Core.Navigate;
using netflix.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

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
