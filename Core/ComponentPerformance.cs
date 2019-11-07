using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace DiscoveryLight.Core
{
    #region Score

    /// <summary>
    /// Get score performance
    /// </summary>
    public class SCORE
    {
        public UInt64? Cpu;
        public UInt64? D3D;
        public UInt64? Hd;
        public UInt64? Graph;
        public UInt64? Ram;

        public void GetPerformance()
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_WinSAT"))
            {
                this.Cpu = ComponentsUtils.GetProperty("CPUScore", mj, ComponentsUtils.ReturnType.UInt64);           // cpu 
                this.D3D = ComponentsUtils.GetProperty("D3DScore", mj, ComponentsUtils.ReturnType.UInt64);           // d3d 
                this.Hd = ComponentsUtils.GetProperty("DiskScore", mj, ComponentsUtils.ReturnType.UInt64);           // storage
                this.Graph = ComponentsUtils.GetProperty("GraphicsScore", mj, ComponentsUtils.ReturnType.UInt64);    // graph
                this.Ram = ComponentsUtils.GetProperty("MemoryScore", mj, ComponentsUtils.ReturnType.UInt64);        // memory
            }
        }

        public SCORE()
        {
            GetPerformance();
        }
    }
    #endregion

    #region Cpu

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
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfFormattedData_Counters_ProcessorInformation")){

                // get cpu thread values
                if (ComponentsUtils.GetProperty("Timestamp_Object", mj, ComponentsUtils.ReturnType.String)[0].Equals(this.selectedCpu)){
                    Thread t = new Thread();                                             // create a new Thread
                    t.Name = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);                    // get thread name
                    t.DPCRate = ComponentsUtils.GetProperty("DPCRate", mj, ComponentsUtils.ReturnType.UInt64);              // get thread dpcreate value 
                    t.Frequency = ComponentsUtils.GetProperty("ProcessorFrequency", mj, ComponentsUtils.ReturnType.UInt64); // get speed
                    this.Cpu.Add(t);                                                     // add in list
                }

                // get total cpu values
                if (ComponentsUtils.GetProperty("Timestamp_Object", mj, ComponentsUtils.ReturnType.String).Equals("_Total") && this.selectedCpu.Equals("Total")) {
                    Thread t = new Thread();                                             // create a new Thread
                    t.Name = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);                    // get thread name
                    t.DPCRate = ComponentsUtils.GetProperty("DPCRate", mj, ComponentsUtils.ReturnType.UInt64);              // get thread dpcreate value 
                    t.Frequency = ComponentsUtils.GetProperty("ProcessorFrequency", mj, ComponentsUtils.ReturnType.String); // get speed
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

    #region System

    /// <summary>
    /// Get Threads and Process number that are running in background
    /// </summary>
    public class PERFORM_SYSTEM
    {
        public String Threads;
        public String Processes;

        public void GetPerformance()
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_System")){
                this.Threads = ComponentsUtils.GetProperty("Threads", mj, ComponentsUtils.ReturnType.String);
                this.Threads = ComponentsUtils.GetProperty("Processes", mj, ComponentsUtils.ReturnType.String);
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
    public class PERFORM_PC
    {

        public UInt64? Per_DiskSizeFree;
        public UInt64? Per_CpuUsage;
        public UInt64? Per_RamSizeUsed;

        public void GetPerformance()
        {
            // Storage
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfFormattedData_PerfDisk_LogicalDisk", "Name", "_Total", ComponentsUtils.Operator.Egual))
                this.Per_DiskSizeFree = ComponentsUtils.GetProperty("PercentFreeSpace", mj, ComponentsUtils.ReturnType.UInt64);

            // Memory
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfFormattedData_PerfOS_Memory"))
                this.Per_RamSizeUsed = ComponentsUtils.GetProperty("PercentCommittedBytesInUse", mj, ComponentsUtils.ReturnType.UInt64);

            // Cpu
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Processor", "Name", "_Total", ComponentsUtils.Operator.Egual))
                this.Per_CpuUsage = ComponentsUtils.GetProperty("DPCRate", mj, ComponentsUtils.ReturnType.UInt64);
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
    public class PERFORM_RAM
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

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Memory"))
            {
                this.CacheUsage = ComponentsUtils.GetProperty("CacheBytes", mj, ComponentsUtils.ReturnType.UInt64);
                this.MaxCacheUsage = ComponentsUtils.GetProperty("CacheBytesPeak", mj, ComponentsUtils.ReturnType.UInt64);
                this.Free = ComponentsUtils.GetProperty("AvailableMBytes", mj, ComponentsUtils.ReturnType.UInt64);
                this.MemoryOut = ComponentsUtils.GetProperty("CommittedBytes", mj, ComponentsUtils.ReturnType.UInt64);
                this.PageIn = ComponentsUtils.GetProperty("PagesInputPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.PageOut = ComponentsUtils.GetProperty("PagesOutputPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.PageWrite = ComponentsUtils.GetProperty("PageWritesPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.PageRead = ComponentsUtils.GetProperty("PageReadsPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.PagePerSec = ComponentsUtils.GetProperty("PagesPersec", mj, ComponentsUtils.ReturnType.UInt64);
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
    public class PERFORM_DISK
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
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_PhysicalDisk"))
            {
                String currentDrive = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);

                if (currentDrive.Substring(0, 1).Equals(this.DriveIndex.ToString()))
                    this._driveName = currentDrive.Substring(2, 1) + ":";
            }
        }

        public void GetPerformance()
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfFormattedData_PerfDisk_LogicalDisk"))
            {
                String currentDriveName = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);
                if (currentDriveName.Equals(this.DriveName))
                {
                    this.FreeSpace = ComponentsUtils.GetProperty("FreeMegabytes", mj, ComponentsUtils.ReturnType.UInt64);
                    this.WriteBytesPerSec = ComponentsUtils.GetProperty("DiskWriteBytesPersec", mj, ComponentsUtils.ReturnType.UInt64);
                    this.ReadBytesPerSec = ComponentsUtils.GetProperty("DiskReadBytesPersec", mj, ComponentsUtils.ReturnType.UInt64);
                    this.TransferPerSec = ComponentsUtils.GetProperty("DiskTransfersPersec", mj, ComponentsUtils.ReturnType.UInt64);
                    this.Percent_FreeSpace = ComponentsUtils.GetProperty("PercentFreeSpace", mj, ComponentsUtils.ReturnType.UInt64);
                    this.Percent_ReadTime = ComponentsUtils.GetProperty("PercentDiskReadTime", mj, ComponentsUtils.ReturnType.UInt64);
                    this.Percent_WriteTime = ComponentsUtils.GetProperty("PercentDiskWriteTime", mj, ComponentsUtils.ReturnType.UInt64);
                    this.Percent_DiskTime = ComponentsUtils.GetProperty("PercentDiskTime", mj, ComponentsUtils.ReturnType.UInt64);
                    this.Percent_IdleTime = ComponentsUtils.GetProperty("PercentIdleTime", mj, ComponentsUtils.ReturnType.UInt64);
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
    public class PERFORM_ETHERNET
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
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfFormattedData_Tcpip_NetworkAdapter", "Name", this.selectedNetwork, ComponentsUtils.Operator.Egual))
            {
                this.ByteReceivedPerSec = ComponentsUtils.GetProperty("BytesReceivedPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.BytesSentPerSec = ComponentsUtils.GetProperty("BytesSentPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.BytesTotalPerSec = ComponentsUtils.GetProperty("BytesTotalPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.PacketsReceivedsPerSec = ComponentsUtils.GetProperty("PacketsReceivedPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.PacketsSentPerSec = ComponentsUtils.GetProperty("PacketsSentPersec", mj, ComponentsUtils.ReturnType.UInt64);
                this.PacketsTotalPerSec = ComponentsUtils.GetProperty("PacketsPersec", mj, ComponentsUtils.ReturnType.UInt64);

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
