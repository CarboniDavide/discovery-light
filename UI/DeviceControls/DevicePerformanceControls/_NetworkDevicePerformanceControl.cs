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
using DiscoveryLight.Core.Commun;
using DiscoveryLight.UI.Charts;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _NetworkDevicePerformanceControl : DeviceControl
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
            CurrentDevice.UpdateCollection();
        }
        protected override void show()
        {
            base.show();
            var CurrentPerformance= (PERFORM_NETWORK.Device)this.CurrentSubDevice;

            lbl_BytesReceived_Value.Text= DataConvert.AsDefaultValue(CurrentPerformance.BytesReceivedPersec.AsString(), "N/A", "{0:N0}");
            lbl_BytesSent_Value.Text= DataConvert.AsDefaultValue( CurrentPerformance.BytesSentPersec.AsString(), "N/A", "{0:N0}");
            lbl_PacketsReceived_Value.Text= DataConvert.AsDefaultValue(CurrentPerformance.PacketsReceivedPersec.AsString(), "N/A", "{0:N0}");
            lbl_PacketsSent_Value.Text= DataConvert.AsDefaultValue(CurrentPerformance.PacketsSentPersec.AsString(), "N/A", "{0:N0}");

            lbl_TotalReceived_Value.Text= DataConvert.AsDefaultValue(x => (Convert.ToDouble(x) / 1024).ToString(), CurrentPerformance.TotalBytesReceived.AsString(), "N/A", "{0:N0}");
            lbl_TotalSent_Value.Text = DataConvert.AsDefaultValue(x => (Convert.ToDouble(x) / 1024).ToString(), CurrentPerformance.TotalBytesSent.AsString(), "N/A", "{0:N0}");

            chartBytesReceived.BarFillSize= ChartPerform.FillOrDefault(x=> Convert.ToInt16(x), CurrentPerformance.PercentBytesReceived.AsString());
            chartBytesSent.BarFillSize= ChartPerform.FillOrDefault(CurrentPerformance.PercentBytesSent.AsString());
            chartPacketsReceived.BarFillSize= ChartPerform.FillOrDefault(CurrentPerformance.PercentPacketsReceived.AsString());
            chartPacketsSent.BarFillSize= ChartPerform.FillOrDefault(CurrentPerformance.PercentPacketsSents.AsString());

            pic_Received.BackColor = DataConvert.AsDefaultValue(CurrentPerformance.BytesReceivedPersec.AsString(), "0").Equals("0") ? Color.Transparent : Color.LightGreen;
            pic_Sent.BackColor = DataConvert.AsDefaultValue(CurrentPerformance.BytesSentPersec.AsString(), "0").Equals("0") ? Color.Transparent : Color.Tomato;
        }
    }
}
