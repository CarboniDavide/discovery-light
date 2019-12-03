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
    public partial class _WindowsScoreDevicePerformanceControl : DevicePerformanceControl
    {
        public _WindowsScoreDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _WindowsScoreDevicePerformanceControl() : base() 
        {
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
            var CurrentPerformance = (PERFORM_SCORE)this.CurrentPerformance;
            chartBar_Cpu.BarFillSize = ChartPerform.FillOrDefault(x => Convert.ToInt16(Convert.ToDouble(x) * 10), CurrentPerformance.Cpu);
            chartBar_D3D.BarFillSize = ChartPerform.FillOrDefault(x => Convert.ToInt16(Convert.ToDouble(x) * 10), CurrentPerformance.D3D); ;
            chartBar_Hd.BarFillSize = ChartPerform.FillOrDefault(x => Convert.ToInt16(Convert.ToDouble(x) * 10), CurrentPerformance.Hd);
            chartBar_Graph.BarFillSize = ChartPerform.FillOrDefault(x=> Convert.ToInt16(Convert.ToDouble(x) * 10), CurrentPerformance.Graph);
            chartBar_Ram.BarFillSize = ChartPerform.FillOrDefault(x => Convert.ToInt16(Convert.ToDouble(x) * 10), CurrentPerformance.Ram);
            abort();
        }
    }
}