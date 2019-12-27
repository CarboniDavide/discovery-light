using DiscoveryLight.Core.Device.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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
    public abstract class DeviceData : _Device
    {
        public DeviceData(string deviceName, Type subDeviceType, String primaryKey) : base(deviceName, subDeviceType)
        {
            PrimaryKey = primaryKey;
        }

        public DeviceData(string deviceName, Type subDeviceType) : base(deviceName, subDeviceType) { }
    }

    #endregion

    #region ComputerSystem

    /// <summary>
    /// Get base Computer System Info
    /// </summary>
    public class ComputerSystem : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty SystemType;
            public MobProperty Manufacturer;
            public MobProperty Model;
            public MobProperty UserName;
            public MobProperty Domain;
        }

        public ComputerSystem() : base("Win32_ComputerSystem", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region OperatingSystem

    /// <summary>
    /// Get base OperatingSystem properties
    /// </summary>
    public class OperatingSystem : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty BuildNumber;
            public MobProperty Manufacturer;
            public MobProperty OSArchitecture;
        }

        public OperatingSystem() : base("Win32_OperatingSystem", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region ComputerSystemProduct

    /// <summary>
    /// Get base ComputerSystemProduct properties
    /// </summary>
    public class ComputerSystemProduct : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty IdentifyingNumber;
        }

        public ComputerSystemProduct() : base("Win32_ComputerSystemProduct", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region Bios
    /// <summary>
    /// Get base Bios properties
    /// </summary>
    public class BIOS : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty Manufacturer;
            public MobProperty SerialNumber;
            public MobProperty ReleaseDate;
        }

        public BIOS() : base("Win32_BIOS", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region BaseBoard

    /// <summary>
    /// Get BaseBoard pc properties
    /// </summary>

    public class BaseBoard : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty Manufacturer;
            public MobProperty Product;
            public MobProperty Version;
        }

        public BaseBoard() : base("Win32_BaseBoard", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region MotherboardDevice

    /// <summary>
    /// Get MotherboardDevice pc properties
    /// </summary>

    public class MotherboardDevice : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty PrimaryBusType;
            public MobProperty SecondaryBusType;
        }

        public MotherboardDevice() : base("Win32_MotherboardDevice", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region SystemSlot

    /// <summary>
    /// Get base SystemSlot properties
    /// </summary>

    public class SystemSlot : DeviceData
    {
        public class SubDevice : _SubDevice { }

        public SystemSlot() : base("Win32_SystemSlot", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region Video

    /// <summary>
    /// Get base Video properties
    /// </summary>

    public class VideoController : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty AdapterCompatibility;
            public MobProperty AdapterDACType;
            public MobProperty AdapterRAM;
            public MobProperty CurrentBitsPerPixel;
            public MobProperty CurrentHorizontalResolution;
            public MobProperty CurrentVerticalResolution;
            public MobProperty CurrentRefreshRate;
            public MobProperty MaxRefreshRate;
            public MobProperty MinRefreshRate;
            public MobProperty CurrentNumberOfColors;
            public MobProperty VideoModeDescription;
        }

        public VideoController() : base("Win32_VideoController", typeof(SubDevice), "Name") {  }
    }

    #endregion

    #region Audio

    /// <summary>
    /// Get base audio properties
    /// </summary>

    public class SoundDevice : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty Manufacturer;
            public MobProperty PowerManagementSupported;
        }

        public SoundDevice() : base("Win32_SoundDevice", typeof(SubDevice), "Caption") { }
    }

    #endregion

    #region CPU

    /// <summary>
    /// Get base cpu properties
    /// </summary>

    public class Processor : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty ProcessorId;
            public MobProperty AddressWidth;
            public MobProperty Manufacturer;
            public MobProperty Revision;
            public MobProperty SocketDesignation;
            public MobProperty NumberOfCores;
            public MobProperty MaxClockSpeed;
            public MobProperty NumberOfLogicalProcessors;
            public MobProperty L2CacheSize;
            public MobProperty L3CacheSize;
        }

        public Processor() : base("Win32_Processor", typeof(SubDevice), "Name") { }

    }

    #endregion

    #region PhysicalMemory

    /// <summary>
    /// Get PhysicalMemory ram properties
    /// </summary>

    public class PhysicalMemory : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty Capacity;
            public MobProperty BankLabel;
            public MobProperty DeviceLocator;
            public MobProperty Manufacturer;
            public MobProperty PartNumber;
            public MobProperty SerialNumber;
            public MobProperty ConfiguredClockSpeed;
            public MobProperty DataWidth;
            public MobProperty MinVoltage;
        }

        public PhysicalMemory() : base("Win32_PhysicalMemory", typeof(SubDevice), "BankLabel") { }
    }

    #endregion

    #region PhysicalMemoryArray

    /// <summary>
    /// Get base PhysicalMemoryArray properties
    /// </summary>

    public class PhysicalMemoryArray : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty MaxCapacity;
            public MobProperty MemoryDevices;
        }

        public PhysicalMemoryArray() : base("Win32_PhysicalMemoryArray", typeof(SubDevice), "Name") { }
    }

    #endregion

    #region DiskDrive

    /// <summary>
    /// Get base storage properties for each pysical disk
    /// </summary>
    public class DiskDrive : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty Index;
            public MobProperty MediaType;
            public MobProperty InterfaceType;
            public MobProperty Size;
            public MobProperty SerialNumber;
            public MobProperty TotalCylinders;
            public MobProperty TotalHeads;
            public MobProperty TotalSectors;
            public MobProperty TotalTracks;
            public MobProperty TracksPerCylinder;
            public MobProperty BytesPerSector;
            public MobProperty FirmwareRevision;
        }

        public DiskDrive() : base("Win32_DiskDrive", typeof(SubDevice), "Caption") { }
    }

    #endregion

    #region NetworkAdapter

    /// <summary>
    /// Get base network properties for each interface
    /// </summary>
    public class NetworkAdapter : DeviceData
    {
        public class SubDevice : _SubDevice
        {
            public MobProperty InterfaceIndex;
            public MobProperty NetConnectionID;
            public MobProperty Manufacturer;
            public MobProperty Speed;
            public MobProperty MACAddress;
            public MobProperty AdapterType;
            public MobProperty IpAddress;
            public MobProperty IpSubnet;
            public MobProperty DefaultIPGateway;
            public MobProperty DNSServerSearchOrder;

            public override _SubDevice Extend()
            {
                var mjext = new WprManagementObjectSearcher("Win32_NetworkAdapterConfiguration").First("Index", DeviceID.AsString(), "=");
                this.Serialize(mjext, new List<string> { "IpAddress", "DefaultIPGateway", "DNSServerSearchOrder", "IpSubnet" });
                return this;
            }
        }

        public override List<_SubDevice> GetCollection()
        {
            return WmiCollection.All()
                .Where(x => x.GetProperty("NetConnectionStatus").AsString() != null)
                .Select(x => new SubDevice().Serialize(x).Extend())
                .ToList();
        }

        public NetworkAdapter() : base("Win32_NetworkAdapter", typeof(SubDevice), "Name") { }
    }

    #endregion
}
