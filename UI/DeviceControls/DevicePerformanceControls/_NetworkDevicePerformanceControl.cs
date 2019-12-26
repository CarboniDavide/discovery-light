using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device.Performance;
using System.Drawing;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _NetworkDevicePerformanceControl : DevicePerformanceControl
    {
        public _NetworkDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _NetworkDevicePerformanceControl() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.UpdateCollection("Name", (CurrentDevice as DevicePerformance).DeviceRelated);
        }
        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_NETWORK.SubDevice)this.CurrentSubDevice;

            lbl_BytesReceived_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.BytesReceivedPersec, "N/A", "{0:N0}");
            lbl_BytesSent_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.BytesSentPersec, "N/A", "{0:N0}");
            lbl_PacketsReceived_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.PacketsReceivedPersec, "N/A", "{0:N0}");
            lbl_PacketsSent_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.PacketsSentPersec, "N/A", "{0:N0}");

            lbl_TotalReceived_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsUInt32() / 1024, CurrentPerformance.TotalBytesReceived, "N/A", "{0:N0}");
            lbl_TotalSent_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsUInt32() / 1024, CurrentPerformance.TotalBytesSent, "N/A", "{0:N0}");

            chartBytesReceived.BarFillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsInt16(), CurrentPerformance.PercentBytesReceived);
            chartBytesSent.BarFillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentBytesSent);
            chartPacketsReceived.BarFillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentPacketsReceived);
            chartPacketsSent.BarFillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentPacketsSents);

            pic_Received.BackColor = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.BytesReceivedPersec, "0").Equals("0") ? Color.Transparent : Color.LightGreen;
            pic_Sent.BackColor = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.BytesSentPersec, "0").Equals("0") ? Color.Transparent : Color.Tomato;
        }
    }
}
