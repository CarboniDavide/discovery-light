﻿using System;
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

        protected override void update()
        {
            base.update();
            CurrentDevice.GetDriveInfo();
        }

        protected override void show()
        {
            base.show();
            var CurrentDevice = (RAM)this.CurrentDevice;
            lbl_Size_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Size, "N/A", "{0:N0}") + " Kbytes";
            lbl_Block_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.BlockNumber.ToString(), "N/A");
            lbl_Type_Value.Text = DataConvert.AsDefaultValue(CurrentDevice.Type, "N/A");

            var CurrentSubDevice = (RAM.Block)this.CurrentSubDevice;
            lbl_BlockSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Capacity, "N/A", "{0:N0}") + " Kbytes";
            lbl_BlockSlotPosition_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Slot, "N/A");
            lbl_BlockLocation_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Location, "N/A");
            lbl_BlockManufacturer_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_BlockNumberParty_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.PartyNumber, "N/A");
            lbl_BlockSerial_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.SerialNumber, "N/A");
            lbl_BlockSpeed_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Speed, "N/A", "{0:N0}") + " Mhz";
            lbl_BlockBusSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.BusSize, "N/A") + " Bytes";
            lbl_BlockVoltage_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Voltage, "N/A", "{0:N0}") + " mV";
            abort();
        }
    }
}
