using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Main : Form
    {
        public _Main()
        {
            InitializeComponent();
            this.LoadFirstDevice();
        }

        private void LoadFirstDevice()
        {
            this.DeviceContainer.Controls.Add(new _BaseHardware());
        }
    }
}
