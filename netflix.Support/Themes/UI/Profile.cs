using System.Windows.Controls;

namespace netflix.Support.Themes.UI
{
    public class Profile : Button
    {
        public Profile()
        {
            DefaultStyleKey = typeof(Profile);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
