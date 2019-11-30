using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using DiscoveryLight.Core.Device.Utils;

namespace DiscoveryLight.Core.Device.Data
{
    #region Interface

    /// <summary>
    /// Device Data main class.
    /// Device Data represents a installed device type. Each device is a collection of subdevice(blocks).
    /// PC can have more subdevices of the same type installed. For example we can have more physical disks mounted. Each of then is a Physical Disk drive.
    /// So Physical Disk is the main drive, and each of them is a subdevice(block)
    /// </summary>
    /// 
    public abstract class DeviceData
    {
        protected readonly string deviceName;       
        protected readonly string className;        
        protected readonly Type classType;          

        private int blockNumber = 0;                             // number of blocks for the same drive( a pc can have one or more cpu, drive audio etc.)
        private List<_Block> blocks = new List<_Block>();        // List of properties for each block           
        private List<ManagementObject> collection;               // drive collection - each collection contains one or more block, one to each installed drive type

        /// <summary>
        /// Override all blocks values if new changes occurred
        /// </summary>
        /// <param name="newListOfValues"></param>
        private void updateInfo(List<_Block> newListOfValues)
        {
            if (newListOfValues.SequenceEqual(Blocks)) return;
            blocks = new List<_Block>();
            blocks = newListOfValues;
            blockNumber = blocks.Count();
        }

        public string DeviceName { get => deviceName; }
        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public List<ManagementObject> Collection { get => collection; set => collection = value; }
        public int BlockNumber { get => blockNumber; set => blockNumber = value; }
        public List<_Block> Blocks { get => blocks; set => updateInfo(value); }

        /// <summary>
        /// Get all properties for all installed drive
        /// </summary>
        public abstract void GetDriveInfo();
        public class _Block
        {
            public String DeviceID;
            public String Name;
        }

        public DeviceData(string deviceName)
        {
            this.deviceName = deviceName;
            this.className = this.GetType().Name;
            this.classType = this.GetType();
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
            // get pc base informations
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_ComputerSystem"))
            {
                this.Name = DeviceUtils.GetProperty("Name", mj);
                this.Type = DeviceUtils.GetProperty("SystemType", mj);
                this.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj);
                this.Model = DeviceUtils.GetProperty("Model", mj);
                this.User = DeviceUtils.GetProperty("UserName", mj);
                this.Domaine = DeviceUtils.GetProperty("Domain", mj);
            }

            // get os base informations
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_OperatingSystem"))
            {
                SystemOS = DeviceUtils.GetProperty("Caption", mj);
                SystemOS_Brand = DeviceUtils.GetProperty("Manufacturer", mj);
                SystemOS_Version = DeviceUtils.GetProperty("BuildNumber", mj);
                SystemOS_Architecture = DeviceUtils.GetProperty("OSArchitecture", mj);
            }

            // get pc base product informations
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_ComputerSystemProduct"))
            {
                IDNumber = DeviceUtils.GetProperty("IdentifyingNumber", mj);
            }
        }

