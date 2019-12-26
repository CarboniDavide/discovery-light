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
    public partial class _ComputerSystemDataControl : DeviceDataControl
    {
        public _ComputerSystemDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _ComputerSystemDataControl() : base()
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
            var CurrentDevice = (ComputerSystem.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Name, "N/A");
            lbl_Type_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.SystemType, "N/A");
            lbl_Manufaturer_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Manufacturer, "N/A");
            lbl_Model_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Model, "N/A");
            lbl_User_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.UserName, "N/A");
            lbl_Domain_Value.Text = MobPropertyDataConvert.AsDefaultValue(CurrentDevice.Domain, "N/A");
            abort();
        }
    }
}
