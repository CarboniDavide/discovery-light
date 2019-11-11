using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.Forms.SplachScreen
{
    public partial class _SplachScreen : Form
    {
        public _SplachScreen()
        {
            InitializeComponent();
            this.Start();
        }

        private async void Start()
        {
            await this.InitDevice();
            await this.loadDevice();
            this.Close();
            this.Dispose();
        }

        private async Task InitDevice()
        {
            Program.Devices = new List<Device>();
            Program.Performances = new List<Performance>();
            Program.Devices.Add(new Device(new CPU()));
            Program.Devices.Add(new Device(new DISK()));
            Program.Devices.Add(new Device(new NETWORK()));
            Program.Devices.Add(new Device(new PC()));
            Program.Devices.Add(new Device(new VIDEO()));
            Program.Devices.Add(new Device(new AUDIO()));
            Program.Devices.Add(new Device(new BIOS()));
            Program.Devices.Add(new Device(new MAINBOARD()));
            Program.Devices.Add(new Device(new RAM()));
            Program.Performances.Add(new Performance(new PERFORM_CPU(null, null)));
            Program.Performances.Add(new Performance(new PERFORM_DISK()));
            Program.Performances.Add(new Performance(new PERFORM_NETWORK(null)));
            Program.Performances.Add(new Performance(new PERFORM_PC()));
            Program.Performances.Add(new Performance(new PERFORM_RAM()));
            Program.Performances.Add(new Performance(new PERFORM_SCORE()));
            Program.Performances.Add(new Performance(new PERFORM_SYSTEM()));
        }

        private async Task loadDevice()
        {
            chgBar_Devices.BarFillSize = 0;
            int step = 100 / Program.Devices.Count;
            foreach (Device device in Program.Devices)
            {
                lbl_LoadIDeviceInfo.Text = "Loading data for: " + device.Name.ToLower();
                await Task.Run(() => device.Properties.GetDriveInfo());
                chgBar_Devices.BarFillSize += step;
            }
        }
    }
}

