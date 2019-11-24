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
            this.BasePcDeviceDataControl.InitData(Program.Devices.Where(d => d.ClassType == typeof(PC)).First());
        }
    }
}
