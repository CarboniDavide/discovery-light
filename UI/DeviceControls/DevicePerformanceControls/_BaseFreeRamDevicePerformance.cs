using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _BaseFreeRamDevicePerformance : DevicePerformanceControl
    {
        public _BaseFreeRamDevicePerformance(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _BaseFreeRamDevicePerformance() : base()
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
            var CurrentPerformance = (PERFORM_RAM.SubDevice)this.CurrentSubDevice;
            chartRAM.FillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PerUsage);
        }
    }
}
