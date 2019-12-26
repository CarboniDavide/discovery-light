using DiscoveryLight.Core.Commun;
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
            CurrentDevice.UpdateCollection();
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_SCORE.SubDevice)this.CurrentSubDevice;
            chartBar_Cpu.BarFillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.CPUScore);
            chartBar_D3D.BarFillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.D3DScore);
            chartBar_Hd.BarFillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.DiskScore);
            chartBar_Graph.BarFillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.GraphicsScore);
            chartBar_Ram.BarFillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsDecimal() * 10, CurrentPerformance.MemoryScore);
            abort();
        }
    }
}