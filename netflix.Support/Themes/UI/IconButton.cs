using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace netflix.Support.Themes.UI
{
    public class IconButton : Button
    {
        public bool UseText
        {
            get { return (bool)GetValue(UseTextProperty); }
            set { SetValue(UseTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UseText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseTextProperty =
            DependencyProperty.Register("UseText", typeof(bool), typeof(IconButton), new PropertyMetadata(true));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IconButton), new PropertyMetadata(new CornerRadius(6)));



        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(IconButton), new PropertyMetadata(null));



        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(IconButton), new PropertyMetadata(new SolidColorBrush(Colors.Black)));



        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(IconButton), new PropertyMetadata(12.0));



        public IconButton()
        {
            DefaultStyleKey = typeof(IconButton);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }
    }
}
