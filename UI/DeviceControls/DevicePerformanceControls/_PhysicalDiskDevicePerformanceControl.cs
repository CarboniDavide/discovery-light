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
    public partial class _PhysicalDiskDevicePerformanceControl : DevicePerformanceControl
    {
        public _PhysicalDiskDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _PhysicalDiskDevicePerformanceControl() : base() 
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
            var CurrentPerformance = (PERFORM_DISK.Device)this.CurrentSubDevice;
            chartDiskFree.FillSize = ChartPerform.FillOrDefault(x=> Convert.ToInt16(100 - Convert.ToInt32(x)), CurrentPerformance.PercentFreeSpace.AsString());
            lbl_Free_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToInt32(x) / 1024).ToString(), CurrentPerformance.FreeMegabytes.AsString(), "N/A", "{0:N0}") + " GB";
            lbl_Write_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToUInt32(x) / 1024).ToString(), CurrentPerformance.DiskWriteBytesPersec.AsString(), "N/A", "{0:N0}") + " KB";
            lbl_Read_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToUInt32(x) / 1024).ToString(), CurrentPerformance.DiskReadBytesPersec.AsString(), "N/A", "{0:N0}") + " KB";
            lbl_Transfer_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.DiskTransfersPersec.AsString(), "N/A", "{0:N0}");
            chartReadTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.PercentDiskReadTime.AsString());
            chartWriteTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.PercentDiskWriteTime.AsString());
            chartDiskTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.PercentDiskTime.AsString());
            chartIdleTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.PercentIdleTime.AsString());
        }
    }
}
