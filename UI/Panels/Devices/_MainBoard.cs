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
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _MainBoard : DevicePanel
    {
        public _MainBoard()
        {
            InitializeComponent();
            this.WindowsScoreDevicePerformanceControl.Init(Program.Performances.Where(d => d.ClassType == typeof(PERFORM_SCORE)).First());
            this.BaseBoardDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(BaseBoard)).First());
            this.MotherBoardDeviceDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(MotherboardDevice)).First());
            this.SystemSlotDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(SystemSlot)).First());
            this.BiosDeviceDataControl.Init(Program.Devices.Where(d => d.ClassType == typeof(BIOS)).First());
        }
    }
}
