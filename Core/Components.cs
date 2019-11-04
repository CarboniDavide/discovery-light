using System;
using System.Management;

namespace DiscoveryLight.Core
{
    public class CONTROL
    {
        public UInt64 Capture_Number(string property_name, ManagementObject obj)
        {
            // Find Value

            try
            {
                if (obj.Properties[property_name].Value != null)
                {
                    return Convert.ToUInt64(obj.Properties[property_name].Value);
                }
                else
                {
                    return 0; // return  0 if the value is null
                }
            }
            catch { return 0; } // return 0 found in case of error
        }

        public string Capture_Value(string property_name, ManagementObject obj)
        {
            // Find Value

            try
            {
                if (obj.Properties[property_name].Value != null)
                {
                    return obj.Properties[property_name].Value.ToString();
                }
                else
                {
                    return "N/A"; // return  null if the value is null
                }
            }
            catch { return "Not Found"; } // return not found in case of error
        }

        public ManagementObjectSearcher Classe_Find(string name)
        {
            ManagementObjectSearcher obj = null;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "select * from meta_class");

            foreach (ManagementClass wmiClass in searcher.Get())
                foreach (QualifierData qd in wmiClass.Qualifiers)
                    if (qd.Name.Equals("dynamic") || qd.Name.Equals("static"))
                        if (wmiClass["__CLASS"].ToString() == name)
                            return obj = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + name); // Object init with query values for the search               

