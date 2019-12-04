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
        private List<ManagementObject> collection;               // drive collection - each collection contains one or more block, one to each installed drive type

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
        public List<ManagementObject> Collection { get => collection; set => collection=  value; }
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
            // get pc base informations
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_ComputerSystem"))
            {
                this.Name= DeviceUtils.GetProperty.AsString("Name", mj);
                this.Type= DeviceUtils.GetProperty.AsString("SystemType", mj);
                this.Manufacturer= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                this.Model= DeviceUtils.GetProperty.AsString("Model", mj);
                this.User= DeviceUtils.GetProperty.AsString("UserName", mj);
                this.Domaine= DeviceUtils.GetProperty.AsString("Domain", mj);
            }

            // get os base informations
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_OperatingSystem"))
            {
                SystemOS= DeviceUtils.GetProperty.AsString("Caption", mj);
                SystemOS_Brand= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                SystemOS_Version= DeviceUtils.GetProperty.AsString("BuildNumber", mj);
                SystemOS_Architecture= DeviceUtils.GetProperty.AsString("OSArchitecture", mj);
            }

            // get pc base product informations
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_ComputerSystemProduct"))
            {
                IDNumber= DeviceUtils.GetProperty.AsString("IdentifyingNumber", mj);
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
                this.Manufacturer= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                this.SerialNumber= DeviceUtils.GetProperty.AsString("SerialNumber", mj);
                this.Version= DeviceUtils.GetProperty.AsString("Caption", mj);
                this.ReleaseData= DeviceUtils.GetProperty.AsString("ReleaseDate", mj);
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
                this.Manufacturer= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                this.Model= DeviceUtils.GetProperty.AsString("Product", mj);
                this.Version= DeviceUtils.GetProperty.AsString("Version", mj);
            }

            // get motherboard bus properties
            foreach (ManagementObject mj in DeviceUtils.GetDriveInfo("Win32_MotherboardDevice")) // Read data
            {
                this.PrimaryBus_Value= DeviceUtils.GetProperty.AsString("PrimaryBusType", mj);
                this.SecondaryBus_Value= DeviceUtils.GetProperty.AsString("SecondaryBusType", mj);
            }

            NumberSlot=  DeviceUtils.GetDriveInfo("Win32_SystemSlot").Count.ToString();
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
            Collection=  DeviceUtils.GetDriveInfo("Win32_VideoController");
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection) // Read data
            {
                var t=  new Block();
                t.DeviceID= DeviceUtils.GetProperty.AsSubString("DeviceID", mj, 15, 1);
                t.Name= DeviceUtils.GetProperty.AsString("Name", mj);
                t.Manufacturer= DeviceUtils.GetProperty.AsString("AdapterCompatibility", mj);
                t.AdpterType= DeviceUtils.GetProperty.AsString("AdapterDACType", mj);
                t.MemorySize= DeviceUtils.GetProperty.AsString("AdapterRAM", mj);
                t.NowBitsPerPixel= DeviceUtils.GetProperty.AsString("CurrentBitsPerPixel", mj);
                t.NowHorizResolution= DeviceUtils.GetProperty.AsString("CurrentHorizontalResolution", mj);
                t.NowVertResolution= DeviceUtils.GetProperty.AsString("CurrentVerticalResolution", mj);
                t.NowRefreshRate= DeviceUtils.GetProperty.AsString("CurrentRefreshRate", mj);
                t.MaxRefreshRate= DeviceUtils.GetProperty.AsString("MaxRefreshRate", mj);
                t.MinRefreshRate= DeviceUtils.GetProperty.AsString("MinRefreshRate", mj);
                t.NowNumberOfColors= DeviceUtils.GetProperty.AsString("CurrentNumberOfColors", mj);
                t.Mode= DeviceUtils.GetProperty.AsString("VideoModeDescription", mj);

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
            Collection=  DeviceUtils.GetDriveInfo("Win32_SoundDevice");
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t=  new Block();
                t.DeviceID= DeviceUtils.GetProperty.AsString("DeviceID", mj);
                t.Name= DeviceUtils.GetProperty.AsString("Caption", mj);
                t.Manufacturer= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                t.PowerManagmentSupport= DeviceUtils.GetProperty.AsString("PowerManagementSupported", mj);
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
            Collection=  DeviceUtils.GetDriveInfo("Win32_Processor");
            // initialize array to contains each drive info
            Blocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection) // Read data
            {
                var t=  new Block();
                t.ProcessorID= DeviceUtils.GetProperty.AsString("ProcessorId", mj);
                t.DeviceID= DeviceUtils.GetProperty.AsSubString("DeviceID", mj, 3, 1);
                t.Name= DeviceUtils.GetProperty.AsString("Name", mj);
                t.AddressSize= DeviceUtils.GetProperty.AsString("AddressWidth", mj);
                t.Description= DeviceUtils.GetProperty.AsString("Description", mj);
                t.Manufacturer= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                t.Revision= DeviceUtils.GetProperty.AsString("Revision", mj);
                t.Socket= DeviceUtils.GetProperty.AsString("SocketDesignation", mj);
                t.N_Core= DeviceUtils.GetProperty.AsString("NumberOfCores", mj);
                t.N_Thread= DeviceUtils.GetProperty.AsString("NumberOfLogicalProcessors", mj);
                t.MaxSpeed= DeviceUtils.GetProperty.AsString("MaxClockSpeed", mj);
                t.L1_Cache = DeviceUtils.GetProperty.AsString("L2CacheSize", mj);
                t.L2_Cache= DeviceUtils.GetProperty.AsString("L2CacheSize", mj);
                t.L3_Cache= DeviceUtils.GetProperty.AsString("L3CacheSize", mj);

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
            Collection=  DeviceUtils.GetDriveInfo("Win32_PhysicalMemory");
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t=  new Block();
                t.Name= DeviceUtils.GetProperty.AsString("Name", mj);
                t.DeviceID= DeviceUtils.GetProperty.AsSubString("BankLabel", mj, 5, 1);
                t.Capacity= DeviceUtils.GetProperty.AsString("Capacity", mj);
                t.Location= DeviceUtils.GetProperty.AsString("BankLabel", mj);
                t.Slot= DeviceUtils.GetProperty.AsString("DeviceLocator", mj);
                t.Manufacturer= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                t.PartyNumber= DeviceUtils.GetProperty.AsString("PartNumber", mj);
                t.SerialNumber= DeviceUtils.GetProperty.AsString("SerialNumber", mj);
                t.Speed= DeviceUtils.GetProperty.AsString("ConfiguredClockSpeed", mj);
                t.BusSize= DeviceUtils.GetProperty.AsString("DataWidth", mj);
                t.Voltage= DeviceUtils.GetProperty.AsString("MinVoltage", mj);

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks=  mmBlocks;

            // get drive info
            var a_collection=  DeviceUtils.GetDriveInfo("Win32_PhysicalMemoryArray");

            foreach (ManagementObject mj in a_collection) // Read data
            {
                this.Size= DeviceUtils.GetProperty.AsString("MaxCapacity", mj); // Size
                this.Type= DeviceUtils.GetProperty.AsString("Caption", mj);     // Type
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
                String currentDrive= DeviceUtils.GetProperty.AsString("Name", mj);

                if (currentDrive.Substring(0, 1).Equals(index))
                    return currentDrive.Substring(2, 1) + ":";
            }

            return null;
        }

        public override void GetDriveInfo()
        {
            // get drive info collection
            Collection=  DeviceUtils.GetDriveInfo("Win32_DiskDrive");
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t=  new Block();
                t.DeviceID= DeviceUtils.GetProperty.AsString("Index", mj);
                t.DriveName=  this.FindDriveName(t.DeviceID);
                t.Name= DeviceUtils.GetProperty.AsString("Caption", mj);
                t.MediaType= DeviceUtils.GetProperty.AsString("MediaType", mj);
                t.Intreface= DeviceUtils.GetProperty.AsString("InterfaceType", mj);
                t.Size= DeviceUtils.GetProperty.AsString("Size", mj);
                t.SerialNumber= DeviceUtils.GetProperty.AsString("SerialNumber", mj);
                t.Cylinders= DeviceUtils.GetProperty.AsString("TotalCylinders", mj);
                t.Heads= DeviceUtils.GetProperty.AsString("TotalHeads", mj);
                t.Sectors= DeviceUtils.GetProperty.AsString("TotalSectors", mj);
                t.Tracks= DeviceUtils.GetProperty.AsString("TotalTracks", mj);
                t.TracksPerCylinder= DeviceUtils.GetProperty.AsString("TracksPerCylinder", mj);
                t.BytesPerSector= DeviceUtils.GetProperty.AsString("BytesPerSector", mj);
                t.FirmwareVersion= DeviceUtils.GetProperty.AsString("FirmwareRevision", mj);

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
            Collection=  DeviceUtils.GetDriveInfo("Win32_NetworkAdapter", "MACAddress", null, DeviceUtils.Operator.NotEgual);
            // initialize array to contains each drive info
            List<_Block> mmBlocks=  new List<_Block>();
            List<String> s=  new List<string>();

            // get all properties for each installed drive
            foreach (ManagementObject mj in Collection)
            {
                var t=  new Block();
                t.DeviceID= DeviceUtils.GetProperty.AsString("DeviceID", mj);
                t.InterfaceIndex= DeviceUtils.GetProperty.AsString("InterfaceIndex", mj);
                t.Name= DeviceUtils.GetProperty.AsString("Name", mj);
                t.UsedNameinPerformance = t.Name.Replace("(", "[");
                t.UsedNameinPerformance = t.UsedNameinPerformance.Replace(")", "]");
                t.Description= DeviceUtils.GetProperty.AsString("Description", mj);
                t.Type= DeviceUtils.GetProperty.AsString("NetConnectionID", mj);
                t.Manufacturer= DeviceUtils.GetProperty.AsString("Manufacturer", mj);
                t.Speed= DeviceUtils.GetProperty.AsString("Speed", mj);
                t.MACAddresse= DeviceUtils.GetProperty.AsString("MACAddress", mj);
                t.AdapterType= DeviceUtils.GetProperty.AsString("AdapterType", mj);

                //get extended information
                using (ManagementObject Mo = new ManagementObject($"Win32_NetworkAdapterConfiguration.Index='{t.DeviceID}'"))
                {
                    t.Ip_Address = DeviceUtils.GetProperty.AsArray("IpAddress", Mo, 0);
                    t.DefualtGetway = DeviceUtils.GetProperty.AsArray("DefaultIPGateway", Mo, 0);
                    t.PrimaryDNS = DeviceUtils.GetProperty.AsArray("DNSServerSearchOrder", Mo, 0);
                    t.SencondaryDNS = DeviceUtils.GetProperty.AsArray("DNSServerSearchOrder", Mo, 1);
                    t.SubNetMask = DeviceUtils.GetProperty.AsArray("IpSubnet", Mo, 0);
                }

                mmBlocks.Add(t);
            }

            // update values for each subdevice if change occured
            Blocks=  mmBlocks;
        }

        public NETWORK():base("Network") { }
    }

    #endregion
}
