using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Main : Form
    {
        public _Main()
        {
            LoadLanguage();                // load selected language first
            InitializeComponent();         // then initialize all form's components 
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
            PanelContainer.LoadPanel("");           // load first panel
        }
    }
}
