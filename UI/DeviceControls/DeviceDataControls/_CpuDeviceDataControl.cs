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
    public partial class _CpuDeviceDataControl : DeviceDataControl
    {
        public _CpuDeviceDataControl(): base()
        {
            InitializeComponent();
            if (Program.Devices != null)
                InitData(Program.Devices.Where(d => d.Properties.GetType() == typeof(CPU)).First().Properties);
        }

        public override void ShowData()
        {
            base.ShowData();
            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = CurrentSubDevice.Name;
            lbl_Size_Value.Text = CurrentSubDevice.AddressSize;
            lbl_Description_Value.Text = CurrentSubDevice.Description;
            lbl_Producteur_Value.Text = CurrentSubDevice.Manufacturer;
            lbl_Revision_Value.Text = CurrentSubDevice.Revision;
            lbl_Socket_Value.Text = CurrentSubDevice.Socket;
            lbl_Core_Value.Text = CurrentSubDevice.N_Core;
            lbl_Thread_Value.Text = CurrentSubDevice.N_Thread;
            lbl_MaxSpeed_Value.Text = CurrentSubDevice.MaxSpeed + " Mhz";
            lbl_L1CacheSize_Value.Text = CurrentSubDevice.L1_Cache + " Kb";
            lbl_L2CacheSize_Value.Text = CurrentSubDevice.L2_Cache + " Kb";
            lbl_L3CacheSize_Value.Text = CurrentSubDevice.L3_Cache + " Kb";
        }
    }
}
