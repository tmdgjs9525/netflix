using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core.Models
{
    public partial class Profile : ObservableObject
    {
        [ObservableProperty]
        public partial string Name { get; set; }

        [ObservableProperty]
        public partial string ImagePath { get; set; }

        public Profile(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;
        }
    }
}
