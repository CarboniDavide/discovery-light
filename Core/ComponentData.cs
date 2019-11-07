using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace DiscoveryLight.Core
{
    public class PC
    {
        public String Name;
        public String Type;
        public String Manufacturer;
        public String Model;
        public String IDNumber;
        public String User;
        public String Domaine;
        public String SystemOS_Version;
        public String SystemOS;
        public String SystemOS_Brand;
        public String SystemOS_Architecture;
        public String RamSize;

        private void GetDriveInfo()
        {
            // get drive info
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_ComputerSystem"))
            {
                this.Name = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);
                this.Type = ComponentsUtils.GetProperty("SystemType", mj, ComponentsUtils.ReturnType.String);
                this.Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                this.Model = ComponentsUtils.GetProperty("Model", mj, ComponentsUtils.ReturnType.String);
                this.User = ComponentsUtils.GetProperty("UserName", mj, ComponentsUtils.ReturnType.String);
                this.Domaine = ComponentsUtils.GetProperty("Domain", mj, ComponentsUtils.ReturnType.String);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_OperatingSystem"))
            {
                SystemOS = ComponentsUtils.GetProperty("Caption", mj, ComponentsUtils.ReturnType.String);
                SystemOS_Brand = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                SystemOS_Version = ComponentsUtils.GetProperty("BuildNumber", mj, ComponentsUtils.ReturnType.String);
                SystemOS_Architecture = ComponentsUtils.GetProperty("OSArchitecture", mj, ComponentsUtils.ReturnType.String);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_ComputerSystemProduct"))
            {
                IDNumber = ComponentsUtils.GetProperty("IdentifyingNumber", mj, ComponentsUtils.ReturnType.String);
            }
        }

        public PC()
        {
            GetDriveInfo();
        }
    }

    public class BIOS
    {
        public String Manufacturer;
        public String SerialNumber;
        public String Version;
        public String ReleaseData;

        public void GetDriveInfo()
        {
            // Get all drive info
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_BIOS"))
            {
                this.Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                this.SerialNumber = ComponentsUtils.GetProperty("SerialNumber", mj, ComponentsUtils.ReturnType.String);
                this.Version = ComponentsUtils.GetProperty("Caption", mj, ComponentsUtils.ReturnType.String);
                this.ReleaseData = ComponentsUtils.GetProperty("ReleaseDate", mj, ComponentsUtils.ReturnType.String);
            }
        }

        public BIOS()
        {
            GetDriveInfo();
        }
    }

    public class MAINBOARD
    {
        public String Manufacturer;
        public String Model;
        public String Version;
        public String PrimaryBus_Value;
        public String SecondaryBus_Value;
        public String NumberSlot;

        public void GetDriveInfo()
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_BaseBoard")) // Read data
            {
                this.Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                this.Model = ComponentsUtils.GetProperty("Product", mj, ComponentsUtils.ReturnType.String);
                this.Version = ComponentsUtils.GetProperty("Version", mj, ComponentsUtils.ReturnType.String);
            }

            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_MotherboardDevice")) // Read data
            {
                this.PrimaryBus_Value = ComponentsUtils.GetProperty("PrimaryBusType", mj, ComponentsUtils.ReturnType.String);
                this.SecondaryBus_Value = ComponentsUtils.GetProperty("SecondaryBusType", mj, ComponentsUtils.ReturnType.String);
            }

            NumberSlot = ComponentsUtils.GetDriveInfo("Win32_SystemSlot").Count.ToString();
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
            public String Name;
            public String Manufacturer;
            public String AdpterType;
            public String MemorySize;
            public String NowBitsPerPixel;
            public String NowHorizResolution;
            public String NowVertResolution;
            public String NowRefreshRate;
            public String MaxRefreshRate;
            public String MinRefreshRate;
            public String NowNumberOfColors;
            public String Mode;
        }

        private List<ManagementObject> collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_VideoController");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber]; 

            int index = 0;

            // get and write values
            foreach (ManagementObject mj in collection) // Read data
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Description", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].AdpterType = ComponentsUtils.GetProperty("AdapterCompatibility", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].MemorySize = ComponentsUtils.GetProperty("AdapterRAM", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].NowBitsPerPixel = ComponentsUtils.GetProperty("CurrentBitsPerPixel", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].NowHorizResolution = ComponentsUtils.GetProperty("CurrentHorizontalResolution", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].NowVertResolution = ComponentsUtils.GetProperty("CurrentVerticalResolution", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].NowRefreshRate = ComponentsUtils.GetProperty("CurrentRefreshRate", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].MaxRefreshRate = ComponentsUtils.GetProperty("MaxRefreshRate", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].MinRefreshRate = ComponentsUtils.GetProperty("MinRefreshRate", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].NowNumberOfColors = ComponentsUtils.GetProperty("CurrentNumberOfColors", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Mode = ComponentsUtils.GetProperty("VideoModeDescription", mj, ComponentsUtils.ReturnType.String);

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
            public String Name;
            public String Manufacturer;
            public String PowerManagmentSupport;
        }

        private List<ManagementObject> collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_SoundDevice");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = ComponentsUtils.GetProperty("Caption", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].PowerManagmentSupport = ComponentsUtils.GetProperty("PowerManagementSupported", mj, ComponentsUtils.ReturnType.String);

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
            public String Name;
            public String AddressSize;
            public String Description;
            public String Manufacturer;
            public String Revision;
            public String Socket;
            public String N_Core;
            public String MaxSpeed;
            public String N_Thread;
            public String L1_Cache;
            public String L2_Cache;
            public String L3_Cache;
        }

        private List<ManagementObject> collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_Processor");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            foreach (ManagementObject mj in collection) // Read data
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].AddressSize = ComponentsUtils.GetProperty("AddressWidth", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Description = ComponentsUtils.GetProperty("Description", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Revision = ComponentsUtils.GetProperty("Revision", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Socket = ComponentsUtils.GetProperty("SocketDesignation", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].N_Core = ComponentsUtils.GetProperty("NumberOfCores", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].N_Thread = ComponentsUtils.GetProperty("NumberOfLogicalProcessors", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].MaxSpeed = ComponentsUtils.GetProperty("MaxClockSpeed", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].L1_Cache = (Convert.ToInt16(ComponentsUtils.GetProperty("L2CacheSize", mj, ComponentsUtils.ReturnType.String)) / 4).ToString();
                this.Block[index].L2_Cache = ComponentsUtils.GetProperty("L2CacheSize", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].L3_Cache = ComponentsUtils.GetProperty("L3CacheSize", mj, ComponentsUtils.ReturnType.String);

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
            public String Value;
            public String Location;
            public String Slot;
            public String Manufacturer;
            public String PartyNumber;
            public String SerialNumber;
            public String Speed;
            public String BusSize;
            public String Voltage;
        }

        public UInt64 Size;
        public int BlockNumber = 0;
        public String Type;
        private List<ManagementObject> collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_PhysicalMemory");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Value = ComponentsUtils.GetProperty("Capacity", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Location = ComponentsUtils.GetProperty("BankLabel", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Slot = ComponentsUtils.GetProperty("DeviceLocator", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].PartyNumber = ComponentsUtils.GetProperty("PartNumber", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].SerialNumber = ComponentsUtils.GetProperty("SerialNumber", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Speed = ComponentsUtils.GetProperty("ConfiguredClockSpeed", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].BusSize = ComponentsUtils.GetProperty("DataWidth", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Voltage = ComponentsUtils.GetProperty("MinVoltage", mj, ComponentsUtils.ReturnType.String);

                index++;
            }

            // Serach for Size and Type

            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_PhysicalMemoryArray");

            foreach (ManagementObject mj in collection) // Read data
            {
                this.Size = Convert.ToUInt64(ComponentsUtils.GetProperty("MaxCapacity", mj, ComponentsUtils.ReturnType.String)); // Size
                this.Type = ComponentsUtils.GetProperty("Caption", mj, ComponentsUtils.ReturnType.String); // Type
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
            public String DriveName;
            public String Index;
            public String Name;
            public String MediaType;
            public String Intreface;
            public String Size;
            public String SerialNumber;
            public String Cylinders;
            public String Heads;
            public String Sectors;
            public String Tracks;
            public String TracksPerCylinder;
            public String BytesPerSector;
            public String FirmwareVersion;
        }

        public int BlockNumber = 0;
        private List<ManagementObject> collection;
        public BLOCK[] Block;

        public String FindDriveName(String index)
        {
            foreach (ManagementObject mj in ComponentsUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_PhysicalDisk"))
            {
                String currentDrive = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);

                if (currentDrive.Substring(0, 1).Equals(index))
                    return currentDrive.Substring(2, 1) + ":";
            }

            return null;
        }

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_DiskDrive");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Index = ComponentsUtils.GetProperty("Index", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].DriveName = this.FindDriveName(this.Block[index].Index);
                this.Block[index].Name = ComponentsUtils.GetProperty("Caption", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].MediaType = ComponentsUtils.GetProperty("MediaType", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Intreface = ComponentsUtils.GetProperty("InterfaceType", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Size = ComponentsUtils.GetProperty("Size", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].SerialNumber = ComponentsUtils.GetProperty("SerialNumber", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Cylinders = ComponentsUtils.GetProperty("TotalCylinders", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Heads = ComponentsUtils.GetProperty("TotalHeads", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Sectors = ComponentsUtils.GetProperty("TotalSectors", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Tracks = ComponentsUtils.GetProperty("TotalTracks", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].TracksPerCylinder = ComponentsUtils.GetProperty("TracksPerCylinder", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].BytesPerSector = ComponentsUtils.GetProperty("BytesPerSector", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].FirmwareVersion = ComponentsUtils.GetProperty("FirmwareRevision", mj, ComponentsUtils.ReturnType.String);

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
            public String Index;
            public String DeviceID;
            public String InterfaceIndex;
            public String Name;
            public String Description;
            public String Type;
            public String Manufacturer;
            public String Speed;
            public String MACAddresse;
        }

        public int BlockNumber = 0;
        private List<ManagementObject> collection;
        public BLOCK[] Block;

        public void GetDriveInfo()
        {
            // get drive info
            collection = ComponentsUtils.GetDriveInfo("Win32_NetworkAdapter", "MACAddress", null, ComponentsUtils.Operator.NotEgual);
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Index = ComponentsUtils.GetProperty("Index", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].DeviceID = ComponentsUtils.GetProperty("DeviceID", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].InterfaceIndex = ComponentsUtils.GetProperty("InterfaceIndex", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Name = ComponentsUtils.GetProperty("Name", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Description = ComponentsUtils.GetProperty("Description", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Type = ComponentsUtils.GetProperty("NetConnectionID", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Manufacturer = ComponentsUtils.GetProperty("Manufacturer", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].Speed = ComponentsUtils.GetProperty("Speed", mj, ComponentsUtils.ReturnType.String);
                this.Block[index].MACAddresse = ComponentsUtils.GetProperty("MACAddress", mj, ComponentsUtils.ReturnType.String);

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
