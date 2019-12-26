using DiscoveryLight.Core.Device.Data;
using System;
using System.Data;
using System.Linq;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Audio : DevicePanel
    {
        public _Audio()
        {
            InitializeComponent();
            this.AudioDeviceDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(SoundDevice)).First());
        }

        private void _Audio_Load(object sender, EventArgs e)
        {
            cmb_Blocks.Init(AudioDeviceDataControl, null, null);
        }
    }
}
