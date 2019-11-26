using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;
using DiscoveryLight.UI.Panels;
using System.Globalization;
using System.Threading;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Main : Form
    {
        public _Main()
        {
            LoadLanguage();
            InitializeComponent();
        }

        public string lang;

        private void LoadLanguage()
        {
            lang = Settings.Settings.Default.UserLanguage;
            CultureInfo culture = new CultureInfo(lang);
            Application.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture.Name);
        }

        private void PanelContainer_Load(object sender, EventArgs e)
        {
            PanelContainer.LoadPanel("");
        }
    }
}
