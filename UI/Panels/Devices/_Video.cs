using DiscoveryLight.Core.Device.Data;
using System;
using System.Data;
using System.Linq;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Video : DevicePanel
    {
        public _Video()
        {
            InitializeComponent();
            this.VideoDeviceDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(VideoController)).First());
        }

        private void _Video_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(VideoDeviceDataControl, null, null);
        }
    }
}
