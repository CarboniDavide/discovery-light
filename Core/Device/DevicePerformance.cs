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
    /// Declare base class structure
    /// </summary>
    public abstract class DevicePerformance
    {
        protected readonly string name;
        protected readonly string className;
        protected readonly Type classType;
        public string Name { get => name; }
        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public abstract void GetPerformance();
        public DevicePerformance(string Name)
        {
            name = Name;
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
        public UInt64? Cpu;
        public UInt64? D3D;
        public UInt64? Hd;
        public UInt64? Graph;
        public UInt64? Ram;

        public override void GetPerformance()
        {
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_WinSAT"))
            {
                this.Cpu = DeviceUtils.GetProperty("CPUScore", mj, DeviceUtils.ReturnType.UInt64);           // cpu 
                this.D3D = DeviceUtils.GetProperty("D3DScore", mj, DeviceUtils.ReturnType.UInt64);           // d3d 
                this.Hd = DeviceUtils.GetProperty("DiskScore", mj, DeviceUtils.ReturnType.UInt64);           // storage
                this.Graph = DeviceUtils.GetProperty("GraphicsScore", mj, DeviceUtils.ReturnType.UInt64);    // graph
                this.Ram = DeviceUtils.GetProperty("MemoryScore", mj, DeviceUtils.ReturnType.UInt64);        // memory
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
                if (DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String).Substring(0, 1).Equals(this.selectedCpu))
                {
                    Thread t = new Thread();                                                                        // create a new Thread
                    t.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);                    // get thread name
                    t.DPCRate = DeviceUtils.GetProperty("DPCRate", mj, DeviceUtils.ReturnType.String);              // get thread dpcreate value 
                    t.Frequency = DeviceUtils.GetProperty("ProcessorFrequency", mj, DeviceUtils.ReturnType.String); // get speed
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_System")){
                this.Threads = DeviceUtils.GetProperty("Threads", mj, DeviceUtils.ReturnType.String);
                this.Processes = DeviceUtils.GetProperty("Processes", mj, DeviceUtils.ReturnType.String);
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

        public UInt64? Per_DiskSizeFree;
        public UInt64? Per_CpuUsage;
        public UInt64? Per_RamSizeUsed;

        public override void GetPerformance()
        {
            // Storage
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_PerfDisk_LogicalDisk", "Name", "_Total", DeviceUtils.Operator.Egual))
                this.Per_DiskSizeFree = DeviceUtils.GetProperty("PercentFreeSpace", mj, DeviceUtils.ReturnType.UInt64);

            // Memory
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_PerfOS_Memory"))
                this.Per_RamSizeUsed = DeviceUtils.GetProperty("PercentCommittedBytesInUse", mj, DeviceUtils.ReturnType.UInt64);

            // Cpu
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Processor", "Name", "_Total", DeviceUtils.Operator.Egual))
                this.Per_CpuUsage = DeviceUtils.GetProperty("DPCRate", mj, DeviceUtils.ReturnType.UInt64);
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
        public UInt64? PerUsage;
        public UInt64? CacheUsage;
        public UInt64? MaxCacheUsage;
        public UInt64? Free;
        public UInt64? MemoryOut;
        public UInt64? PageIn;
        public UInt64? PageOut;
        public UInt64? PagePerSec;
        public UInt64? PageWrite;
        public UInt64? PageRead;

        public override void GetPerformance()
        {

            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Memory"))
            {
                this.CacheUsage = DeviceUtils.GetProperty("CacheBytes", mj, DeviceUtils.ReturnType.UInt64);
                this.MaxCacheUsage = DeviceUtils.GetProperty("CacheBytesPeak", mj, DeviceUtils.ReturnType.UInt64);
                this.Free = DeviceUtils.GetProperty("AvailableMBytes", mj, DeviceUtils.ReturnType.UInt64);
                this.MemoryOut = DeviceUtils.GetProperty("CommittedBytes", mj, DeviceUtils.ReturnType.UInt64);
                this.PageIn = DeviceUtils.GetProperty("PagesInputPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PageOut = DeviceUtils.GetProperty("PagesOutputPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PageWrite = DeviceUtils.GetProperty("PageWritesPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PageRead = DeviceUtils.GetProperty("PageReadsPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PagePerSec = DeviceUtils.GetProperty("PagesPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PerUsage = (DeviceUtils.GetProperty("AvailableBytes", mj, DeviceUtils.ReturnType.UInt64) / (DeviceUtils.GetProperty("CommitLimit", mj, DeviceUtils.ReturnType.UInt64) / 100));
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
        public UInt64? FreeSpace;
        public UInt64? WriteBytesPerSec;
        public UInt64? ReadBytesPerSec;
        public UInt64? TransferPerSec;

        public UInt64? Percent_FreeSpace;
        public UInt64? Percent_ReadTime;
        public UInt64? Percent_WriteTime;
        public UInt64? Percent_DiskTime;
        public UInt64? Percent_IdleTime;

        private int? _driveIndex;
        private string _driveName;

        public int? DriveIndex {
            get { return _driveIndex; }
            set { _driveIndex = value; this.FindDrive(); }
        }

        public string DriveName { get => _driveName; set => _driveName = value; }

        public void FindDrive()
        {
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_PhysicalDisk"))
            {
                String currentDrive = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);

                if (currentDrive.Substring(0, 1).Equals(this.DriveIndex.ToString()))
                    this._driveName = currentDrive.Substring(2, 1) + ":";
            }
        }

        public override void GetPerformance()
        {
            if (this.DriveIndex == null) return;
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_PerfDisk_LogicalDisk"))
            {
                String currentDriveName = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                if (currentDriveName.Equals(this.DriveName))
                {
                    this.FreeSpace = DeviceUtils.GetProperty("FreeMegabytes", mj, DeviceUtils.ReturnType.UInt64);
                    this.WriteBytesPerSec = DeviceUtils.GetProperty("DiskWriteBytesPersec", mj, DeviceUtils.ReturnType.UInt64);
                    this.ReadBytesPerSec = DeviceUtils.GetProperty("DiskReadBytesPersec", mj, DeviceUtils.ReturnType.UInt64);
                    this.TransferPerSec = DeviceUtils.GetProperty("DiskTransfersPersec", mj, DeviceUtils.ReturnType.UInt64);
                    this.Percent_FreeSpace = DeviceUtils.GetProperty("PercentFreeSpace", mj, DeviceUtils.ReturnType.UInt64);
                    this.Percent_ReadTime = DeviceUtils.GetProperty("PercentDiskReadTime", mj, DeviceUtils.ReturnType.UInt64);
                    this.Percent_WriteTime = DeviceUtils.GetProperty("PercentDiskWriteTime", mj, DeviceUtils.ReturnType.UInt64);
                    this.Percent_DiskTime = DeviceUtils.GetProperty("PercentDiskTime", mj, DeviceUtils.ReturnType.UInt64);
                    this.Percent_IdleTime = DeviceUtils.GetProperty("PercentIdleTime", mj, DeviceUtils.ReturnType.UInt64);
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
        public UInt64? ByteReceivedPerSec;
        public UInt64? BytesSentPerSec;
        public UInt64? BytesTotalPerSec;
        public UInt64? PacketsReceivedsPerSec;
        public UInt64? PacketsSentPerSec;
        public UInt64? PacketsTotalPerSec;

        public UInt64? PercentBytesReceived;
        public UInt64? PercentBytesSent;
        public UInt64? PercentPacketsReceived;
        public UInt64? PercentPacketsSents;

        private string selectedNetwork;

        public string SelectedNetwork { get => selectedNetwork; set => selectedNetwork = value; }

        public override void GetPerformance()
        {
            if (this.selectedNetwork == null) return;
            UInt64? Den;
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_Tcpip_NetworkAdapter", "Name", this.selectedNetwork, DeviceUtils.Operator.Egual))
            {
                this.ByteReceivedPerSec = DeviceUtils.GetProperty("BytesReceivedPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.BytesSentPerSec = DeviceUtils.GetProperty("BytesSentPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.BytesTotalPerSec = DeviceUtils.GetProperty("BytesTotalPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PacketsReceivedsPerSec = DeviceUtils.GetProperty("PacketsReceivedPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PacketsSentPerSec = DeviceUtils.GetProperty("PacketsSentPersec", mj, DeviceUtils.ReturnType.UInt64);
                this.PacketsTotalPerSec = DeviceUtils.GetProperty("PacketsPersec", mj, DeviceUtils.ReturnType.UInt64);

                if (BytesTotalPerSec != null)
                {
                    Den = (BytesTotalPerSec / 100);

                    if (Den != 0)
                    {
                        PercentBytesReceived = ByteReceivedPerSec != null ? (ByteReceivedPerSec / (BytesTotalPerSec / 100)) : null;
                        PercentBytesSent = BytesSentPerSec != null ? (BytesSentPerSec / (BytesTotalPerSec / 100)) : null;
                    }
                    else
                    {
                        PercentBytesReceived = 0;
                        PercentBytesSent = 0;
                    }
                }

                if (PacketsTotalPerSec !=  null)
                {
                    Den = (PacketsTotalPerSec / 100);
                    if (Den != 0)
                    {
                        PercentPacketsReceived = PacketsReceivedsPerSec != null ? (PacketsReceivedsPerSec / (PacketsTotalPerSec / 100)) : null;
                        PercentPacketsSents = PacketsSentPerSec != null ? (PacketsSentPerSec / (PacketsTotalPerSec / 100)) : null;
                    }
                    else
                    {
                        PercentPacketsSents = 0;
                        PercentPacketsReceived = 0;
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
