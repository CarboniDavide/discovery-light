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
            CurrentDevice.UpdateCollection("Name", (CurrentDevice as DevicePerformance).DeviceRelated);
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_DISK.SubDevice)this.CurrentSubDevice;
            
            lbl_Free_Value.Text = MobPropertyDataConvert.AsDefaultValue(x=> x.AsUInt32() / 1024, CurrentPerformance.FreeMegabytes, "N/A", "{0:N0}") + " GB";
            lbl_Write_Value.Text = MobPropertyDataConvert.AsDefaultValue(x=> x.AsUInt32() / 1024, CurrentPerformance.DiskWriteBytesPersec, "N/A", "{0:N0}") + " KB";
            lbl_Read_Value.Text = MobPropertyDataConvert.AsDefaultValue(x=> x.AsUInt32() / 1024, CurrentPerformance.DiskReadBytesPersec, "N/A", "{0:N0}") + " KB";
            lbl_Transfer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.DiskTransfersPersec, "N/A", "{0:N0}");
            chartReadTime.BarFillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentDiskReadTime);
            chartWriteTime.BarFillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentDiskWriteTime);
            chartDiskTime.BarFillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentDiskTime);
            chartIdleTime.BarFillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PercentIdleTime);
            chartDiskFree.FillSize = MobPropertyChartConvert.FillOrDefault(x => 100 - x.AsInt32(), CurrentPerformance.PercentFreeSpace);
        }
    }
}
