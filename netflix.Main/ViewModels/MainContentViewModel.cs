using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.ParameterNames;
using netflix.Core.Regions;
using netflix.Data.Services;
using netflix.Dialog;
using netflix.ViewManager.Navigate;
using netflix.ViewManager.Parameter;
using System.Collections.ObjectModel;

namespace netflix.ViewModels
{
    public partial class MainContentViewModel : ViewModelBase, INavigateAware
    {
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IMediaInfoService _mediaInfoService;

        [ObservableProperty]
        public partial MediaInfo RecommendedItem { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<RecommendationList>? RecommendationList { get; set; } = new ObservableCollection<RecommendationList>();


        [ObservableProperty]
        public partial RecommendationList Test { get; set; } = new RecommendationList();

        public MainContentViewModel(IDialogService dialogService, INavigationService navigationService, IMediaInfoService mediaInfoService)
        {
            _mediaInfoService = mediaInfoService;
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        [RelayCommand]
        private void Play(MediaInfo mediaInfo)
        {
            _navigationService.NavigateTo(RegionNames.MainRegion, ViewNames.MoviePlayerView, new Parameters()
            {
                { ParameterNames.MediaInfo, mediaInfo }
            });
        }

        [RelayCommand]
        private void ShowMediaInfo(MediaInfo item)
        {
            _dialogService.ShowDialog(DialogNames.DetailMediaInfoDialogView, new Parameters()
            {
                { ParameterNames.MediaInfo, item },
                { ParameterNames.MediaInfoList, Test }
            });
        }

        public async void NavigateTo(Parameters parameters)
        {
            RecommendedItem = new MediaInfo
            {
                PosterUrl = "https://occ-0-4960-993.1.nflxso.net/dnm/api/v6/6AYY37jfdO6hpXcMjf9Yu5cnmO0/AAAABTtqEr23wkU_fY69qASaHlwsopBiJnEWX0kZJs1SPUljgU7dXT_wj_RUm9gTSbwhXB4wNcNm7ZYteEIxssmgXWQjIZC8qOvlAXXT.webp?r=6e4",
                Description = "닥터 홈즈",
            };

            Test = new RecommendationList
            {
                RecommendationListName = "User를 위한 콘텐츠",
                RecommendList = await _mediaInfoService.GetMediaInfosAsync()
            };
        }
    }
}
