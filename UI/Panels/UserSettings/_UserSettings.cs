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
using DiscoveryLight.UI.Components;

namespace DiscoveryLight.UI.Panels.UserSettings
{
    /// <summary>
    /// User Settings.
    /// Perform all user settings as language and frequency
    /// </summary>
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
            anm_PanelSet.ClosePanel();                                            // close settings using animation  
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            String lang = (sender as LanguageLinkRadio).Language.ToString();      // get selected language
            newLAnguage = lang;                                                                     
            Settings.Settings.Default.UserLanguage = lang;                        // update global settings              
            needRestart = (oldLAnguage != newLAnguage);                           // inform that a new restart is required  
            lbl_InfoRestart.Visible = needRestart;                                // show a message to inform user that application will be restarted              
        }
       
        private void cmd_Apply_Click(object sender, EventArgs e)
        {
            Settings.Settings.Default.Save();                                     // save all changes in global settings  
            if (needRestart) Application.Restart();                               // restart application to use the new selected language  
        }

        private void nmr_Freq_ValueChanged(object sender, EventArgs e)
        {
            Settings.Settings.Default.Frequency = nmr_Freq.Value.ToString();      // change frequency value in global settings
        }

        private void _UserSettings_Load(object sender, EventArgs e)
        {
            loadSettings();                                                       // read all saved settings      
        }

        private void loadSettings()
        {
            nmr_Freq.Value = Convert.ToDecimal(Settings.Settings.Default.Frequency);    // read current saved frequency
            oldLAnguage = Settings.Settings.Default.UserLanguage;                       // read current saved language                
            switch (oldLAnguage)                                                        // select language radio button according with the current language
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
