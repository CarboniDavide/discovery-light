using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _BaseFreeStorageDevicePerformance : DevicePerformanceControl
    {
        public _BaseFreeStorageDevicePerformance(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _BaseFreeStorageDevicePerformance() : base()
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
            var CurrentPerformance = (PERFORM_DISK.SubDevice)this.CurrentSubDevice;
            chartHD.FillSize = MobPropertyChartConvert.FillOrDefault(x => 100 - x.AsInt32(), CurrentPerformance.PercentFreeSpace);
        }
    }
}
