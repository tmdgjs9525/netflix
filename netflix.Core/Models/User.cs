using CommunityToolkit.Mvvm.ComponentModel;

namespace netflix.Core.Models
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        public partial string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }
}
