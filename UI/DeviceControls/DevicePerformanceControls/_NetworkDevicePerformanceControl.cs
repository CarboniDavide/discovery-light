﻿using System;
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
            var CurrentPerformance = (PERFORM_NETWORK)this.CurrentPerformance;
            lbl_BytesReceived_Value.Text = CurrentPerformance.ByteReceivedPerSec.ToString();
            lbl_BytesSent_Value.Text = CurrentPerformance.BytesSentPerSec.ToString();
            lbl_PacketsReceived_Value.Text = CurrentPerformance.PacketsReceivedsPerSec.ToString();
            lbl_PacketsSent_Value.Text = CurrentPerformance.PacketsSentPerSec.ToString();
            chartBytesReceived.BarFillSize = Convert.ToInt16(CurrentPerformance.PercentBytesReceived);
            chartBytesSent.BarFillSize = Convert.ToInt16(CurrentPerformance.PercentBytesSent);
            chartPacketsReceived.BarFillSize = Convert.ToInt16(CurrentPerformance.PercentPacketsReceived);
            chartPacketsSent.BarFillSize = Convert.ToInt16(CurrentPerformance.PercentPacketsSents);
            lbl_TotalReceived_Value.Text = ( (double)(Convert.ToInt32(CurrentPerformance.TotalBytesReceived) /100)).ToString();
            lbl_TotalSent_Value.Text = ((double)(Convert.ToInt32( CurrentPerformance.TotalBytesSent) / 1024)).ToString();
            pic_Received.BackColor = CurrentPerformance.ByteReceivedPerSec.Equals("0") ? Color.Transparent : System.Drawing.Color.LightGreen;
            pic_Sent.BackColor = CurrentPerformance.BytesSentPerSec.Equals("0") ? Color.Transparent : System.Drawing.Color.Tomato;
        }
    }
}
