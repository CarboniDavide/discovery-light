using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using DiscoveryLight.Core.Device.Utils;

namespace DiscoveryLight.Core.Device.Data
{
    #region Interface

    /// <summary>
    /// Declare base class structure
    /// </summary>
    /// 
    public abstract class DeviceData
    {
        private string deviceName;
        private int blockNumber = 0;
        private List<_Block> blocks = new List<_Block>();


        public string DeviceName { get => deviceName; set => deviceName = value; }
        public int BlockNumber { get => blockNumber; set => blockNumber = value; }
        public List<_Block> Blocks { get => blocks; set => blocks = value; }

        public abstract void GetDriveInfo();

        public class _Block
        {
            public String DeviceID;
            public String Name;
        }
    }

    #endregion

    #region PC

    /// <summary>
    /// Get base pc properties
    /// </summary>
    public class PC: DeviceData
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

        public override void GetDriveInfo()
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
        }
    }

    #endregion

    #region Bios
    /// <summary>
    /// Get base Bios properties
    /// </summary>
    public class BIOS: DeviceData
    {
        public String Manufacturer;
        public String SerialNumber;
        public String Version;
        public String ReleaseData;

        public override void GetDriveInfo()
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
        }
    }

    #endregion

    #region Mainboard

    /// <summary>
    /// Get base pc properties
    /// </summary>

    public class MAINBOARD: DeviceData
    {
        public String Manufacturer;
        public String Model;
        public String Version;
        public String PrimaryBus_Value;
        public String SecondaryBus_Value;
        public String NumberSlot;

        public override void GetDriveInfo()
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
        }
    }

    #endregion

    #region Video

    /// <summary>
    /// Get base Video properties
    /// </summary>

    public class VIDEO: DeviceData
    {
        public class Block: _Block
        {
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

        public override void GetDriveInfo()
        {
            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_VideoController");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Blocks = new List<_Block>();

            // get and write values
            foreach (ManagementObject mj in collection) // Read data
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj, DeviceUtils.ReturnType.String).Substring(15,1);
                t.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                t.Manufacturer = DeviceUtils.GetProperty("AdapterCompatibility", mj, DeviceUtils.ReturnType.String);
                t.AdpterType = DeviceUtils.GetProperty("AdapterDACType", mj, DeviceUtils.ReturnType.String);
                t.MemorySize = DeviceUtils.GetProperty("AdapterRAM", mj, DeviceUtils.ReturnType.String);
                t.NowBitsPerPixel = DeviceUtils.GetProperty("CurrentBitsPerPixel", mj, DeviceUtils.ReturnType.String);
                t.NowHorizResolution = DeviceUtils.GetProperty("CurrentHorizontalResolution", mj, DeviceUtils.ReturnType.String);
                t.NowVertResolution = DeviceUtils.GetProperty("CurrentVerticalResolution", mj, DeviceUtils.ReturnType.String);
                t.NowRefreshRate = DeviceUtils.GetProperty("CurrentRefreshRate", mj, DeviceUtils.ReturnType.String);
                t.MaxRefreshRate = DeviceUtils.GetProperty("MaxRefreshRate", mj, DeviceUtils.ReturnType.String);
                t.MinRefreshRate = DeviceUtils.GetProperty("MinRefreshRate", mj, DeviceUtils.ReturnType.String);
                t.NowNumberOfColors = DeviceUtils.GetProperty("CurrentNumberOfColors", mj, DeviceUtils.ReturnType.String);
                t.Mode = DeviceUtils.GetProperty("VideoModeDescription", mj, DeviceUtils.ReturnType.String);

                Blocks.Add(t);
            }
        }

        public VIDEO()
        {
        }
    }

    #endregion

    #region Audio

    /// <summary>
    /// Get base audio properties
    /// </summary>

    public class AUDIO: DeviceData
    {
        public class Block: _Block
        {
            public String Manufacturer;
            public String PowerManagmentSupport;
        }

        private List<ManagementObject> collection;

        public override void GetDriveInfo()
        {
            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_SoundDevice");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Blocks = new List<_Block>();

            foreach (ManagementObject mj in collection)
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj, DeviceUtils.ReturnType.String);
                t.Name = DeviceUtils.GetProperty("Caption", mj, DeviceUtils.ReturnType.String);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                t.PowerManagmentSupport = DeviceUtils.GetProperty("PowerManagementSupported", mj, DeviceUtils.ReturnType.String);
                Blocks.Add(t);
            }
        }

        public AUDIO()
        {
        }
    }

    #endregion

    #region CPU

    /// <summary>
    /// Get base cpu properties
    /// </summary>

    public class CPU: DeviceData
    {
        public class Block: _Block
        {
            public String ProcessorID;
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
        public override void GetDriveInfo()
        {
            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_Processor");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Blocks = new List<_Block>();

            foreach (ManagementObject mj in collection) // Read data
            {
                var t = new Block();
                t.ProcessorID = DeviceUtils.GetProperty("ProcessorId", mj, DeviceUtils.ReturnType.String);
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj, DeviceUtils.ReturnType.String).Substring(3, 1);
                t.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                t.AddressSize = DeviceUtils.GetProperty("AddressWidth", mj, DeviceUtils.ReturnType.String);
                t.Description = DeviceUtils.GetProperty("Description", mj, DeviceUtils.ReturnType.String);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                t.Revision = DeviceUtils.GetProperty("Revision", mj, DeviceUtils.ReturnType.String);
                t.Socket = DeviceUtils.GetProperty("SocketDesignation", mj, DeviceUtils.ReturnType.String);
                t.N_Core = DeviceUtils.GetProperty("NumberOfCores", mj, DeviceUtils.ReturnType.String);
                t.N_Thread = DeviceUtils.GetProperty("NumberOfLogicalProcessors", mj, DeviceUtils.ReturnType.String);
                t.MaxSpeed = DeviceUtils.GetProperty("MaxClockSpeed", mj, DeviceUtils.ReturnType.String);
                t.L1_Cache = (Convert.ToInt16(DeviceUtils.GetProperty("L2CacheSize", mj, DeviceUtils.ReturnType.String)) / 4).ToString();
                t.L2_Cache = DeviceUtils.GetProperty("L2CacheSize", mj, DeviceUtils.ReturnType.String);
                t.L3_Cache = DeviceUtils.GetProperty("L3CacheSize", mj, DeviceUtils.ReturnType.String);

                Blocks.Add(t);
            }
        }

        public CPU()
        {
        }

    }

    #endregion

    #region Memory

    /// <summary>
    /// Get base ram properties
    /// </summary>

    public class RAM: DeviceData
    {
        public class Block: _Block
        {
            public String Capacity;
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
        public String Type;
        private List<ManagementObject> collection;

        public override void GetDriveInfo()
        {
            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_PhysicalMemory");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Blocks = new List<_Block>();

            // search et write values
            foreach (ManagementObject mj in collection)
            {
                var t = new Block();
                t.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                t.DeviceID = DeviceUtils.GetProperty("BankLabel", mj, DeviceUtils.ReturnType.String).Substring(5,1);
                t.Capacity = DeviceUtils.GetProperty("Capacity", mj, DeviceUtils.ReturnType.String);
                t.Location = DeviceUtils.GetProperty("BankLabel", mj, DeviceUtils.ReturnType.String);
                t.Slot = DeviceUtils.GetProperty("DeviceLocator", mj, DeviceUtils.ReturnType.String);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                t.PartyNumber = DeviceUtils.GetProperty("PartNumber", mj, DeviceUtils.ReturnType.String);
                t.SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj, DeviceUtils.ReturnType.String);
                t.Speed = DeviceUtils.GetProperty("ConfiguredClockSpeed", mj, DeviceUtils.ReturnType.String);
                t.BusSize = DeviceUtils.GetProperty("DataWidth", mj, DeviceUtils.ReturnType.String);
                t.Voltage = DeviceUtils.GetProperty("MinVoltage", mj, DeviceUtils.ReturnType.String);

                Blocks.Add(t);
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
        }

    }

    #endregion

    #region Storage

    /// <summary>
    /// Get base storage properties for each pysical disk
    /// </summary>
    public class DISK: DeviceData
    {
        public class Block: _Block
        {
            public String DriveName;
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

        private List<ManagementObject> collection;

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

        public override void GetDriveInfo()
        {
            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_DiskDrive");
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Blocks = new List<_Block>();  

            // search et write values
            foreach (ManagementObject mj in collection)
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("Index", mj, DeviceUtils.ReturnType.String);
                t.DriveName = this.FindDriveName(t.DeviceID);
                t.Name = DeviceUtils.GetProperty("Caption", mj, DeviceUtils.ReturnType.String);
                t.MediaType = DeviceUtils.GetProperty("MediaType", mj, DeviceUtils.ReturnType.String);
                t.Intreface = DeviceUtils.GetProperty("InterfaceType", mj, DeviceUtils.ReturnType.String);
                t.Size = DeviceUtils.GetProperty("Size", mj, DeviceUtils.ReturnType.String);
                t.SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj, DeviceUtils.ReturnType.String);
                t.Cylinders = DeviceUtils.GetProperty("TotalCylinders", mj, DeviceUtils.ReturnType.String);
                t.Heads = DeviceUtils.GetProperty("TotalHeads", mj, DeviceUtils.ReturnType.String);
                t.Sectors = DeviceUtils.GetProperty("TotalSectors", mj, DeviceUtils.ReturnType.String);
                t.Tracks = DeviceUtils.GetProperty("TotalTracks", mj, DeviceUtils.ReturnType.String);
                t.TracksPerCylinder = DeviceUtils.GetProperty("TracksPerCylinder", mj, DeviceUtils.ReturnType.String);
                t.BytesPerSector = DeviceUtils.GetProperty("BytesPerSector", mj, DeviceUtils.ReturnType.String);
                t.FirmwareVersion = DeviceUtils.GetProperty("FirmwareRevision", mj, DeviceUtils.ReturnType.String);

                Blocks.Add(t);
            }
        }

        public DISK()
        {
        }

    }

    #endregion

    #region Network

    /// <summary>
    /// Get base network properties for each interface
    /// </summary>
    public class NETWORK: DeviceData
    {
        public class Block: _Block
        {
            public String InterfaceIndex;
            public String Description;
            public String Type;
            public String Manufacturer;
            public String Speed;
            public String MACAddresse;
            public String AdapterType;
        }

        private List<ManagementObject> collection;

        public override void GetDriveInfo()
        {
            // get drive info
            collection = DeviceUtils.GetDriveInfo("Win32_NetworkAdapter", "MACAddress", null, DeviceUtils.Operator.NotEgual);
            // count number of drive
            BlockNumber = collection.Count;
            // initialize array to contains each drive info
            Blocks = new List<_Block>();

            // search et write values
            foreach (ManagementObject mj in collection)
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj, DeviceUtils.ReturnType.String);
                t.InterfaceIndex = DeviceUtils.GetProperty("InterfaceIndex", mj, DeviceUtils.ReturnType.String);
                t.Name = DeviceUtils.GetProperty("Name", mj, DeviceUtils.ReturnType.String);
                t.Description = DeviceUtils.GetProperty("Description", mj, DeviceUtils.ReturnType.String);
                t.Type = DeviceUtils.GetProperty("NetConnectionID", mj, DeviceUtils.ReturnType.String);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj, DeviceUtils.ReturnType.String);
                t.Speed = DeviceUtils.GetProperty("Speed", mj, DeviceUtils.ReturnType.String);
                t.MACAddresse = DeviceUtils.GetProperty("MACAddress", mj, DeviceUtils.ReturnType.String);
                t.AdapterType = DeviceUtils.GetProperty("AdapterType", mj, DeviceUtils.ReturnType.String);

                Blocks.Add(t);
            }
        }

        public NETWORK()
        {
        }

    }

    #endregion

    #region Threads
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
    #endregion
}
