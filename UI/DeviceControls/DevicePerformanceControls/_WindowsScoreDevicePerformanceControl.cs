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
            chartBar_Cpu.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Cpu) * 10);
            chartBar_D3D.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.D3D) * 10);
            chartBar_Hd.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Hd) * 10);
            chartBar_Graph.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Graph) * 10);
            chartBar_Ram.BarFillSize = Convert.ToInt16(Convert.ToDouble(CurrentPerformance.Ram) * 10);
            abort();
        }
    }
}
