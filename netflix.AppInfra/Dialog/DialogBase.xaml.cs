using System;
using System.Windows;
using System.Windows.Controls;

namespace netflix.Dialog
{
    /// <summary>
    /// DialogBase.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DialogBase : ChildWindow
    {
        public DialogBase()
        {
            InitializeComponent();
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button closeButton = (Button)GetTemplateChild("CloseButton");
            FrameworkElement chrome = (FrameworkElement)GetTemplateChild("Chrome");

            closeButton.Visibility = Visibility.Collapsed;
            chrome.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Control content = dialogContent.Content as Control ?? throw new ArgumentNullException("ContentControls Content is not UserControl. should be UserControl");

            Width = content.Width;
            Height = content.Height;

            Opacity = 1;
        }
    }
}
