using CommunityToolkit.Mvvm.ComponentModel;
using netflix.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace netflix.Main.ViewModels
{
    public partial class Test : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; }

        [ObservableProperty]
        public partial string Description { get; set; }
    }

    public partial class BookMarkedViewModel : ViewModelBase
    {
        
        [ObservableProperty]
        public partial ObservableCollection<Test> MyList { get; set; } = new ObservableCollection<Test>();


        public BookMarkedViewModel()
        {
            MyList.Add(new Test() { Title = "Title1", Description = "Description1"});
            MyList.Add(new Test() { Title = "Title2", Description = "Description2" });
            MyList.Add(new Test() { Title = "Title3", Description = "Description3" });
            MyList.Add(new Test() { Title = "Title4", Description = "Description4" });
        }
    }
}
