﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DiscoveryLight.Core.Device.Utils;

namespace DiscoveryLight.Core.Device.Performance
{
    #region Interface
    public interface IPreUpdate
    {
        /// <summary>
        /// Use Pre load method before update
        /// </summary>
        void PreUpdate();

        /// <summary>
        /// Check if a update has been performed
        /// </summary>
        Boolean IsUpdated { get; set; }
    }

    public interface IConvertable
    {
        /// <summary>
        /// Convert property before update
        /// </summary>
        String ConvertDeviceName(String DeviceName);

        /// <summary>
        /// Check if a conversion has been performed
        /// </summary>
        Boolean IsConverted { get; set; }

        /// <summary>
        /// Store the value to convert
        /// </summary>
        String ValueToConvert { get; set; }
    }

    /// <summary>
    /// Device Performance main class.
    /// Device Performance represents a installed device type. Each device can have more childs or subdevices(collection)
    /// PC can have more subdevices of the same type installed. For example we can have more physical disks mounted. Each of then is a Physical Disk drive.
    /// So Physical Disk is the main drive, and each of them is a subdevice.
    /// Device Performance read all performance values for all subdevice for a selected device(drive)
    /// </summary>
    /// 
    public class DevicePerformance: AbstractDevice, IConvertable, IPreUpdate
    {
        public Boolean IsConverted { get; set; }

        public Boolean IsUpdated { get; set; }

        public String ValueToConvert { get; set; }

        public virtual void PreUpdate() {
            IsUpdated = true;
        }

        public virtual String ConvertDeviceName(String DeviceName) { return null; }

        public override List<_Device> GetCollection() {
            if(!IsUpdated) PreUpdate();
            return new List<_Device>();
        }

        public override _Device GetCollection(string Device)
        {
            if (!IsUpdated) PreUpdate();
            return new _Device();
        }

        public override void UpdateCollection()
        {
            Devices = GetCollection();
        }

        public override void UpdateCollection(string Device) 
        {
            _Device Selected;
            int index=0;
            foreach (_Device device in Devices){
                try{
                    string Key = (device.GetType().GetField(PrimaryKey).GetValue(device) as MobProperty).AsString();
                    if (Key != null && Key.Equals(Device))
                        index = Devices.IndexOf(device); break;
                }
                catch{
                    Selected = null;
                }
            }

            Devices[index] = GetCollection(Device);
        }

        public override _Device GetDevice(string DeviceName, bool GetRelated)
        {
            return base.GetDevice(GetRelated ? ConvertDeviceName(DeviceName) : DeviceName);
        }

        public DevicePerformance(string DeviceName) : base(DeviceName) { }
    }

    #endregion

    #region Score

    /// <summary>
    /// Get score performance
    /// </summary>
    public class PERFORM_SCORE: DevicePerformance
    {
        public class Device: _Device
        {
            public MobProperty CPUScore;
            public MobProperty D3DScore;
            public MobProperty DiskScore;
            public MobProperty GraphicsScore;
            public MobProperty MemoryScore;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

            return collection;
        }

        public PERFORM_SCORE(): base("Win32_WinSAT") { }
    }
    #endregion

    #region Cpu: Performance

    /// <summary>
    /// Get usage for each selected cpu'thread
    /// </summary>
    public class PERFORM_CPU : DevicePerformance, IConvertable, IPreUpdate
    {
        public class Device : _Device
        {
            public MobProperty PercentProcessorTime;
            public MobProperty Frequency;
            public MobProperty PercentofMaximumFrequency;
            public MobProperty ProcessorFrequency;
            public MobProperty PercentProcessorPerformance;
            public MobProperty MaxSpeed;
            public override _Device Extend(WprManagementObject Obj)
            {
                MaxSpeed = Obj == null ? null : Obj.GetProperty("MaxClockSpeed");

                if (MaxSpeed == null || PercentProcessorPerformance == null)                         // use base frequency for tboost 
                    Frequency = ProcessorFrequency;
                else
                {
                    var frequency = Convert.ToInt16((Convert.ToUInt16(MaxSpeed.AsString())) / 100) * Convert.ToUInt16(PercentProcessorPerformance.AsString());
                    Frequency = new MobProperty(frequency);
                }

                return this;
            }
        }

