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
    public partial class _MemoryDeviceDataControl : DeviceDataControl
    {
        public _MemoryDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _MemoryDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _MemoryDeviceDataControl() : base()
        {
            InitializeComponent();
        }

        public override void ShowData()
        {
            base.ShowData();
            var CurrentDevice = (RAM)this.CurrentDevice;
            lbl_Size_Value.Text = CurrentDevice.Size.ToString() + " Kbytes";
            lbl_Block_Value.Text = CurrentDevice.BlockNumber.ToString();
            lbl_Type_Value.Text = CurrentDevice.Type;

            var CurrentSubDevice = (RAM.Block)this.CurrentSubDevice;
            lbl_BlockSize_Value.Text = CurrentSubDevice.Capacity + " Kbytes";
            lbl_BlockSlotPosition_Value.Text = CurrentSubDevice.Slot;
            lbl_BlockLocation_Value.Text = CurrentSubDevice.Location;
            lbl_BlockManufacturer_Value.Text = CurrentSubDevice.Manufacturer;
            lbl_BlockNumberParty_Value.Text = CurrentSubDevice.PartyNumber;
            lbl_BlockSerial_Value.Text = CurrentSubDevice.SerialNumber;
            lbl_BlockSpeed_Value.Text = CurrentSubDevice.Speed + " Mhz";
            lbl_BlockBusSize_Value.Text = CurrentSubDevice.BusSize + " Bytes";
            lbl_BlockVoltage_Value.Text = CurrentSubDevice.Voltage + " mV";
        }
    }
}
