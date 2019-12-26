using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System.Data;
using System.Linq;

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
