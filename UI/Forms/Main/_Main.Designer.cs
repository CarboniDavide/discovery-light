using DiscoveryLight.UI.Panels.UserSettings;
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Forms.Main
{
    partial class _Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Main));
            this.UserSettings = new DiscoveryLight.UI.Panels.UserSettings._UserSettings();
            this.Navigation = new DiscoveryLight.UI.Forms.Main._Navigation();
            this.Footer = new DiscoveryLight.UI.Forms.Main._Footer();
            this.PanelContainer = new DiscoveryLight.UI.Panels.Devices._PanelContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserSettings
            // 
            this.UserSettings.BackColor = System.Drawing.SystemColors.HighlightText;
            resources.ApplyResources(this.UserSettings, "UserSettings");
            this.UserSettings.Name = "UserSettings";
            // 
            // Navigation
            // 
            this.Navigation.BackColor = System.Drawing.SystemColors.InactiveBorder;
            resources.ApplyResources(this.Navigation, "Navigation");
            this.Navigation.Name = "Navigation";
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Footer.ChartBarSize = 0D;
            this.Footer.ChartBarStep = 0D;
            this.Footer.CurrentTitle = null;
            resources.ApplyResources(this.Footer, "Footer");
            this.Footer.MainTitle = null;
            this.Footer.Name = "Footer";
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelContainer.CurrentPanel = null;
            resources.ApplyResources(this.PanelContainer, "PanelContainer");
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Load += new System.EventHandler(this.PanelContainer_Load);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // _Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UserSettings);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.Navigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "_Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public _UserSettings UserSettings;
        public _Navigation Navigation;
        public _Footer Footer;
        private System.Windows.Forms.PictureBox pictureBox1;
        public _PanelContainer PanelContainer;
    }
}