        List<WprManagementObject> mjext;

        public override void PreUpdate()
        {
            base.PreUpdate();
            mjext = new WprManagementObjectSearcher("Win32_Processor").All();
        }

        public override String ConvertDeviceName(String DeviceName)
        {
            var mjx = new WprManagementObjectSearcher("Win32_Processor").Find("Name", DeviceName, "=").First();
            return mjx.GetProperty("DeviceID").AsSubString(3, 1) + ",_Total";
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj).Extend(mjext.Where(d => d.GetProperty("DeviceID").AsSubString(3, 1).Equals(mj.GetProperty("Name").AsSubString(0, 1))).FirstOrDefault()));

            return collection;
        }

        public PERFORM_CPU() : base("Win32_PerfFormattedData_Counters_ProcessorInformation") { PrimaryKey = "Name"; }
    }

    #endregion

    #region System: Performance

    /// <summary>
    /// Get Threads and Process number that are running in background
    /// </summary>
    public class PERFORM_SYSTEM: DevicePerformance
    {
        public class Device: _Device 
        { 
            public MobProperty Threads;
            public MobProperty Processes;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

            return collection;
        }

        public PERFORM_SYSTEM(): base("Win32_PerfRawData_PerfOS_System") {}
    }

    #endregion

    #region Memory
    /// <summary>
    /// Get Memory Ram performance
    /// </summary>
    public class PERFORM_RAM: DevicePerformance
    {
        public class Device : _Device
        {
            public MobProperty PerUsage;
            public MobProperty CacheBytes;
            public MobProperty CacheBytesPeak;
            public MobProperty AvailableMBytes;
            public MobProperty CommittedBytes;
            public MobProperty PagesInputPersec;
            public MobProperty PagesOutputPersec;
            public MobProperty PagesPersec;
            public MobProperty PageWritesPersec;
            public MobProperty PageReadsPersec;

            public override _Device Extend(WprManagementObject Obj)
            {
                var pUsage = (Convert.ToInt64(Obj.GetProperty("AvailableBytes").AsString()) / (Convert.ToInt64(Obj.GetProperty("CommitLimit").AsString()) / 100)).ToString();
                PerUsage = new MobProperty(pUsage);
                return this;
            }
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj).Extend(mj));

            return collection;
        }

        public PERFORM_RAM(): base("Win32_PerfRawData_PerfOS_Memory") {}

    }

    #endregion

    #region Storage

    /// <summary>
    /// Get local storage performance
    /// </summary>
    public class PERFORM_DISK: DevicePerformance, IConvertable
    {
        public class Device : _Device
        {
            public MobProperty FreeMegabytes;
            public MobProperty DiskWriteBytesPersec;
            public MobProperty DiskReadBytesPersec;
            public MobProperty DiskTransfersPersec;

            public MobProperty PercentFreeSpace;
            public MobProperty PercentDiskReadTime;
            public MobProperty PercentDiskWriteTime;
            public MobProperty PercentDiskTime;
            public MobProperty PercentIdleTime;
        }

        public override String ConvertDeviceName(String DeviceName)
        {
            var mj = new WprManagementObjectSearcher("Win32_DiskDrive").First("Caption", DeviceName, "=");
            foreach (WprManagementObject mjt in new WprManagementObjectSearcher("Win32_PerfRawData_PerfDisk_PhysicalDisk").All() ?? new List<WprManagementObject>())
            {
                String currentDrive = mjt.GetProperty("Name").AsString();
                var s = mj.GetProperty("Index").AsString();
                if (currentDrive != null && currentDrive.Substring(0, 1).Equals(mj.GetProperty("Index").AsString()))
                    return  (currentDrive.Substring(2, 1) + ":").ToString();
            }

            return null;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

            return collection;
        }

        public PERFORM_DISK(): base("Win32_PerfFormattedData_PerfDisk_LogicalDisk") { PrimaryKey = "Name"; }
    }

    #endregion

    #region Network

    /// <summary>
    /// Get Network Performance
    /// </summary>
    public class PERFORM_NETWORK: DevicePerformance, IConvertable
    {
        public class Device : _Device
        {
            public MobProperty BytesReceivedPersec;
            public MobProperty BytesSentPersec;
            public MobProperty BytesTotalPersec;
            public MobProperty PacketsReceivedPersec;
            public MobProperty PacketsSentPersec;
            public MobProperty PacketsPersec;

            public MobProperty PercentBytesReceived;
            public MobProperty PercentBytesSent;
            public MobProperty PercentPacketsReceived;
            public MobProperty PercentPacketsSents;

            public MobProperty TotalBytesReceived;
            public MobProperty TotalBytesSent;
            public MobProperty TotalBytes;

            public override _Device Extend(WprManagementObject Obj)
            {
                UInt64? Den;
                if (BytesTotalPersec.AsString() != null)
                {
                    Den = (Convert.ToUInt64(BytesTotalPersec.AsString()) / 100);

                    if (Den != 0)
                    {
                        var percentBytesReceived = BytesReceivedPersec.AsString() != null ? (Convert.ToUInt64(BytesReceivedPersec.AsString()) / (Convert.ToUInt64(BytesTotalPersec.AsString()) / 100)).ToString() : null;
                        PercentBytesReceived = new MobProperty(percentBytesReceived);
                        var percentBytesSent = BytesSentPersec.AsString() != null ? (Convert.ToUInt64(BytesSentPersec.AsString()) / (Convert.ToUInt64(BytesTotalPersec.AsString()) / 100)).ToString() : null;
                        PercentBytesSent = new MobProperty(percentBytesSent);
                    }
                    else
                    {
                        PercentBytesReceived = new MobProperty("0");
                        PercentBytesSent = new MobProperty("0");
                    }
                }
                else
                {
                    PercentBytesReceived = new MobProperty(null);
                    PercentBytesSent = new MobProperty(null);
                }

                if (PacketsPersec.AsString() != null)
                {
                    Den = (Convert.ToUInt64(PacketsPersec.AsString()) / 100);
                    if (Den != 0)
                    {
                        var percentPacketsReceived = PacketsReceivedPersec.AsString() != null ? (Convert.ToUInt64(PacketsReceivedPersec.AsString()) / (Convert.ToUInt64(PacketsPersec.AsString()) / 100)).ToString() : null;
                        PercentPacketsReceived = new MobProperty(percentPacketsReceived);
                        var percentPacketsSents = PacketsSentPersec.AsString() != null ? (Convert.ToUInt64(PacketsSentPersec.AsString()) / (Convert.ToUInt64(PacketsPersec.AsString()) / 100)).ToString() : null;
                        PercentPacketsSents = new MobProperty(percentPacketsSents);
                    }
                    else
                    {
                        PercentPacketsSents = new MobProperty("0");
                        PercentPacketsReceived = new MobProperty("0");
                    }
                }
                else
                {
                    PercentPacketsReceived = new MobProperty(null);
                    PercentPacketsSents = new MobProperty(null);
                }

                var mjx = new WprManagementObjectSearcher("Win32_PerfRawData_Tcpip_NetworkAdapter").First("Name", Name.AsString(), "=") ?? new WprManagementObject();
                TotalBytesReceived = mjx.GetProperty("BytesReceivedPersec");
                TotalBytesSent = mjx.GetProperty("BytesSentPersec");
                TotalBytes = mjx.GetProperty("BytesTotalPersec");

                return this;
            }
        }

        public override String ConvertDeviceName(String DeviceName)
        {
            return DeviceName.Replace("(", "[").Replace(")", "]"); 
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

            return collection;
        }
        
        public PERFORM_NETWORK(): base("Win32_PerfFormattedData_Tcpip_NetworkAdapter") { PrimaryKey = "Name"; }

    }

    #endregion

}
