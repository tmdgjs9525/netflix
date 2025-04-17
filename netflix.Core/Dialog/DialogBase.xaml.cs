using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using CommunityToolkit.Mvvm.DependencyInjection;

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

            closeButton.Visibility = Visibility.Collapsed;
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
