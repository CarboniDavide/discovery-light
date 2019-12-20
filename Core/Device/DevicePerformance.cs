using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DiscoveryLight.Core.Device.Utils;

namespace DiscoveryLight.Core.Device.Performance
{
    #region Interface
    
    /// <summary>
    /// Device Performance main class.
    /// Device Performance represents a installed device type. Each device can have more childs or subdevices(collection)
    /// PC can have more subdevices of the same type installed. For example we can have more physical disks mounted. Each of then is a Physical Disk drive.
    /// So Physical Disk is the main drive, and each of them is a subdevice.
    /// Device Performance read all performance values for all subdevice for a selected device(drive)
    /// </summary>
    /// 
    public class DevicePerformance: _Device, IRelatable, IPreUpdate
    {
        public DevicePerformance(string DeviceName) : base(DeviceName) { }
    }

    #endregion

    #region Score

    /// <summary>
    /// Get score performance
    /// </summary>
    public class PERFORM_SCORE: DevicePerformance
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty CPUScore;
            public MobProperty D3DScore;
            public MobProperty DiskScore;
            public MobProperty GraphicsScore;
            public MobProperty MemoryScore;
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            var collection = base.GetCollection();

            var mj = new WprManagementObjectSearcher(DeviceName).First(FieldName, Value, "=") ?? new WprManagementObject();
            collection.Add(new SubDevice().Serialize(mj));

            return collection;
        }

        public override List<_SubDevice> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new SubDevice().Serialize(mj));

            return collection;
        }

        public PERFORM_SCORE(): base("Win32_WinSAT") { }
    }
    #endregion

    #region Cpu: Performance

    /// <summary>
    /// Get usage for each selected cpu'thread
    /// </summary>
    public class PERFORM_CPU : DevicePerformance, IRelatable, IPreUpdate
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty PercentProcessorTime;
            public MobProperty Frequency;
            public MobProperty PercentofMaximumFrequency;
            public MobProperty ProcessorFrequency;
            public MobProperty PercentProcessorPerformance;
            public MobProperty MaxSpeed;
            public override _SubDevice Extend(dynamic Obj)
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

        public override String GetRelatedDevice()
        {
            DeviceRelated = base.GetRelatedDevice();
            var mjx = new WprManagementObjectSearcher("Win32_Processor").Find("Name", DevicetoToRelate, "=").First();
            DeviceRelated = mjx.GetProperty("DeviceID").AsSubString(3, 1);

            return DeviceRelated;
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            var collection = base.GetCollection();

            var mj = new WprManagementObjectSearcher(DeviceName).First(FieldName, Value, "=") ?? new WprManagementObject();
            collection.Add(new SubDevice().Serialize(mj).Extend(mjext.Where(d => d.GetProperty("DeviceID").AsSubString(3, 1).Equals(mj.GetProperty("Name").AsSubString(0, 1))).FirstOrDefault()));

            return collection;
        }

        public override List<_SubDevice> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new SubDevice().Serialize(mj).Extend(mjext.Where(d => d.GetProperty("DeviceID").AsSubString(3, 1).Equals(mj.GetProperty("Name").AsSubString(0, 1))).FirstOrDefault()));

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
        public class SubDevice : _SubDevice 
        { 
            public MobProperty Threads;
            public MobProperty Processes;
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            var collection = base.GetCollection();

            var mj = new WprManagementObjectSearcher(DeviceName).First(FieldName, Value, "=") ?? new WprManagementObject();
            collection.Add(new SubDevice().Serialize(mj));

            return collection;
        }

        public override List<_SubDevice> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new SubDevice().Serialize(mj));

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
        public class SubDevice : _SubDevice
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
            public MobProperty CommitLimit;
            public MobProperty AvailableBytes;

            public override _SubDevice Extend()
            {
                PerUsage = (CommitLimit.IsNull || AvailableBytes.IsNull) ? new MobProperty(null) : new MobProperty((Convert.ToInt64(AvailableBytes.AsString()) / (Convert.ToInt64(CommitLimit.AsString()) / 100)).ToString());
                return this;
            }
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            var collection = base.GetCollection();

            var mj = new WprManagementObjectSearcher(DeviceName).First(FieldName, Value, "=") ?? new WprManagementObject();
            collection.Add(new SubDevice().Serialize(mj).Extend());

            return collection;
        }

        public override List<_SubDevice> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new SubDevice().Serialize(mj).Extend());

            return collection;
        }

        public PERFORM_RAM(): base("Win32_PerfRawData_PerfOS_emory") {}

    }

    #endregion

    #region Storage

    /// <summary>
    /// Get local storage performance
    /// </summary>
    public class PERFORM_DISK: DevicePerformance, IRelatable
    {
        public class SubDevice : _SubDevice
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

        public override String GetRelatedDevice()
        {
            DeviceRelated = base.GetRelatedDevice();

            var mj = new WprManagementObjectSearcher("Win32_DiskDrive").First("Caption", DevicetoToRelate, "=");
            foreach (WprManagementObject mjt in new WprManagementObjectSearcher("Win32_PerfRawData_PerfDisk_PhysicalDisk").All() ?? new List<WprManagementObject>())
            {
                String currentDrive = mjt.GetProperty("Name").AsString();
                var s = mj.GetProperty("Index").AsString();
                if (currentDrive != null && currentDrive.Substring(0, 1).Equals(mj.GetProperty("Index").AsString()))
                    DeviceRelated = (currentDrive.Substring(2, 1) + ":").ToString();
            }

            return DeviceRelated;
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            var collection = base.GetCollection();

            var mj = new WprManagementObjectSearcher(DeviceName).First(FieldName, Value, "=") ?? new WprManagementObject();
            collection.Add(new SubDevice().Serialize(mj));

            return collection;
        }


        public override List<_SubDevice> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new SubDevice().Serialize(mj));

            return collection;
        }

        public PERFORM_DISK(): base("Win32_PerfFormattedData_PerfDisk_LogicalDisk") { PrimaryKey = "Name"; }
    }

    #endregion

    #region Network

    /// <summary>
    /// Get Network Performance
    /// </summary>
    public class PERFORM_NETWORK: DevicePerformance, IRelatable
    {
        public class SubDevice : _SubDevice
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

            public override _SubDevice Extend()
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

        public override String GetRelatedDevice()
        {
            DeviceRelated = base.GetRelatedDevice();
            DeviceRelated = DevicetoToRelate.Replace("(", "[").Replace(")", "]");
            return DeviceRelated;
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            var collection = base.GetCollection();

            var mj = new WprManagementObjectSearcher(DeviceName).First(FieldName, Value, "=") ?? new WprManagementObject();
            collection.Add(new SubDevice().Serialize(mj).Extend());

            return collection;
        }

        public override List<_SubDevice> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new SubDevice().Serialize(mj).Extend());

            return collection;
        }
        
        public PERFORM_NETWORK(): base("Win32_PerfFormattedData_Tcpip_NetworkAdapter") { PrimaryKey = "Name"; }

    }

    #endregion

}
