﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.UI.BaseUserControl;


namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    /// <summary>
    /// Extend Device Control.
    /// </summary>
    public abstract class AbstractDeviceDataControl : DeviceControl
    {
        public abstract void InitData(DeviceData Device);
    }
    public class DeviceDataControl: AbstractDeviceDataControl
    {
        private DeviceData currentDevice;               // main device type
        private DeviceData._Block currentSubDevice;     // a child for the current device    
        
        public DeviceData CurrentDevice
        {
            get { return currentDevice; }
            set
            {
                if (value == null) return;
                currentDevice = value;
                CurrentSubDevice = (CurrentDevice.Blocks.Count != 0) ? CurrentDevice.Blocks.First() : new DeviceData._Block();
            }
        }
        public DeviceData._Block CurrentSubDevice
        {
            get { return currentSubDevice; }
            set { 
                currentSubDevice = value; 
                if (value != null) show();  // upadate UI when a new subdevice is selected
            } 
        }

        public override void InitData(DeviceData Device)
        {
            CurrentDevice = Device;
            CurrentSubDevice = (CurrentDevice.Blocks.Count != 0) ? CurrentDevice.Blocks.First() : new DeviceData._Block();
            show();
        }

        public DeviceDataControl(DeviceData Device) 
        {
            InitData(Device);
        }

        public DeviceDataControl(DeviceData Device, Boolean GetDriveInfo)
        {
            if (GetDriveInfo)
                Device.GetDriveInfo();
            InitData(Device);
        }

        public DeviceDataControl() { }
    }
}
