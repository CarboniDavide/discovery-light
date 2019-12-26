using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _BaseProcessorUsageDevicePerformance : DevicePerformanceControl
    {
        public _BaseProcessorUsageDevicePerformance(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _BaseProcessorUsageDevicePerformance() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.UpdateCollection("Name", "_Total");
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_CPU.SubDevice)this.CurrentSubDevice;
            chartCPU.FillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentProcessorTime);
        }
    }
}
