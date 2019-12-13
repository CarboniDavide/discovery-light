﻿using System;
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
            public MobProperty SystemType;
            public MobProperty Manufacturer;
            public MobProperty Model;
            public MobProperty UserName;
            public MobProperty Domain;
        }


        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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
            public MobProperty BuildNumber;
            public MobProperty Manufacturer;
            public MobProperty OSArchitecture;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));
            
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
            public MobProperty IdentifyingNumber;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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
            public MobProperty Manufacturer;
            public MobProperty Product;
            public MobProperty Version;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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
            public MobProperty PrimaryBusType;
            public MobProperty SecondaryBusType;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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
            public MobProperty Manufacturer;
            public MobProperty PowerManagementSupported;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

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
            public MobProperty MaxCapacity;
            public MobProperty MemoryDevices;
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
                collection.Add(new Device().Serialize(mj));

            return collection;
        }

        public PhysicalMemoryArray() : base("Win32_PhysicalMemoryArray") { PrimaryKey = "Name"; }
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
            public MobProperty Index;
            public MobProperty DriveName;
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

        public MobProperty FindDriveName(MobProperty index)
        {
            // get all properties for each installed drive
            foreach (WprManagementObject mj in new WprManagementObjectSearcher("Win32_PerfRawData_PerfDisk_PhysicalDisk").All())
            {
                String currentDrive= mj.GetProperty("Name").AsString();

                if (currentDrive.Substring(0, 1).Equals(index.AsString()))
                    return mj.GetProperty("Name");
            }

            return new MobProperty(null);
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
            {
                var t = new Device().Serialize(mj) as Device;
                // add extended intems
                t.DriveName = this.FindDriveName(t.Index);
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
        }

        public override List<_Device> GetCollection()
        {
            var collection = base.GetCollection();

            foreach (WprManagementObject mj in WmiCollection)
            {
                var t = new Device().Serialize(mj) as Device;

                // add extended intems
                var mjext = new WprManagementObjectSearcher("Win32_NetworkAdapterConfiguration").First("Index", t.DeviceID.AsString(), "=");
                t.Serialize(mjext, new List<string> { "IpAddress", "DefaultIPGateway", "DNSServerSearchOrder", "IpSubnet" });

                collection.Add(t);
            }

            return collection;
        }

        public NetworkAdapter():base("Win32_NetworkAdapter") { PrimaryKey = "Name"; }
    }

    #endregion
}
