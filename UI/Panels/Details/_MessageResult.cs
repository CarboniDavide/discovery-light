using System;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Panels.Details
{
    public partial class _MessageResult : UserControl
    {
        public _MessageResult()
        {
            InitializeComponent();
        }

        public void HideMessages(Boolean hide, String className)
        {
            lbl_ClasseName.Visible = !hide;
            lbl_MessageResult.Visible = !hide;
            if (className == null) return;
            lbl_ClasseName.Text = className;
        }

        public void HideImages(Boolean hide)
        {
            pic_ImageResult.Visible = !hide;
        }

        public void HideControl(Boolean hide)
        {
            this.Visible = !hide;
        }

        public String ClassName
        {
            get { return lbl_ClasseName.Text; }
            set { lbl_ClasseName.Text = value; }
        }
    }
}
