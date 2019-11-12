using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Data;

namespace DiscoveryLight.UI.Controls.DeviceDataControls
{
    public abstract class AbstractDeviceDataControl : System.Windows.Forms.UserControl
    {
        public abstract void InitData(DeviceData Device);
        public abstract void ShowData();
    }
    public class DeviceDataControl: AbstractDeviceDataControl
    {
        private DeviceData currentDevice;
        private DeviceData._Block currentSubDevice;
        private Type deviceType;
        private String deviceName;

        public DeviceData CurrentDevice
        {
            get { return currentDevice; }
            set
            {
                currentDevice = value;
                deviceType = currentDevice.GetType();
                deviceName = currentDevice.ToString();
            }
        }
        public DeviceData._Block CurrentSubDevice { get => currentSubDevice; set => currentSubDevice = value; }
        public Type DeviceType { get => deviceType; set => deviceType = value; }
        public string DeviceName { get => deviceName; set => deviceName = value; }

        public override void InitData(DeviceData Device)
        {
            CurrentDevice = Device;
            CurrentSubDevice = (CurrentDevice.Blocks.Count != 0) ? CurrentDevice.Blocks.First() : new DeviceData._Block();
        }
        public override void ShowData() { }

        public DeviceDataControl(DeviceData Device)
        {
            InitData(Device);
        }
    }
}
