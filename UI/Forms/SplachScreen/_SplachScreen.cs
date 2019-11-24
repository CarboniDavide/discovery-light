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
            Program.Devices = new List<DeviceData>();
            Program.Performances = new List<DevicePerformance>();
            Program.Devices.Add(new CPU());
            Program.Devices.Add(new DISK());
            Program.Devices.Add(new NETWORK());
            Program.Devices.Add(new PC());
            Program.Devices.Add(new VIDEO());
            Program.Devices.Add(new AUDIO());
            Program.Devices.Add(new BIOS());
            Program.Devices.Add(new MAINBOARD());
            Program.Devices.Add(new RAM());
            Program.Performances.Add(new PERFORM_CPU(null, null));
            Program.Performances.Add(new PERFORM_DISK());
            Program.Performances.Add(new PERFORM_NETWORK(null));
            Program.Performances.Add(new PERFORM_PC());
            Program.Performances.Add(new PERFORM_RAM());
            Program.Performances.Add(new PERFORM_SCORE());
            Program.Performances.Add(new PERFORM_SYSTEM());
        }

        private async Task loadDevice()
        {
            chgBar_Devices.BarFillSize = 0;
            int step = 100 / Program.Devices.Count;
            foreach (DeviceData device in Program.Devices)
            {
                lbl_LoadIDeviceInfo.Text = "Loading data for: " + device.ClassName.ToLower();
                await Task.Run(() => device.GetDriveInfo());
                chgBar_Devices.BarFillSize += step;
            }
        }
    }
}

