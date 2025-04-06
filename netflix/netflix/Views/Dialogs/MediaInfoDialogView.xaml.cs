using System.Windows;
using System.Windows.Controls;

namespace netflix.Views.Dialogs
{
    public partial class MediaInfoDialogView : ChildWindow
    {
        public MediaInfoDialogView()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

