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
    public partial class _CpuDeviceDataControl : DeviceDataControl
    {
        public _CpuDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _CpuDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _CpuDeviceDataControl() : base()
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
            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A");
            lbl_Size_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.AddressSize, "N/A") + " bit";
            lbl_Description_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Description, "N/A");
            lbl_Producteur_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_Revision_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Revision, "N/A");
            lbl_Socket_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Socket, "N/A");
            lbl_Core_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.N_Core, "N/A");
            lbl_Thread_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.N_Thread, "N/A");
            lbl_MaxSpeed_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MaxSpeed, "N/A", "{0:N0}") + " Mhz";
            lbl_L1CacheSize_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToInt16(x)/4).ToString(), CurrentSubDevice.L1_Cache, "N/A") + " Kb";
            lbl_L2CacheSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.L2_Cache, "N/A") + " Kb";
            lbl_L3CacheSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.L3_Cache, "N/A") + " Kb";
            abort();
        }
    }
}
