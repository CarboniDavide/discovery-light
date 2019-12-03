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
            CurrentPerformance.GetPerformance();
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_DISK)this.CurrentPerformance;
            chartDiskFree.FillSize = ChartPerform.FillOrDefault(x=> Convert.ToInt16(100 - Convert.ToInt32(x)), CurrentPerformance.Percent_FreeSpace);
            lbl_Free_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToInt32(x) / 1024).ToString(), CurrentPerformance.FreeSpace, "N/A", "{0:N0}") + " GB";
            lbl_Write_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToUInt32(x) / 1024).ToString(), CurrentPerformance.WriteBytesPerSec, "N/A", "{0:N0}") + " KB";
            lbl_Read_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToUInt32(x) / 1024).ToString(), CurrentPerformance.ReadBytesPerSec, "N/A", "{0:N0}") + " KB";
            lbl_Transfer_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.TransferPerSec, "N/A", "{0:N0}");
            chartReadTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.Percent_ReadTime);
            chartWriteTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.Percent_WriteTime);
            chartDiskTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.Percent_DiskTime);
            chartIdleTime.BarFillSize = ChartPerform.FillOrDefault(CurrentPerformance.Percent_IdleTime);
        }
    }
}
