using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoveryLight.Logging;
using Microsoft.Win32;

namespace DiscoveryLight.Core.Commun
{
    public class NetFramework
    {
        private string requiredVersionFull;
        private readonly int requiredVersionNumber = 452;
        private Boolean isRequiredInstalled;
        private List<String> installedVersions;

        public string RequiredVersionFull { get => requiredVersionFull;}
        public bool IsRequiredInstalled { get => isRequiredInstalled;}
        public List<string> InstalledVersions { get => installedVersions;}

        private string[] GetBaseVersions()
        {
            var baseKeyName = @"SOFTWARE\Microsoft\NET Framework Setup\NDP";
            var installedFrameworkVersions = Registry.LocalMachine.OpenSubKey(baseKeyName);

            var versionNames = installedFrameworkVersions.GetSubKeyNames();
            return versionNames;
        }

        private List<String> GetListOfVersions()
        {
            List<string> res = new List<string>();
            foreach (string version in GetBaseVersions())
            {
                string subkey = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\" + version + "\\Full\\";
                try
                {
                    var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey);
                    if (ndpKey != null && ndpKey.GetValue("Version", "") != null)
                    {
                        var s = ndpKey.GetSubKeyNames();
                        res.Add(ndpKey.GetValue("Version", "").ToString());
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.Log(LogTarget.File, exception.ToString());
                }
            }

            return res;
        }

        private string GetRequiredVersion()
        {
            var s = AppDomain.CurrentDomain.SetupInformation;
            return AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName;
        }

        private Boolean Check()
        {
            List<int> versions = new List<int>();
            versions = installedVersions.Select(x => Convert.ToInt32(x.Substring(0, 5).Replace(".", ""))).ToList();
            if (versions.Count == 0) return false;
            int? required = versions.Where(x => x > requiredVersionNumber).FirstOrDefault();
            return (required != null);
        }

        private void GetListOfInstalledFrameworks() {
            installedVersions = GetListOfVersions();
            isRequiredInstalled = Check();
        }

        public NetFramework()
        {
            requiredVersionFull = GetRequiredVersion();
            GetListOfInstalledFrameworks();
        }
    }
}
