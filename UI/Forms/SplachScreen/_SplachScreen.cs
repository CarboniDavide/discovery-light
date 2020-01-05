using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using OperatingSystem = DiscoveryLight.Core.Device.Data.OperatingSystem;
using DiscoveryLight.Core.Commun;

namespace DiscoveryLight.UI.Forms.SplachScreen
{
    public partial class _SplachScreen : Form
    {
        public _SplachScreen()
        {
            InitializeComponent();          // load all device device data and performance
            this.checkVersion();            // check for requireed framework
            this.Start();                   // start to load all devices
        }

        private void checkVersion()
        {
            NetFramework net = new NetFramework();
            if (!net.IsRequiredInstalled)
            {
                MessageBox.Show("Discovery Require " + net.RequiredVersionFull, "Discovery Version Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
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
            Program.Performances.Add(new PERFORM_CPU());
            Program.Performances.Add(new PERFORM_DISK());
            Program.Performances.Add(new PERFORM_NETWORK());
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
                await Task.Run(() => device.UpdateCollection());     // get device data info
                chgBar_Devices.BarFillSize += step;              // updata loading charging bar
            }
        }
    }
}

