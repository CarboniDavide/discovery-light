using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System;
using System.Data;
using System.Linq;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _PhysicalDisk : DevicePanel
    {
        public _PhysicalDisk()
        {
            InitializeComponent();
            this.PhysicalDiskDevicePerformanceControl.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_DISK)).First());
            this.PhysicalDiskDeviceDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(DiskDrive)).First());
        }

        private void _PhysicalDisk_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(PhysicalDiskDeviceDataControl, PhysicalDiskDevicePerformanceControl, null);
        }
    }
}
