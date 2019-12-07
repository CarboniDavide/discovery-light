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
using System.Threading;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _BaseHardware : DevicePanel
    {
        public _BaseHardware()
        {
            InitializeComponent();
            this.BasePcDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_PC)).First());
            this.ComputerSystem.InitData(Program.Devices.Where(d => d.ClassType == typeof(DiscoveryLight.Core.Device.Data.ComputerSystem)).First());
            this.ComputerSystemProduct.InitData(Program.Devices.Where(d => d.ClassType == typeof(DiscoveryLight.Core.Device.Data.ComputerSystemProduct)).First());
            this.OperatingSystem.InitData(Program.Devices.Where(d => d.ClassType == typeof(DiscoveryLight.Core.Device.Data.OperatingSystem)).First());
        }
    }
}
