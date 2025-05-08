using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using netflix.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Main.ViewModels
{
    public partial class ContentControlViewModel : ViewModelBase
    {
        [ObservableProperty]
        public partial ObservableCollection<Parentab> As { get; set; } = new();

        public ContentControlViewModel()
        {
            for (int i = 0; i < 5; i++)
            {
                As.Add(new a() { IsSelected = true, Name = "aaaaaaaa" });
                As.Add(new b() { IsSelected = true, Name = "bbbbbb" });
            }
        }

        [RelayCommand]
        private void AddA()
        {
            As.Add(new a() { IsSelected = true, Name = "aaaaaaaa" });
        }

        [RelayCommand]
        private void AddB()
        {
            As.Add(new b() { IsSelected = true, Name = "bbbbbb" });
        }
    }

    public partial class Parentab : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private bool _isSelected;
    }
    public partial class b : Parentab
    {

    }

    public partial class a : Parentab
    {

    }
}
