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
    public partial class _BaseHardware : Device
    {
        public _BaseHardware(): base(typeof(PC))
        {
            InitializeComponent();
        }
        
        public override void LoadProperties() {}

    }
}
