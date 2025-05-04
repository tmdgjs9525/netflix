using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using netflix.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Core
{
    public partial class AppState : ObservableObject
    {
        [ObservableProperty]
        public partial User LoggedInUser { get; set; }

        [ObservableProperty]
        public partial Profile CurrentProfile { get; set; }

        public AppState(User user, Profile profile)
        {
            LoggedInUser = user;
            CurrentProfile = profile;
        }
    }
}
