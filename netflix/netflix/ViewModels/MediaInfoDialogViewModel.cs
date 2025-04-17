using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Dialog;
using netflix.Models;
using netflix.Parameter;
using System;
using System.Collections.ObjectModel;

namespace netflix.ViewModels
{
    public partial class MediaInfoDialogViewModel : ViewModelBase, IDialogAware
    {
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action<IDialogResult?>? RequestClose;

        [ObservableProperty]
        public partial MediaInfo MediaInfo { get; set; } = null!;

        [ObservableProperty]
        public partial ObservableCollection<MediaInfo> MediaInfoList { get; set; } = null!;

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
            if (parameters.ContainsKey(ParameterNames.ParameterNames.MediaInfo))
            {
                MediaInfo = parameters.GetValue<MediaInfo>(ParameterNames.ParameterNames.MediaInfo);
            }

            if (parameters.ContainsKey(ParameterNames.ParameterNames.MediaInfoList))
            {
                var list = parameters.GetValue<RecommendationList>(ParameterNames.ParameterNames.MediaInfoList);
                MediaInfoList = list.RecommendList;
            }
        }
    }
}
