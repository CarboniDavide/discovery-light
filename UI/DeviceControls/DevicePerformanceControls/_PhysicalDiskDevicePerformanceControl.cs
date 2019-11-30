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
            chartDiskFree.FillSize = Convert.ToInt16(100 - Convert.ToInt32(CurrentPerformance.Percent_FreeSpace));
            lbl_Free_Value.Text = (Convert.ToInt32(CurrentPerformance.FreeSpace) / 1024).ToString() + " GB";
            lbl_Write_Value.Text = (Convert.ToUInt32(CurrentPerformance.WriteBytesPerSec) / 1024).ToString() + " KB";
            lbl_Read_Value.Text = (Convert.ToUInt32(CurrentPerformance.ReadBytesPerSec) / 1024).ToString() + " KB";
            lbl_Transfer_Value.Text = CurrentPerformance.TransferPerSec.ToString();
            chartReadTime.BarFillSize = Convert.ToInt16(CurrentPerformance.Percent_ReadTime);
            chartWriteTime.BarFillSize = Convert.ToInt16(CurrentPerformance.Percent_WriteTime);
            chartDiskTime.BarFillSize = Convert.ToInt16(CurrentPerformance.Percent_DiskTime);
            chartIdleTime.BarFillSize = Convert.ToInt16(CurrentPerformance.Percent_IdleTime);
        }
    }
}
