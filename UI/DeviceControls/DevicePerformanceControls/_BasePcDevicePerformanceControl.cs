using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _BasePcDevicePerformanceControl : DevicePerformanceControl
    {
        public _BasePcDevicePerformanceControl(): base()
        {
            InitializeComponent();
        }


        public override void ShowPerformance()
        {
            base.ShowPerformance();
            var CurrentPerformance = (PERFORM_PC)this.CurrentPerformance;
            chartRAM.FillSize = (int)CurrentPerformance.Per_RamSizeUsed;
            chartHD.FillSize = (int)(100 - CurrentPerformance.Per_DiskSizeFree);
            chartCPU.FillSize = (int)CurrentPerformance.Per_CpuUsage;
        }

        private void _BasePcDevicePerformanceControl_Load(object sender, EventArgs e)
        {
            if (Program.Performances == null) return;
            InitPerformace(Program.Performances.Where(d => d.Properties.GetType() == typeof(PERFORM_PC)).First().Properties);
        }
    }
}
