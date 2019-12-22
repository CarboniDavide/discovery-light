using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Commun;
using DiscoveryLight.UI.DeviceControls.DevicePerformanceControls;

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _SystemSlotDataControl : DeviceDataControl
    {
        public _SystemSlotDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }
        
        public _SystemSlotDataControl() : base()
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
            var CurrentDevice = (SystemSlot.SubDevice)this.CurrentSubDevice;
            lbl_SlotNumber_Value.Text = DataConvert.AsDefaultValue(this.CurrentDevice.SubDevices.Count().ToString(), "N/A"); ;
            abort();
        }
    }
}
