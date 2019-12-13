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
            CurrentDevice.UpdateCollection();
        }

        protected override void show()
        {
            base.show();
            var CurrentSubDevice = (Processor.Device)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A");
            lbl_Size_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.AddressWidth, "N/A") + " bit";
            lbl_Description_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Description, "N/A");
            lbl_Producteur_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_Revision_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Revision, "N/A");
            lbl_Socket_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.SocketDesignation, "N/A");
            lbl_Core_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NumberOfCores, "N/A");
            lbl_Thread_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NumberOfLogicalProcessors, "N/A");
            lbl_MaxSpeed_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MaxClockSpeed, "N/A", "{0:N0}") + " Mhz";
            lbl_L1CacheSize_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToInt16(x)/4).ToString(), CurrentSubDevice.L2CacheSize, "N/A") + " Kb";
            lbl_L2CacheSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.L2CacheSize, "N/A") + " Kb";
            lbl_L3CacheSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.L3CacheSize, "N/A") + " Kb";
            abort();
        }
    }
}
