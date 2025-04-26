using netflix.Core;
using netflix.Navigate;
using System;

namespace netflix.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        #endregion

        #region properties

        #endregion
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #region Commands

        #endregion
    }
}
