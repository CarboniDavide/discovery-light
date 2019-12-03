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
using DiscoveryLight.UI.Charts;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _BasePcDevicePerformanceControl : DevicePerformanceControl
    {
        public _BasePcDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _BasePcDevicePerformanceControl() : base() {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentPerformance.GetPerformance();
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_PC)this.CurrentPerformance;
            chartRAM.FillSize = ChartPerform.FillOrDefault(CurrentPerformance.Per_RamSizeUsed);
            chartHD.FillSize = ChartPerform.FillOrDefault(x => (100 - Convert.ToInt32(x)), CurrentPerformance.Per_DiskSizeFree);
            chartCPU.FillSize = ChartPerform.FillOrDefault(CurrentPerformance.Per_CpuUsage);
        }
    }
}
