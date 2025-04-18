using netflix.Core.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace netflix.Main.Themes.UI
{
    internal class VideoPreview : Control
    {
        private Border PART_Body = null!;

        public ICommand BodyCommand
        {
            get { return (ICommand)GetValue(BodyCommandProperty); }
            set { SetValue(BodyCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BodyCommandProperty =
            DependencyProperty.Register("BodyCommand", typeof(ICommand), typeof(VideoPreview), new PropertyMetadata(null));

        public static readonly DependencyProperty BodyCommandParameterProperty =
            DependencyProperty.Register(
                "BodyCommandParameter",
                typeof(MediaInfo),
                typeof(VideoPreview),
                new PropertyMetadata(null));

        public MediaInfo BodyCommandParameter
        {
            get { return (MediaInfo)GetValue(BodyCommandParameterProperty); }
            set { SetValue(BodyCommandParameterProperty, value); }
        }

        public VideoPreview()
        {
            DefaultStyleKey = typeof(VideoPreview);
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_Body = (Border)GetTemplateChild("PART_Body");

            PART_Body.MouseLeftButtonUp += PART_Body_MouseLeftButtonUp;
        }

        private void PART_Body_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BodyCommand?.Execute(BodyCommandParameter);
        }
    }
}
