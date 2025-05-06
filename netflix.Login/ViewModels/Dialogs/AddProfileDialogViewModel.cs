using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.ParameterNames;
using netflix.Core.Regions;
using netflix.Dialog;
using netflix.Navigate;
using netflix.Parameter;
using System;

namespace netflix.Login.ViewModels
{
    public partial class AddProfileDialogViewModel : ViewModelBase, IDialogAware
    {
        #region fields
        private readonly INavigationService _navigationService;
        public string Title { get; set; } = "Add Profile";

        public event Action<IDialogResult?>? RequestClose;
        #endregion

        [ObservableProperty]
        public partial Profile Profile { get; set; } = new ();

        public AddProfileDialogViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(Parameters parameters)
        {
            
        }

        [RelayCommand]
        private void Save()
        {
            RequestClose?.Invoke(new DialogResult(parameters: new Parameters()
            {
                { ParameterNames.Profile, Profile }
            }));
        }
    }
}
