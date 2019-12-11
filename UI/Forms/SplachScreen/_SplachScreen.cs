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
using OperatingSystem = DiscoveryLight.Core.Device.Data.OperatingSystem;

namespace DiscoveryLight.UI.Forms.SplachScreen
{
    public partial class _SplachScreen : Form
    {
        public _SplachScreen()
        {
            InitializeComponent();     // load all device device data and performance
            this.Start();
        }

        private async void Start()
        {
            await this.InitDevice();      // first init all device
            await this.loadDevice();      // second load properties for each device and performance  
            this.Close();
            this.Dispose();
        }

        private async Task InitDevice()
        {
            Program.Devices = new List<DeviceData>();
            Program.Performances = new List<DevicePerformance>();
            Program.Devices.Add(new ComputerSystem());
            Program.Devices.Add(new OperatingSystem());
            Program.Devices.Add(new ComputerSystemProduct());
            Program.Devices.Add(new BIOS());
            Program.Devices.Add(new BaseBoard());
            Program.Devices.Add(new MotherboardDevice());
            Program.Devices.Add(new SystemSlot());
            Program.Devices.Add(new VideoController());
            Program.Devices.Add(new SoundDevice());
            Program.Devices.Add(new Processor());
            Program.Devices.Add(new PhysicalMemory());
            Program.Devices.Add(new PhysicalMemoryArray());
            Program.Devices.Add(new DiskDrive());
            Program.Devices.Add(new NetworkAdapter());
            Program.Performances.Add(new PERFORM_CPU(null));
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
                await Task.Run(() => device.GetCollection());     // get device data info
                chgBar_Devices.BarFillSize += step;              // updata loading charging bar
            }
        }
    }
}

