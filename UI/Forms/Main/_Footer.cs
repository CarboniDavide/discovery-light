using DiscoveryLight.UI.BaseUserControl;
using System;
using System.ComponentModel;

namespace DiscoveryLight.UI.Forms.Main
{
    public partial class _Footer : _BaseUserControl
    {
        public _Footer()
        {
            InitializeComponent();
        }

        public String FooterTittleName;

        private String waitMessage;
        private String loadMessage;
        private String mainTitle;
        private String currentTitle;
        private double chartBarStep;
        private double chartBarSize;

        [Localizable(true)]
        public string WaitMessage
        {
            get { return waitMessage; }
            set
            {
                waitMessage = value;
                CurrentTitle = value;
            }
        }
        [Localizable(true)]
        public string LoadMessage
        {
            get { return loadMessage; }
            set
            {
                loadMessage = value;
                CurrentTitle = value;
            }
        }
        public string CurrentTitle
        {
            get { return currentTitle; }
            set
            {
                currentTitle = value;
                ChartBar.CustomText = value;
            }
        }
        public string MainTitle
        {
            get { return mainTitle; }
            set
            {
                mainTitle = value;
                CurrentTitle = value;
            }
        }
        public double ChartBarStep { get => chartBarStep; set => chartBarStep = value; }
        public double ChartBarSize
        {
            get { return chartBarSize; }
            set
            {
                chartBarSize = value;
                ChartBar.BarFillSize = (int)chartBarSize;
            }
        }

        public void SetMainTitle()
        {
            MainTitle = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;  // get panel name
            this.ChartBar.BarFillSize = 0;                                                          // reset charging bar    
            this.FooterTittleName = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;     // get a backup to the current title
        }
        public void SetWaitTitle()
        {
            MainTitle = WaitMessage;
            this.ChartBar.BarFillSize = 0;                                                          // reset charging bar    
            this.FooterTittleName = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;     // get a backup to the current title
        }
        public void SetLoadTitle()
        {
            MainTitle = LoadMessage;
            this.ChartBar.BarFillSize = 0;                                                          // reset charging bar    
            this.FooterTittleName = FormsCollection.Main.PanelContainer.CurrentPanel.PanelName;     // get a backup to the current title
        }
        public void InitChartBar(Decimal? QuantityDivider)
        {
            ChartBarSize = 0;
            if (QuantityDivider == null || QuantityDivider == 0)
            {
                ChartBar.BarFillSize = 0;
                return;
            };
            chartBarStep = (double)Decimal.Divide(100, Convert.ToDecimal(QuantityDivider));
        }
        public void UpdateChartBar()
        {
            ChartBarSize += ChartBarStep;
        }
    }
}
