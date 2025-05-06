using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.ParameterNames;
using netflix.Core.Regions;
using netflix.Data.Interfaces;
using netflix.Dialog;
using netflix.Navigate;
using netflix.Parameter;
using System.Collections.ObjectModel;

namespace netflix.Login.ViewModels
{
    public partial class ProfileSelectionViewModel : ViewModelBase, INavigateAware
    {
        #region fields
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IUserService _userService;
        private readonly AppState _appState;
        #endregion


        [ObservableProperty]
        public partial User CurrentUser { get; set; } = null!;

        public ProfileSelectionViewModel(INavigationService navigationService,IDialogService dialogService ,IUserService userService, AppState appState)
        {
            _userService = userService;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _appState = appState;
        }

        [RelayCommand]
        private void AddProfile()
        {
            _dialogService.ShowDialog(ViewNames.AddProfileDialogView, callback : (callBackValue) =>
            {
                var parameters = callBackValue.Parameters;

                if (parameters.ContainsKey(ParameterNames.Profile))
                {
                    CurrentUser.Profiles.Add(parameters.GetValue<Profile>(ParameterNames.Profile));
                }
            });
        }

        [RelayCommand]
        private void SelectProfile(Profile selectedProfile)
        {
            _appState.CurrentProfile = selectedProfile;
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MainView);
        }

        public void NavigateTo(Parameters parameters)
        {
            CurrentUser = _appState.LoggedInUser;
        }
    }
}
