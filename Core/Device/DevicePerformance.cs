using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace DiscoveryLight.Core.Device.Data
{
    #region Interface
    /// <summary>
    /// Declare base class structure
    /// </summary>
    public interface Performance
    {
        void GetPerformance();
    }

    #endregion

    #region Score

    /// <summary>
    /// Get score performance
    /// </summary>
    public class SCORE: Performance
    {
        public UInt64? Cpu;
        public UInt64? D3D;
        public UInt64? Hd;
        public UInt64? Graph;
        public UInt64? Ram;

        public void GetPerformance()
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

        public SCORE()
        {
            GetPerformance();
        }
    }
    #endregion

    #region Cpu: Performance

    /// <summary>
    /// Get usage for each selected cpu'thread
    /// </summary>
    public class PERFORM_CPU
    {
        public struct Thread
        {
            public UInt64? DPCRate;
            public String Name;
            public UInt64? Frequency;
        }

        public List<Thread> Cpu;                 // Cpu list of thread
        private string selectedCpu;       

        public void GetPerformance()
        {
            // create a list of thread for the selected cpu
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfFormattedData_Counters_ProcessorInformation")){

                // get cpu thread values
                if (DeviceUtils.GetProperty("Timestamp_Object", mj, DeviceUtils.ReturnType.String)[0].Equals(this.selectedCpu)){
                    Thread t = new Thread();                                             // create a new Thread
                    t.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);                    // get thread name
                    t.DPCRate = DeviceUtils.GetProperty("DPCRate", mj, DeviceUtils.ReturnType.UInt64);              // get thread dpcreate value 
                    t.Frequency = DeviceUtils.GetProperty("ProcessorFrequency", mj, DeviceUtils.ReturnType.UInt64); // get speed
                    this.Cpu.Add(t);                                                     // add in list
                }

                // get total cpu values
                if (DeviceUtils.GetProperty("Timestamp_Object", mj, DeviceUtils.ReturnType.String).Equals("_Total") && this.selectedCpu.Equals("Total")) {
                    Thread t = new Thread();                                             // create a new Thread
                    t.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);                    // get thread name
                    t.DPCRate = DeviceUtils.GetProperty("DPCRate", mj, DeviceUtils.ReturnType.UInt64);              // get thread dpcreate value 
                    t.Frequency = DeviceUtils.GetProperty("ProcessorFrequency", mj, DeviceUtils.ReturnType.String); // get speed
                    this.Cpu.Add(t);                                                     // add in list
                }
            }

        }

        public PERFORM_CPU(string cpu)
        {
            this.selectedCpu = cpu;
            this.Cpu = new List<Thread>();
            GetPerformance();
        }
    }

    #endregion

    #region System: Performance

    /// <summary>
    /// Get Threads and Process number that are running in background
    /// </summary>
    public class PERFORM_SYSTEM
    {
        public String Threads;
        public String Processes;

        public void GetPerformance()
        {
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_System")){
                this.Threads = DeviceUtils.GetProperty("Threads", mj, DeviceUtils.ReturnType.String);
                this.Threads = DeviceUtils.GetProperty("Processes", mj, DeviceUtils.ReturnType.String);
            }
        }

        public PERFORM_SYSTEM()
        {
            GetPerformance();
        }
    }

    #endregion

    #region Base Pc Performances

    /// <summary>
    /// Get General Pc informations as Storage size Memory used and Cpu usage
    /// </summary>
    public class PERFORM_PC: Performance
    {

        public UInt64? Per_DiskSizeFree;
        public UInt64? Per_CpuUsage;
        public UInt64? Per_RamSizeUsed;

        public void GetPerformance()
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

        public PERFORM_PC()
        {
            this.GetPerformance();
        }
    }

    #endregion

    #region Memory
    /// <summary>
    /// Get Memory Ram performance
    /// </summary>
    public class PERFORM_RAM: Performance
    {
        public UInt64? CacheUsage;
        public UInt64? MaxCacheUsage;
        public UInt64? Free;
        public UInt64? MemoryOut;
        public UInt64? PageIn;
        public UInt64? PageOut;
        public UInt64? PagePerSec;
        public UInt64? PageWrite;
        public UInt64? PageRead;

        public void GetPerformance()
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
            }
        }

        public PERFORM_RAM()
        {
            this.GetPerformance();
        }

    }

    #endregion

    #region Storage

    /// <summary>
    /// Get local storage performance
    /// </summary>
    public class PERFORM_DISK: Performance
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

        private int _driveIndex;
        private string _driveName;

        public int DriveIndex {
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

        public void GetPerformance()
        {
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

        public PERFORM_DISK(int index)
        {
            this.DriveIndex = index;
            this.GetPerformance();
        }

        public PERFORM_DISK(string driveName)
        {
            this._driveName = driveName;
            this.GetPerformance();
        }

        public PERFORM_DISK()
        {
            this.GetPerformance();
        }
    }

    #endregion

    #region Network

    /// <summary>
    /// Get Network Performance
    /// </summary>
    public class PERFORM_ETHERNET: Performance
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

        public void GetPerformance()
        {
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
        
        public PERFORM_ETHERNET(string NetworkName)
        {
                this.selectedNetwork = NetworkName;
                this.GetPerformance();
        }

    }

    #endregion

}
