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
        private string devicetoToRelate;
        private Boolean isRelated = true;

        public Boolean IsRelated { get { return isRelated; } set { isRelated = value; } }

        public Boolean IsUpdated { get; set; }

        public String DevicetoToRelate { get { return devicetoToRelate; } set { devicetoToRelate = value; IsRelated = false; } }

        public String DeviceRelated { get; set; }

        public virtual void PreUpdate()
        {
            IsUpdated = true;
        }

        public virtual String GetRelatedDevice()
        {
            IsRelated = true;
            DeviceRelated = null;
            return DeviceRelated;
        }

        public override List<_SubDevice> GetCollection()
        {
            if (!IsUpdated) PreUpdate();
            if (!IsRelated) GetRelatedDevice();
            return new List<_SubDevice>();
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            return base.GetCollection();
        }

        public override List<_SubDevice> GetCollection(Func<_SubDevice, Boolean> condition) {
            return base.GetCollection();
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
            base.GetCollection();
            return WmiCollection.Find(FieldName, Value, "=").Select(x => new SubDevice().Serialize(x)).ToList();
        }

        public override List<_SubDevice> GetCollection()
        {
            base.GetCollection();
            return WmiCollection.All().Select(x => new SubDevice().Serialize(x)).ToList();
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
            public override _SubDevice Extend(dynamic wprObj)
            {
                List<WprManagementObject> obj = wprObj as List<WprManagementObject>;
                WprManagementObject current = obj.Where(d => d.GetProperty("DeviceID").AsSubString(3, 1).Equals(Name.AsSubString(0, 1))).FirstOrDefault();

                MaxSpeed = current == null ? null : current.GetProperty("MaxClockSpeed");

                if (MaxSpeed == null || PercentProcessorPerformance == null)                         // use base frequency for tboost 
                    Frequency = ProcessorFrequency;
                else
                {
                    int? frequency = (MaxSpeed.AsInt() / 100) * PercentProcessorPerformance.AsInt();
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
            var mjx = new WprManagementObjectSearcher("Win32_Processor").Find(x => x.GetProperty("Name").AsString().Equals(DevicetoToRelate)).First();
            DeviceRelated = mjx.GetProperty("DeviceID").AsSubString(3, 1);

            return DeviceRelated;
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            base.GetCollection();
            return WmiCollection.Find(FieldName, Value, "=").Select(x => new SubDevice().Serialize(x).Extend(mjext)).ToList();
        }

        public override List<_SubDevice> GetCollection()
        {
            return GetCollectionWithPerformance(base.GetCollection());
        }

        private List<_SubDevice> GetCollectionBase(List<_SubDevice> collection)
        {
            return WmiCollection.All().Select(x => new SubDevice().Serialize(x).Extend(mjext)).ToList();
        }

        private List<_SubDevice> GetCollectionWithPerformance(List<_SubDevice> collection)
        {
            foreach (WprManagementObject mj in WmiCollection.All())
            {
                var t = new SubDevice();
                t.Name = mj.GetProperty("Name");
                t.PercentProcessorTime = mj.GetProperty("PercentProcessorTime");
                t.PercentofMaximumFrequency = mj.GetProperty("PercentofMaximumFrequency");
                t.ProcessorFrequency = mj.GetProperty("ProcessorFrequency");
                t.PercentProcessorPerformance = mj.GetProperty("PercentProcessorPerformance");
                t.Extend(mjext);
                collection.Add(t);
            }

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
            base.GetCollection();
            return WmiCollection.Find(FieldName, Value, "=").Select(x => new SubDevice().Serialize(x)).ToList();
        }

        public override List<_SubDevice> GetCollection()
        {
            base.GetCollection();
            return WmiCollection.All().Select(x => new SubDevice().Serialize(x)).ToList();
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
            base.GetCollection();
            return WmiCollection.Find(FieldName, Value, "=").Select(x => new SubDevice().Serialize(x).Extend()).ToList();
        }

        public override List<_SubDevice> GetCollection()
        {
            base.GetCollection();
            return WmiCollection.All().Select(x => new SubDevice().Serialize(x).Extend()).ToList();
        }

        public PERFORM_RAM(): base("Win32_PerfRawData_PerfOS_Memory") {}

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

            WprManagementObject mj = new WprManagementObjectSearcher("Win32_DiskDrive").First(x => x.GetProperty("Caption").AsString().Equals(DevicetoToRelate)) ?? new WprManagementObject();
            foreach (WprManagementObject mjt in new WprManagementObjectSearcher("Win32_PerfRawData_PerfDisk_PhysicalDisk").All())
            {
                string currentDrive = mjt.GetProperty("Name").AsString();
                string driveIndex = mj.GetProperty("Index").AsString();

                if (currentDrive != null && currentDrive.Substring(0, 1).Equals(driveIndex))
                    DeviceRelated = (currentDrive.Substring(2, 1) + ":").ToString();
            }

            return DeviceRelated;
        }

        public override List<_SubDevice> GetCollection(String FieldName, String Value)
        {
            base.GetCollection();
            return WmiCollection.Find(x => x.GetProperty(FieldName).AsString().Equals(Value)).Select(x => new SubDevice().Serialize(x)).ToList();
        }


        public override List<_SubDevice> GetCollection()
        {
            base.GetCollection();
            return WmiCollection.All().Select(x => new SubDevice().Serialize(x)).ToList();
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

                var mjx = new WprManagementObjectSearcher("Win32_PerfRawData_Tcpip_NetworkAdapter").First(x => x.GetProperty("Name").AsString().Equals(Name.AsString())) ?? new WprManagementObject();
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
            base.GetCollection();
            return WmiCollection.Find(FieldName, Value, "=").Select(x => new SubDevice().Serialize(x).Extend()).ToList();
        }

        public override List<_SubDevice> GetCollection()
        {
            base.GetCollection();
            return WmiCollection.All().Select(x => new SubDevice().Serialize(x).Extend()).ToList();
        }
        
        public PERFORM_NETWORK(): base("Win32_PerfFormattedData_Tcpip_NetworkAdapter") { PrimaryKey = "Name"; }

    }

    #endregion

}
