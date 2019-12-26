﻿using System;
using System.Linq;
using System.Reflection;

namespace DiscoveryLight.UI.Panels.Devices
{
    /// <summary>
    /// Panel Factory
    /// </summary>
    class PanelCollection
    {
        /// <summary>
        /// Return a new instance for a required panel
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DevicePanel PanelFactory(String name)
        {
            switch (name)
            {
                case "_Audio":
                    return new _Audio();
                case "_BaseHardware":
                    return new _BaseHardware();
                case "_MainBoard":
                    return new _MainBoard();
                case "_Memory":
                    return new _Memory();
                case "_Network":
                    return new _Network();
                case "_PhysicalDisk":
                    return new _PhysicalDisk();
                case "_Video":
                    return new _Video();
                case "_CPU":
                    return new _CPU();
                case "_All":
                    return new _Details();
                default:
                    return new _BaseHardware();
            }
        }

        /// <summary>
        /// Get type using assembly and namespace
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        public Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
    }
}