        public PC():base("Pc") { }
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
                this.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj);
                this.SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj);
                this.Version = DeviceUtils.GetProperty("Caption", mj);
                this.ReleaseData = DeviceUtils.GetProperty("ReleaseDate", mj);
            }
        }

        public BIOS():base("Bios") { }
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
            // get motherboard chip properties
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_BaseBoard")) // Read data
            {
                this.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj);
                this.Model = DeviceUtils.GetProperty("Product", mj);
                this.Version = DeviceUtils.GetProperty("Version", mj);
            }

            // get motherboard bus properties
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_MotherboardDevice")) // Read data
            {
                this.PrimaryBus_Value = DeviceUtils.GetProperty("PrimaryBusType", mj);
                this.SecondaryBus_Value = DeviceUtils.GetProperty("SecondaryBusType", mj);
            }

            NumberSlot = DeviceUtils.GetDriveInfo("Win32_SystemSlot").Count.ToString();
        }

        public MAINBOARD():base("Mainboard") { }
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

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection = DeviceUtils.GetDriveInfo("Win32_VideoController");
            // initialize array to contains each drive info
            List<_Block> mmBlocks = new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection) // Read data
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj, 15, 1);
                t.Name = DeviceUtils.GetProperty("Name", mj);
                t.Manufacturer = DeviceUtils.GetProperty("AdapterCompatibility", mj);
                t.AdpterType = DeviceUtils.GetProperty("AdapterDACType", mj);
                t.MemorySize = DeviceUtils.GetProperty("AdapterRAM", mj);
                t.NowBitsPerPixel = DeviceUtils.GetProperty("CurrentBitsPerPixel", mj);
                t.NowHorizResolution = DeviceUtils.GetProperty("CurrentHorizontalResolution", mj);
                t.NowVertResolution = DeviceUtils.GetProperty("CurrentVerticalResolution", mj);
                t.NowRefreshRate = DeviceUtils.GetProperty("CurrentRefreshRate", mj);
                t.MaxRefreshRate = DeviceUtils.GetProperty("MaxRefreshRate", mj);
                t.MinRefreshRate = DeviceUtils.GetProperty("MinRefreshRate", mj);
                t.NowNumberOfColors = DeviceUtils.GetProperty("CurrentNumberOfColors", mj);
                t.Mode = DeviceUtils.GetProperty("VideoModeDescription", mj);

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks = mmBlocks;
        }

        public VIDEO():base("Video") { }
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

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection = DeviceUtils.GetDriveInfo("Win32_SoundDevice");
            // initialize array to contains each drive info
            List<_Block> mmBlocks = new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj);
                t.Name = DeviceUtils.GetProperty("Caption", mj);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj);
                t.PowerManagmentSupport = DeviceUtils.GetProperty("PowerManagementSupported", mj);
                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks = mmBlocks;
        }

        public AUDIO(): base("Audio") { }
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

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection = DeviceUtils.GetDriveInfo("Win32_Processor");
            // initialize array to contains each drive info
            Blocks = new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection) // Read data
            {
                var t = new Block();
                t.ProcessorID = DeviceUtils.GetProperty("ProcessorId", mj);
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj, 3, 1);
                t.Name = DeviceUtils.GetProperty("Name", mj);
                t.AddressSize = DeviceUtils.GetProperty("AddressWidth", mj);
                t.Description = DeviceUtils.GetProperty("Description", mj);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj);
                t.Revision = DeviceUtils.GetProperty("Revision", mj);
                t.Socket = DeviceUtils.GetProperty("SocketDesignation", mj);
                t.N_Core = DeviceUtils.GetProperty("NumberOfCores", mj);
                t.N_Thread = DeviceUtils.GetProperty("NumberOfLogicalProcessors", mj);
                t.MaxSpeed = DeviceUtils.GetProperty("MaxClockSpeed", mj);
                t.L1_Cache = (Convert.ToInt16(DeviceUtils.GetProperty("L2CacheSize", mj)) / 4).ToString();
                t.L2_Cache = DeviceUtils.GetProperty("L2CacheSize", mj);
                t.L3_Cache = DeviceUtils.GetProperty("L3CacheSize", mj);

                Blocks.Add(t);
            }
        }

        public CPU(): base("Cpu") { }

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

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection = DeviceUtils.GetDriveInfo("Win32_PhysicalMemory");
            // initialize array to contains each drive info
            List<_Block> mmBlocks = new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t = new Block();
                t.Name = DeviceUtils.GetProperty("Name", mj);
                t.DeviceID = DeviceUtils.GetProperty("BankLabel", mj, 5, 1);
                t.Capacity = DeviceUtils.GetProperty("Capacity", mj);
                t.Location = DeviceUtils.GetProperty("BankLabel", mj);
                t.Slot = DeviceUtils.GetProperty("DeviceLocator", mj);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj);
                t.PartyNumber = DeviceUtils.GetProperty("PartNumber", mj);
                t.SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj);
                t.Speed = DeviceUtils.GetProperty("ConfiguredClockSpeed", mj);
                t.BusSize = DeviceUtils.GetProperty("DataWidth", mj);
                t.Voltage = DeviceUtils.GetProperty("MinVoltage", mj);

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks = mmBlocks;

            // get drive info
            var a_collection = DeviceUtils.GetDriveInfo("Win32_PhysicalMemoryArray");

            foreach (ManagementObject mj in a_collection) // Read data
            {
                this.Size = Convert.ToUInt64(DeviceUtils.GetProperty("MaxCapacity", mj)); // Size
                this.Type = DeviceUtils.GetProperty("Caption", mj); // Type
            }
        }

        public RAM(): base("Memory") { }
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

        /// <summary>
        /// Get drive name using index value
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public String FindDriveName(String index)
        {
            // get all properties for each installed drive
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_PerfRawData_PerfDisk_PhysicalDisk"))
            {
                String currentDrive = DeviceUtils.GetProperty("Name", mj);

                if (currentDrive.Substring(0, 1).Equals(index))
                    return currentDrive.Substring(2, 1) + ":";
            }

            return null;
        }

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection = DeviceUtils.GetDriveInfo("Win32_DiskDrive");
            // initialize array to contains each drive info
            List<_Block> mmBlocks = new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("Index", mj);
                t.DriveName = this.FindDriveName(t.DeviceID);
                t.Name = DeviceUtils.GetProperty("Caption", mj);
                t.MediaType = DeviceUtils.GetProperty("MediaType", mj);
                t.Intreface = DeviceUtils.GetProperty("InterfaceType", mj);
                t.Size = DeviceUtils.GetProperty("Size", mj);
                t.SerialNumber = DeviceUtils.GetProperty("SerialNumber", mj);
                t.Cylinders = DeviceUtils.GetProperty("TotalCylinders", mj);
                t.Heads = DeviceUtils.GetProperty("TotalHeads", mj);
                t.Sectors = DeviceUtils.GetProperty("TotalSectors", mj);
                t.Tracks = DeviceUtils.GetProperty("TotalTracks", mj);
                t.TracksPerCylinder = DeviceUtils.GetProperty("TracksPerCylinder", mj);
                t.BytesPerSector = DeviceUtils.GetProperty("BytesPerSector", mj);
                t.FirmwareVersion = DeviceUtils.GetProperty("FirmwareRevision", mj);

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks = mmBlocks;
        }

        public DISK(): base("Storage") { }
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
            public String Ip_Address;
            public String SubNetMask;
            public String DefualtGetway;
            public String PrimaryDNS;
            public String SencondaryDNS;
        }

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection = DeviceUtils.GetDriveInfo("Win32_NetworkAdapter", "MACAddress", null, DeviceUtils.Operator.NotEgual);
            // initialize array to contains each drive info
            List<_Block> mmBlocks = new List<_Block>();
            List<String> s = new List<string>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t = new Block();
                t.DeviceID = DeviceUtils.GetProperty("DeviceID", mj);
                t.InterfaceIndex = DeviceUtils.GetProperty("InterfaceIndex", mj);
                t.Name = DeviceUtils.GetProperty("Name", mj);
                t.Description = DeviceUtils.GetProperty("Description", mj);
                t.Type = DeviceUtils.GetProperty("NetConnectionID", mj);
                t.Manufacturer = DeviceUtils.GetProperty("Manufacturer", mj);
                t.Speed = DeviceUtils.GetProperty("Speed", mj);
                t.MACAddresse = DeviceUtils.GetProperty("MACAddress", mj);
                t.AdapterType = DeviceUtils.GetProperty("AdapterType", mj);

                mmBlocks.Add(t);
            }

            //get extended information
            // get drive info collection
            Collection = DeviceUtils.GetDriveInfo("Win32_NetworkAdapterConfiguration", "MACAddress", null, DeviceUtils.Operator.NotEgual);
            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                Block c = (NETWORK.Block)mmBlocks.Where(d => d.Name == DeviceUtils.GetProperty("Description", mj) ).FirstOrDefault();

                c.Ip_Address = DeviceUtils.GetProperty("IpAddress", mj, 0);
                c.DefualtGetway = DeviceUtils.GetProperty("DefaultIPGateway", mj, 0);
                c.PrimaryDNS = DeviceUtils.GetProperty("DNSServerSearchOrder", mj, 0);
                c.SencondaryDNS = DeviceUtils.GetProperty("DNSServerSearchOrder", mj, 1);
                c.SubNetMask = DeviceUtils.GetProperty("IpSubnet", mj, 0);

                var Index = mmBlocks.FindIndex(d => d.Name == DeviceUtils.GetProperty("Description", mj));
                mmBlocks[Index] = c;
            }

            // update values for each subdevice if change occured
            Blocks = mmBlocks;
        }

        public NETWORK():base("Network") { }
    }

    #endregion
}
