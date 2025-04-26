using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.ParameterNames;
using netflix.Core.Regions;
using netflix.Dialog;
using netflix.Parameter;
using System.Collections.ObjectModel;

namespace netflix.ViewModels
{
    public partial class MainContentViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        [ObservableProperty]
        public partial MediaInfo RecommendedItem { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<RecommendationList>? RecommendationList { get; set; }


        [ObservableProperty]
        public partial RecommendationList Test { get; set; }

        public MainContentViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            RecommendedItem = new MediaInfo
            {
                PosterUrl = "https://occ-0-4960-993.1.nflxso.net/dnm/api/v6/6AYY37jfdO6hpXcMjf9Yu5cnmO0/AAAABTtqEr23wkU_fY69qASaHlwsopBiJnEWX0kZJs1SPUljgU7dXT_wj_RUm9gTSbwhXB4wNcNm7ZYteEIxssmgXWQjIZC8qOvlAXXT.webp?r=6e4",
                Description = "닥터 홈즈",
            };

            Test = new RecommendationList
            {

                RecommendationListName = "User를 위한 콘텐츠",
                RecommendList = GetVideoInfos()
            };
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

        private static ObservableCollection<MediaInfo> GetVideoInfos()
        {
            var list = new ObservableCollection<MediaInfo>();

            for (int i = 0; i < 2; i++)
            {
                list.Add(new MediaInfo
                {
                    PosterUrl = "https://occ-0-4960-993.1.nflxso.net/dnm/api/v6/Qs00mKCpRvrkl3HZAN5KwEL1kpE/AAAABQQPgp0enivys4Kys7bdtv9EhBTui3ZSHqRheO1PRKTPalv5LWiyIOxzWBCakweVYXPj_cdOJnhvx4CW-QO_I0_eSeuwaokkM0gWTPt5IecUmLNHxGRFc0CXIi0ui3X8s13VNo902l__cbDgZqneJZeyTVkEtwN07h_mP-0sjfOc3jr94vjq9nDrN6eQb4h3k5fx7nyzzo7PCF7ZVyUBw-Y9xJeEDgjs7B9J2_ZiV3WxeOgfg12W1_04GHbdW0MdJRUKQ8JzveJp8lZb7B10PDt_a7BNntY60QLyPjlxesoP0wIgDTMk0x3ABLkF3V2eanIfL9qazmMHBrUNF1-w6YMELfJKpBy8uCaMHRGhRPZIOqSoVty1_3ZQRS67tgX1tb5r1DYeEePhgwxNNX8fKQULQHyb-sYeMHwOV9tirEc8LDtLa6TDMrA34T_21tr4T1J2lyKDfesi0c-Rvu-GQvjLqA1v8wnBP67jQOmwsEgbPVd3AYYRAnFfFZpr9gqweWg.webp?r=edb",
                    LastWatchedEpisode = new Episode()
                    {
                        Season = 1,
                        EpisodeNumber = 1,
                        Title = "첫화",
                    }
                });
                list.Add(new MediaInfo
                {
                    PosterUrl = "https://occ-0-4960-993.1.nflxso.net/dnm/api/v6/Qs00mKCpRvrkl3HZAN5KwEL1kpE/AAAABZtMQgEddAKxtEMt7Iq1kslEbbrGGvExUlgbZ5e8VBVv_yfW1csTEkRCqSsyaRdp15HOOP-cwvZoeQ3xS-UtDcawEfK7YlK8qdj-lv2vUMEV_0YI_a-knGDYQHpvC_Fsl4wIocPi6tmyKSEzhFzIWuGMy8eWsb8v-fzImFs0W3lgxhUuAH-T7Uk08LPPryI.jpg?r=298",
                    LastWatchedEpisode = new Episode()
                    {
                        Season = 1,
                        EpisodeNumber = 1,
                        Title = "첫화",
                    }
                });
                list.Add(new MediaInfo
                {
                    PosterUrl = "https://occ-0-4960-993.1.nflxso.net/dnm/api/v6/Qs00mKCpRvrkl3HZAN5KwEL1kpE/AAAABSdbYn6Mxlo0kKzddB4v3iBYW1oRxI7Ic-yFDFofgP4fYzimqorlW5dU-nLcJpAgVvX4EXJJAFZEtLhRlwOnRPEhNtmGEodCSgc.webp?r=699",
                    LastWatchedEpisode = new Episode()
                    {
                        Season = 1,
                        EpisodeNumber = 1,
                        Title = "첫화", 
                    }
                });
            }

            return list;
        }
    }
}
