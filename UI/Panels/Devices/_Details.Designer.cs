﻿namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _Details
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Details));
            this.WmiNameSpace = new DiscoveryLight.UI.Panels.Details._WmiNameSpace();
            this.WmiClasses = new DiscoveryLight.UI.Panels.Details._WmiClasses();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WmiDetails = new DiscoveryLight.UI.Panels.Details._WmiDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // WmiNameSpace
            // 
            this.WmiNameSpace.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.WmiNameSpace, "WmiNameSpace");
            this.WmiNameSpace.Footer = null;
            this.WmiNameSpace.Name = "WmiNameSpace";
            this.WmiNameSpace.SubPanelContainer = null;
            // 
            // WmiClasses
            // 
            this.WmiClasses.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.WmiClasses, "WmiClasses");
            this.WmiClasses.Footer = null;
            this.WmiClasses.Name = "WmiClasses";
            this.WmiClasses.SubPanelContainer = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // WmiDetails
            // 
            this.WmiDetails.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.WmiDetails, "WmiDetails");
            this.WmiDetails.Footer = null;
            this.WmiDetails.Name = "WmiDetails";
            this.WmiDetails.SubPanelContainer = null;
            // 
            // _Details
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WmiDetails);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WmiClasses);
            this.Controls.Add(this.WmiNameSpace);
            this.Name = "_Details";
            this.PanelIndex = 8;
            this.Load += new System.EventHandler(this._Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Details._WmiNameSpace WmiNameSpace;
        public Details._WmiClasses WmiClasses;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Details._WmiDetails WmiDetails;
    }
}
