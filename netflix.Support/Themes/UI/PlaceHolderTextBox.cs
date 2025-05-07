using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace netflix.Support.Themes.UI
{
    public class PlaceHolderTextBox : TextBox
    {
        //bool isFocused = false;

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
            //CheckTrigger();

            //MouseLeave += PlaceHolderTextBox_MouseLeave;
            //GotFocus += PlaceHolderTextBox_GotFocus;
            //LostFocus += PlaceHolderTextBox_LostFocus;
            //Loaded += PlaceHolderTextBox_Loaded;

            //groups = VisualStateManager.GetVisualStateGroups(t).Cast<VisualStateGroup>().ToList();
            //if (groups == null)
            //{
            //    Debug.WriteLine("VisualStateGroups not found.");
            //}
            //else
            //{
            //    foreach (VisualStateGroup group in groups)
            //    {
            //        Debug.WriteLine($"Group: {group.Name}");
            //        foreach (VisualState state in group.States)
            //        {
            //            Debug.WriteLine($"  State: {state.Name}");
            //        }
            //    }
            //}
        }

        //private void PlaceHolderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //}

        //private void PlaceHolderTextBox_Loaded(object sender, RoutedEventArgs e)
        //{
        //    CheckTrigger();
        //}

        //private void PlaceHolderTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    isFocused = false;
        //    CheckTrigger();
        //}

        //private void CheckTrigger()
        //{
        //    if (string.IsNullOrEmpty(Text))
        //    {
        //        // 텍스트가 비어 있으면 Unfocused 애니메이션 실행
        //        VisualStateManager.GoToElementState(this, "Unfocused", true);
        //    }
        //    else
        //    {

        //        // 텍스트가 있으면 애니메이션을 건너뛰고 바로 상태를 변경
        //        var a = VisualStateManager.GoToElementState(this, "Focused", true);
        //        if (a == false)
        //        {
        //            VisualStateManager.GoToElementState(this, "Unfocused", true);
        //        }
        //    }
        //}

        //private void PlaceHolderTextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    base.OnGotFocus(e);
        //    isFocused = true;
        //}

        //private void PlaceHolderTextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(Text) && isFocused is false)
        //    {
        //       var a = VisualStateManager.GoToState(this, "Unfocused", true);

        //        if (a)
        //        {

        //        }
        //    }
        //}
    }
}
