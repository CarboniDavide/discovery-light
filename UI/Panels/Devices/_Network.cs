using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System;
using System.Data;
using System.Linq;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Network : DevicePanel
    {
        public _Network()
        {
            InitializeComponent();
            this.NetworkDevicePerformanceControl.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_NETWORK)).First());
            this.NetworkDeviceDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(NetworkAdapter)).First());
        }

        private void _Network_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(NetworkDeviceDataControl, NetworkDevicePerformanceControl, null);
        }
    }
}
