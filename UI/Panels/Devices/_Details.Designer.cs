namespace DiscoveryLight.UI.Panels.Devices
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
            this.WmiDetails = new DiscoveryLight.UI.Panels.Details._WmiDetails();
            this.SuspendLayout();
            // 
            // WmiNameSpace
            // 
            resources.ApplyResources(this.WmiNameSpace, "WmiNameSpace");
            this.WmiNameSpace.Footer = null;
            this.WmiNameSpace.Name = "WmiNameSpace";
            this.WmiNameSpace.SubPanelContainer = null;
            // 
            // WmiClasses
            // 
            resources.ApplyResources(this.WmiClasses, "WmiClasses");
            this.WmiClasses.Footer = null;
            this.WmiClasses.Name = "WmiClasses";
            this.WmiClasses.SubPanelContainer = null;
            // 
            // WmiDetails
            // 
            resources.ApplyResources(this.WmiDetails, "WmiDetails");
            this.WmiDetails.Footer = null;
            this.WmiDetails.Name = "WmiDetails";
            this.WmiDetails.SubPanelContainer = null;
            // 
            // _Details
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.WmiDetails);
            this.Controls.Add(this.WmiClasses);
            this.Controls.Add(this.WmiNameSpace);
            this.Name = "_Details";
            this.PanelIndex = 8;
            this.Load += new System.EventHandler(this._Details_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Details._WmiNameSpace WmiNameSpace;
        public Details._WmiClasses WmiClasses;
        public Details._WmiDetails WmiDetails;
    }
}
