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

        private Boolean needRestart = false;
        private String oldLAnguage;
        private String newLAnguage;

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            anm_PanelSet.ClosePanel();
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            String lang = (sender as LanguageLinkRadio).Language.ToString();
            newLAnguage = lang;
            Settings.Settings.Default.UserLanguage = lang;
            needRestart = (oldLAnguage != newLAnguage);
            lbl_InfoRestart.Visible = needRestart;
        }
       
        private void cmd_Apply_Click(object sender, EventArgs e)
        {
            Settings.Settings.Default.Save();
            if (needRestart) Application.Restart();
        }

        private void nmr_Freq_ValueChanged(object sender, EventArgs e)
        {
            Settings.Settings.Default.Frequency = nmr_Freq.Value.ToString();
        }

        private void _UserSettings_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void loadSettings()
        {
            nmr_Freq.Value = Convert.ToDecimal(Settings.Settings.Default.Frequency);
            oldLAnguage = Settings.Settings.Default.UserLanguage;
            switch (oldLAnguage)
            {
                case "en-EN":
                    rdb_Eng.Select();
                    break;
                case "it-IT":
                    rdb_It.Select();
                    break;
                case "fr-FR":
                    rdb_Fr.Select();
                    break;
                case "de-DE":
                    rdb_Germ.Select();
                    break;
            }
        }
    }
}
