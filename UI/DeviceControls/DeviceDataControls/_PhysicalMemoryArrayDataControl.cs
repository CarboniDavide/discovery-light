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

namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    public partial class _PhysicalMemoryArrayDataControl : DeviceDataControl
    {
        public _PhysicalMemoryArrayDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _PhysicalMemoryArrayDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _PhysicalMemoryArrayDataControl() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.GetCollection();
        }

        protected override void show()
        {
            base.show();
            var CurrentDevice = (PhysicalMemoryArray)this.CurrentDevice;
            lbl_Size_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Size, "N/A", "{0:N0}") + " Kbytes";
            lbl_Block_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.MemoryDevices, "N/A");
            lbl_Type_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Type, "N/A");
            abort();
        }
    }
}
