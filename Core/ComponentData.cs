using System;
using System.Management;

namespace DiscoveryLight.Core
{
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

        private void Search()
        {
            if ((mos = ComponentsUtils.Classe_Find("Win32_ComputerSystem")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Name = ComponentsUtils.Capture_Value("Name", mj);
                    this.Type = ComponentsUtils.Capture_Value("SystemType", mj);
                    this.Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                    this.Model = ComponentsUtils.Capture_Value("Model", mj);
                    this.User = ComponentsUtils.Capture_Value("UserName", mj);
                    this.Domaine = ComponentsUtils.Capture_Value("Domain", mj);
                }

            if ((mos = ComponentsUtils.Classe_Find("Win32_OperatingSystem")) != null)
                foreach (ManagementObject mj in mos.Get())
                {
                    SystemOS = ComponentsUtils.Capture_Value("Caption", mj);
                    SystemOS_Brand = ComponentsUtils.Capture_Value("Manufacturer", mj);
                    SystemOS_Version = ComponentsUtils.Capture_Value("BuildNumber", mj);
                    SystemOS_Architecture = ComponentsUtils.Capture_Value("OSArchitecture", mj);
                }

            if ((mos = ComponentsUtils.Classe_Find("Win32_ComputerSystemProduct")) != null)
                foreach (ManagementObject mj in mos.Get())
                {
                    IDNumber = ComponentsUtils.Capture_Value("IdentifyingNumber", mj);
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

        public void Search()
        {
            if ((mos = ComponentsUtils.Classe_Find("Win32_BIOS")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                    this.SerialNumber = ComponentsUtils.Capture_Value("SerialNumber", mj);
                    this.Version = ComponentsUtils.Capture_Value("Caption", mj);
                    this.ReleaseData = ComponentsUtils.Capture_Value("ReleaseDate", mj);
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

        public void Search()
        {
            if ((mos = ComponentsUtils.Classe_Find("Win32_BaseBoard")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                    this.Model = ComponentsUtils.Capture_Value("Product", mj);
                    this.Version = ComponentsUtils.Capture_Value("Version", mj);
                }

            if ((mos = ComponentsUtils.Classe_Find("Win32_MotherboardDevice")) != null)
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.PrimaryBus_Value = ComponentsUtils.Capture_Value("PrimaryBusType", mj);
                    this.SecondaryBus_Value = ComponentsUtils.Capture_Value("SecondaryBusType", mj);
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

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = ComponentsUtils.Classe_Find("Win32_VideoController")) != null)
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

            if (((mos = ComponentsUtils.Classe_Find("Win32_VideoController")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Block[Index].Name = ComponentsUtils.Capture_Value("Name", mj);
                    this.Block[Index].Manufacturer = ComponentsUtils.Capture_Value("Description", mj);
                    this.Block[Index].AdpterType = ComponentsUtils.Capture_Value("AdapterCompatibility", mj);
                    this.Block[Index].MemorySize = ComponentsUtils.Capture_Number("AdapterRAM", mj).ToString();
                    this.Block[Index].NowBitsPerPixel = ComponentsUtils.Capture_Value("CurrentBitsPerPixel", mj);
                    this.Block[Index].NowHorizResolution = ComponentsUtils.Capture_Value("CurrentHorizontalResolution", mj);
                    this.Block[Index].NowVertResolution = ComponentsUtils.Capture_Value("CurrentVerticalResolution", mj);
                    this.Block[Index].NowRefreshRate = ComponentsUtils.Capture_Value("CurrentRefreshRate", mj);
                    this.Block[Index].MaxRefreshRate = ComponentsUtils.Capture_Value("MaxRefreshRate", mj);
                    this.Block[Index].MinRefreshRate = ComponentsUtils.Capture_Value("MinRefreshRate", mj);
                    this.Block[Index].NowNumberOfColors = ComponentsUtils.Capture_Value("CurrentNumberOfColors", mj);
                    this.Block[Index].Mode = ComponentsUtils.Capture_Value("VideoModeDescription", mj);

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

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = ComponentsUtils.Classe_Find("Win32_SoundDevice")) != null)
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

            if (((mos = ComponentsUtils.Classe_Find("Win32_SoundDevice")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Block[Index].Name = ComponentsUtils.Capture_Value("Caption", mj);
                    this.Block[Index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                    this.Block[Index].PowerManagmentSupport = ComponentsUtils.Capture_Value("PowerManagementSupported", mj);

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

        private Int16 CPU_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = ComponentsUtils.Classe_Find("Win32_Processor")) != null)
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

            if (((mos = ComponentsUtils.Classe_Find("Win32_Processor")) != null) || (this.CpuNumbers != 0))
            {

                int Index = 0;

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Elements[Index].Name = ComponentsUtils.Capture_Value("Name", mj);
                    this.Elements[Index].AddressSize = ComponentsUtils.Capture_Value("AddressWidth", mj);
                    this.Elements[Index].Description = ComponentsUtils.Capture_Value("Description", mj);
                    this.Elements[Index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                    this.Elements[Index].Revision = ComponentsUtils.Capture_Value("Revision", mj);
                    this.Elements[Index].Socket = ComponentsUtils.Capture_Value("SocketDesignation", mj);
                    this.Elements[Index].N_Core = ComponentsUtils.Capture_Value("NumberOfCores", mj);
                    this.Elements[Index].N_Thread = ComponentsUtils.Capture_Value("NumberOfLogicalProcessors", mj);
                    this.Elements[Index].MaxSpeed = ComponentsUtils.Capture_Value("MaxClockSpeed", mj);
                    this.Elements[Index].L1_Cache = (Convert.ToInt16(ComponentsUtils.Capture_Value("L2CacheSize", mj)) / 4).ToString();
                    this.Elements[Index].L2_Cache = ComponentsUtils.Capture_Value("L2CacheSize", mj);
                    this.Elements[Index].L3_Cache = ComponentsUtils.Capture_Value("L3CacheSize", mj);

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

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = ComponentsUtils.Classe_Find("Win32_PhysicalMemory")) != null)
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

            if (((mos = ComponentsUtils.Classe_Find("Win32_PhysicalMemory")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get())
                {
                    this.Block[Index].Value = ComponentsUtils.Capture_Value("Capacity", mj);
                    this.Block[Index].Location = ComponentsUtils.Capture_Value("BankLabel", mj);
                    this.Block[Index].Slot = ComponentsUtils.Capture_Value("DeviceLocator", mj);
                    this.Block[Index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                    this.Block[Index].PartyNumber = ComponentsUtils.Capture_Value("PartNumber", mj);
                    this.Block[Index].SerialNumber = ComponentsUtils.Capture_Value("SerialNumber", mj);
                    this.Block[Index].Speed = ComponentsUtils.Capture_Value("ConfiguredClockSpeed", mj);
                    this.Block[Index].BusSize = ComponentsUtils.Capture_Value("DataWidth", mj);
                    this.Block[Index].Voltage = ComponentsUtils.Capture_Value("MinVoltage", mj);

                    Index++;
                }
            }

            // Serach for Size and Type

            if (((mos = ComponentsUtils.Classe_Find("Win32_PhysicalMemoryArray")) != null) || (this.NumbersBlocks != 0))
            {
                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Size = Convert.ToUInt64(ComponentsUtils.Capture_Value("MaxCapacity", mj)); // Size
                    this.Type = ComponentsUtils.Capture_Value("Caption", mj); // Type
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

        private Int16 Blocks_Count()
        {
            // Components count
            ManagementObjectCollection Collection;

            if ((mos = ComponentsUtils.Classe_Find("Win32_DiskDrive")) != null)
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

            if (((mos = ComponentsUtils.Classe_Find("Win32_DiskDrive")) != null) || (this.NumbersBlocks != 0))
            {
                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    this.Block[Index].Index = ComponentsUtils.Capture_Value("Index", mj);
                    this.Block[Index].Name = ComponentsUtils.Capture_Value("Caption", mj);
                    this.Block[Index].MediaType = ComponentsUtils.Capture_Value("MediaType", mj);
                    this.Block[Index].Intreface = ComponentsUtils.Capture_Value("InterfaceType", mj);
                    this.Block[Index].Size = ComponentsUtils.Capture_Value("Size", mj);
                    this.Block[Index].SerialNumber = ComponentsUtils.Capture_Value("SerialNumber", mj);
                    this.Block[Index].Cylinders = ComponentsUtils.Capture_Value("TotalCylinders", mj);
                    this.Block[Index].Heads = ComponentsUtils.Capture_Value("TotalHeads", mj);
                    this.Block[Index].Sectors = ComponentsUtils.Capture_Value("TotalSectors", mj);
                    this.Block[Index].Tracks = ComponentsUtils.Capture_Value("TotalTracks", mj);
                    this.Block[Index].TracksPerCylinder = ComponentsUtils.Capture_Value("TracksPerCylinder", mj);
                    this.Block[Index].BytesPerSector = ComponentsUtils.Capture_Value("BytesPerSector", mj);
                    this.Block[Index].FirmwareVersion = ComponentsUtils.Capture_Value("FirmwareRevision", mj);

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

        private Int16 Blocks_Count()
        {

            Int16 Count = 0;

            // Components count
            ManagementObjectSearcher mos;

            if ((mos = ComponentsUtils.Classe_Find("Win32_NetworkAdapter")) != null)
            {
                foreach (ManagementObject mj in mos.Get()) // Read data
                    if (ComponentsUtils.Capture_Value("MACAddress", mj) != "N/A")
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

            if (((mos = ComponentsUtils.Classe_Find("Win32_NetworkAdapter")) != null) || (this.NumbersBlocks != 0))
            {

                int Index = 0;

                // search et write values

                foreach (ManagementObject mj in mos.Get()) // Read data
                {
                    if ((ComponentsUtils.Capture_Value("MACAddress", mj) != "N/A"))
                    {
                        this.Block[Index].Index = ComponentsUtils.Capture_Value("Index", mj);
                        this.Block[Index].DeviceID = ComponentsUtils.Capture_Value("DeviceID", mj);
                        this.Block[Index].InterfaceIndex = ComponentsUtils.Capture_Value("InterfaceIndex", mj);
                        this.Block[Index].Name = ComponentsUtils.Capture_Value("Name", mj);
                        this.Block[Index].Description = ComponentsUtils.Capture_Value("Description", mj);
                        this.Block[Index].Type = ComponentsUtils.Capture_Value("NetConnectionID", mj);
                        this.Block[Index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                        this.Block[Index].Speed = ComponentsUtils.Capture_Value("Speed", mj);
                        this.Block[Index].MACAddresse = ComponentsUtils.Capture_Value("MACAddress", mj);

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
