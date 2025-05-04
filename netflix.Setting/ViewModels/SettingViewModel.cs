using CommunityToolkit.Mvvm.ComponentModel;
using netflix.Core;
using netflix.Core.Models;
using netflix.Core.ParameterNames;
using netflix.Navigate;
using netflix.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Setting.ViewModels
{
    public partial class SettingViewModel : ViewModelBase, INavigateAware
    {
        [ObservableProperty]
        public partial Profile CurrentProfile { get; set; }

        public SettingViewModel()
        {
            
        }

        public void NavigateTo(Parameters parameters)
        {
            if (parameters.ContainsKey(ParameterNames.Profile))
            {
                CurrentProfile = parameters.GetValue<Profile>(ParameterNames.Profile);
            }
        }
    }
}
