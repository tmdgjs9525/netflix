using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core.Models
{
    public partial class MediaInfo : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        public partial string Title { get; set; } = string.Empty; // 제목

        [ObservableProperty]
        public partial Episode LastWatchedEpisode { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<Episode> Episodes { get; set; }

        [ObservableProperty]
        public partial string Genre { get; set; } = string.Empty; // 장르

        [ObservableProperty]
        public partial string Director { get; set; } = string.Empty; // 감독

        [ObservableProperty]
        public partial string Cast { get; set; } = string.Empty; // 출연진 

        [ObservableProperty]
        public partial DateTime ReleaseDate { get; set; } // 개봉일 / 첫 방영일

        [ObservableProperty]
        public partial int Duration { get; set; } // 러닝타임 (분 단위)

        [ObservableProperty]
        public partial string Description { get; set; } = string.Empty; // 간단한 설명

        [ObservableProperty]
        public partial string PosterUrl { get; set; } = string.Empty; // 포스터 이미지 URL

        [ObservableProperty]
        public partial double Rating { get; set; } // 평점

        [ObservableProperty]
        public partial bool WatchedVideo { get; set; }
    }
}