            return null;
            /*
            try
            {
                obj = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + name); // Object init with query values for the search       
                return obj;
            }
            catch
            {
                return null;
            }*/
        }
    }

    public class PERFORM_MAINBOARD
    {
        public string NumberSlot = "Not Found";

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        public void Search()
        {
            if ((mos = Control.Classe_Find("Win32_SystemSlot")) != null)
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
        CONTROL Control = new CONTROL();

        public void Search()
        {
            if ((mos = Control.Classe_Find("Win32_WinSAT")) != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Data read
                {
                    this.Cpu = Control.Capture_Number("CPUScore", mj).ToString();
                    this.D3D = Control.Capture_Number("D3DScore", mj).ToString();
                    this.Hd = Control.Capture_Number("DiskScore", mj).ToString();
                    this.Graph = Control.Capture_Number("GraphicsScore", mj).ToString();
                    this.Ram = Control.Capture_Number("MemoryScore", mj).ToString();
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
        CONTROL Control = new CONTROL();

        public UInt16 Usage_Core = 0;

        public UInt16 Usage(string cpu_thread)
        {
            if (mos != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Data read for the cores
                    if (Control.Capture_Value("Name", mj) == cpu_thread)
                        this.Usage_Core = Convert.ToUInt16(Control.Capture_Number("DPCRate", mj));

                return this.Usage_Core;
            }
            else
                return 0;
        }

        public PERFORM_CPU_CORES()
        {
            mos = Control.Classe_Find("Win32_PerfRawData_PerfOS_Processor");
        }
    }

    public class PERFORM_SYSTEM
    {
        ManagementObjectSearcher mos;
        ManagementObjectSearcher mosSpeed;
        CONTROL Control = new CONTROL();

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
                    this.Threads = Convert.ToUInt16(Control.Capture_Number("Threads", mj));
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
                    this.Processes = Convert.ToUInt16(Control.Capture_Number("Processes", mj));

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
                        this.Speed = Convert.ToUInt16(Control.Capture_Number("ProcessorFrequency", mj));
                    count++;
                }
                return this.Speed;
            }
            else
                return 0;
        }

        public PERFORM_SYSTEM()
        {
            mos = Control.Classe_Find("Win32_PerfRawData_PerfOS_System"); // Object init with query values for the search
            mosSpeed = Control.Classe_Find("Win32_PerfFormattedData_Counters_ProcessorInformation"); // Object init with query values for the search
        }
    }

    public class PERFORM_PC
    {

        ManagementObjectSearcher mosDisk;
        ManagementObjectSearcher mosRam;
        ManagementObjectSearcher mosCpu;
        CONTROL Control = new CONTROL();

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
                    if (Control.Capture_Value("Name", mj) == "_Total")
                        this.Perc_CpuFreq = Convert.ToUInt16(Control.Capture_Number("DPCRate", mj));
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
                    this.Perc_RamSizeFree = Convert.ToUInt16((Convert.ToUInt64(Control.Capture_Number("AvailableBytes", mj)) / (Convert.ToUInt64(Control.Capture_Number("CommitLimit", mj)) / 100)));

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
                        this.Perc_DiskSizeFree = Convert.ToUInt16((Convert.ToUInt64(Control.Capture_Number("PercentFreeSpace", mj))) / (Convert.ToUInt64(Control.Capture_Number("PercentFreeSpace_Base", mj)) / 100));
                    }

                return (this.Perc_DiskSizeFree);
            }
            else
                return 0;
        }

        public PERFORM_PC()
        {
            mosDisk = Control.Classe_Find("Win32_PerfRawData_PerfDisk_LogicalDisk"); // Object init with query values for the search
            mosRam = Control.Classe_Find("Win32_PerfRawData_PerfOS_Memory"); // Object init with query values for the search
            mosCpu = Control.Classe_Find("Win32_PerfRawData_PerfOS_Processor"); // Object init with query values for the search
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
        CONTROL Control = new CONTROL();

        public void Search()
        {

            if (mos != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Data read
                {
                    this.CacheUsage = Control.Capture_Number("CacheBytes", mj).ToString();
                    this.MaxCacheUsage = Control.Capture_Number("CacheBytesPeak", mj).ToString();
                    this.Free = Control.Capture_Number("AvailableMBytes", mj).ToString();
                    this.MemoryOut = Control.Capture_Number("CommittedBytes", mj).ToString();
                    this.PageIn = Control.Capture_Number("PagesInputPersec", mj).ToString();
                    this.PageOut = Control.Capture_Number("PagesOutputPersec", mj).ToString();
                    this.PageWrite = Control.Capture_Number("PageWritesPersec", mj).ToString();
                    this.PageRead = Control.Capture_Number("PageReadsPersec", mj).ToString();
                    this.PagePerSec = Control.Capture_Number("PagesPersec", mj).ToString();
                }
            }
        }

        public PERFORM_RAM()
        {
            mos = Control.Classe_Find("Win32_PerfRawData_PerfOS_Memory"); // Object init with query values for the search    
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
        CONTROL Control = new CONTROL();

        public string FindDrive(int disk_number)
        {
            ManagementObjectSearcher mos;

            mos = Control.Classe_Find("Win32_PerfRawData_PerfDisk_PhysicalDisk"); // Object init with query values for the search    

            string DriveName = null;
            string DriveIndex = null;

            if (mos != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Data read
                {
                    if ((Control.Capture_Value("Name", mj) != "Null") || (Control.Capture_Value("Name", mj) != "Not Found"))
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
                    if (Control.Capture_Value("Name", mj) == drive_name)
                    {
                        this.FreeSpace = Control.Capture_Number("FreeMegabytes", mj).ToString();
                        this.WriteBytesPerSec = Control.Capture_Number("DiskWriteBytesPersec", mj).ToString();
                        this.ReadBytesPerSec = Control.Capture_Number("DiskReadBytesPersec", mj).ToString();
                        this.TransferPerSec = Control.Capture_Number("DiskTransfersPersec", mj).ToString();
                        this.Percent_FreeSpace = Convert.ToUInt16(Control.Capture_Number("PercentFreeSpace", mj));
                        this.Percent_ReadTime = Convert.ToUInt16(Control.Capture_Number("PercentDiskReadTime", mj));
                        this.Percent_WriteTime = Convert.ToUInt16(Control.Capture_Number("PercentDiskWriteTime", mj));
                        this.Percent_DiskTime = Convert.ToUInt16(Control.Capture_Number("PercentDiskTime", mj));
                        this.Percent_IdleTime = Convert.ToUInt16(Control.Capture_Number("PercentIdleTime", mj));
                    }
                }
            }
        }

        public PERFORM_DISK()
        {
            mos = Control.Classe_Find("Win32_PerfFormattedData_PerfDisk_LogicalDisk"); // Object init with query values for the search   
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
        CONTROL Control = new CONTROL();

        public Boolean Read(string carte_name)
        {
            UInt64 Den;

            if (mos != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Data read
                {
                    if (Control.Capture_Value("Name", mj).Length == carte_name.Length)
                    {
                        this.ByteReceivedPerSec = Control.Capture_Number("BytesReceivedPersec", mj);
                        this.BytesSentPerSec = Control.Capture_Number("BytesSentPersec", mj);
                        this.BytesTotalPerSec = Control.Capture_Number("BytesTotalPersec", mj);
                        this.PacketsReceivedsPerSec = Control.Capture_Number("PacketsReceivedPersec", mj);
                        this.PacketsSentPerSec = Control.Capture_Number("PacketsSentPersec", mj);
                        this.PacketsTotalPerSec = Control.Capture_Number("PacketsPersec", mj);
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
            mos = Control.Classe_Find("Win32_PerfFormattedData_Tcpip_NetworkInterface");
        }

    }

    //
    // Data Class
    //

    public class PC
    {
        public string Name;
        public string Type;
        public string Manufacturer;
        public string Model;
        public string IDNumber;
        public string User;
        public string Domaine;
        public string SystemOS_Version;
        public string SystemOS;
        public string SystemOS_Brand;
        public string SystemOS_Architecture;
        public string RamSize;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        private void Search()
        {
            if ((mos = Control.Classe_Find("Win32_ComputerSystem")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Name = Control.Capture_Value("Name", mj);
                    this.Type = Control.Capture_Value("SystemType", mj);
                    this.Manufacturer = Control.Capture_Value("Manufacturer", mj);
                    this.Model = Control.Capture_Value("Model", mj);
                    this.User = Control.Capture_Value("UserName", mj);
                    this.Domaine = Control.Capture_Value("Domain", mj);
                }

            if ((mos = Control.Classe_Find("Win32_OperatingSystem")) != null)
                foreach (ManagementObject mj in mos.Get())
                {
                    SystemOS = Control.Capture_Value("Caption", mj);
                    SystemOS_Brand = Control.Capture_Value("Manufacturer", mj);
                    SystemOS_Version = Control.Capture_Value("BuildNumber", mj);
                    SystemOS_Architecture = Control.Capture_Value("OSArchitecture", mj);
                }

            if ((mos = Control.Classe_Find("Win32_ComputerSystemProduct")) != null)
                foreach (ManagementObject mj in mos.Get())
                {
                    IDNumber = Control.Capture_Value("IdentifyingNumber", mj);
                }
        }

        public PC()
        {
            Search(); // Init componenents and searching the data
        }
    }

    public class BIOS
    {
        public string Manufacturer;
        public string SerialNumber;
        public string Version;
        public string ReleaseData;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        public void Search()
        {
            if ((mos = Control.Classe_Find("Win32_BIOS")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Manufacturer = Control.Capture_Value("Manufacturer", mj);
                    this.SerialNumber = Control.Capture_Value("SerialNumber", mj);
                    this.Version = Control.Capture_Value("Caption", mj);
                    this.ReleaseData = Control.Capture_Value("ReleaseDate", mj);
                }
        }

        public BIOS()
        {
            Search(); // Init componenents and searching the data
        }
    }

    public class MAINBOARD
    {
        public string Manufacturer;
        public string Model;
        public string Version;
        public string PrimaryBus_Value;
        public string SecondaryBus_Value;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        public void Search()
        {
            if ((mos = Control.Classe_Find("Win32_BaseBoard")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Manufacturer = Control.Capture_Value("Manufacturer", mj);
                    this.Model = Control.Capture_Value("Product", mj);
                    this.Version = Control.Capture_Value("Version", mj);
                }

            if ((mos = Control.Classe_Find("Win32_MotherboardDevice")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.PrimaryBus_Value = Control.Capture_Value("PrimaryBusType", mj);
                    this.SecondaryBus_Value = Control.Capture_Value("SecondaryBusType", mj);
                }
        }

        public MAINBOARD()
        {
            Search(); // Init componenents and searching the data
        }
    }

    public class VIDEO
    {
        public Int16 NumbersBlocks = 0;

        public struct BLOCK
        {
            public string Name;
            public string Manufacturer;
            public string AdpterType;
            public string MemorySize;
            public string NowBitsPerPixel;
            public string NowHorizResolution;
            public string NowVertResolution;
            public string NowRefreshRate;
            public string MaxRefreshRate;
            public string MinRefreshRate;
            public string NowNumberOfColors;
            public string Mode;
        }

        public BLOCK[] Block;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = Control.Classe_Find("Win32_VideoController")) != null)
                Collection = mos.Get();
            else
                return 0;

            return Convert.ToInt16(Collection.Count); // Return dimension
        }

        private void Blocks_Init()
        {
            NumbersBlocks = Blocks_Count(); // Blocks numbers search
            Block = new BLOCK[NumbersBlocks]; // Init array dimension
            for (int i = 0; i < NumbersBlocks; i++)
                Block[i] = new BLOCK(); // Creat blocks
        }

        public void Search()
        {
            Blocks_Init();

            if (((mos = Control.Classe_Find("Win32_VideoController")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Block[Index].Name = Control.Capture_Value("Name", mj);
                    this.Block[Index].Manufacturer = Control.Capture_Value("Description", mj);
                    this.Block[Index].AdpterType = Control.Capture_Value("AdapterCompatibility", mj);
                    this.Block[Index].MemorySize = Control.Capture_Number("AdapterRAM", mj).ToString();
                    this.Block[Index].NowBitsPerPixel = Control.Capture_Value("CurrentBitsPerPixel", mj);
                    this.Block[Index].NowHorizResolution = Control.Capture_Value("CurrentHorizontalResolution", mj);
                    this.Block[Index].NowVertResolution = Control.Capture_Value("CurrentVerticalResolution", mj);
                    this.Block[Index].NowRefreshRate = Control.Capture_Value("CurrentRefreshRate", mj);
                    this.Block[Index].MaxRefreshRate = Control.Capture_Value("MaxRefreshRate", mj);
                    this.Block[Index].MinRefreshRate = Control.Capture_Value("MinRefreshRate", mj);
                    this.Block[Index].NowNumberOfColors = Control.Capture_Value("CurrentNumberOfColors", mj);
                    this.Block[Index].Mode = Control.Capture_Value("VideoModeDescription", mj);

                    Index++;
                }
            }
        }

        public VIDEO()
        {
            Search(); // Init componenents and searching the data
        }

    }

    public class AUDIO
    {
        public Int16 NumbersBlocks = 0;

        public struct BLOCK
        {
            public string Name;
            public string Manufacturer;
            public string PowerManagmentSupport;
        }

        public BLOCK[] Block;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = Control.Classe_Find("Win32_SoundDevice")) != null)
                Collection = mos.Get();
            else
                return 0;

            return Convert.ToInt16(Collection.Count); // Return dimension
        }

        private void Blocks_Init()
        {
            NumbersBlocks = Blocks_Count(); // Blocks numbers search
            Block = new BLOCK[NumbersBlocks]; // Init array dimension
            for (int i = 0; i < NumbersBlocks; i++)
                Block[i] = new BLOCK(); // Blocks creation
        }

        public void Search()
        {
            Blocks_Init();

            if (((mos = Control.Classe_Find("Win32_SoundDevice")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Block[Index].Name = Control.Capture_Value("Caption", mj);
                    this.Block[Index].Manufacturer = Control.Capture_Value("Manufacturer", mj);
                    this.Block[Index].PowerManagmentSupport = Control.Capture_Value("PowerManagementSupported", mj);

                    Index++;
                }
            }
        }

        public AUDIO()
        {
            Search(); // Init componenents and searching the data
        }
    }

    public class CPU
    {
        public Int16 CpuNumbers = 0;

        public struct ELEMENTS
        {
            public string Name;
            public string AddressSize;
            public string Description;
            public string Manufacturer;
            public string Revision;
            public string Socket;
            public string N_Core;
            public string MaxSpeed;
            public string N_Thread;
            public string L1_Cache;
            public string L2_Cache;
            public string L3_Cache;
        }

        public ELEMENTS[] Elements;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        private Int16 CPU_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = Control.Classe_Find("Win32_Processor")) != null)
                Collection = mos.Get();
            else
                return 0;

            return Convert.ToInt16(Collection.Count); // Return dimension
        }

        private void CPU_Init()
        {
            CpuNumbers = CPU_Count(); // Blocks numbers search
            Elements = new ELEMENTS[CpuNumbers]; // Init array dimension
            for (int i = 0; i < CpuNumbers; i++)
                Elements[i] = new ELEMENTS(); // Blocks creation
        }

        public void Search()
        {
            CPU_Init();

            if (((mos = Control.Classe_Find("Win32_Processor")) != null) || (this.CpuNumbers != 0))
            {

                int Index = 0;

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Elements[Index].Name = Control.Capture_Value("Name", mj);
                    this.Elements[Index].AddressSize = Control.Capture_Value("AddressWidth", mj);
                    this.Elements[Index].Description = Control.Capture_Value("Description", mj);
                    this.Elements[Index].Manufacturer = Control.Capture_Value("Manufacturer", mj);
                    this.Elements[Index].Revision = Control.Capture_Value("Revision", mj);
                    this.Elements[Index].Socket = Control.Capture_Value("SocketDesignation", mj);
                    this.Elements[Index].N_Core = Control.Capture_Value("NumberOfCores", mj);
                    this.Elements[Index].N_Thread = Control.Capture_Value("NumberOfLogicalProcessors", mj);
                    this.Elements[Index].MaxSpeed = Control.Capture_Value("MaxClockSpeed", mj);
                    this.Elements[Index].L1_Cache = (Convert.ToInt16(Control.Capture_Value("L2CacheSize", mj)) / 4).ToString();
                    this.Elements[Index].L2_Cache = Control.Capture_Value("L2CacheSize", mj);
                    this.Elements[Index].L3_Cache = Control.Capture_Value("L3CacheSize", mj);

                    Index++;
                }
            }
        }

        public CPU()
        {
            Search(); // Init componenents and searching the data
        }

    }

    public class RAM
    {

        public UInt64 Size;
        public Int16 NumbersBlocks = 0;
        public string Type;

        public struct BLOCK
        {
            public string Value;
            public string Location;
            public string Slot;
            public string Manufacturer;
            public string PartyNumber;
            public string SerialNumber;
            public string Speed;
            public string BusSize;
            public string Voltage;
        }

        public BLOCK[] Block;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = Control.Classe_Find("Win32_PhysicalMemory")) != null)
                Collection = mos.Get();
            else
                return 0;

            return Convert.ToInt16(Collection.Count); // Return dimension
        }

        private void Blocks_Init()
        {
            NumbersBlocks = Blocks_Count(); // Blocks numbers search
            Block = new BLOCK[NumbersBlocks]; // Init array dimension
            for (int i = 0; i < NumbersBlocks; i++)
                Block[i] = new BLOCK(); // Creat blocks
        }

        public void Search()
        {
            Blocks_Init();

            if (((mos = Control.Classe_Find("Win32_PhysicalMemory")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get())
                {
                    this.Block[Index].Value = Control.Capture_Value("Capacity", mj);
                    this.Block[Index].Location = Control.Capture_Value("BankLabel", mj);
                    this.Block[Index].Slot = Control.Capture_Value("DeviceLocator", mj);
                    this.Block[Index].Manufacturer = Control.Capture_Value("Manufacturer", mj);
                    this.Block[Index].PartyNumber = Control.Capture_Value("PartNumber", mj);
                    this.Block[Index].SerialNumber = Control.Capture_Value("SerialNumber", mj);
                    this.Block[Index].Speed = Control.Capture_Value("ConfiguredClockSpeed", mj);
                    this.Block[Index].BusSize = Control.Capture_Value("DataWidth", mj);
                    this.Block[Index].Voltage = Control.Capture_Value("MinVoltage", mj);

                    Index++;
                }
            }

            // Serach for Size and Type

            if (((mos = Control.Classe_Find("Win32_PhysicalMemoryArray")) != null) || (this.NumbersBlocks != 0))
            {
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Size = Convert.ToUInt64(Control.Capture_Value("MaxCapacity", mj)); // Size
                    this.Type = Control.Capture_Value("Caption", mj); // Type
                }
            }
        }

        public RAM()
        {
            Search(); // Init componenents and searching the data
        }

    }

    public class DISK
    {
        public Int16 NumbersBlocks = 0;

        public struct BLOCK
        {
            public string Index;
            public string Name;
            public string MediaType;
            public string Intreface;
            public string Size;
            public string SerialNumber;
            public string Cylinders;
            public string Heads;
            public string Sectors;
            public string Tracks;
            public string TracksPerCylinder;
            public string BytesPerSector;
            public string FirmwareVersion;
        }

        public BLOCK[] Block;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = Control.Classe_Find("Win32_DiskDrive")) != null)
                Collection = mos.Get();
            else
                return 0;

            return Convert.ToInt16(Collection.Count); // Return dimension
        }

        private void Blocks_Init()
        {
            NumbersBlocks = Blocks_Count(); // Blocks numbers search
            Block = new BLOCK[NumbersBlocks]; // Init array dimension
            for (int i = 0; i < NumbersBlocks; i++)
                Block[i] = new BLOCK(); // Creat blocks
        }

        public void Search()
        {
            Blocks_Init();

            if (((mos = Control.Classe_Find("Win32_DiskDrive")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Block[Index].Index = Control.Capture_Value("Index", mj);
                    this.Block[Index].Name = Control.Capture_Value("Caption", mj);
                    this.Block[Index].MediaType = Control.Capture_Value("MediaType", mj);
                    this.Block[Index].Intreface = Control.Capture_Value("InterfaceType", mj);
                    this.Block[Index].Size = Control.Capture_Value("Size", mj);
                    this.Block[Index].SerialNumber = Control.Capture_Value("SerialNumber", mj);
                    this.Block[Index].Cylinders = Control.Capture_Value("TotalCylinders", mj);
                    this.Block[Index].Heads = Control.Capture_Value("TotalHeads", mj);
                    this.Block[Index].Sectors = Control.Capture_Value("TotalSectors", mj);
                    this.Block[Index].Tracks = Control.Capture_Value("TotalTracks", mj);
                    this.Block[Index].TracksPerCylinder = Control.Capture_Value("TracksPerCylinder", mj);
                    this.Block[Index].BytesPerSector = Control.Capture_Value("BytesPerSector", mj);
                    this.Block[Index].FirmwareVersion = Control.Capture_Value("FirmwareRevision", mj);

                    Index++;
                }
            }
        }

        public DISK()
        {
            Search(); // Init componenents and searching the data
        }

    }

    public class ETHERNET
    {

        public Int16 NumbersBlocks = 0;

        public struct BLOCK
        {
            public string Index;
            public string DeviceID;
            public string InterfaceIndex;
            public string Name;
            public string Description;
            public string Type;
            public string Manufacturer;
            public string Speed;
            public string MACAddresse;
        }

        public BLOCK[] Block;

        ManagementObjectSearcher mos;
        CONTROL Control = new CONTROL();

        private Int16 Blocks_Count()
        {

            Int16 Count = 0;

            // Components count
            ManagementObjectSearcher mos;

            if ((mos = Control.Classe_Find("Win32_NetworkAdapter")) != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Read data
                    if (Control.Capture_Value("MACAddress", mj) != "N/A")
                        Count++;
            }
            else
                return 0;

            return Count; // Return dimension
        }

        private void Blocks_Init()
        {
            NumbersBlocks = Blocks_Count(); // Blocks numbers search
            Block = new BLOCK[NumbersBlocks]; // Init array dimension
            for (int i = 0; i < NumbersBlocks; i++)
                Block[i] = new BLOCK(); // Creat blocks
        }

        public void Search()
        {
            Blocks_Init();

            if (((mos = Control.Classe_Find("Win32_NetworkAdapter")) != null) || (this.NumbersBlocks != 0))
            {

                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    if ((Control.Capture_Value("MACAddress", mj) != "N/A"))
                    {
                        this.Block[Index].Index = Control.Capture_Value("Index", mj);
                        this.Block[Index].DeviceID = Control.Capture_Value("DeviceID", mj);
                        this.Block[Index].InterfaceIndex = Control.Capture_Value("InterfaceIndex", mj);
                        this.Block[Index].Name = Control.Capture_Value("Name", mj);
                        this.Block[Index].Description = Control.Capture_Value("Description", mj);
                        this.Block[Index].Type = Control.Capture_Value("NetConnectionID", mj);
                        this.Block[Index].Manufacturer = Control.Capture_Value("Manufacturer", mj);
                        this.Block[Index].Speed = Control.Capture_Value("Speed", mj);
                        this.Block[Index].MACAddresse = Control.Capture_Value("MACAddress", mj);

                        Index++;
                    }
                }
            }
        }

        public ETHERNET()
        {
            Search(); // Init componenents and searching the data
        }

    }

    //
    // PROCESS CLASS
    //

    public class EXECUTE_PROCESS
    {
        public System.Threading.Thread Th;

        public void Start(System.Threading.ParameterizedThreadStart th)
        {
            this.Th = new System.Threading.Thread(th);
            this.Th.Start();
        }

        public void Stop()
        {
            this.Th.Abort();
        }
    }
}
