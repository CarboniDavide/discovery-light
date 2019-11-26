using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using DiscoveryLight.UI.Buttons;

namespace DiscoveryLight.UI.Panels.UserSettings
{
    public partial class _UserSettings : UserControl
    {
        public _UserSettings()
        {
            InitializeComponent();
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            anm_PanelSet.ClosePanel();
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            String lang = (sender as LanguageLinkRadio).Language.ToString();

            CultureInfo culture = new CultureInfo(lang);
            Application.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture.Name);

        }
    }
}
