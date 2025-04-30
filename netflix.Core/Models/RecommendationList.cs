using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace netflix.Core.Models
{
    public partial class RecommendationList : ObservableObject
    {
        [ObservableProperty]
        public partial string RecommendationListName { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<MediaInfo> RecommendList { get; set; } = new ObservableCollection<MediaInfo>();
    }
}
