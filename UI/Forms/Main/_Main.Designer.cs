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
            this.FooterBar = new DiscoveryLight.UI.Forms.Main._Footer();
            this.NavigationBar = new DiscoveryLight.UI.Forms.Main._Navigation();
            this.PanelContainer = new DiscoveryLight.UI.Panels.Devices._PanelContainer();
            this.UserSettings = new DiscoveryLight.UI.Panels.UserSettings._UserSettings();
            this.SuspendLayout();
            // 
            // FooterBar
            // 
            this.FooterBar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FooterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterBar.Location = new System.Drawing.Point(40, 360);
            this.FooterBar.Name = "FooterBar";
            this.FooterBar.Size = new System.Drawing.Size(630, 40);
            this.FooterBar.TabIndex = 2;
            // 
            // NavigationBar
            // 
            this.NavigationBar.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.NavigationBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavigationBar.Location = new System.Drawing.Point(0, 0);
            this.NavigationBar.Name = "NavigationBar";
            this.NavigationBar.Size = new System.Drawing.Size(40, 400);
            this.NavigationBar.TabIndex = 1;
            // 
            // PanelContainer
            // 
            this.PanelContainer.CurrentPanel = null;
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(40, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(630, 360);
            this.PanelContainer.TabIndex = 3;
            // 
            // UserSettings
            // 
            this.UserSettings.BackColor = System.Drawing.SystemColors.HighlightText;
            this.UserSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.UserSettings.Location = new System.Drawing.Point(670, 0);
            this.UserSettings.Name = "UserSettings";
            this.UserSettings.Size = new System.Drawing.Size(0, 360);
            this.UserSettings.TabIndex = 4;
            // 
            // _Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 400);
            this.Controls.Add(this.UserSettings);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.FooterBar);
            this.Controls.Add(this.NavigationBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Discovery";
            this.ResumeLayout(false);

        }

        #endregion
        public _Footer FooterBar;
        public _Navigation NavigationBar;
        public _PanelContainer PanelContainer;
        public _UserSettings UserSettings;
    }
}