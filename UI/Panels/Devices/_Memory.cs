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
    public partial class _Memory : DevicePanel
    {
        public _Memory()
        {
            InitializeComponent();
            this.MemoryDevicePerformanceControl.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_RAM)).First());
            this.PhysicalMemoryDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(PhysicalMemory)).First());
            this.PhysicalMemoryArrayDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(PhysicalMemoryArray)).First());
        }

        private void _Memory_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(PhysicalMemoryDataControl, null, null);
        }
    }
}
