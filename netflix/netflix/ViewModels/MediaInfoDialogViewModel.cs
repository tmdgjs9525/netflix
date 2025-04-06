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

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(Parameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
