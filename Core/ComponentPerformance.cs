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
        public string Cpu;
        public string D3D;
        public string Hd;
        public string Graph;
        public string Ram;

        public void GetPerformance()
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_WinSAT"))
            {
                this.Cpu = ComponentsUtils.GetProperty("CPUScore", mj);           // cpu 
                this.D3D = ComponentsUtils.GetProperty("D3DScore", mj);           // d3d 
                this.Hd = ComponentsUtils.GetProperty("DiskScore", mj);           // storage
                this.Graph = ComponentsUtils.GetProperty("GraphicsScore", mj);    // graph
                this.Ram = ComponentsUtils.GetProperty("MemoryScore", mj);        // memory
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
            public string DPCRate;
            public string Name;
            public string Frequency;
        }

        public List<Thread> Cpu;                 // Cpu list of thread
        private string selectedCpu;       

        public void GetPerformance()
        {
            // create a list of thread for the selected cpu
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfFormattedData_Counters_ProcessorInformation")){

                // get cpu thread values
                if (ComponentsUtils.GetProperty("Timestamp_Object", mj)[0].Equals(this.selectedCpu)){
                    Thread t = new Thread();                                             // create a new Thread
                    t.Name = ComponentsUtils.GetProperty("Name", mj);                    // get thread name
                    t.DPCRate = ComponentsUtils.GetProperty("DPCRate", mj);              // get thread dpcreate value 
                    t.Frequency = ComponentsUtils.GetProperty("ProcessorFrequency", mj); // get speed
                    this.Cpu.Add(t);                                                     // add in list
                }

                // get total cpu values
                if (ComponentsUtils.GetProperty("Timestamp_Object", mj).Equals("_Total") && this.selectedCpu.Equals("Total")) {
                    Thread t = new Thread();                                             // create a new Thread
                    t.Name = ComponentsUtils.GetProperty("Name", mj);                    // get thread name
                    t.DPCRate = ComponentsUtils.GetProperty("DPCRate", mj);              // get thread dpcreate value 
                    t.Frequency = ComponentsUtils.GetProperty("ProcessorFrequency", mj); // get speed
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
        public string Threads;
        public string Processes;

        public void GetPerformance()
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_System")){
                this.Threads = ComponentsUtils.GetProperty("Threads", mj);
                this.Threads = ComponentsUtils.GetProperty("Processes", mj);
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

        public string Per_DiskSizeUsed;
        public string Per_CpuUsage;
        public string Per_RamSizeUsed;

        public void GetPerformance()
        {
            // Storage
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_LogicalDisk", "Name", "_Total"))
            {
                this.Per_DiskSizeUsed = Convert.ToString(100 - ((Convert.ToUInt64(ComponentsUtils.GetProperty("PercentFreeSpace", mj))) / (Convert.ToUInt64(ComponentsUtils.GetProperty("PercentFreeSpace_Base", mj)) / 100)));
            }

            // Memory
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Memory"))
            {
                this.Per_RamSizeUsed = Convert.ToString(100 - ((Convert.ToUInt64(ComponentsUtils.GetProperty("AvailableBytes", mj)) / (Convert.ToUInt64(ComponentsUtils.GetProperty("CommitLimit", mj)) / 100))));
            }

            // Cpu
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfOS_Processor", "Name", "_Total"))
            {
                this.Per_CpuUsage = ComponentsUtils.GetProperty("DPCRate", mj);
            }
        }

        public PERFORM_PC()
        {
            this.GetPerformance();
        }
    }

    #endregion

    #region Memory
    public class PERFORM_RAM
    {
        public string CacheUsage = "0";
        public string MaxCacheUsage = "0";
        public string Free = "0";
        public string MemoryOut = "0";
        public string PageIn = "0";
        public string PageOut = "0";
        public string PagePerSec = "0";
        public string PageWrite = "0";
        public string PageRead = "0";

        ManagementObjectSearcher mos;

        public void GetPerformance()
        {

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_LogicalDisk"))
            {
                this.CacheUsage = ComponentsUtils.GetProperty("CacheBytes", mj);
                this.MaxCacheUsage = ComponentsUtils.GetProperty("CacheBytesPeak", mj;
                this.Free = ComponentsUtils.GetProperty("AvailableMBytes", mj);
                this.MemoryOut = ComponentsUtils.GetProperty("CommittedBytes", mj);
                this.PageIn = ComponentsUtils.GetProperty("PagesInputPersec", mj);
                this.PageOut = ComponentsUtils.GetProperty("PagesOutputPersec", mj);
                this.PageWrite = ComponentsUtils.GetProperty("PageWritesPersec", mj);
                this.PageRead = ComponentsUtils.GetProperty("PageReadsPersec", mj);
                this.PagePerSec = ComponentsUtils.GetProperty("PagesPersec", mj);
            }
        }

        public PERFORM_RAM()
        {
            this.GetPerformance();
        }

    }

    #endregion

    #region Storage
    public class PERFORM_DISK
    {
        public string FreeSpace = "0";
        public string WriteBytesPerSec = "0";
        public string ReadBytesPerSec = "0";
        public string TransferPerSec = "0";

        public UInt16 Percent_FreeSpace = 0;
        public UInt16 Percent_ReadTime = 0;
        public UInt16 Percent_WriteTime = 0;
        public UInt16 Percent_DiskTime = 0;
        public UInt16 Percent_IdleTime = 0;

        private string selectedDrive;

        ManagementObjectSearcher mos;

        public string FindDrive(int disk_number)
        {
            ManagementObjectSearcher mos;

            mos = ComponentsUtils.Classe_Find("Win32_PerfRawData_PerfDisk_PhysicalDisk"); // Object init with query values for the search    

            string DriveName = null;
            string DriveIndex = null;

            if (mos != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Data read
                {
                    if ((ComponentsUtils.Capture_Value("Name", mj) != "Null") || (ComponentsUtils.Capture_Value("Name", mj) != "Not Found"))
                    {
                        DriveIndex = mj.Properties["Name"].Value.ToString().Substring(0, 1);
                        if (DriveIndex == disk_number.ToString())
                            DriveName = mj.Properties["Name"].Value.ToString().Substring(2, 1);
                    }
                    else
                        return null;
                }
                return DriveName + ":";
            }
            else
                return null;
        }

        public void Read(string drive_name)
        {
            if ((mos != null) || (drive_name != null))
            {
                foreach (ManagementObject mj in mos.Get()) // Data read
                {
                    if (ComponentsUtils.Capture_Value("Name", mj) == drive_name)
                    {
                        this.FreeSpace = ComponentsUtils.Capture_Number("FreeMegabytes", mj).ToString();
                        this.WriteBytesPerSec = ComponentsUtils.Capture_Number("DiskWriteBytesPersec", mj).ToString();
                        this.ReadBytesPerSec = ComponentsUtils.Capture_Number("DiskReadBytesPersec", mj).ToString();
                        this.TransferPerSec = ComponentsUtils.Capture_Number("DiskTransfersPersec", mj).ToString();
                        this.Percent_FreeSpace = Convert.ToUInt16(ComponentsUtils.Capture_Number("PercentFreeSpace", mj));
                        this.Percent_ReadTime = Convert.ToUInt16(ComponentsUtils.Capture_Number("PercentDiskReadTime", mj));
                        this.Percent_WriteTime = Convert.ToUInt16(ComponentsUtils.Capture_Number("PercentDiskWriteTime", mj));
                        this.Percent_DiskTime = Convert.ToUInt16(ComponentsUtils.Capture_Number("PercentDiskTime", mj));
                        this.Percent_IdleTime = Convert.ToUInt16(ComponentsUtils.Capture_Number("PercentIdleTime", mj));
                    }
                }
            }
        }

        public PERFORM_DISK(string drive_name)
        {
            this.selectedDrive = drive_name;
            mos = ComponentsUtils.Classe_Find("Win32_PerfFormattedData_PerfDisk_LogicalDisk"); // Object init with query values for the search   
        }
    }

    #endregion

    #region Network

    public class PERFORM_ETHERNET
    {
        public UInt64 ByteReceivedPerSec;
        public UInt64 BytesSentPerSec;
        public UInt64 BytesTotalPerSec;
        public UInt64 PacketsReceivedsPerSec;
        public UInt64 PacketsSentPerSec;
        public UInt64 PacketsTotalPerSec;

        public UInt64 PercentBytesReceived;
        public UInt64 PercentBytesSent;
        public UInt64 PercentPacketsReceived;
        public UInt64 PercentPacketsSents;

        ManagementObjectSearcher mos;

        public Boolean Read(string carte_name)
        {
            UInt64 Den;

            if (mos != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Data read
                {
                    if (ComponentsUtils.Capture_Value("Name", mj).Length == carte_name.Length)
                    {
                        this.ByteReceivedPerSec = ComponentsUtils.Capture_Number("BytesReceivedPersec", mj);
                        this.BytesSentPerSec = ComponentsUtils.Capture_Number("BytesSentPersec", mj);
                        this.BytesTotalPerSec = ComponentsUtils.Capture_Number("BytesTotalPersec", mj);
                        this.PacketsReceivedsPerSec = ComponentsUtils.Capture_Number("PacketsReceivedPersec", mj);
                        this.PacketsSentPerSec = ComponentsUtils.Capture_Number("PacketsSentPersec", mj);
                        this.PacketsTotalPerSec = ComponentsUtils.Capture_Number("PacketsPersec", mj);
                        // Percent calcul

                        if (BytesTotalPerSec == 0)
                        {
                            PercentBytesReceived = 0;
                            PercentBytesSent = 0;
                        }
                        else
                        {
                            Den = (BytesTotalPerSec / 100);

                            if (Den != 0)
                            {
                                PercentBytesReceived = ByteReceivedPerSec / (BytesTotalPerSec / 100);
                                PercentBytesSent = BytesSentPerSec / (BytesTotalPerSec / 100);
                            }
                            else
                            {
                                PercentBytesReceived = 0;
                                PercentBytesSent = 0;
                            }
                        }
                        if (PacketsTotalPerSec == 0)
                        {
                            PercentPacketsSents = 0;
                            PercentPacketsReceived = 0;
                        }
                        else
                        {
                            Den = (PacketsTotalPerSec / 100);
                            if (Den != 0)
                            {
                                PercentPacketsReceived = PacketsReceivedsPerSec / (PacketsTotalPerSec / 100);
                                PercentPacketsSents = PacketsSentPerSec / (PacketsTotalPerSec / 100);
                            }
                            else
                            {
                                PercentPacketsSents = 0;
                                PercentPacketsReceived = 0;
                            }
                        }
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }

        public PERFORM_ETHERNET()
        {
            mos = ComponentsUtils.Classe_Find("Win32_PerfFormattedData_Tcpip_NetworkInterface");
        }

    }

    #endregion
}
