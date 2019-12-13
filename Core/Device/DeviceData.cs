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
    public abstract class DeviceData: AbstractDevice
    {
        protected readonly string deviceName;
        private String primaryKey;

        public string DeviceName { get => deviceName; }
        
        public List<WprManagementObject> WmiCollection
        {
            get { 
                var res = new WprManagementObjectSearcher(deviceName).All();
                IsNull = (res == null);
                return res ?? new List<WprManagementObject>() { new WprManagementObject() };
            }
        }

        public string PrimaryKey { get => primaryKey; set => primaryKey = value; }

        public override List<_Device> GetCollection() {
            // initialize array to contains each drive info
            return new List<_Device>();
        }

        public override void UpdateCollection()
        {
            Devices = GetCollection();
        }

        public override _Device GetDevice(String GetBy) { return null; }

        public override void UpdateDevice(string DeviceName) { }

        public DeviceData(string deviceName)
        {
            this.deviceName=  deviceName;
            
        }
    }

    #endregion

    #region ComputerSystem

    /// <summary>
    /// Get base Computer System Info
    /// </summary>
    public class ComputerSystem : DeviceData
    {
        public class Device : _Device
        {
            public String SystemType;
            public String Manufacturer;
            public String Model;
            public String UserName;
            public String Domain;
        }


        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();
            
            // get pc base informations
            var mj = WmiCollection.First();
            var t = new Device();
            t.Name = mj.GetProperty("Name").AsString();
            t.SystemType = mj.GetProperty("SystemType").AsString();
            t.Manufacturer = mj.GetProperty("Manufacturer").AsString();
            t.Model = mj.GetProperty("Model").AsString();
            t.UserName = mj.GetProperty("UserName").AsString();
            t.Domain = mj.GetProperty("Domain").AsString();
            
            collection.Add(t);
            
            return collection;
        }

        public ComputerSystem() : base("Win32_ComputerSystem") { PrimaryKey = "Name"; }
    }

    #endregion

    #region OperatingSystem

    /// <summary>
    /// Get base OperatingSystem properties
    /// </summary>
    public class OperatingSystem : DeviceData
    {
        public class Device:_Device{
            public String BuildNumber;
            public String Manufacturer;
            public String OSArchitecture;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();
            // get os base informations
            var mj = WmiCollection.First();
            var t = new Device();
            t.Manufacturer = mj.GetProperty("Manufacturer").AsString();
            t.BuildNumber = mj.GetProperty("BuildNumber").AsString();
            t.OSArchitecture = mj.GetProperty("OSArchitecture").AsString();
            
            collection.Add(t);
            
            return collection;
        }

        public OperatingSystem() : base("Win32_OperatingSystem") { PrimaryKey = "Name"; }
    }

    #endregion

    #region ComputerSystemProduct

    /// <summary>
    /// Get base ComputerSystemProduct properties
    /// </summary>
    public class ComputerSystemProduct : DeviceData
    {
        public class Device : _Device
        {
            public String IDNumber;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();
            // get pc base product informations
            var mj = WmiCollection.First();
            var t = new Device();
            t.IDNumber= mj.GetProperty("IdentifyingNumber").AsString();
            
            collection.Add(t);
            
            return collection;
        }

        public ComputerSystemProduct():base("Win32_ComputerSystemProduct") { PrimaryKey = "Name"; }
    }

    #endregion

    #region Bios
    /// <summary>
    /// Get base Bios properties
    /// </summary>
    public class BIOS: DeviceData
    {
        public class Device : _Device
        {
            public String Manufacturer;
            public String SerialNumber;
            public String ReleaseDate;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();
            // Get all drive info
            var mj = WmiCollection.First();
            var t = new Device();
            t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
            t.SerialNumber= mj.GetProperty("SerialNumber").AsString();
            t.ReleaseDate = mj.GetProperty("ReleaseDate").AsString();
            
            collection.Add(t);
            
            return collection;
        }

        public BIOS():base("Win32_BIOS") { PrimaryKey = "Name"; }
    }

    #endregion

    #region BaseBoard

    /// <summary>
    /// Get BaseBoard pc properties
    /// </summary>

    public class BaseBoard : DeviceData
    {
        public class Device : _Device
        {
            public String Manufacturer;
            public String Product;
            public String Version;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();
            // get motherboard chip properties
            var mj = WmiCollection.First();
            var t = new Device();
            t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
            t.Product = mj.GetProperty("Product").AsString();
            t.Version= mj.GetProperty("Version").AsString();
            
            collection.Add(t);
            
            return collection;
        }

        public BaseBoard():base("Win32_BaseBoard") { PrimaryKey = "Name"; }
    }

    #endregion

    #region MotherboardDevice

    /// <summary>
    /// Get MotherboardDevice pc properties
    /// </summary>

    public class MotherboardDevice : DeviceData
    {
        public class Device : _Device
        {
            public String PrimaryBusType;
            public String SecondaryBusType;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();
            // get motherboard bus properties
            var mj = WmiCollection.First();
            var t = new Device();
            t.PrimaryBusType = mj.GetProperty("PrimaryBusType").AsString();
            t.SecondaryBusType = mj.GetProperty("SecondaryBusType").AsString();
            
            collection.Add(t);
            
            return collection;
        }

        public MotherboardDevice() : base("Win32_MotherboardDevice") { PrimaryKey = "Name"; }
    }

    #endregion

    #region SystemSlot

    /// <summary>
    /// Get base SystemSlot properties
    /// </summary>

    public class SystemSlot : DeviceData
    {
        public class Device : _Device
        {
            public String NumberSlot;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();
            // get slot number
            var mj = WmiCollection;
            var t = new Device();
            t.NumberSlot = IsNull ? null : WmiCollection.Count.ToString();
            
            collection.Add(t);
            
            return collection;
        }

        public SystemSlot() : base("Win32_SystemSlot") { PrimaryKey = "Name"; }
    }

    #endregion

    #region Video

    /// <summary>
    /// Get base Video properties
    /// </summary>

    public class VideoController : DeviceData
    {
        public class Device: _Device
        {
            public String AdapterCompatibility;
            public String AdapterDACType;
            public String AdapterRAM;
            public String CurrentBitsPerPixel;
            public String CurrentHorizontalResolution;
            public String CurrentVerticalResolution;
            public String CurrentRefreshRate;
            public String MaxRefreshRate;
            public String MinRefreshRate;
            public String CurrentNumberOfColors;
            public String VideoModeDescription;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in WmiCollection) // Read data
            {
                var t=  new Device();
                t.DeviceID = mj.GetProperty("DeviceID").AsString();
                t.Name= mj.GetProperty("Name").AsString();
                t.AdapterCompatibility = mj.GetProperty("AdapterCompatibility").AsString();
                t.AdapterDACType = mj.GetProperty("AdapterDACType").AsString();
                t.AdapterRAM = mj.GetProperty("AdapterRAM").AsString();
                t.CurrentBitsPerPixel = mj.GetProperty("CurrentBitsPerPixel").AsString();
                t.CurrentHorizontalResolution = mj.GetProperty("CurrentHorizontalResolution").AsString();
                t.CurrentVerticalResolution = mj.GetProperty("CurrentVerticalResolution").AsString();
                t.CurrentRefreshRate = mj.GetProperty("CurrentRefreshRate").AsString();
                t.MaxRefreshRate = mj.GetProperty("MaxRefreshRate").AsString();
                t.MinRefreshRate= mj.GetProperty("MinRefreshRate").AsString();
                t.CurrentNumberOfColors = mj.GetProperty("CurrentNumberOfColors").AsString();
                t.VideoModeDescription = mj.GetProperty("VideoModeDescription").AsString();

                collection.Add(t);
            }

            return collection;
        }

        public VideoController():base("Win32_VideoController") { PrimaryKey = "Name"; }
    }

    #endregion

    #region Audio

    /// <summary>
    /// Get base audio properties
    /// </summary>

    public class SoundDevice : DeviceData
    {
        public class Device: _Device
        {
            public String Manufacturer;
            public String PowerManagementSupported;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in WmiCollection)
            {
                var t=  new Device();
                t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
                t.PowerManagementSupported = mj.GetProperty("PowerManagementSupported").AsString();
                
                collection.Add(t);
            }

            return collection;
        }

        public SoundDevice(): base("Win32_SoundDevice") { PrimaryKey = "Caption"; }
    }

    #endregion

    #region CPU

    /// <summary>
    /// Get base cpu properties
    /// </summary>

    public class Processor : DeviceData
    {
        public class Device: _Device
        {
            public String ProcessorId;
            public String AddressWidth;
            public String Manufacturer;
            public String Revision;
            public String SocketDesignation;
            public String NumberOfCores;
            public String MaxClockSpeed;
            public String NumberOfLogicalProcessors;
            public String L2CacheSize;
            public String L3CacheSize;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in WmiCollection) // Read data
            {
                var t=  new Device();
                t.ProcessorId = mj.GetProperty("ProcessorId").AsString();
                t.AddressWidth = mj.GetProperty("AddressWidth").AsString();
                t.Description = mj.GetProperty("Description").AsString();
                t.Manufacturer = mj.GetProperty("Manufacturer").AsString();
                t.Revision = mj.GetProperty("Revision").AsString();
                t.SocketDesignation = mj.GetProperty("SocketDesignation").AsString();
                t.NumberOfCores = mj.GetProperty("NumberOfCores").AsString();
                t.NumberOfLogicalProcessors = mj.GetProperty("NumberOfLogicalProcessors").AsString();
                t.MaxClockSpeed = mj.GetProperty("MaxClockSpeed").AsString();
                t.L2CacheSize = mj.GetProperty("L2CacheSize").AsString();
                t.L3CacheSize = mj.GetProperty("L3CacheSize").AsString();

                collection.Add(t);
            }

            return collection;
        }

        public Processor(): base("Win32_Processor") { PrimaryKey = "Name"; }

    }

    #endregion

    #region PhysicalMemory

    /// <summary>
    /// Get PhysicalMemory ram properties
    /// </summary>

    public class PhysicalMemory : DeviceData
    {
        public class Device: _Device
        {
            public String Capacity;
            public String BankLabel;
            public String DeviceLocator;
            public String Manufacturer;
            public String PartNumber;
            public String SerialNumber;
            public String ConfiguredClockSpeed;
            public String DataWidth;
            public String MinVoltage;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in WmiCollection)
            {
                var t=  new Device();
                t.Capacity= mj.GetProperty("Capacity").AsString();
                t.BankLabel = mj.GetProperty("BankLabel").AsString();
                t.DeviceLocator = mj.GetProperty("DeviceLocator").AsString();
                t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
                t.PartNumber = mj.GetProperty("PartNumber").AsString();
                t.SerialNumber= mj.GetProperty("SerialNumber").AsString();
                t.ConfiguredClockSpeed = mj.GetProperty("ConfiguredClockSpeed").AsString();
                t.DataWidth = mj.GetProperty("DataWidth").AsString();
                t.MinVoltage = mj.GetProperty("MinVoltage").AsString();

                collection.Add(t);
            }

            return  collection;
        }

        public PhysicalMemory(): base("Win32_PhysicalMemory") { PrimaryKey = "BankLabel"; }
    }

    #endregion

    #region PhysicalMemoryArray

    /// <summary>
    /// Get base PhysicalMemoryArray properties
    /// </summary>

    public class PhysicalMemoryArray : DeviceData
    {
        public class Device : _Device
        {
            public String MaxCapacity;
            public String MemoryDevices;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            // get drive info
            var mj = WmiCollection.First();
            var t = new Device();
            
            t.MaxCapacity = mj.GetProperty("MaxCapacity").AsString();               // Size
            t.MemoryDevices = mj.GetProperty("MemoryDevices").AsString();    // Moudule's numbers
            
            collection.Add(t);

            return collection;
        }

        public PhysicalMemoryArray() : base("Win32_PhysicalMoryArray") { PrimaryKey = "Name"; }
    }

    #endregion

    #region DiskDrive

    /// <summary>
    /// Get base storage properties for each pysical disk
    /// </summary>
    public class DiskDrive : DeviceData
    {
        public class Device: _Device
        {
            public String Index;
            public String DriveName;
            public String MediaType;
            public String InterfaceType;
            public String Size;
            public String SerialNumber;
            public String TotalCylinders;
            public String TotalHeads;
            public String TotalSectors;
            public String TotalTracks;
            public String TracksPerCylinder;
            public String BytesPerSector;
            public String FirmwareRevision;
        }

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

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in WmiCollection)
            {
                var t=  new Device();
                t.Index= mj.GetProperty("Index").AsString();
                t.DriveName=  this.FindDriveName(t.Index);
                t.MediaType= mj.GetProperty("MediaType").AsString();
                t.InterfaceType = mj.GetProperty("InterfaceType").AsString();
                t.Size= mj.GetProperty("Size").AsString();
                t.SerialNumber= mj.GetProperty("SerialNumber").AsString();
                t.TotalCylinders = mj.GetProperty("TotalCylinders").AsString();
                t.TotalHeads = mj.GetProperty("TotalHeads").AsString();
                t.TotalSectors = mj.GetProperty("TotalSectors").AsString();
                t.TotalTracks = mj.GetProperty("TotalTracks").AsString(); ;
                t.TracksPerCylinder = mj.GetProperty("TracksPerCylinder").AsString();
                t.BytesPerSector= mj.GetProperty("BytesPerSector").AsString();
                t.FirmwareRevision = mj.GetProperty("FirmwareRevision").AsString();

                collection.Add(t);
            }

            return collection;
        }

        public DiskDrive(): base("Win32_DiskDrive") { PrimaryKey = "Caption"; }
    }

    #endregion

    #region NetworkAdapter

    /// <summary>
    /// Get base network properties for each interface
    /// </summary>
    public class NetworkAdapter : DeviceData
    {
        public class Device: _Device
        {
            public String InterfaceIndex;
            public String NetConnectionID;
            public String Manufacturer;
            public String Speed;
            public String MACAddress;
            public String AdapterType;
            public String IpAddress;
            public String IpSubnet;
            public String DefaultIPGateway;
            public String PrimaryDNS;
            public String SencondaryDNS;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            // get all properties for each installed drive
            foreach (WprManagementObject mj in WmiCollection)
            {
                var t=  new Device();
                t.InterfaceIndex= mj.GetProperty("InterfaceIndex").AsString();
                t.NetConnectionID = mj.GetProperty("NetConnectionID").AsString();
                t.Manufacturer= mj.GetProperty("Manufacturer").AsString();
                t.Speed= mj.GetProperty("Speed").AsString();
                t.MACAddress = mj.GetProperty("MACAddress").AsString();
                t.AdapterType= mj.GetProperty("AdapterType").AsString();

                //get extended information
                var mjext = new WprManagementObjectSearcher("Win32_NetworkAdapterConfiguration").Unique("Index", t.DeviceID, "=");
                t.IpAddress = mjext.GetProperty("IpAddress").AsArray(0);
                t.DefaultIPGateway = mjext.GetProperty("DefaultIPGateway").AsArray(0);
                t.PrimaryDNS = mjext.GetProperty("DNSServerSearchOrder").AsArray(0);
                t.SencondaryDNS = mjext.GetProperty("DNSServerSearchOrder").AsArray(1);
                t.IpSubnet = mjext.GetProperty("IpSubnet").AsArray(0);

                collection.Add(t);
            }

            return collection;
        }

        public NetworkAdapter():base("Win32_NetworkAdapter") { PrimaryKey = "Name"; }
    }

    #endregion
}
