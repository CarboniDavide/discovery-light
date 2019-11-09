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
    public partial class _Video : Device
    {
        public _Video(): base(typeof(VIDEO))
        {
            InitializeComponent();
        }

        public override void LoadProperties() { }
    }
}
