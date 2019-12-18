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
    public partial class _CpuDeviceDataControl : DeviceDataControl
    {
        public _CpuDeviceDataControl(DeviceData Device) : base(Device)
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
            var CurrentSubDevice = (Processor.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name.AsString(), "N/A");
            lbl_Size_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.AddressWidth.AsString(), "N/A") + " bit";
            lbl_Description_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Description.AsString(), "N/A");
            lbl_Producteur_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer.AsString(), "N/A");
            lbl_Revision_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Revision.AsString(), "N/A");
            lbl_Socket_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.SocketDesignation.AsString(), "N/A");
            lbl_Core_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NumberOfCores.AsString(), "N/A");
            lbl_Thread_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NumberOfLogicalProcessors.AsString(), "N/A");
            lbl_MaxSpeed_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MaxClockSpeed.AsString(), "N/A", "{0:N0}") + " Mhz";
            lbl_L1CacheSize_Value.Text = DataConvert.AsDefaultValue(x=> (Convert.ToInt16(x)/4).ToString(), CurrentSubDevice.L2CacheSize.AsString(), "N/A") + " Kb";
            lbl_L2CacheSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.L2CacheSize.AsString(), "N/A") + " Kb";
            lbl_L3CacheSize_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.L3CacheSize.AsString(), "N/A") + " Kb";
            abort();
        }
    }
}
