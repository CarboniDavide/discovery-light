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
            CurrentPerformance.GetPerformance();
        }
        protected override void show()
        {
            base.show();
            var CurrentPerformance= (PERFORM_NETWORK)this.CurrentPerformance;

            lbl_BytesReceived_Value.Text= DataConvert.AsDefaultValue(CurrentPerformance.ByteReceivedPerSec, "N/A", "{0:N0}");
            lbl_BytesSent_Value.Text= DataConvert.AsDefaultValue( CurrentPerformance.BytesSentPerSec, "N/A", "{0:N0}");
            lbl_PacketsReceived_Value.Text= DataConvert.AsDefaultValue(CurrentPerformance.PacketsReceivedsPerSec, "N/A", "{0:N0}");
            lbl_PacketsSent_Value.Text= DataConvert.AsDefaultValue(CurrentPerformance.PacketsSentPerSec, "N/A", "{0:N0}");

            lbl_TotalReceived_Value.Text= DataConvert.AsDefaultValue(x => (Convert.ToDouble(x) / 1024).ToString(), CurrentPerformance.TotalBytesReceived, "N/A", "{0:N0}");
            lbl_TotalSent_Value.Text = DataConvert.AsDefaultValue(x => (Convert.ToDouble(x) / 1024).ToString(), CurrentPerformance.TotalBytesSent, "N/A", "{0:N0}");

            chartBytesReceived.BarFillSize= ChartPerform.FillOrDefault(Convert.ToInt16(CurrentPerformance.PercentBytesReceived));
            chartBytesSent.BarFillSize= ChartPerform.FillOrDefault(CurrentPerformance.PercentBytesSent);
            chartPacketsReceived.BarFillSize= ChartPerform.FillOrDefault(CurrentPerformance.PercentPacketsReceived);
            chartPacketsSent.BarFillSize= ChartPerform.FillOrDefault(CurrentPerformance.PercentPacketsSents);

            pic_Received.BackColor = DataConvert.AsDefaultValue(CurrentPerformance.ByteReceivedPerSec, "0").Equals("0") ? Color.Transparent : Color.LightGreen;
            pic_Sent.BackColor = DataConvert.AsDefaultValue(CurrentPerformance.BytesSentPerSec, "0").Equals("0") ? Color.Transparent : Color.Tomato;
        }
    }
}
