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
using DiscoveryLight.UI.Charts;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _BaseFreeRamDevicePerformance : DevicePerformanceControl
    {
        public _BaseFreeRamDevicePerformance(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _BaseFreeRamDevicePerformance() : base() {
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
            chartRAM.FillSize = ChartPerform.FillOrDefault(CurrentPerformance.PerUsage);
        }
    }
}
