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
    public partial class _VideoControllerDataControl : DeviceDataControl
    {
        public _VideoControllerDataControl(DeviceData Device) : base(Device)
        {
            InitializeComponent();
        }

        public _VideoControllerDataControl(DeviceData Device, Boolean GetDriveInfo) : base(Device, GetDriveInfo)
        {
            InitializeComponent();
        }

        public _VideoControllerDataControl() : base()
        {
            InitializeComponent();
        }

        protected override void update()
        {
            base.update();
            CurrentDevice.GetCollection();
        }

        protected override void show()
        {
            base.show();
            var CurrentSubDevice = (VideoController.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name, "N/A"); ;
            lbl_Manufacturer_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Manufacturer, "N/A");
            lbl_Adapter_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.AdpterType, "N/A");
            lbl_Memory_Value.Text = DataConvert.AsDefaultValue(x => (Convert.ToUInt64(x) / 1024).ToString(), CurrentSubDevice.MemorySize, "N/A", "{0:N0}") + " MB";
            lbl_BitsPixel_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NowBitsPerPixel, "N/A");
            lbl_HorizontalResolution_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NowHorizResolution, "N/A", "{0:N0}") + " Pixel";
            lbl_VerticalResolution_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NowVertResolution, "N/A", "{0:N0}") + " Pixel";
            lbl_FreqNow_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NowRefreshRate, "N/A") + " Hz";
            lbl_FreqMax_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MaxRefreshRate, "N/A") + " Hz";
            lbl_FreqMin_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MinRefreshRate, "N/A") + " Hz";
            lbl_ColorsNumber_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.NowNumberOfColors, "N/A", "{0:N0}"); ;
            lbl_ModalitySupported_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Mode, "N/A"); ;
        }
    }
}
