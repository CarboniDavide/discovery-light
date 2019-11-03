using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Forms;

namespace DiscoveryLight
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormsCollection.SplachScreen = new UI.Forms.SplachScreen._SplachScreen();
            Application.Run(FormsCollection.SplachScreen);
        }
    }
}
