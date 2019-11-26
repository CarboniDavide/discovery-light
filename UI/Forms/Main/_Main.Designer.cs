﻿using DiscoveryLight.UI.Panels.UserSettings;
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
            this.Navigation = new DiscoveryLight.UI.Forms.Main._Navigation();
            this.Footer = new DiscoveryLight.UI.Forms.Main._Footer();
            this.PanelContainer = new DiscoveryLight.UI.Panels.Devices._PanelContainer();
            this.UserSettings = new DiscoveryLight.UI.Panels.UserSettings._UserSettings();
            this.SuspendLayout();
            // 
            // Navigation
            // 
            this.Navigation.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Navigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.Navigation.Location = new System.Drawing.Point(0, 0);
            this.Navigation.Name = "Navigation";
            this.Navigation.Size = new System.Drawing.Size(40, 400);
            this.Navigation.TabIndex = 1;
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(40, 360);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(630, 40);
            this.Footer.TabIndex = 3;
            // 
            // PanelContainer
            // 
            this.PanelContainer.CurrentPanel = null;
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(40, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(630, 360);
            this.PanelContainer.TabIndex = 4;
            this.PanelContainer.Load += new System.EventHandler(this.PanelContainer_Load);
            // 
            // UserSettings
            // 
            this.UserSettings.BackColor = System.Drawing.SystemColors.HighlightText;
            this.UserSettings.Location = new System.Drawing.Point(670, 1);
            this.UserSettings.Name = "UserSettings";
            this.UserSettings.Size = new System.Drawing.Size(0, 400);
            this.UserSettings.TabIndex = 5;
            // 
            // _Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 400);
            this.Controls.Add(this.UserSettings);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.Navigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Discovery";
            this.ResumeLayout(false);

        }

        #endregion
        public _Navigation Navigation;
        public _Footer Footer;
        public _PanelContainer PanelContainer;
        public _UserSettings UserSettings;
    }
}