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
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.UI.Components;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _PhysicalDisk : DevicePanel
    {
        public _PhysicalDisk()
        {
            InitializeComponent();
            this.PhysicalDiskDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_DISK)).First());
            this.PhysicalDiskDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(DiskDrive)).First());
        }

        private void _PhysicalDisk_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(PhysicalDiskDeviceDataControl, PhysicalDiskDevicePerformanceControl, Components.DataControlComboBox.StringValue.Name, null);
        }
    }
}
