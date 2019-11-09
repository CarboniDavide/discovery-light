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

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _MainBoard : Device
    {
        public _MainBoard(): base(typeof(MAINBOARD))
        {
            InitializeComponent();
        }

        public override void LoadProperties() { }
    }
}
