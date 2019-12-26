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
            CurrentDevice.UpdateCollection();
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_SCORE.SubDevice)this.CurrentSubDevice;
            chartBar_Cpu.BarFillSize = ChartPerform.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.CPUScore);
            chartBar_D3D.BarFillSize = ChartPerform.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.D3DScore);
            chartBar_Hd.BarFillSize = ChartPerform.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.DiskScore);
            chartBar_Graph.BarFillSize = ChartPerform.FillOrDefault(x=> x.AsDecimal() * 10, CurrentPerformance.GraphicsScore);
            chartBar_Ram.BarFillSize = ChartPerform.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.MemoryScore);
            abort();
        }
    }
}