using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using DiscoveryLight.Logging;
using System.Threading;
using DiscoveryLight.UI.Panels.Details;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Details : DevicePanel
    {
        public _Details()
        {
            InitializeComponent();
        }

        public void StopLoadedTask()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().BaseType.FullName == typeof(BaseSubPanel).ToString())
                {
                    var t = (BaseSubPanel)c;
                    t.StopLoadedSubTask();
                }
            }
        }

        private void _Details_Load(object sender, EventArgs e)
        {
            this.WmiNameSpace.Init();
            this.WmiNameSpace.Load();
        }
    }
}
