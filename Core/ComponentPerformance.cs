using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace DiscoveryLight.Core
{
    class ComponentPerformance
    {
        public class PERFORM_MAINBOARD
        {
            public string NumberSlot = "Not Found";

            ManagementObjectSearcher mos;

            public void Search()
            {
                if ((mos = ComponentsUtils.Classe_Find("Win32_SystemSlot")) != null)
                {
                    int count = 0;

                    foreach (ManagementObject mj in mos.Get()) // Data read
                        count++;

                    NumberSlot = count.ToString(); // return the number of slots
                }
            }

            public PERFORM_MAINBOARD()
            {
                Search(); // Init componenents and searching the data
            }

        }

        public class SCORE
        {

            public string Cpu = "0";
            public string D3D = "0";
            public string Hd = "0";
            public string Graph = "0";
            public string Ram = "0";

            ManagementObjectSearcher mos;

            public void Search()
            {
                if ((mos = ComponentsUtils.Classe_Find("Win32_WinSAT")) != null)
                {
                    foreach (ManagementObject mj in mos.Get()) // Data read
                    {
                        this.Cpu = ComponentsUtils.Capture_Number("CPUScore", mj).ToString();
                        this.D3D = ComponentsUtils.Capture_Number("D3DScore", mj).ToString();
                        this.Hd = ComponentsUtils.Capture_Number("DiskScore", mj).ToString();
                        this.Graph = ComponentsUtils.Capture_Number("GraphicsScore", mj).ToString();
                        this.Ram = ComponentsUtils.Capture_Number("MemoryScore", mj).ToString();
                    }
                }
            }

            public SCORE()
            {
                Search(); // Init componenents and searching the data
            }
        }

        public class PERFORM_CPU_CORES
        {
            ManagementObjectSearcher mos;

            public UInt16 Usage_Core = 0;

            public UInt16 Usage(string cpu_thread)
            {
                if (mos != null)
                {
                    foreach (ManagementObject mj in mos.Get()) // Data read for the cores
                        if (ComponentsUtils.Capture_Value("Name", mj) == cpu_thread)
                            this.Usage_Core = Convert.ToUInt16(ComponentsUtils.Capture_Number("DPCRate", mj));

                    return this.Usage_Core;
                }
                else
                    return 0;
            }

            public PERFORM_CPU_CORES()
            {
                mos = ComponentsUtils.Classe_Find("Win32_PerfRawData_PerfOS_Processor");
            }
        }

        public class PERFORM_SYSTEM
        {
            ManagementObjectSearcher mos;
            ManagementObjectSearcher mosSpeed;

            public UInt16 Threads = 0;
            public UInt16 Processes = 0;
            public UInt16 Speed = 0;

            public UInt16 Thread_Values()
            {
                //
                //  Count threads numbers

                if (mos != null)
                {
                    foreach (ManagementObject mj in mos.Get()) // Data read
                        this.Threads = Convert.ToUInt16(ComponentsUtils.Capture_Number("Threads", mj));
                    return this.Threads;
                }
                else
                    return 0;
            }

            public UInt16 Processes_Values()
            {
                //
                // Count processes numbers

                if (mos != null)
                {
                    foreach (ManagementObject mj in mos.Get()) // Data read
                        this.Processes = Convert.ToUInt16(ComponentsUtils.Capture_Number("Processes", mj));

                    return this.Processes;
                }
                else
                    return 0;
            }

            public UInt16 Speed_Values(int cpu_name)
            {
                //
                // Cloclk speed find
                if (mosSpeed != null)
                {
                    int count = 0;
                    foreach (ManagementObject mj in mosSpeed.Get())
                    {
                        if (count == cpu_name) // Data read
                            this.Speed = Convert.ToUInt16(ComponentsUtils.Capture_Number("ProcessorFrequency", mj));
                        count++;
                    }
                    return this.Speed;
                }
                else
                    return 0;
            }

            public PERFORM_SYSTEM()
            {
                mos = ComponentsUtils.Classe_Find("Win32_PerfRawData_PerfOS_System"); // Object init with query values for the search
                mosSpeed = ComponentsUtils.Classe_Find("Win32_PerfFormattedData_Counters_ProcessorInformation"); // Object init with query values for the search
            }
        }

        public class PERFORM_PC
        {

            ManagementObjectSearcher mosDisk;
            ManagementObjectSearcher mosRam;
            ManagementObjectSearcher mosCpu;

            public UInt16 Perc_DiskSizeFree = 0;
            public UInt16 Perc_CpuFreq = 0;
            public UInt16 Perc_RamSizeFree = 0;

            public UInt16 CpuValue_Usage()
            {
                //
                // Cpu Speed

                if (mosCpu != null)
                {
                    foreach (ManagementObject mj in mosCpu.Get()) // Data read
                    {
                        if (ComponentsUtils.Capture_Value("Name", mj) == "_Total")
                            this.Perc_CpuFreq = Convert.ToUInt16(ComponentsUtils.Capture_Number("DPCRate", mj));
                    }

                    return this.Perc_CpuFreq;
                }
                else
                    return 0;
            }

            public UInt16 Ram_Free()
            {
                //
                // Free Memory

                if (mosRam != null)
                {
                    foreach (ManagementObject mj in mosRam.Get()) // Data read
                        this.Perc_RamSizeFree = Convert.ToUInt16((Convert.ToUInt64(ComponentsUtils.Capture_Number("AvailableBytes", mj)) / (Convert.ToUInt64(ComponentsUtils.Capture_Number("CommitLimit", mj)) / 100)));

                    return Perc_RamSizeFree;
                }
                else
                    return 0;
            }

            public UInt16 Disk_Free()
            {
                //
                // Free disk space
                if (mosDisk != null)
                {
                    foreach (ManagementObject mj in mosDisk.Get()) // Data read
                        if (mj.Properties["Name"].Value.ToString() == "_Total")
                        {
                            this.Perc_DiskSizeFree = Convert.ToUInt16((Convert.ToUInt64(ComponentsUtils.Capture_Number("PercentFreeSpace", mj))) / (Convert.ToUInt64(ComponentsUtils.Capture_Number("PercentFreeSpace_Base", mj)) / 100));
                        }

                    return (this.Perc_DiskSizeFree);
                }
                else
                    return 0;
            }

            public PERFORM_PC()
            {
                mosDisk = ComponentsUtils.Classe_Find("Win32_PerfRawData_PerfDisk_LogicalDisk"); // Object init with query values for the search
                mosRam = ComponentsUtils.Classe_Find("Win32_PerfRawData_PerfOS_Memory"); // Object init with query values for the search
                mosCpu = ComponentsUtils.Classe_Find("Win32_PerfRawData_PerfOS_Processor"); // Object init with query values for the search
            }
        }

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

            public void Search()
            {

                if (mos != null)
                {
                    foreach (ManagementObject mj in mos.Get()) // Data read
                    {
                        this.CacheUsage = ComponentsUtils.Capture_Number("CacheBytes", mj).ToString();
                        this.MaxCacheUsage = ComponentsUtils.Capture_Number("CacheBytesPeak", mj).ToString();
                        this.Free = ComponentsUtils.Capture_Number("AvailableMBytes", mj).ToString();
                        this.MemoryOut = ComponentsUtils.Capture_Number("CommittedBytes", mj).ToString();
                        this.PageIn = ComponentsUtils.Capture_Number("PagesInputPersec", mj).ToString();
                        this.PageOut = ComponentsUtils.Capture_Number("PagesOutputPersec", mj).ToString();
                        this.PageWrite = ComponentsUtils.Capture_Number("PageWritesPersec", mj).ToString();
                        this.PageRead = ComponentsUtils.Capture_Number("PageReadsPersec", mj).ToString();
                        this.PagePerSec = ComponentsUtils.Capture_Number("PagesPersec", mj).ToString();
                    }
                }
            }

            public PERFORM_RAM()
            {
                mos = ComponentsUtils.Classe_Find("Win32_PerfRawData_PerfOS_Memory"); // Object init with query values for the search    
            }

        }

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

            public PERFORM_DISK()
            {
                mos = ComponentsUtils.Classe_Find("Win32_PerfFormattedData_PerfDisk_LogicalDisk"); // Object init with query values for the search   
            }
        }

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
    }
}
