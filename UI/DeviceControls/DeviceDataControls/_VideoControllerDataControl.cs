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
    public partial class _VideoControllerDataControl : DeviceDataControl
    {
        public _VideoControllerDataControl(DeviceData Device) : base(Device)
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
            CurrentDevice.UpdateCollection();
        }

        protected override void show()
        {
            base.show();
            var CurrentSubDevice = (VideoController.SubDevice)this.CurrentSubDevice;
            lbl_Name_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.Name.AsString(), "N/A"); ;
            lbl_Manufacturer_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.AdapterCompatibility.AsString(), "N/A");
            lbl_Adapter_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.AdapterDACType.AsString(), "N/A");
            lbl_Memory_Value.Text = DataConvert.AsDefaultValue(x => (Convert.ToUInt64(x) / 1024).ToString(), CurrentSubDevice.AdapterRAM.AsString(), "N/A", "{0:N0}") + " MB";
            lbl_BitsPixel_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.CurrentBitsPerPixel.AsString(), "N/A");
            lbl_HorizontalResolution_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.CurrentHorizontalResolution.AsString(), "N/A", "{0:N0}") + " Pixel";
            lbl_VerticalResolution_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.CurrentVerticalResolution.AsString(), "N/A", "{0:N0}") + " Pixel";
            lbl_FreqNow_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.CurrentRefreshRate.AsString(), "N/A") + " Hz";
            lbl_FreqMax_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MaxRefreshRate.AsString(), "N/A") + " Hz";
            lbl_FreqMin_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.MinRefreshRate.AsString(), "N/A") + " Hz";
            lbl_ColorsNumber_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.CurrentNumberOfColors.AsString(), "N/A", "{0:N0}"); ;
            lbl_ModalitySupported_Value.Text = DataConvert.AsDefaultValue(CurrentSubDevice.VideoModeDescription.AsString(), "N/A"); ;
        }
    }
}
