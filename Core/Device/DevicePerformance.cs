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

    public interface PreGetPerformance
    {
        void PreGetPerformance();
        Boolean IsPreGetPerformance { get; set; }
    }


    /// <summary>
    /// Device Performance main class.
    /// Device Performance represents a installed device type. Each device can have more childs or subdevices(collection)
    /// PC can have more subdevices of the same type installed. For example we can have more physical disks mounted. Each of then is a Physical Disk drive.
    /// So Physical Disk is the main drive, and each of them is a subdevice.
    /// Device Performance read all performance values for all subdevice for a selected device(drive)
    /// </summary>
    /// 
    public abstract class DevicePerformance: PreGetPerformance
    {
        protected readonly string deviceName;
        protected readonly string className;
        protected readonly Type classType;

        private string currentSelected;
        private string relatedSelected;

        public Boolean IsPreGetPerformance { get; set; }
        public string DeviceName { get => deviceName; }
        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public string CurrentSelected { get { return currentSelected; } set { currentSelected = value; IsPreGetPerformance = true; } }
        public string RelatedSelected { get => relatedSelected; set => relatedSelected = value; }

        public virtual void PreGetPerformance() {}

        /// <summary>
        /// Get properties performance for each installed drive
        /// </summary>
        public abstract void GetPerformance();
        public DevicePerformance(string DeviceName)
        {
            this.deviceName=  DeviceName;
            this.className=  this.GetType().Name;
            this.classType=  this.GetType();
        }
    }

    #endregion

    #region Score

    /// <summary>
    /// Get score performance
    /// </summary>
    public class PERFORM_SCORE: DevicePerformance
    {
        public String Cpu;
        public String D3D;
        public String Hd;
        public String Graph;
        public String Ram;

        public override void GetPerformance()
        {
            // get all properties for each installed drive
            foreach (WprManagementObject mj in new WprManagementObjectSearcher("Win32_WinSAT").All() ?? new List<WprManagementObject>())
            {
                this.Cpu=  mj.GetProperty("CPUScore").AsString();           // cpu 
                this.D3D=  mj.GetProperty("D3DScore").AsString();           // d3d 
                this.Hd=  mj.GetProperty("DiskScore").AsString();           // storage
                this.Graph=  mj.GetProperty("GraphicsScore").AsString();    // graph
                this.Ram=  mj.GetProperty("MemoryScore").AsString();        // memory
            }
        }

        public PERFORM_SCORE(): base("Score Performance") {}
    }
    #endregion

    #region Cpu: Performance

    /// <summary>
    /// Get usage for each selected cpu'thread
    /// </summary>
    public class PERFORM_CPU: DevicePerformance, PreGetPerformance
    {
        public struct Thread
        {
            public String Usage;
            public String Name;
            public String Frequency;
            public String PercentofMaximumFrequency;
            public String ProcessorFrequency;
            public String TBooster;
            public String PercentProcessorPerformance;
        }

        public List<Thread> Cpu=  new List<Thread>();                 // Cpu list of thread
        string Maxsp = null;
        public override void PreGetPerformance()
        {
            IsPreGetPerformance = false;
            var mj = new WprManagementObjectSearcher("Win32_Processor").Find("Name", CurrentSelected, "=").First();
            Maxsp = mj.GetProperty("MaxClockSpeed").AsString();
            RelatedSelected = mj.GetProperty("DeviceID").AsSubString(3, 1);
        }

        public override void GetPerformance()
        {
            if (IsPreGetPerformance) PreGetPerformance();

            this.Cpu=  new List<Thread>();
            // create a list of thread for the selected cpu
            foreach (WprManagementObject mj in new WprManagementObjectSearcher("Win32_PerfFormattedData_Counters_ProcessorInformation").All() ?? new List<WprManagementObject>() { new WprManagementObject()})
            {
                string CpuName = mj.GetProperty("Name").AsSubString(0, 1);
                if (CpuName != null && CpuName.Equals(RelatedSelected))
                {
                    Thread t=  new Thread();                                                                        // create a new Thread
                    t.Name=  mj.GetProperty("Name").AsString();                                          // get thread name
                    t.Usage=  mj.GetProperty("PercentProcessorTime").AsString();                         // get thread dpcreate value 
                    t.PercentofMaximumFrequency = mj.GetProperty("PercentofMaximumFrequency").AsString();
                    t.ProcessorFrequency = mj.GetProperty("ProcessorFrequency").AsString();
                    t.PercentProcessorPerformance = mj.GetProperty("PercentProcessorPerformance").AsString();
                    // calculate frequency using turbo speed
                    if (Maxsp == null || t.PercentProcessorPerformance == null)                                      // use base frequency for tboost 
                        t.Frequency = t.ProcessorFrequency;
                    else
                        t.Frequency = Convert.ToUInt16((Convert.ToDouble(Maxsp) / 100) * Convert.ToUInt16(t.PercentProcessorPerformance)).ToString();
                    this.Cpu.Add(t);
                }
            }
        }

        public PERFORM_CPU(string cpu): base("Cpu Performance")
        {
            this.RelatedSelected=  cpu;
        }

        public PERFORM_CPU(): base("Cpu Performance") { }
    }

    #endregion

    #region System: Performance

    /// <summary>
    /// Get Threads and Process number that are running in background
    /// </summary>
    public class PERFORM_SYSTEM: DevicePerformance
    {
        public String Threads;
        public String Processes;

        public override void GetPerformance()
        {
            // get thread and process loaded
            foreach (WprManagementObject mj in new WprManagementObjectSearcher("Win32_PerfRawData_PerfOS_System").All() ?? new List<WprManagementObject> { new WprManagementObject()}){
                this.Threads=  mj.GetProperty("Threads").AsString();
                this.Processes=  mj.GetProperty("Processes").AsString();
            }
        }

        public PERFORM_SYSTEM(): base("System Base Performance") {}
    }

    #endregion

    #region Base Pc Performances

    /// <summary>
    /// Get General Pc informations as Storage size Memory used and Cpu usage
    /// </summary>
    public class PERFORM_PC: DevicePerformance
    {

        public String Per_DiskSizeFree;
        public String Per_CpuUsage;
        public String Per_RamSizeUsed;

        public override void GetPerformance()
        {
            // Storage
            var mj = new WprManagementObjectSearcher("Win32_PerfFormattedData_PerfDisk_LogicalDisk").First("Name", "_Total", "=") ?? new WprManagementObject();
            this.Per_DiskSizeFree=  mj.GetProperty("PercentFreeSpace").AsString();

            // Memory
            mj = new WprManagementObjectSearcher("Win32_PerfFormattedData_PerfOS_Memory").First() ?? new WprManagementObject();
            this.Per_RamSizeUsed=  mj.GetProperty("PercentCommittedBytesInUse").AsString();

            // Cpu
            mj = new WprManagementObjectSearcher("Win32_PerfFormattedData_Counters_ProcessorInformation").First("Name", "_Total", "=") ?? new WprManagementObject();
            this.Per_CpuUsage=  mj.GetProperty("PercentProcessorTime").AsString();
        }

        public PERFORM_PC(): base("Pc Base Performance") {}
    }

    #endregion

    #region Memory
    /// <summary>
    /// Get Memory Ram performance
    /// </summary>
    public class PERFORM_RAM: DevicePerformance
    {
        public String PerUsage;
        public String CacheUsage;
        public String MaxCacheUsage;
        public String Free;
        public String MemoryOut;
        public String PageIn;
        public String PageOut;
        public String PagePerSec;
        public String PageWrite;
        public String PageRead;

        public override void GetPerformance()
        {
            // get all memory ram properties from the collection
            foreach (WprManagementObject mj in new WprManagementObjectSearcher("Win32_PerfRawData_PerfOS_Memory").All() ?? new List<WprManagementObject> { new WprManagementObject()})
            {
                this.CacheUsage=  mj.GetProperty("CacheBytes").AsString();
                this.MaxCacheUsage=  mj.GetProperty("CacheBytesPeak").AsString();
                this.Free=  mj.GetProperty("AvailableMBytes").AsString();
                this.MemoryOut=  mj.GetProperty("CommittedBytes").AsString();
                this.PageIn=  mj.GetProperty("PagesInputPersec").AsString();
                this.PageOut=  mj.GetProperty("PagesOutputPersec").AsString();
                this.PageWrite=  mj.GetProperty("PageWritesPersec").AsString();
                this.PageRead=  mj.GetProperty("PageReadsPersec").AsString();
                this.PagePerSec=  mj.GetProperty("PagesPersec").AsString();
                this.PerUsage=  (Convert.ToInt64(mj.GetProperty("AvailableBytes").AsString()) / (Convert.ToInt64(mj.GetProperty("CommitLimit").AsString()) / 100)).ToString();
            }
        }

        public PERFORM_RAM(): base("Memory Performance") {}

    }

    #endregion

    #region Storage

    /// <summary>
    /// Get local storage performance
    /// </summary>
    public class PERFORM_DISK: DevicePerformance, PreGetPerformance
    {
        public String FreeSpace;
        public String WriteBytesPerSec;
        public String ReadBytesPerSec;
        public String TransferPerSec;

        public String Percent_FreeSpace;
        public String Percent_ReadTime;
        public String Percent_WriteTime;
        public String Percent_DiskTime;
        public String Percent_IdleTime;

        public override void PreGetPerformance()
        {
            var mj = new WprManagementObjectSearcher("Win32_DiskDrive").First("Caption", CurrentSelected, "=");
            foreach (WprManagementObject mjt in new WprManagementObjectSearcher("Win32_PerfRawData_PerfDisk_PhysicalDisk").All() ?? new List<WprManagementObject>())
            {
                String currentDrive = mjt.GetProperty("Name").AsString();
                var s = mj.GetProperty("Index").AsString();
                if (currentDrive != null && currentDrive.Substring(0, 1).Equals(mj.GetProperty("Index").AsString()))
                    RelatedSelected =  (currentDrive.Substring(2, 1) + ":").ToString();
            }
        }

        public override void GetPerformance()
        {
            if (IsPreGetPerformance) PreGetPerformance();
            var mj = new WprManagementObjectSearcher("Win32_PerfFormattedData_PerfDisk_LogicalDisk").First("Name", RelatedSelected, "=") ?? new WprManagementObject();
            FreeSpace=  mj.GetProperty("FreeMegabytes").AsString();
            WriteBytesPerSec=  mj.GetProperty("DiskWriteBytesPersec").AsString();
            ReadBytesPerSec=  mj.GetProperty("DiskReadBytesPersec").AsString();
            TransferPerSec=  mj.GetProperty("DiskTransfersPersec").AsString();
            Percent_FreeSpace=  mj.GetProperty("PercentFreeSpace").AsString();
            Percent_ReadTime=  mj.GetProperty("PercentDiskReadTime").AsString();
            Percent_WriteTime=  mj.GetProperty("PercentDiskWriteTime").AsString();
            Percent_DiskTime=  mj.GetProperty("PercentDiskTime").AsString();
            Percent_IdleTime=  mj.GetProperty("PercentIdleTime").AsString();
        }

        public PERFORM_DISK(string DriveName): base("Storage Performance")
        {
            this.RelatedSelected=  DriveName;
        }

        public PERFORM_DISK(): base("Storage Performance") { }
    }

    #endregion

    #region Network

    /// <summary>
    /// Get Network Performance
    /// </summary>
    public class PERFORM_NETWORK: DevicePerformance, PreGetPerformance
    {
        public String ByteReceivedPerSec;
        public String BytesSentPerSec;
        public String BytesTotalPerSec;
        public String PacketsReceivedsPerSec;
        public String PacketsSentPerSec;
        public String PacketsTotalPerSec;

        public String PercentBytesReceived;
        public String PercentBytesSent;
        public String PercentPacketsReceived;
        public String PercentPacketsSents;

        public String TotalBytesReceived;
        public String TotalBytesSent;
        public String TotalBytes;

        public override void PreGetPerformance()
        {
            RelatedSelected = CurrentSelected.Replace("(", "[");
            RelatedSelected = RelatedSelected.Replace(")", "]");
        }

        public override void GetPerformance()
        {
            if (IsPreGetPerformance) PreGetPerformance();
            UInt64? Den;
            // get properties from the selected network adapter
            var mj = new WprManagementObjectSearcher("Win32_PerfFormattedData_Tcpip_NetworkAdapter").First("Name", RelatedSelected, "=") ?? new WprManagementObject();
            ByteReceivedPerSec=  mj.GetProperty("BytesReceivedPersec").AsString();
            BytesSentPerSec=  mj.GetProperty("BytesSentPersec").AsString();
            BytesTotalPerSec=  mj.GetProperty("BytesTotalPersec").AsString();
            PacketsReceivedsPerSec=  mj.GetProperty("PacketsReceivedPersec").AsString();
            PacketsSentPerSec=  mj.GetProperty("PacketsSentPersec").AsString();
            PacketsTotalPerSec=  mj.GetProperty("PacketsPersec").AsString();

            // convert values
            if (BytesTotalPerSec != null)
            {
                Den=  (Convert.ToUInt64(BytesTotalPerSec) / 100);

                if (Den != 0)
                {
                    PercentBytesReceived=  ByteReceivedPerSec != null ? (Convert.ToUInt64(ByteReceivedPerSec) / (Convert.ToUInt64(BytesTotalPerSec) / 100)).ToString() : null;
                    PercentBytesSent=  BytesSentPerSec != null ? (Convert.ToUInt64(BytesSentPerSec) / (Convert.ToUInt64(BytesTotalPerSec) / 100)).ToString() : null;
                }
                else
                {
                    PercentBytesReceived=  "0";
                    PercentBytesSent=  "0";
                }
            }
            else
            {
                PercentBytesReceived = null;
                PercentBytesSent = null;
            }

            if (PacketsTotalPerSec != null)
            {
                Den = (Convert.ToUInt64(PacketsTotalPerSec) / 100);
                if (Den != 0)
                {
                    PercentPacketsReceived = PacketsReceivedsPerSec != null ? (Convert.ToUInt64(PacketsReceivedsPerSec) / (Convert.ToUInt64(PacketsTotalPerSec) / 100)).ToString() : null;
                    PercentPacketsSents = PacketsSentPerSec != null ? (Convert.ToUInt64(PacketsSentPerSec) / (Convert.ToUInt64(PacketsTotalPerSec) / 100)).ToString() : null;
                }
                else
                {
                    PercentPacketsSents = "0";
                    PercentPacketsReceived = "0";
                }
            }
            else {
                PercentPacketsReceived = null;
                PercentPacketsSents = null;
            }

            mj = new WprManagementObjectSearcher("Win32_PerfRawData_Tcpip_NetworkAdapter").First("Name", RelatedSelected, "=") ?? new WprManagementObject();
            TotalBytesReceived = mj.GetProperty("BytesReceivedPersec").AsString();
            TotalBytesSent = mj.GetProperty("BytesSentPersec").AsString();
            TotalBytes = mj.GetProperty("BytesTotalPersec").AsString();
        }
        
        public PERFORM_NETWORK(string NetworkName): base("Network Performance")
        {
                RelatedSelected=  NetworkName;
        }

        public PERFORM_NETWORK(): base("Network Performance") { }

    }

    #endregion

}
