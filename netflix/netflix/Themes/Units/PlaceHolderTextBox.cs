using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace netflix.Themes.Units
{
    internal class PlaceHolderTextBox : TextBox
    {
        bool isFocused = false;

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PlaceHolderTextBox), new PropertyMetadata(new CornerRadius(0)));

        public Brush PlaceHolderForeground
        {
            get { return (Brush)GetValue(PlaceHolderForegroundProperty); }
            set { SetValue(PlaceHolderForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderForegroundProperty =
            DependencyProperty.Register("PlaceHolderForeground", typeof(Brush), typeof(PlaceHolderTextBox), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));



        public PlaceHolderTextBox()
        {
            DefaultStyleKey = typeof(PlaceHolderTextBox);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            MouseLeave += PlaceHolderTextBox_MouseLeave;
            GotFocus += PlaceHolderTextBox_GotFocus;
            LostFocus += PlaceHolderTextBox_LostFocus;
        }

        private void PlaceHolderTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            isFocused = false;

            if (string.IsNullOrEmpty(Text))
            {
                // 텍스트가 비어 있으면 Unfocused 애니메이션 실행
                VisualStateManager.GoToState(this, "Unfocused", true);
            }
            else
            {
                // 텍스트가 있으면 애니메이션을 건너뛰고 바로 상태를 변경
                VisualStateManager.GoToState(this, "Focused", true);
            }
        }

        private void PlaceHolderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            isFocused = true;
        }

        private void PlaceHolderTextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(Text) && isFocused is false)
            {
                VisualStateManager.GoToState(this, "Unfocused", true);
            }
        }
    }
}
