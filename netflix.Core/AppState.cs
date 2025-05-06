using CommunityToolkit.Mvvm.ComponentModel;
using netflix.Core.Models;

namespace netflix.Core
{
    public partial class AppState : ObservableObject
    {
        [ObservableProperty]
        public partial User LoggedInUser { get; set; }

        [ObservableProperty]
        public partial Profile? CurrentProfile { get; set; }

        public AppState(User user)
        {
            LoggedInUser = user;
        }

    }
}
