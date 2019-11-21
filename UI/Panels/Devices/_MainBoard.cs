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

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _MainBoard : DevicePanel
    {
        public _MainBoard()
        {
            InitializeComponent();
            this.WindowsScoreDevicePerformanceControl.InitPerformace(Program.Performances.Where(d => d.Properties.GetType() == typeof(PERFORM_SCORE)).First().Properties);
        }
    }
}
