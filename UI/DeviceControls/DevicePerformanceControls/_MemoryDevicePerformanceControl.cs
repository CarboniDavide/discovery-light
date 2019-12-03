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
            lbl_CacheUsage_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToUInt64(x) / 1048576).ToString(), CurrentPerformanceCPU.CacheUsage, "N/A", "{0:N0}") + " MB";
            lbl_CacheUsageMax_Value.Text = DataConvert.AsDefaultValue(x => (Convert.ToUInt64(x) / 1048576).ToString(), CurrentPerformanceCPU.MaxCacheUsage, "N/A", "{0:N0}") + " MB";
            lbl_RamOut_Value.Text = DataConvert.AsDefaultValue( x=> (Convert.ToUInt64(x) / 1048576).ToString(), CurrentPerformanceCPU.MemoryOut, "N/A", "{0:N0}") + " MB";
            lbl_Free_Value.Text = DataConvert.AsDefaultValue(CurrentPerformanceCPU.Free, "N/A", "{0:N0}") + " MB";
            lbl_PageIn_Value.Text = DataConvert.AsDefaultValue(CurrentPerformanceCPU.PageIn, "N/A", "{0:N0}");
            lbl_PageOut_Value.Text = DataConvert.AsDefaultValue(CurrentPerformanceCPU.PageOut, "N/A", "{0:N0}");
            lbl_PageWrite_Value.Text = DataConvert.AsDefaultValue(CurrentPerformanceCPU.PageWrite, "N/A", "{0:N0}");
            lbl_PageRead_Value.Text = DataConvert.AsDefaultValue(CurrentPerformanceCPU.PageRead, "N/A", "{0:N0}");
            lbl_PagePersec_Value.Text = DataConvert.AsDefaultValue(CurrentPerformanceCPU.PagePerSec, "N/A", "{0:N0}");
            chartRamUsage.FillSize = ChartPerform.FillOrDefault( x=> Convert.ToInt32(100 - Convert.ToInt32(x)), CurrentPerformanceCPU.PerUsage);
        }
    }
}
