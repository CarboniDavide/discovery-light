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
            lbl_Manufacturer_Value.Text = CurrentDevice.Manufacturer;
            lbl_Model_Value.Text = CurrentDevice.Model;
            lbl_Version_Value.Text = CurrentDevice.Version;
            lbl_PrimaryBus_Value.Text = CurrentDevice.PrimaryBus_Value;
            lbl_SecondaryBus_Value.Text = CurrentDevice.SecondaryBus_Value;
            lbl_SlotNumber_Value.Text = CurrentDevice.NumberSlot;
        }
    }
}
