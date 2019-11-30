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
    public partial class _MemoryDevicePerformanceControl : DevicePerformanceControl
    {
        public _MemoryDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _MemoryDevicePerformanceControl() : base() 
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
            var CurrentPerformanceCPU = (PERFORM_RAM)this.CurrentPerformance;
            lbl_CacheUsage_Value.Text = (Convert.ToUInt64(CurrentPerformanceCPU.CacheUsage) / 1048576).ToString() + " MB";
            lbl_CacheUsageMax_Value.Text = (Convert.ToUInt64(CurrentPerformanceCPU.MaxCacheUsage) / 1048576).ToString() + " MB";
            lbl_RamOut_Value.Text = (Convert.ToUInt64(CurrentPerformanceCPU.MemoryOut) / 1048576).ToString() + " MB";
            lbl_Free_Value.Text = CurrentPerformanceCPU.Free + " MB";
            lbl_PageIn_Value.Text = CurrentPerformanceCPU.PageIn.ToString();
            lbl_PageOut_Value.Text = CurrentPerformanceCPU.PageOut.ToString();
            lbl_PageWrite_Value.Text = CurrentPerformanceCPU.PageWrite.ToString();
            lbl_PageRead_Value.Text = CurrentPerformanceCPU.PageRead.ToString();
            lbl_PagePersec_Value.Text = CurrentPerformanceCPU.PagePerSec.ToString();
            chartRamUsage.FillSize = Convert.ToInt32(100 - Convert.ToInt32(CurrentPerformanceCPU.PerUsage));
        }
    }
}
