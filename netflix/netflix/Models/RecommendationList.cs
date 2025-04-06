using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Models
{
    public partial class RecommendationList : ObservableObject 
    {
        [ObservableProperty]
        public partial string RecommendationListName { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<MideaInfo> RecommendList { get; set; } = new ObservableCollection<MideaInfo>();
    }
}
