using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace netflix.Core.Dialog
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

            Control content = dialogContent.Content as Control ?? throw new ArgumentNullException("ContentControls Content is not UserControl. should be UserControl");
        }
    }
}
