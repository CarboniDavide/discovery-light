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
            CurrentDevice.UpdateCollection();
        }
        protected override void show()
        {
            base.show();
            var CurrentPerformance = (PERFORM_RAM.SubDevice)this.CurrentSubDevice;
            lbl_CacheUsage_Value.Text = MobPropertyDataConvert.AsDefaultValue(x=> x.AsUInt64() / 1048576, CurrentPerformance.CacheBytes, "N/A", "{0:N0}") + " MB";
            lbl_CacheUsageMax_Value.Text = MobPropertyDataConvert.AsDefaultValue(x => x.AsUInt64() / 1048576, CurrentPerformance.CacheBytesPeak, "N/A", "{0:N0}") + " MB";
            lbl_RamOut_Value.Text = MobPropertyDataConvert.AsDefaultValue( x=> x.AsUInt64() / 1048576, CurrentPerformance.CommittedBytes, "N/A", "{0:N0}") + " MB";
            lbl_Free_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.AvailableMBytes, "N/A", "{0:N0}") + " MB";
            lbl_PageIn_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.PagesInputPersec, "N/A", "{0:N0}");
            lbl_PageOut_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.PagesOutputPersec, "N/A", "{0:N0}");
            lbl_PageWrite_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.PageWritesPersec, "N/A", "{0:N0}");
            lbl_PageRead_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.PageReadsPersec, "N/A", "{0:N0}");
            lbl_PagePersec_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentPerformance.PagesPersec, "N/A", "{0:N0}");
            chartRamUsage.FillSize = MobPropertyChartConvert.FillOrDefault(CurrentPerformance.PerUsage);
        }
    }
}
