using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.ParameterNames;
using netflix.Dialog;
using netflix.Parameter;
using System;
using System.Collections.ObjectModel;

namespace netflix.Main.ViewModels.Dialogs
{
    public partial class DetailMediaInfoDialogViewModel : ViewModelBase, IDialogAware
    {
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<IDialogResult?>? RequestClose;

        [ObservableProperty]
        public partial MediaInfo MediaInfo { get; set; } = null!;

        [ObservableProperty]
        public partial ObservableCollection<MediaInfo> MediaInfoList { get; set; } = null!;

        public DetailMediaInfoDialogViewModel()
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
            if (parameters.ContainsKey(ParameterNames.MediaInfo))
            {
                MediaInfo = parameters.GetValue<MediaInfo>(ParameterNames.MediaInfo);
            }

            if (parameters.ContainsKey(ParameterNames.MediaInfoList))
            {
                var list = parameters.GetValue<RecommendationList>(ParameterNames.MediaInfoList);
                MediaInfoList = list.RecommendList;
            }
        }
    }
}
