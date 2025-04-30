using System;
using System.Windows;
using System.Windows.Controls;

namespace netflix.Support.AttachProperties
{
    public static class ContentControlTemplateHelper
    {
        public static readonly DependencyProperty EnableAutoTemplateProperty =
            DependencyProperty.RegisterAttached(
                "EnableAutoTemplate",
                typeof(bool),
                typeof(ContentControlTemplateHelper),
                new PropertyMetadata(false, OnEnableAutoTemplateChanged));

        public static void SetEnableAutoTemplate(ContentControl element, bool value)
        {
            element.SetValue(EnableAutoTemplateProperty, value);
        }

        public static bool GetEnableAutoTemplate(ContentControl element)
        {
            return (bool)element.GetValue(EnableAutoTemplateProperty);
        }

        private static void OnEnableAutoTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContentControl cc)
            {
                if ((bool)e.NewValue)
                {
                    // Content가 바뀔 때마다 처리
                    cc.DataContextChanged += (s, _) => TrySetTemplate(cc);
                    cc.Loaded += (s, _) => TrySetTemplate(cc);
                }
            }
        }

        private static void TrySetTemplate(ContentControl cc)
        {
            if (cc.Content == null)
                return;

            var contentType = cc.Content.GetType();

            foreach (var resourceKey in cc.Resources.Keys)
            {
                if (cc.Resources[resourceKey] is DataTemplate dt && dt.DataType is Type dtType)
                {
                    if (dtType.IsAssignableFrom(contentType))
                    {
                        cc.ContentTemplate = dt;
                        return;
                    }
                }
            }
        }
    }
}
