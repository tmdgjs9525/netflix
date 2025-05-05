using System.Windows.Controls;

namespace netflix.Main.Controls
{
    public partial class TopMenu : UserControl
    {
        public TopMenu()
        {
            this.InitializeComponent();
        }

        private void Profile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProfilePopup.IsOpen = !ProfilePopup.IsOpen;
        }
    }
}
