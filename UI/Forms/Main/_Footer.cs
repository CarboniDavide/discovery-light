using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Footer : UserControl
    {
        public _Footer()
        {
            InitializeComponent();
        }

        public void ChangeTitle(string title)
        {
            this.ChartBar.CustomText = title;
            this.ChartBar.BarFillSize = 0;
        }
    }
}
