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
    public partial class _WindowsScoreDevicePerformanceControl : DevicePerformanceControl
    {
        public _WindowsScoreDevicePerformanceControl()
        {
            InitializeComponent();
            if (Program.Performances == null) return;
            InitPerformace(Program.Performances.Where(d => d.Properties.GetType() == typeof(PERFORM_SCORE)).First().Properties);
        }

        public override void ShowPerformance()
        {
            base.ShowPerformance();
            var CurrentPerformance = (PERFORM_SCORE)this.CurrentPerformance;
            chartBar_Cpu.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Cpu) * 10);
            chartBar_D3D.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.D3D) * 10);
            chartBar_Hd.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Hd) * 10);
            chartBar_Graph.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Graph) * 10);
            chartBar_Ram.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Ram) * 10);
            StopPerformance();
        }
    }
}
