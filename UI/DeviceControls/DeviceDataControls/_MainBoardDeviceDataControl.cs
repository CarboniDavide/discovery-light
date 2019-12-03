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
    public partial class _MainBoardDeviceDataControl : DeviceDataControl
    {
        public _MainBoardDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _MainBoardDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _MainBoardDeviceDataControl() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.GetDriveInfo();
        }

        protected override void show()
        {
            base.show();
            var CurrentDevice = (MAINBOARD)this.CurrentDevice;
            lbl_Manufacturer_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Manufacturer, "N/A");
            lbl_Model_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Model, "N/A");
            lbl_Version_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Version, "N/A");
            lbl_PrimaryBus_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.PrimaryBus_Value, "N/A");
            lbl_SecondaryBus_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.SecondaryBus_Value, "N/A");
            lbl_SlotNumber_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.NumberSlot, "N/A");
            abort();
        }
    }
}
