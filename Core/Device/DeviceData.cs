using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace DiscoveryLight.Core.Device.Data
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_ComputerSystem"))
            {
                this.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                this.Type = DeviceUtils.GetProperty("SystemType", mj, DeviceUtils.ReturnType.String);
                this.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                this.Model = DeviceUtils.GetProperty("Model", mj, DeviceUtils.ReturnType.String);
                this.User = DeviceUtils.GetProperty("UserName", mj, DeviceUtils.ReturnType.String);
                this.Domaine = DeviceUtils.GetProperty("Domain", mj, DeviceUtils.ReturnType.String);
            }

            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_OperatingSystem"))
            {
                SystemOS = DeviceUtils.GetProperty("Caption", mj, DeviceUtils.ReturnType.String);
                SystemOS_Brand = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                SystemOS_Version = DeviceUtils.GetProperty("BuildNumber", mj, DeviceUtils.ReturnType.String);
                SystemOS_Architecture = DeviceUtils.GetProperty("OSArchitecture", mj, DeviceUtils.ReturnType.String);
            }

            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_ComputerSystemProduct"))
            {
                IDNumber = DeviceUtils.GetProperty("IdentifyingNumber", mj, DeviceUtils.ReturnType.String);
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_BIOS"))
            {
                this.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                this.SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj, DeviceUtils.ReturnType.String);
                this.Version = DeviceUtils.GetProperty("Caption", mj, DeviceUtils.ReturnType.String);
                this.ReleaseData = DeviceUtils.GetProperty("ReleaseDate", mj, DeviceUtils.ReturnType.String);
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_BaseBoard")) // Read data
            {
                this.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                this.Model = DeviceUtils.GetProperty("Product", mj, DeviceUtils.ReturnType.String);
                this.Version = DeviceUtils.GetProperty("Version", mj, DeviceUtils.ReturnType.String);
            }

            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_MotherboardDevice")) // Read data
            {
                this.PrimaryBus_Value = DeviceUtils.GetProperty("PrimaryBusType", mj, DeviceUtils.ReturnType.String);
                this.SecondaryBus_Value = DeviceUtils.GetProperty("SecondaryBusType", mj, DeviceUtils.ReturnType.String);
            }

            NumberSlot = DeviceUtils.GetDriveInfo("Win32_SystemSlot").Count.ToString();
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
            collection = DeviceUtils.GetDriveInfo("Win32_VideoController");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber]; 

            int index = 0;

            // get and write values
            foreach (ManagementObject mj in collection) // Read data
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Manufacturer = DeviceUtils.GetProperty("Description", mj, DeviceUtils.ReturnType.String);
                this.Block[index].AdpterType = DeviceUtils.GetProperty("AdapterCompatibility", mj, DeviceUtils.ReturnType.String);
                this.Block[index].MemorySize = DeviceUtils.GetProperty("AdapterRAM", mj, DeviceUtils.ReturnType.String);
                this.Block[index].NowBitsPerPixel = DeviceUtils.GetProperty("CurrentBitsPerPixel", mj, DeviceUtils.ReturnType.String);
                this.Block[index].NowHorizResolution = DeviceUtils.GetProperty("CurrentHorizontalResolution", mj, DeviceUtils.ReturnType.String);
                this.Block[index].NowVertResolution = DeviceUtils.GetProperty("CurrentVerticalResolution", mj, DeviceUtils.ReturnType.String);
                this.Block[index].NowRefreshRate = DeviceUtils.GetProperty("CurrentRefreshRate", mj, DeviceUtils.ReturnType.String);
                this.Block[index].MaxRefreshRate = DeviceUtils.GetProperty("MaxRefreshRate", mj, DeviceUtils.ReturnType.String);
                this.Block[index].MinRefreshRate = DeviceUtils.GetProperty("MinRefreshRate", mj, DeviceUtils.ReturnType.String);
                this.Block[index].NowNumberOfColors = DeviceUtils.GetProperty("CurrentNumberOfColors", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Mode = DeviceUtils.GetProperty("VideoModeDescription", mj, DeviceUtils.ReturnType.String);

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
            collection = DeviceUtils.GetDriveInfo("Win32_SoundDevice");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = DeviceUtils.GetProperty("Caption", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                this.Block[index].PowerManagmentSupport = DeviceUtils.GetProperty("PowerManagementSupported", mj, DeviceUtils.ReturnType.String);

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
            collection = DeviceUtils.GetDriveInfo("Win32_Processor");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            foreach (ManagementObject mj in collection) // Read data
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                this.Block[index].AddressSize = DeviceUtils.GetProperty("AddressWidth", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Description = DeviceUtils.GetProperty("Description", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Revision = DeviceUtils.GetProperty("Revision", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Socket = DeviceUtils.GetProperty("SocketDesignation", mj, DeviceUtils.ReturnType.String);
                this.Block[index].N_Core = DeviceUtils.GetProperty("NumberOfCores", mj, DeviceUtils.ReturnType.String);
                this.Block[index].N_Thread = DeviceUtils.GetProperty("NumberOfLogicalProcessors", mj, DeviceUtils.ReturnType.String);
                this.Block[index].MaxSpeed = DeviceUtils.GetProperty("MaxClockSpeed", mj, DeviceUtils.ReturnType.String);
                this.Block[index].L1_Cache = (Convert.ToInt16(DeviceUtils.GetProperty("L2CacheSize", mj, DeviceUtils.ReturnType.String)) / 4).ToString();
                this.Block[index].L2_Cache = DeviceUtils.GetProperty("L2CacheSize", mj, DeviceUtils.ReturnType.String);
                this.Block[index].L3_Cache = DeviceUtils.GetProperty("L3CacheSize", mj, DeviceUtils.ReturnType.String);

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
            collection = DeviceUtils.GetDriveInfo("Win32_PhysicalMemory");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Value = DeviceUtils.GetProperty("Capacity", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Location = DeviceUtils.GetProperty("BankLabel", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Slot = DeviceUtils.GetProperty("DeviceLocator", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                this.Block[index].PartyNumber = DeviceUtils.GetProperty("PartNumber", mj, DeviceUtils.ReturnType.String);
                this.Block[index].SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Speed = DeviceUtils.GetProperty("ConfiguredClockSpeed", mj, DeviceUtils.ReturnType.String);
                this.Block[index].BusSize = DeviceUtils.GetProperty("DataWidth", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Voltage = DeviceUtils.GetProperty("MinVoltage", mj, DeviceUtils.ReturnType.String);

                index++;
            }

            // Serach for Size and Type

            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_PhysicalMemoryArray");

            foreach (ManagementObject mj in collection) // Read data
            {
                this.Size = Convert.ToUInt64(DeviceUtils.GetProperty("MaxCapacity", mj, DeviceUtils.ReturnType.String)); // Size
                this.Type = DeviceUtils.GetProperty("Caption", mj, DeviceUtils.ReturnType.String); // Type
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
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_PhysicalDisk"))
            {
                String currentDrive = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);

                if (currentDrive.Substring(0, 1).Equals(index))
                    return currentDrive.Substring(2, 1) + ":";
            }

            return null;
        }

        public void GetDriveInfo()
        {
            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_DiskDrive");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Index = DeviceUtils.GetProperty("Index", mj, DeviceUtils.ReturnType.String);
                this.Block[index].DriveName = this.FindDriveName(this.Block[index].Index);
                this.Block[index].Name = DeviceUtils.GetProperty("Caption", mj, DeviceUtils.ReturnType.String);
                this.Block[index].MediaType = DeviceUtils.GetProperty("MediaType", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Intreface = DeviceUtils.GetProperty("InterfaceType", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Size = DeviceUtils.GetProperty("Size", mj, DeviceUtils.ReturnType.String);
                this.Block[index].SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Cylinders = DeviceUtils.GetProperty("TotalCylinders", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Heads = DeviceUtils.GetProperty("TotalHeads", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Sectors = DeviceUtils.GetProperty("TotalSectors", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Tracks = DeviceUtils.GetProperty("TotalTracks", mj, DeviceUtils.ReturnType.String);
                this.Block[index].TracksPerCylinder = DeviceUtils.GetProperty("TracksPerCylinder", mj, DeviceUtils.ReturnType.String);
                this.Block[index].BytesPerSector = DeviceUtils.GetProperty("BytesPerSector", mj, DeviceUtils.ReturnType.String);
                this.Block[index].FirmwareVersion = DeviceUtils.GetProperty("FirmwareRevision", mj, DeviceUtils.ReturnType.String);

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
            collection = DeviceUtils.GetDriveInfo("Win32_NetworkAdapter", "MACAddress", null, DeviceUtils.Operator.NotEgual);
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Block = new BLOCK[BlockNumber];

            int index = 0;

            // search et write values

            foreach (ManagementObject mj in collection)
            {
                this.Block[index] = new BLOCK();
                this.Block[index].Index = DeviceUtils.GetProperty("Index", mj, DeviceUtils.ReturnType.String);
                this.Block[index].DeviceID = DeviceUtils.GetProperty("DeviceID", mj, DeviceUtils.ReturnType.String);
                this.Block[index].InterfaceIndex = DeviceUtils.GetProperty("InterfaceIndex", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Description = DeviceUtils.GetProperty("Description", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Type = DeviceUtils.GetProperty("NetConnectionID", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                this.Block[index].Speed = DeviceUtils.GetProperty("Speed", mj, DeviceUtils.ReturnType.String);
                this.Block[index].MACAddresse = DeviceUtils.GetProperty("MACAddress", mj, DeviceUtils.ReturnType.String);

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
