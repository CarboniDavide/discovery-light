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

        private void GetDriveInfo()
        {
            // get drive info
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_ComputerSystem"))
            {
                this.Name = ComponentsUtils.Capture_Value("Name", mj);
                this.Type = ComponentsUtils.Capture_Value("SystemType", mj);
                this.Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                this.Model = ComponentsUtils.Capture_Value("Model", mj);
                this.User = ComponentsUtils.Capture_Value("UserName", mj);
                this.Domaine = ComponentsUtils.Capture_Value("Domain", mj);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_OperatingSystem"))
            {
                SystemOS = ComponentsUtils.Capture_Value("Caption", mj);
                SystemOS_Brand = ComponentsUtils.Capture_Value("Manufacturer", mj);
                SystemOS_Version = ComponentsUtils.Capture_Value("BuildNumber", mj);
                SystemOS_Architecture = ComponentsUtils.Capture_Value("OSArchitecture", mj);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_ComputerSystemProduct"))
            {
                IDNumber = ComponentsUtils.Capture_Value("IdentifyingNumber", mj);
            }
        }

        public PC()
        {
            GetDriveInfo();
        }
    }

    public class BIOS
    {
        public string Manufacturer;
        public string SerialNumber;
        public string Version;
        public string ReleaseData;

        public void GetDriveInfo()
        {
            // Get all drive info
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_BIOS"))
            {
                this.Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                this.SerialNumber = ComponentsUtils.Capture_Value("SerialNumber", mj);
                this.Version = ComponentsUtils.Capture_Value("Caption", mj);
                this.ReleaseData = ComponentsUtils.Capture_Value("ReleaseDate", mj);
            }
        }

        public BIOS()
        {
            GetDriveInfo();
        }
    }

    public class MAINBOARD
    {
        public string Manufacturer;
        public string Model;
        public string Version;
        public string PrimaryBus_Value;
        public string SecondaryBus_Value;

        public void GetDriveInfo()
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_BaseBoard")) // Read data
            {
                this.Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                this.Model = ComponentsUtils.Capture_Value("Product", mj);
                this.Version = ComponentsUtils.Capture_Value("Version", mj);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_MotherboardDevice")) // Read data
            {
                this.PrimaryBus_Value = ComponentsUtils.Capture_Value("PrimaryBusType", mj);
                this.SecondaryBus_Value = ComponentsUtils.Capture_Value("SecondaryBusType", mj);
            }
        }

        public MAINBOARD()
        {
            GetDriveInfo();
        }
    }

    public class VIDEO
    {
        public int BlockNumber = 0;
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

        private ManagementObjectCollection collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_VideoController");
            // count number of drive
            BlockNumber = (collection == null) ? collection.Count : 0;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber]; 

            int index = 0;

            // get and write values
            foreach (ManagementObject mj in collection) // Read data
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = ComponentsUtils.Capture_Value("Name", mj);
                this.Block[index].Manufacturer = ComponentsUtils.Capture_Value("Description", mj);
                this.Block[index].AdpterType = ComponentsUtils.Capture_Value("AdapterCompatibility", mj);
                this.Block[index].MemorySize = ComponentsUtils.Capture_Number("AdapterRAM", mj).ToString();
                this.Block[index].NowBitsPerPixel = ComponentsUtils.Capture_Value("CurrentBitsPerPixel", mj);
                this.Block[index].NowHorizResolution = ComponentsUtils.Capture_Value("CurrentHorizontalResolution", mj);
                this.Block[index].NowVertResolution = ComponentsUtils.Capture_Value("CurrentVerticalResolution", mj);
                this.Block[index].NowRefreshRate = ComponentsUtils.Capture_Value("CurrentRefreshRate", mj);
                this.Block[index].MaxRefreshRate = ComponentsUtils.Capture_Value("MaxRefreshRate", mj);
                this.Block[index].MinRefreshRate = ComponentsUtils.Capture_Value("MinRefreshRate", mj);
                this.Block[index].NowNumberOfColors = ComponentsUtils.Capture_Value("CurrentNumberOfColors", mj);
                this.Block[index].Mode = ComponentsUtils.Capture_Value("VideoModeDescription", mj);

                index++;
            }
        }

        public VIDEO()
        {
            GetDriveInfo(); // Init componenents and searching the data
        }

    }

    public class AUDIO
    {
        public int BlockNumber = 0;
        public struct BLOCK
        {
            public string Name;
            public string Manufacturer;
            public string PowerManagmentSupport;
        }

        private ManagementObjectCollection collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_SoundDevice");
            // count number of drive
            BlockNumber = (collection == null) ? collection.Count : 0;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = ComponentsUtils.Capture_Value("Caption", mj);
                this.Block[index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                this.Block[index].PowerManagmentSupport = ComponentsUtils.Capture_Value("PowerManagementSupported", mj);

                index++;
            }
        }

        public AUDIO()
        {
            GetDriveInfo(); // Init componenents and searching the data
        }
    }

    public class CPU
    {
        public int BlockNumber = 0;

        public struct BLOCK
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

        private ManagementObjectCollection collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_Processor");
            // count number of drive
            BlockNumber = (collection == null) ? collection.Count : 0;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            foreach (ManagementObject mj in collection) // Read data
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = ComponentsUtils.Capture_Value("Name", mj);
                this.Block[index].AddressSize = ComponentsUtils.Capture_Value("AddressWidth", mj);
                this.Block[index].Description = ComponentsUtils.Capture_Value("Description", mj);
                this.Block[index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                this.Block[index].Revision = ComponentsUtils.Capture_Value("Revision", mj);
                this.Block[index].Socket = ComponentsUtils.Capture_Value("SocketDesignation", mj);
                this.Block[index].N_Core = ComponentsUtils.Capture_Value("NumberOfCores", mj);
                this.Block[index].N_Thread = ComponentsUtils.Capture_Value("NumberOfLogicalProcessors", mj);
                this.Block[index].MaxSpeed = ComponentsUtils.Capture_Value("MaxClockSpeed", mj);
                this.Block[index].L1_Cache = (Convert.ToInt16(ComponentsUtils.Capture_Value("L2CacheSize", mj)) / 4).ToString();
                this.Block[index].L2_Cache = ComponentsUtils.Capture_Value("L2CacheSize", mj);
                this.Block[index].L3_Cache = ComponentsUtils.Capture_Value("L3CacheSize", mj);

                index++;
            }
        }

        public CPU()
        {
            GetDriveInfo();
        }

    }

    public class RAM
    {
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

        public UInt64 Size;
        public int BlockNumber = 0;
        public string Type;
        private ManagementObjectCollection collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_PhysicalMemory");
            // count number of drive
            BlockNumber = (collection == null) ? collection.Count : 0;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Value = ComponentsUtils.Capture_Value("Capacity", mj);
                this.Block[index].Location = ComponentsUtils.Capture_Value("BankLabel", mj);
                this.Block[index].Slot = ComponentsUtils.Capture_Value("DeviceLocator", mj);
                this.Block[index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                this.Block[index].PartyNumber = ComponentsUtils.Capture_Value("PartNumber", mj);
                this.Block[index].SerialNumber = ComponentsUtils.Capture_Value("SerialNumber", mj);
                this.Block[index].Speed = ComponentsUtils.Capture_Value("ConfiguredClockSpeed", mj);
                this.Block[index].BusSize = ComponentsUtils.Capture_Value("DataWidth", mj);
                this.Block[index].Voltage = ComponentsUtils.Capture_Value("MinVoltage", mj);

                index++;
            }

            // Serach for Size and Type

            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_PhysicalMemoryArray");

            foreach (ManagementObject mj in collection) // Read data
            {
                this.Size = Convert.ToUInt64(ComponentsUtils.Capture_Value("MaxCapacity", mj)); // Size
                this.Type = ComponentsUtils.Capture_Value("Caption", mj); // Type
            }
        }

        public RAM()
        {
            GetDriveInfo();
        }

    }

    public class DISK
    {
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

        public int BlockNumber = 0;
        private ManagementObjectCollection collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_DiskDrive");
            // count number of drive
            BlockNumber = (collection == null) ? collection.Count : 0;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Index = ComponentsUtils.Capture_Value("Index", mj);
                this.Block[index].Name = ComponentsUtils.Capture_Value("Caption", mj);
                this.Block[index].MediaType = ComponentsUtils.Capture_Value("MediaType", mj);
                this.Block[index].Intreface = ComponentsUtils.Capture_Value("InterfaceType", mj);
                this.Block[index].Size = ComponentsUtils.Capture_Value("Size", mj);
                this.Block[index].SerialNumber = ComponentsUtils.Capture_Value("SerialNumber", mj);
                this.Block[index].Cylinders = ComponentsUtils.Capture_Value("TotalCylinders", mj);
                this.Block[index].Heads = ComponentsUtils.Capture_Value("TotalHeads", mj);
                this.Block[index].Sectors = ComponentsUtils.Capture_Value("TotalSectors", mj);
                this.Block[index].Tracks = ComponentsUtils.Capture_Value("TotalTracks", mj);
                this.Block[index].TracksPerCylinder = ComponentsUtils.Capture_Value("TracksPerCylinder", mj);
                this.Block[index].BytesPerSector = ComponentsUtils.Capture_Value("BytesPerSector", mj);
                this.Block[index].FirmwareVersion = ComponentsUtils.Capture_Value("FirmwareRevision", mj);

                index++;
            }
        }

        public DISK()
        {
            GetDriveInfo();
        }

    }

    public class ETHERNET
    {
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

        public int BlockNumber = 0;
        private ManagementObjectCollection collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_NetworkAdapter");
            // count number of drive
            BlockNumber = (collection == null) ? collection.Count : 0;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Index = ComponentsUtils.Capture_Value("Index", mj);
                this.Block[index].DeviceID = ComponentsUtils.Capture_Value("DeviceID", mj);
                this.Block[index].InterfaceIndex = ComponentsUtils.Capture_Value("InterfaceIndex", mj);
                this.Block[index].Name = ComponentsUtils.Capture_Value("Name", mj);
                this.Block[index].Description = ComponentsUtils.Capture_Value("Description", mj);
                this.Block[index].Type = ComponentsUtils.Capture_Value("NetConnectionID", mj);
                this.Block[index].Manufacturer = ComponentsUtils.Capture_Value("Manufacturer", mj);
                this.Block[index].Speed = ComponentsUtils.Capture_Value("Speed", mj);
                this.Block[index].MACAddresse = ComponentsUtils.Capture_Value("MACAddress", mj);

                index++;
            }
        }

        public ETHERNET()
        {
            GetDriveInfo(); // Init componenents and searching the data
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
