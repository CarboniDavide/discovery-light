using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiscoveryLight.UI.Forms;
using DiscoveryLight.UI.Forms.SplachScreen;
using DiscoveryLight.UI.Forms.Main;
using DiscoveryLight.Core.Devices;

namespace DiscoveryLight
{
    
    static class Program
    {
        static public List<Device> Devices;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Laod and init hardware components
            FormsCollection.SplachScreen = new _SplachScreen();
            Application.Run(FormsCollection.SplachScreen);
            // Load main windows
            FormsCollection.Main = new _Main();
            Application.Run(FormsCollection.Main);
        }
    }
}
