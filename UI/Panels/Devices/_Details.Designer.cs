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
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource2 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource3 = new System.Threading.CancellationTokenSource();
            this.WmiNameSpace = new DiscoveryLight.UI.Panels.Details._WmiNameSpace();
            this.WmiClasses = new DiscoveryLight.UI.Panels.Details._WmiClasses();
            this.WmiDetails = new DiscoveryLight.UI.Panels.Details._WmiDetails();
            this.SuspendLayout();
            // 
            // WmiNameSpace
            // 
            this.WmiNameSpace.Dock = System.Windows.Forms.DockStyle.Top;
            this.WmiNameSpace.ListValues = null;
            this.WmiNameSpace.Location = new System.Drawing.Point(0, 0);
            this.WmiNameSpace.Name = "WmiNameSpace";
            this.WmiNameSpace.Size = new System.Drawing.Size(630, 50);
            this.WmiNameSpace.TabIndex = 0;
            // 
            // WmiClasses
            // 
            this.WmiClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.WmiClasses.ListValues = null;
            this.WmiClasses.Location = new System.Drawing.Point(0, 50);
            this.WmiClasses.Name = "WmiClasses";
            this.WmiClasses.Size = new System.Drawing.Size(630, 50);
            this.WmiClasses.TabIndex = 1;
            // 
            // WmiDetails
            // 
            this.WmiDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.WmiDetails.ListValues = null;
            this.WmiDetails.Location = new System.Drawing.Point(0, 100);
            this.WmiDetails.Name = "WmiDetails";
            this.WmiDetails.Size = new System.Drawing.Size(630, 260);
            this.WmiDetails.TabIndex = 2;
            // 
            // _Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.WmiDetails);
            this.Controls.Add(this.WmiClasses);
            this.Controls.Add(this.WmiNameSpace);
            this.Name = "_Details";
            this.Size = new System.Drawing.Size(630, 360);
            this.Load += new System.EventHandler(this._Details_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Details._WmiNameSpace WmiNameSpace;
        public Details._WmiClasses WmiClasses;
        public Details._WmiDetails WmiDetails;
    }
}
