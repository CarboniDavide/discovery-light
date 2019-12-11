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

        private int deviceNumer=  0;                             // number of blocks for the same drive( a pc can have one or more cpu, drive audio etc.)
        private List<_Device> devices=  new List<_Device>();        // List of properties for each block           
        private Boolean isNull;

        public string DeviceName { get => deviceName; }
        public string ClassName { get => className; }
        public Type ClassType { get => classType; }
        public List<WprManagementObject> Collection
        {
            get { 
                var res = new WprManagementObjectSearcher(deviceName).All();
                isNull = (res == null);
                return res ?? new List<WprManagementObject>() { new WprManagementObject() };
            }
        }
        public int DeviceNumber { get => deviceNumer; set => deviceNumer=  value; }
        public List<_Device> Devices { get => devices; set => devices = value; }
        public bool IsNull { get => isNull; set => isNull = value; }

        /// <summary>
        /// Get all properties for all installed drive
        /// </summary>
        public abstract void GetCollection();
        public class _Device
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

    #region ComputerSystem

    /// <summary>
    /// Get base Computer System Info
    /// </summary>
    public class ComputerSystem : DeviceData
    {
        public String Name;
        public String Type;
        public String Manufacturer;
        public String Model;
        public String User;
        public String Domaine;

        public override void GetCollection()
        {
            // get pc base informations
            var mj = Collection.First();
            Name = mj.GetProperty("Name").AsString();
            Type = mj.GetProperty("SystemType").AsString();
            Manufacturer = mj.GetProperty("Manufacturer").AsString();
            Model = mj.GetProperty("Model").AsString();
            User = mj.GetProperty("UserName").AsString();
            Domaine = mj.GetProperty("Domain").AsString();
        }

        public ComputerSystem() : base("Win32_ComputerSystem") { }
    }

    #endregion

    #region OperatingSystem

    /// <summary>
    /// Get base OperatingSystem properties
    /// </summary>
    public class OperatingSystem : DeviceData
    {
        public String SystemOS_Version;
        public String SystemOS;
        public String SystemOS_Brand;
        public String SystemOS_Architecture;
        public String RamSize;

        public override void GetCollection()
        {
            // get os base informations
            var mj = Collection.First();
            SystemOS = mj.GetProperty("Caption").AsString();
            SystemOS_Brand = mj.GetProperty("Manufacturer").AsString();
            SystemOS_Version = mj.GetProperty("BuildNumber").AsString();
            SystemOS_Architecture = mj.GetProperty("OSArchitecture").AsString();
        }

        public OperatingSystem() : base("Win32_OperatingSystem") { }
    }

    #endregion

    #region ComputerSystemProduct

    /// <summary>
    /// Get base ComputerSystemProduct properties
    /// </summary>
    public class ComputerSystemProduct : DeviceData
    {
        public String IDNumber;

        public override void GetCollection()
        {
            // get pc base product informations
            var mj = Collection.First();
            IDNumber= mj.GetProperty("IdentifyingNumber").AsString();
        }

        public ComputerSystemProduct():base("Win32_ComputerSystemProduct") { }
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

        public override void GetCollection()
        {
            // Get all drive info
            var mj = Collection.First();
            Manufacturer= mj.GetProperty("Manufacturer").AsString();
            SerialNumber= mj.GetProperty("SerialNumber").AsString();
            Version= mj.GetProperty("Caption").AsString();
            ReleaseData= mj.GetProperty("ReleaseDate").AsString();
        }

        public BIOS():base("Win32_BIOS") { }
    }

    #endregion

    #region BaseBoard

    /// <summary>
    /// Get BaseBoard pc properties
    /// </summary>

    public class BaseBoard : DeviceData
    {
        public String Manufacturer;
        public String Model;
        public String Version;

        public override void GetCollection()
        {
            // get motherboard chip properties
            var mj = Collection.First();
            Manufacturer= mj.GetProperty("Manufacturer").AsString();
            Model= mj.GetProperty("Product").AsString();
            Version= mj.GetProperty("Version").AsString();
        }

        public BaseBoard():base("Win32_BaseBoard") { }
    }

    #endregion

    #region MotherboardDevice

    /// <summary>
    /// Get MotherboardDevice pc properties
    /// </summary>

    public class MotherboardDevice : DeviceData
    {
        public String PrimaryBus_Value;
        public String SecondaryBus_Value;

        public override void GetCollection()
        {
            // get motherboard bus properties
            var mj = Collection.First();
            PrimaryBus_Value = mj.GetProperty("PrimaryBusType").AsString();
            SecondaryBus_Value = mj.GetProperty("SecondaryBusType").AsString();
        }

        public MotherboardDevice() : base("Win32_MotherboardDevice") { }
    }

    #endregion

    #region SystemSlot

    /// <summary>
    /// Get base SystemSlot properties
    /// </summary>

    public class SystemSlot : DeviceData
    {
        public String NumberSlot;

        public override void GetCollection()
        {
            // get slot number
            var mj = Collection;
            NumberSlot = IsNull ? null : Collection.Count.ToString();
        }

        public SystemSlot() : base("Win32_SystemSlot") { }
    }

    #endregion

    #region Video

    /// <summary>
    /// Get base Video properties
    /// </summary>

    public class VideoController : DeviceData
    {
        public class Block: _Device
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

        public override void GetCollection()
        {
            // initialize array to contains each drive info
            List<_Device> mmBlocks=  new List<_Device>();

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
            Devices=  mmBlocks;
        }

        public VideoController():base("Win32_VideoController") { }
    }

    #endregion

    #region Audio

    /// <summary>
    /// Get base audio properties
    /// </summary>

    public class SoundDevice : DeviceData
    {
        public class Block: _Device
        {
            public String Manufacturer;
            public String PowerManagmentSupport;
        }

        public override void GetCollection()
        {
            // initialize array to contains each drive info
            List<_Device> mmBlocks=  new List<_Device>();

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
            Devices=  mmBlocks;
        }

        public SoundDevice(): base("Win32_SoundDevice") { }
    }

    #endregion

    #region CPU

    /// <summary>
    /// Get base cpu properties
    /// </summary>

    public class Processor : DeviceData
    {
        public class Block: _Device
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

        public override void GetCollection()
        {
            // initialize array to contains each drive info
            List<_Device> mmBlocks = new List<_Device>();

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

                mmBlocks.Add(t);
            }
            // update values for each subdevice if change occured
            Devices = mmBlocks;
        }

        public Processor(): base("Win32_Processor") { }

    }

    #endregion

    #region PhysicalMemory

    /// <summary>
    /// Get PhysicalMemory ram properties
    /// </summary>

    public class PhysicalMemory : DeviceData
    {
        public class Block: _Device
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

        public override void GetCollection()
        {
            // initialize array to contains each drive info
            List<_Device> mmBlocks=  new List<_Device>();

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
            Devices=  mmBlocks;
        }

        public PhysicalMemory(): base("Win32_PhysicalMemory") { }
    }

    #endregion

    #region PhysicalMemoryArray

    /// <summary>
    /// Get base PhysicalMemoryArray properties
    /// </summary>

    public class PhysicalMemoryArray : DeviceData
    {
        public String Size;
        public String Type;
        public String MemoryDevices;

        public override void GetCollection()
        {
            // get drive info
            var mj = Collection.First();
            this.Size = mj.GetProperty("MaxCapacity").AsString();               // Size
            this.Type = mj.GetProperty("Caption").AsString();                   // Type
            this.MemoryDevices = mj.GetProperty("MemoryDevices").AsString();    // Moudule's numbers
        }

        public PhysicalMemoryArray() : base("Win32_PhysicalMoryArray") { }
    }

    #endregion

    #region DiskDrive

    /// <summary>
    /// Get base storage properties for each pysical disk
    /// </summary>
    public class DiskDrive : DeviceData
    {
        public class Block: _Device
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

        public override void GetCollection()
        {
            // initialize array to contains each drive info
            List<_Device> mmBlocks=  new List<_Device>();

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
            Devices=  mmBlocks;
        }

        public DiskDrive(): base("Win32_DiskDrive") { }
    }

    #endregion

    #region NetworkAdapter

    /// <summary>
    /// Get base network properties for each interface
    /// </summary>
    public class NetworkAdapter : DeviceData
    {
        public class Block: _Device
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

        public override void GetCollection()
        {
            // initialize array to contains each drive info
            List<_Device> mmBlocks=  new List<_Device>();

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
            Devices=  mmBlocks;
        }

        public NetworkAdapter():base("Win32_NetworkAdapter") { }
    }

    #endregion
}
