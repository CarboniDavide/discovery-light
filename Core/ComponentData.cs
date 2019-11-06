using System;
using System.Linq;
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
                this.Name = ComponentsUtils.GetProperty("Name", mj);
                this.Type = ComponentsUtils.GetProperty("SystemType", mj);
                this.Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj);
                this.Model = ComponentsUtils.GetProperty("Model", mj);
                this.User = ComponentsUtils.GetProperty("UserName", mj);
                this.Domaine = ComponentsUtils.GetProperty("Domain", mj);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_OperatingSystem"))
            {
                SystemOS = ComponentsUtils.GetProperty("Caption", mj);
                SystemOS_Brand = ComponentsUtils.GetProperty("Manufacturer", mj);
                SystemOS_Version = ComponentsUtils.GetProperty("BuildNumber", mj);
                SystemOS_Architecture = ComponentsUtils.GetProperty("OSArchitecture", mj);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_ComputerSystemProduct"))
            {
                IDNumber = ComponentsUtils.GetProperty("IdentifyingNumber", mj);
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
                this.Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj);
                this.SerialNumber = ComponentsUtils.GetProperty("SerialNumber", mj);
                this.Version = ComponentsUtils.GetProperty("Caption", mj);
                this.ReleaseData = ComponentsUtils.GetProperty("ReleaseDate", mj);
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
                this.Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj);
                this.Model = ComponentsUtils.GetProperty("Product", mj);
                this.Version = ComponentsUtils.GetProperty("Version", mj);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_MotherboardDevice")) // Read data
            {
                this.PrimaryBus_Value = ComponentsUtils.GetProperty("PrimaryBusType", mj);
                this.SecondaryBus_Value = ComponentsUtils.GetProperty("SecondaryBusType", mj);
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
                this.Block[index].Name = ComponentsUtils.GetProperty("Name", mj);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Description", mj);
                this.Block[index].AdpterType = ComponentsUtils.GetProperty("AdapterCompatibility", mj);
                this.Block[index].MemorySize = ComponentsUtils.Capture_Number("AdapterRAM", mj).ToString();
                this.Block[index].NowBitsPerPixel = ComponentsUtils.GetProperty("CurrentBitsPerPixel", mj);
                this.Block[index].NowHorizResolution = ComponentsUtils.GetProperty("CurrentHorizontalResolution", mj);
                this.Block[index].NowVertResolution = ComponentsUtils.GetProperty("CurrentVerticalResolution", mj);
                this.Block[index].NowRefreshRate = ComponentsUtils.GetProperty("CurrentRefreshRate", mj);
                this.Block[index].MaxRefreshRate = ComponentsUtils.GetProperty("MaxRefreshRate", mj);
                this.Block[index].MinRefreshRate = ComponentsUtils.GetProperty("MinRefreshRate", mj);
                this.Block[index].NowNumberOfColors = ComponentsUtils.GetProperty("CurrentNumberOfColors", mj);
                this.Block[index].Mode = ComponentsUtils.GetProperty("VideoModeDescription", mj);

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
                this.Block[index].Name = ComponentsUtils.GetProperty("Caption", mj);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj);
                this.Block[index].PowerManagmentSupport = ComponentsUtils.GetProperty("PowerManagementSupported", mj);

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
                this.Block[index].Name = ComponentsUtils.GetProperty("Name", mj);
                this.Block[index].AddressSize = ComponentsUtils.GetProperty("AddressWidth", mj);
                this.Block[index].Description = ComponentsUtils.GetProperty("Description", mj);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj);
                this.Block[index].Revision = ComponentsUtils.GetProperty("Revision", mj);
                this.Block[index].Socket = ComponentsUtils.GetProperty("SocketDesignation", mj);
                this.Block[index].N_Core = ComponentsUtils.GetProperty("NumberOfCores", mj);
                this.Block[index].N_Thread = ComponentsUtils.GetProperty("NumberOfLogicalProcessors", mj);
                this.Block[index].MaxSpeed = ComponentsUtils.GetProperty("MaxClockSpeed", mj);
                this.Block[index].L1_Cache = (Convert.ToInt16(ComponentsUtils.GetProperty("L2CacheSize", mj)) / 4).ToString();
                this.Block[index].L2_Cache = ComponentsUtils.GetProperty("L2CacheSize", mj);
                this.Block[index].L3_Cache = ComponentsUtils.GetProperty("L3CacheSize", mj);

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
                this.Block[index].Value = ComponentsUtils.GetProperty("Capacity", mj);
                this.Block[index].Location = ComponentsUtils.GetProperty("BankLabel", mj);
                this.Block[index].Slot = ComponentsUtils.GetProperty("DeviceLocator", mj);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj);
                this.Block[index].PartyNumber = ComponentsUtils.GetProperty("PartNumber", mj);
                this.Block[index].SerialNumber = ComponentsUtils.GetProperty("SerialNumber", mj);
                this.Block[index].Speed = ComponentsUtils.GetProperty("ConfiguredClockSpeed", mj);
                this.Block[index].BusSize = ComponentsUtils.GetProperty("DataWidth", mj);
                this.Block[index].Voltage = ComponentsUtils.GetProperty("MinVoltage", mj);

                index++;
            }

            // Serach for Size and Type

            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_PhysicalMemoryArray");

            foreach (ManagementObject mj in collection) // Read data
            {
                this.Size = Convert.ToUInt64(ComponentsUtils.GetProperty("MaxCapacity", mj)); // Size
                this.Type = ComponentsUtils.GetProperty("Caption", mj); // Type
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
                this.Block[index].Index = ComponentsUtils.GetProperty("Index", mj);
                this.Block[index].Name = ComponentsUtils.GetProperty("Caption", mj);
                this.Block[index].MediaType = ComponentsUtils.GetProperty("MediaType", mj);
                this.Block[index].Intreface = ComponentsUtils.GetProperty("InterfaceType", mj);
                this.Block[index].Size = ComponentsUtils.GetProperty("Size", mj);
                this.Block[index].SerialNumber = ComponentsUtils.GetProperty("SerialNumber", mj);
                this.Block[index].Cylinders = ComponentsUtils.GetProperty("TotalCylinders", mj);
                this.Block[index].Heads = ComponentsUtils.GetProperty("TotalHeads", mj);
                this.Block[index].Sectors = ComponentsUtils.GetProperty("TotalSectors", mj);
                this.Block[index].Tracks = ComponentsUtils.GetProperty("TotalTracks", mj);
                this.Block[index].TracksPerCylinder = ComponentsUtils.GetProperty("TracksPerCylinder", mj);
                this.Block[index].BytesPerSector = ComponentsUtils.GetProperty("BytesPerSector", mj);
                this.Block[index].FirmwareVersion = ComponentsUtils.GetProperty("FirmwareRevision", mj);

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
                this.Block[index].Index = ComponentsUtils.GetProperty("Index", mj);
                this.Block[index].DeviceID = ComponentsUtils.GetProperty("DeviceID", mj);
                this.Block[index].InterfaceIndex = ComponentsUtils.GetProperty("InterfaceIndex", mj);
                this.Block[index].Name = ComponentsUtils.GetProperty("Name", mj);
                this.Block[index].Description = ComponentsUtils.GetProperty("Description", mj);
                this.Block[index].Type = ComponentsUtils.GetProperty("NetConnectionID", mj);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj);
                this.Block[index].Speed = ComponentsUtils.GetProperty("Speed", mj);
                this.Block[index].MACAddresse = ComponentsUtils.GetProperty("MACAddress", mj);

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
