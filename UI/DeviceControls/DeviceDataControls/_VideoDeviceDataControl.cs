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
    public partial class _VideoDeviceDataControl : DeviceDataControl
    {
        public _VideoDeviceDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _VideoDeviceDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _VideoDeviceDataControl() : base()
        {
            InitializeComponent();
        }

        public override void ShowData()
        {
            base.ShowData();
            var CurrentSubDevice = (VIDEO.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = CurrentSubDevice.Name;
            lbl_Manufacturer_Value.Text = CurrentSubDevice.Manufacturer;
            lbl_Adapter_Value.Text = CurrentSubDevice.AdpterType;
            lbl_Memory_Value.Text = (Convert.ToUInt64(CurrentSubDevice.MemorySize) / 1024).ToString() + " MB"; ;
            lbl_BitsPixel_Value.Text = CurrentSubDevice.NowBitsPerPixel;
            lbl_HorizontalResolution_Value.Text = CurrentSubDevice.NowHorizResolution + " Pixel";
            lbl_VerticalResolution_Value.Text = CurrentSubDevice.NowVertResolution + " Pixel";
            lbl_FreqNow_Value.Text = CurrentSubDevice.NowRefreshRate + " Hz";
            lbl_FreqMax_Value.Text = CurrentSubDevice.MaxRefreshRate + " Hz";
            lbl_FreqMin_Value.Text = CurrentSubDevice.MinRefreshRate + " Hz";
            lbl_ColorsNumber_Value.Text = CurrentSubDevice.NowNumberOfColors;
            lbl_ModalitySupported_Value.Text = CurrentSubDevice.Mode;
        }
    }
}
