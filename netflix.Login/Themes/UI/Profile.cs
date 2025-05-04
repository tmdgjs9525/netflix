using System.Windows.Controls;

namespace netflix.Login.Themes.UI
{
    internal class Profile : Button
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
