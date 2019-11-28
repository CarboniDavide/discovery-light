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

        private void _Details_Load(object sender, EventArgs e)
        {
            this.WmiNameSpace.Start();
        }
    }
}
