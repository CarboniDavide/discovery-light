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

        private int blockNumber=  0;                             // number of blocks for the same drive( a pc can have one or more cpu, drive audio etc.)
        private List<_Block> blocks=  new List<_Block>();        // List of properties for each block           
        private List<WprManagementObject> collection;               // drive collection - each collection contains one or more block, one to each installed drive type

        /// <summary>
        /// Override all blocks values if new changes occurred
        /// </summary>
        /// <param name="newListOfValues"></param>
        private void updateInfo(List<_Block> newListOfValues)
        {
            if (newListOfValues.SequenceEqual(Blocks)) return;
            blocks=  new List<_Block>();
            blocks=  newListOfValues;
            blockNumber=  blocks.Count();
        }

        public string DeviceName { get => deviceName; }
        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public List<WprManagementObject> Collection { get => collection; set => collection=  value; }
        public int BlockNumber { get => blockNumber; set => blockNumber=  value; }
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
            this.deviceName=  deviceName;
            this.className=  this.GetType().Name;
            this.classType=  this.GetType();
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
            WprManagementObject mj; ;
            // get pc base informations
            mj = new WprManagementObjectSearcher("Win32_ComputerSystem").First();
            Name = mj.GetProperty("Name").AsString();
            Type = mj.GetProperty("SystemType").AsString();
            Manufacturer = mj.GetProperty("Manufacturer").AsString();
            Model = mj.GetProperty("Model").AsString();
            User = mj.GetProperty("UserName").AsString();
            Domaine = mj.GetProperty("Domain").AsString();

            // get os base informations
            mj = new WprManagementObjectSearcher("Win32_OperatingSystem").First();
            SystemOS= mj.GetProperty("Caption").AsString();
            SystemOS_Brand= mj.GetProperty("Manufacturer").AsString();
            SystemOS_Version= mj.GetProperty("BuildNumber").AsString();
            SystemOS_Architecture= mj.GetProperty("OSArchitecture").AsString();

            // get pc base product informations
            mj = new WprManagementObjectSearcher("Win32_ComputerSystemProduct").First();
            IDNumber= mj.GetProperty("IdentifyingNumber").AsString();
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
            var mj = new WprManagementObjectSearcher("Win32_BIOS").First();
            Manufacturer= mj.GetProperty("Manufacturer").AsString();
            SerialNumber= mj.GetProperty("SerialNumber").AsString();
            Version= mj.GetProperty("Caption").AsString();
            ReleaseData= mj.GetProperty("ReleaseDate").AsString();
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
            var mj = new WprManagementObjectSearcher("Win32_BaseBoard").First();
            Manufacturer= mj.GetProperty("Manufacturer").AsString();
            Model= mj.GetProperty("Product").AsString();
            Version= mj.GetProperty("Version").AsString();


            // get motherboard bus properties
            mj = new WprManagementObjectSearcher("Win32_MotherboardDevice").First();
            PrimaryBus_Value= mj.GetProperty("PrimaryBusType").AsString();
            SecondaryBus_Value= mj.GetProperty("SecondaryBusType").AsString();

            // get slot number
            NumberSlot = new WprManagementObjectSearcher("Win32_SystemSlot").All().Count.ToString();
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
            Collection=  new WprManagementObjectSearcher("Win32_VideoController").All();
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in Collection) // Read data
            {
                var t=  new Block();
                t.DeviceID= mj.GetProperty("DeviceID").AsSubString(15, 1);
                t.Name= mj.GetProperty("Name").AsString();
                t.Manufacturer= mj.GetProperty("AdapterCompatibility").AsString();
                t.AdpterType= mj.GetProperty("AdapterDACType").AsString();
                t.MemorySize= mj.GetProperty("AdapterRAM").AsString();
                t.NowBitsPerPixel= mj.GetProperty("CurrentBitsPerPixel").AsString();
                t.NowHorizResolution= mj.GetProperty("CurrentHorizontalResolution").AsString();
                t.NowVertResolution= mj.GetProperty("CurrentVerticalResolution").AsString();
                t.NowRefreshRate= mj.GetProperty("CurrentRefreshRate").AsString();
                t.MaxRefreshRate= mj.GetProperty("MaxRefreshRate").AsString();
                t.MinRefreshRate= mj.GetProperty("MinRefreshRate").AsString();
                t.NowNumberOfColors= mj.GetProperty("CurrentNumberOfColors").AsString();
                t.Mode= mj.GetProperty("VideoModeDescription").AsString();

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks=  mmBlocks;
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
            Collection=  new WprManagementObjectSearcher("Win32_SoundDevice").All();
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in Collection)
            {
                var t=  new Block();
                t.DeviceID= mj.GetProperty("DeviceID").AsString();
                t.Name= mj.GetProperty("Caption").AsString();
                t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
                t.PowerManagmentSupport= mj.GetProperty("PowerManagementSupported").AsString();
                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks=  mmBlocks;
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
            Collection=  new WprManagementObjectSearcher("Win32_Processor").All();
            // initialize array to contains each drive info
            Blocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in Collection) // Read data
            {
                var t=  new Block();
                t.ProcessorID= mj.GetProperty("ProcessorId").AsString();
                t.DeviceID= mj.GetProperty("DeviceID").AsSubString(3, 1);
                t.Name= mj.GetProperty("Name").AsString();
                t.AddressSize = mj.GetProperty("AddressWidth").AsString();
                t.Description = mj.GetProperty("Description").AsString();
                t.Manufacturer = mj.GetProperty("Manufacturer").AsString();
                t.Revision = mj.GetProperty("Revision").AsString();
                t.Socket = mj.GetProperty("SocketDesignation").AsString();
                t.N_Core = mj.GetProperty("NumberOfCores").AsString();
                t.N_Thread = mj.GetProperty("NumberOfLogicalProcessors").AsString();
                t.MaxSpeed = mj.GetProperty("MaxClockSpeed").AsString();
                t.L1_Cache = mj.GetProperty("L2CacheSize").AsString();
                t.L2_Cache = mj.GetProperty("L2CacheSize").AsString();
                t.L3_Cache = mj.GetProperty("L3CacheSize").AsString();

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

        public String Size;
        public String Type;

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection=  new WprManagementObjectSearcher("Win32_PhysicalMemory").All();
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in Collection)
            {
                var t=  new Block();
                t.Name= mj.GetProperty("Name").AsString();
                t.DeviceID= mj.GetProperty("BankLabel").AsSubString(5, 1);
                t.Capacity= mj.GetProperty("Capacity").AsString();
                t.Location= mj.GetProperty("BankLabel").AsString();
                t.Slot= mj.GetProperty("DeviceLocator").AsString();
                t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
                t.PartyNumber= mj.GetProperty("PartNumber").AsString();
                t.SerialNumber= mj.GetProperty("SerialNumber").AsString();
                t.Speed= mj.GetProperty("ConfiguredClockSpeed").AsString();
                t.BusSize= mj.GetProperty("DataWidth").AsString();
                t.Voltage= mj.GetProperty("MinVoltage").AsString();

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks=  mmBlocks;

            // get drive info
            var mjext=  new WprManagementObjectSearcher("Win32_PhysicalMemoryArray").First();
            this.Size= mjext.GetProperty("MaxCapacity").AsString(); // Size
            this.Type= mjext.GetProperty("Caption").AsString();     // Type
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
            foreach (WprManagementObject mj in new WprManagementObjectSearcher("Win32_PerfRawData_PerfDisk_PhysicalDisk").All())
            {
                String currentDrive= mj.GetProperty("Name").AsString();

                if (currentDrive.Substring(0, 1).Equals(index))
                    return currentDrive.Substring(2, 1) + ":";
            }

            return null;
        }

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection= new WprManagementObjectSearcher("Win32_DiskDrive").All();
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in Collection)
            {
                var t=  new Block();
                t.DeviceID= mj.GetProperty("Index").AsString();
                t.DriveName=  this.FindDriveName(t.DeviceID);
                t.Name= mj.GetProperty("Caption").AsString();
                t.MediaType= mj.GetProperty("MediaType").AsString();
                t.Intreface= mj.GetProperty("InterfaceType").AsString();
                t.Size= mj.GetProperty("Size").AsString();
                t.SerialNumber= mj.GetProperty("SerialNumber").AsString();
                t.Cylinders= mj.GetProperty("TotalCylinders").AsString();
                t.Heads= mj.GetProperty("TotalHeads").AsString();
                t.Sectors= mj.GetProperty("TotalSectors").AsString();
                t.Tracks= mj.GetProperty("TotalTracks").AsString(); ;
                t.TracksPerCylinder= mj.GetProperty("TracksPerCylinder").AsString();
                t.BytesPerSector= mj.GetProperty("BytesPerSector").AsString();
                t.FirmwareVersion= mj.GetProperty("FirmwareRevision").AsString();

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks=  mmBlocks;
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
            public String UsedNameinPerformance;
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
            Collection=  new WprManagementObjectSearcher("Win32_NetworkAdapter").All();
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in Collection)
            {
                var t=  new Block();
                t.DeviceID= mj.GetProperty("DeviceID").AsString();
                t.InterfaceIndex= mj.GetProperty("InterfaceIndex").AsString();
                t.Name= mj.GetProperty("Name").AsString(); ;
                t.UsedNameinPerformance = t.Name.Replace("(", "[");
                t.UsedNameinPerformance = t.UsedNameinPerformance.Replace(")", "]");
                t.Description= mj.GetProperty("Description").AsString();
                t.Type= mj.GetProperty("NetConnectionID").AsString();
                t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
                t.Speed= mj.GetProperty("Speed").AsString();
                t.MACAddresse= mj.GetProperty("MACAddress").AsString();
                t.AdapterType= mj.GetProperty("AdapterType").AsString();

                //get extended information
                var mjext = new WprManagementObjectSearcher("Win32_NetworkAdapterConfiguration").Unique("Index", t.DeviceID, "=");
                t.Ip_Address = mjext.GetProperty("IpAddress").AsArray(0);
                t.DefualtGetway = mjext.GetProperty("DefaultIPGateway").AsArray(0);
                t.PrimaryDNS = mjext.GetProperty("DNSServerSearchOrder").AsArray(0);
                t.SencondaryDNS = mjext.GetProperty("DNSServerSearchOrder").AsArray(1);
                t.SubNetMask = mjext.GetProperty("IpSubnet").AsArray(0);

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks=  mmBlocks;
        }

        public NETWORK():base("Network") { }
    }

    #endregion
}
