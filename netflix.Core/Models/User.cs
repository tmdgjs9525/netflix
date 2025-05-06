using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace netflix.Core.Models
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        public partial string Name { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<Profile> Profiles { get; set; } = new ();

        public User(string name = "Default")
        {
            Name = name;
        }
    }
}
