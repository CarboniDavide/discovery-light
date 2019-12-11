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
    public partial class _MotherBoardDeviceDataControl : DeviceDataControl
    {
        public _MotherBoardDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _MotherBoardDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _MotherBoardDeviceDataControl() : base()
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
            var CurrentDevice = (MotherboardDevice.Device)this.CurrentSubDevice;
            lbl_PrimaryBus_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.PrimaryBus_Value, "N/A");
            lbl_SecondaryBus_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SecondaryBus_Value, "N/A");
            abort();
        }
    }
}
