using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.UI.Components;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Video: DevicePanel
    {
        public _Video()
        {
            InitializeComponent();
            this.VideoDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(VideoController)).First());
        }

        private void _Video_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(VideoDeviceDataControl, null, null);
        }
    }
}
