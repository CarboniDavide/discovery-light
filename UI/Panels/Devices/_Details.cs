using System;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _Details : DevicePanel
    {
        public _Details()
        {
            InitializeComponent();
        }

        private void _Details_Load(object sender, EventArgs e)
        {
            this.WmiNameSpace.Start();
        }
    }
}
