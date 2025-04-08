using CommunityToolkit.Mvvm.Input;
using netflix.Dialog;
using netflix.Parameter;
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
            
        }
    }
}
