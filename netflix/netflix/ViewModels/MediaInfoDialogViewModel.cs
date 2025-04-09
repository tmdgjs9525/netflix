using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Dialog;
using netflix.Models;
using netflix.Parameter;
using netflix.ParameterNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ViewModels
{
    public partial class MediaInfoDialogViewModel : ViewModelBase, IDialogAware
    {
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<IDialogResult?>? RequestClose;

        [ObservableProperty]
        public partial MediaInfo MediaInfo { get; set; }

        public MediaInfoDialogViewModel()
        {
            
        }

        [RelayCommand]
        private void Close()
        {
            RequestClose?.Invoke(null);
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
            if (parameters.ContainsKey(ParameterNames.ParameterNames.MedaiInfo))
            {
                MediaInfo = parameters.GetValue<MediaInfo>(ParameterNames.ParameterNames.MedaiInfo);
            }
        }
    }
}
