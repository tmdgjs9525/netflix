using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace netflix.Support.Themes.UI
{
    public class GradientHoverButton : Button
    {
        Storyboard? mouseEnterStoryBoard;
        Storyboard? mouseLeaveStoryBoard;

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(GradientHoverButton), new PropertyMetadata(new CornerRadius(6)));

        public Color HoverBackground
        {
            get { return (Color)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HoverBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register("HoverBackground", typeof(Color), typeof(GradientHoverButton), new PropertyMetadata(null));
        public GradientHoverButton()
        {
            DefaultStyleKey = typeof(GradientHoverButton);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SetStoryboard();

            MouseEnter += HoverEffectButton_MouseEnter;
            MouseLeave += HoverEffectButton_MouseLeave;
        }

        private void HoverEffectButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseLeaveStoryBoard?.Begin();
        }

        private void HoverEffectButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseEnterStoryBoard?.Begin();
        }

        private void SetStoryboard()
        {
            if (Background == null)
            {
                Background = new SolidColorBrush(Colors.LightGray);
            }

            var backgroundBrush = (SolidColorBrush)Background;
            var originalColor = backgroundBrush.Color;

            // 마우스 오버 애니메이션
            ColorAnimation mouseOverAnimation = new ColorAnimation
            {
                Duration = TimeSpan.FromMilliseconds(200),
                To = HoverBackground
            };

            mouseEnterStoryBoard = new Storyboard();
            Storyboard.SetTarget(mouseOverAnimation, backgroundBrush);
            Storyboard.SetTargetProperty(mouseOverAnimation, new PropertyPath("(SolidColorBrush.Color)"));
            mouseEnterStoryBoard.Children.Add(mouseOverAnimation);

            // 마우스 나갈 때 애니메이션
            ColorAnimation mouseLeaveAnimation = new ColorAnimation
            {
                Duration = TimeSpan.FromMilliseconds(200),
                To = originalColor
            };

            mouseLeaveStoryBoard = new Storyboard();
            Storyboard.SetTarget(mouseLeaveAnimation, backgroundBrush);
            Storyboard.SetTargetProperty(mouseLeaveAnimation, new PropertyPath("(SolidColorBrush.Color)"));
            mouseLeaveStoryBoard.Children.Add(mouseLeaveAnimation);
        }
    }
}
