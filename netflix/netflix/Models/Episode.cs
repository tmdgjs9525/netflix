using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Models
{
    public partial class Episode : ObservableObject
    {
        [ObservableProperty]
        public partial int Season { get; set; }

        [ObservableProperty]
        public partial int EpisodeNumber { get; set; }

        [ObservableProperty]
        public partial string Title { get; set; } // 에피소드 제목

        [ObservableProperty]
        public partial DateTime AirDate { get; set; } // 방영일

        public override string ToString()
        {
            return $"시즌{Season}: {EpisodeNumber}화 {Title}";
        }
    }
}
