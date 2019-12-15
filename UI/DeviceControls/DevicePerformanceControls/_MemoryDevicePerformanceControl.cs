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
    public partial class _MemoryDevicePerformanceControl : DeviceControl
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
            var CurrentPerformance = (PERFORM_RAM.Device)this.CurrentSubDevice;
            lbl_CacheUsage_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToUInt64(x) / 1048576).ToString(), CurrentPerformance.CacheBytes.AsString(), "N/A", "{0:N0}") + " MB";
            lbl_CacheUsageMax_Value.Text = DataConvert.AsDefaultValue(x => (Convert.ToUInt64(x) / 1048576).ToString(), CurrentPerformance.CacheBytesPeak.AsString(), "N/A", "{0:N0}") + " MB";
            lbl_RamOut_Value.Text = DataConvert.AsDefaultValue( x=> (Convert.ToUInt64(x) / 1048576).ToString(), CurrentPerformance.CommittedBytes.AsString(), "N/A", "{0:N0}") + " MB";
            lbl_Free_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.AvailableMBytes.AsString(), "N/A", "{0:N0}") + " MB";
            lbl_PageIn_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.PagesInputPersec.AsString(), "N/A", "{0:N0}");
            lbl_PageOut_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.PagesOutputPersec.AsString(), "N/A", "{0:N0}");
            lbl_PageWrite_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.PageWritesPersec.AsString(), "N/A", "{0:N0}");
            lbl_PageRead_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.PageReadsPersec.AsString(), "N/A", "{0:N0}");
            lbl_PagePersec_Value.Text = DataConvert.AsDefaultValue(CurrentPerformance.PagesPersec.AsString(), "N/A", "{0:N0}");
            chartRamUsage.FillSize = ChartPerform.FillOrDefault(CurrentPerformance.PerUsage.AsString());
        }
    }
}
