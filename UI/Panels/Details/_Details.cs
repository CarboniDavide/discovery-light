using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Panels.Details
{
    public partial class _Details : DevicePanel
    {
        public _Details()
        {
            InitializeComponent();
        }
        public override void StopLoadedTask()
        {
            base.StopLoadedTask();
         
            foreach (Control c in this.SubPanelContainer.Controls)
            {
                if (c.GetType().BaseType.FullName == typeof(BaseSubPanel).ToString())
                {
                    var t = (BaseSubPanel)c;
                    t.StopLoadedSubTask();
                }
            }
        }
    }
}
