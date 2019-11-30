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
    public abstract class DevicePerformance
    {
        protected readonly string deviceName;
        protected readonly string className;
        protected readonly Type classType;
        public string DeviceName { get => deviceName; }
        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        /// <summary>
        /// Get properties performance for each installed drive
        /// </summary>
        public abstract void GetPerformance();
        public DevicePerformance(string DeviceName)
        {
            this.deviceName = DeviceName;
            this.className = this.GetType().Name;
            this.classType = this.GetType();
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_WinSAT"))
            {
                this.Cpu = DeviceUtils.GetProperty("CPUScore", mj);           // cpu 
                this.D3D = DeviceUtils.GetProperty("D3DScore", mj);           // d3d 
                this.Hd = DeviceUtils.GetProperty("DiskScore", mj);           // storage
                this.Graph = DeviceUtils.GetProperty("GraphicsScore", mj);    // graph
                this.Ram = DeviceUtils.GetProperty("MemoryScore", mj);        // memory
            }
        }

        public PERFORM_SCORE(): base("Score Performance") {}
    }
    #endregion

    #region Cpu: Performance

    /// <summary>
    /// Get usage for each selected cpu'thread
    /// </summary>
    public class PERFORM_CPU: DevicePerformance
    {
        public struct Thread
        {
            public String DPCRate;
            public String Name;
            public String Frequency;
        }

        public List<Thread> Cpu = new List<Thread>();                 // Cpu list of thread
        private string selectedCpu;
        private string selectedThread;

        public string SelectedCpu
        {
            get { return selectedCpu; }
            set { selectedCpu = value; this.MakeName(); }
        }
        public string SelectedThread {
            get { return selectedThread; }
            set { selectedThread = value; this.MakeName(); }
        }

        public string MakeName() {
            return (this.selectedCpu != null && this.selectedThread != null) ? this.selectedCpu + "," + this.selectedThread : null;
        }
        public override void GetPerformance()
        {
            if (this.selectedCpu == null) return;
            this.Cpu = new List<Thread>();
            // create a list of thread for the selected cpu
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_Counters_ProcessorInformation")){
                if (DeviceUtils.GetProperty("Name", mj, 0, 1).Equals(this.selectedCpu))
                {
                    Thread t = new Thread();                                                                        // create a new Thread
                    t.Name = DeviceUtils.GetProperty("Name", mj);                    // get thread name
                    t.DPCRate = DeviceUtils.GetProperty("DPCRate", mj);              // get thread dpcreate value 
                    t.Frequency = DeviceUtils.GetProperty("ProcessorFrequency", mj); // get speed
                    this.Cpu.Add(t);
                }
            }
        }

        public PERFORM_CPU(string cpu, string thread): base("Cpu Performance")
        {
            this.SelectedCpu = cpu;
            this.SelectedThread = thread;
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_System")){
                this.Threads = DeviceUtils.GetProperty("Threads", mj);
                this.Processes = DeviceUtils.GetProperty("Processes", mj);
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_PerfDisk_LogicalDisk", "Name", "_Total", DeviceUtils.Operator.Egual))
                this.Per_DiskSizeFree = DeviceUtils.GetProperty("PercentFreeSpace", mj);

            // Memory
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_PerfOS_Memory"))
                this.Per_RamSizeUsed = DeviceUtils.GetProperty("PercentCommittedBytesInUse", mj);

            // Cpu
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Processor", "Name", "_Total", DeviceUtils.Operator.Egual))
                this.Per_CpuUsage = DeviceUtils.GetProperty("DPCRate", mj);
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Memory"))
            {
                this.CacheUsage = DeviceUtils.GetProperty("CacheBytes", mj);
                this.MaxCacheUsage = DeviceUtils.GetProperty("CacheBytesPeak", mj);
                this.Free = DeviceUtils.GetProperty("AvailableMBytes", mj);
                this.MemoryOut = DeviceUtils.GetProperty("CommittedBytes", mj);
                this.PageIn = DeviceUtils.GetProperty("PagesInputPersec", mj);
                this.PageOut = DeviceUtils.GetProperty("PagesOutputPersec", mj);
                this.PageWrite = DeviceUtils.GetProperty("PageWritesPersec", mj);
                this.PageRead = DeviceUtils.GetProperty("PageReadsPersec", mj);
                this.PagePerSec = DeviceUtils.GetProperty("PagesPersec", mj);
                this.PerUsage = (Convert.ToInt64(DeviceUtils.GetProperty("AvailableBytes", mj)) / (Convert.ToInt64(DeviceUtils.GetProperty("CommitLimit", mj)) / 100)).ToString();
            }
        }

        public PERFORM_RAM(): base("Memory Performance") {}

    }

    #endregion

    #region Storage

    /// <summary>
    /// Get local storage performance
    /// </summary>
    public class PERFORM_DISK: DevicePerformance
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

        private int? _driveIndex;
        private string _driveName;

        public int? DriveIndex {
            get { return _driveIndex; }
            set { _driveIndex = value; this.FindDrive(); }
        }

        public string DriveName { get => _driveName; set => _driveName = value; }

        /// <summary>
        /// Get the selected physical disk from all collection using index
        /// </summary>
        public void FindDrive()
        {
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_PhysicalDisk"))
            {
                String currentDrive = DeviceUtils.GetProperty("Name", mj);

                if (currentDrive.Substring(0, 1).Equals(this.DriveIndex.ToString()))
                    this._driveName = currentDrive.Substring(2, 1) + ":";
            }
        }

        public override void GetPerformance()
        {
            if (this.DriveIndex == null) return;
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_PerfDisk_LogicalDisk"))
            {
                String currentDriveName = DeviceUtils.GetProperty("Name", mj);
                // get only properties from selected drive
                if (currentDriveName.Equals(this.DriveName))
                {
                    this.FreeSpace = DeviceUtils.GetProperty("FreeMegabytes", mj);
                    this.WriteBytesPerSec = DeviceUtils.GetProperty("DiskWriteBytesPersec", mj);
                    this.ReadBytesPerSec = DeviceUtils.GetProperty("DiskReadBytesPersec", mj);
                    this.TransferPerSec = DeviceUtils.GetProperty("DiskTransfersPersec", mj);
                    this.Percent_FreeSpace = DeviceUtils.GetProperty("PercentFreeSpace", mj);
                    this.Percent_ReadTime = DeviceUtils.GetProperty("PercentDiskReadTime", mj);
                    this.Percent_WriteTime = DeviceUtils.GetProperty("PercentDiskWriteTime", mj);
                    this.Percent_DiskTime = DeviceUtils.GetProperty("PercentDiskTime", mj);
                    this.Percent_IdleTime = DeviceUtils.GetProperty("PercentIdleTime", mj);
                }
            }
        }

        public PERFORM_DISK(int index): base("Storage Performance")
        {
            this.DriveIndex = index;
        }

        public PERFORM_DISK(string driveName): base("Storage Performance")
        {
            this._driveName = driveName;
        }

        public PERFORM_DISK(): base("Storage Performance") { }
    }

    #endregion

    #region Network

    /// <summary>
    /// Get Network Performance
    /// </summary>
    public class PERFORM_NETWORK: DevicePerformance
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

        private string selectedNetwork;

        public string SelectedNetwork { get => selectedNetwork; set => selectedNetwork = value; }

        public override void GetPerformance()
        {
            if (this.selectedNetwork == null) return;
            UInt64? Den;
            // get properties from the selected network adapter
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_Tcpip_NetworkAdapter", "Name", this.selectedNetwork, DeviceUtils.Operator.Egual))
            {
                this.ByteReceivedPerSec = DeviceUtils.GetProperty("BytesReceivedPersec", mj);
                this.BytesSentPerSec = DeviceUtils.GetProperty("BytesSentPersec", mj);
                this.BytesTotalPerSec = DeviceUtils.GetProperty("BytesTotalPersec", mj);
                this.PacketsReceivedsPerSec = DeviceUtils.GetProperty("PacketsReceivedPersec", mj);
                this.PacketsSentPerSec = DeviceUtils.GetProperty("PacketsSentPersec", mj);
                this.PacketsTotalPerSec = DeviceUtils.GetProperty("PacketsPersec", mj);

                // convert values
                if (BytesTotalPerSec != null)
                {
                    Den = (Convert.ToUInt64(BytesTotalPerSec) / 100);

                    if (Den != 0)
                    {
                        PercentBytesReceived = ByteReceivedPerSec != null ? (Convert.ToUInt64(ByteReceivedPerSec) / (Convert.ToUInt64(BytesTotalPerSec) / 100)).ToString() : null;
                        PercentBytesSent = BytesSentPerSec != null ? (Convert.ToUInt64(BytesSentPerSec) / (Convert.ToUInt64(BytesTotalPerSec) / 100)).ToString() : null;
                    }
                    else
                    {
                        PercentBytesReceived = "0";
                        PercentBytesSent = "0";
                    }
                }

                if (PacketsTotalPerSec !=  null)
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
            }
        }
        
        public PERFORM_NETWORK(string NetworkName): base("Network Performance")
        {
                this.selectedNetwork = NetworkName;
        }

        public PERFORM_NETWORK(): base("Network Performance") { }

    }

    #endregion

}
