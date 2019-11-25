namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _BiosDeviceDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_BiosDeviceDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_BiosManufacturer = new System.Windows.Forms.Label();
            this.lbl_BiosManufacturer_Value = new System.Windows.Forms.Label();
            this.lbl_BiosSerialNumber = new System.Windows.Forms.Label();
            this.lbl_BiosVersion = new System.Windows.Forms.Label();
            this.lbl_BiosReleaseDate = new System.Windows.Forms.Label();
            this.lbl_BiosSerialNumber_Value = new System.Windows.Forms.Label();
            this.lbl_BiosVersion_Value = new System.Windows.Forms.Label();
            this.lbl_BiosReleaseDate_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_BiosManufacturer
            // 
            resources.ApplyResources(this.lbl_BiosManufacturer, "lbl_BiosManufacturer");
            this.lbl_BiosManufacturer.Name = "lbl_BiosManufacturer";
            // 
            // lbl_BiosManufacturer_Value
            // 
            resources.ApplyResources(this.lbl_BiosManufacturer_Value, "lbl_BiosManufacturer_Value");
            this.lbl_BiosManufacturer_Value.Name = "lbl_BiosManufacturer_Value";
            // 
            // lbl_BiosSerialNumber
            // 
            resources.ApplyResources(this.lbl_BiosSerialNumber, "lbl_BiosSerialNumber");
            this.lbl_BiosSerialNumber.Name = "lbl_BiosSerialNumber";
            // 
            // lbl_BiosVersion
            // 
            resources.ApplyResources(this.lbl_BiosVersion, "lbl_BiosVersion");
            this.lbl_BiosVersion.Name = "lbl_BiosVersion";
            // 
            // lbl_BiosReleaseDate
            // 
            resources.ApplyResources(this.lbl_BiosReleaseDate, "lbl_BiosReleaseDate");
            this.lbl_BiosReleaseDate.Name = "lbl_BiosReleaseDate";
            // 
            // lbl_BiosSerialNumber_Value
            // 
            resources.ApplyResources(this.lbl_BiosSerialNumber_Value, "lbl_BiosSerialNumber_Value");
            this.lbl_BiosSerialNumber_Value.Name = "lbl_BiosSerialNumber_Value";
            // 
            // lbl_BiosVersion_Value
            // 
            resources.ApplyResources(this.lbl_BiosVersion_Value, "lbl_BiosVersion_Value");
            this.lbl_BiosVersion_Value.Name = "lbl_BiosVersion_Value";
            // 
            // lbl_BiosReleaseDate_Value
            // 
            resources.ApplyResources(this.lbl_BiosReleaseDate_Value, "lbl_BiosReleaseDate_Value");
            this.lbl_BiosReleaseDate_Value.Name = "lbl_BiosReleaseDate_Value";
            // 
            // _BiosDeviceDataControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_BiosReleaseDate_Value);
            this.Controls.Add(this.lbl_BiosVersion_Value);
            this.Controls.Add(this.lbl_BiosSerialNumber_Value);
            this.Controls.Add(this.lbl_BiosReleaseDate);
            this.Controls.Add(this.lbl_BiosVersion);
            this.Controls.Add(this.lbl_BiosSerialNumber);
            this.Controls.Add(this.lbl_BiosManufacturer_Value);
            this.Controls.Add(this.lbl_BiosManufacturer);
            this.Name = "_BiosDeviceDataControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
       
        private System.Windows.Forms.Label lbl_BiosManufacturer;
        private System.Windows.Forms.Label lbl_BiosManufacturer_Value;
        private System.Windows.Forms.Label lbl_BiosSerialNumber;
        private System.Windows.Forms.Label lbl_BiosVersion;
        private System.Windows.Forms.Label lbl_BiosReleaseDate;
        private System.Windows.Forms.Label lbl_BiosSerialNumber_Value;
        private System.Windows.Forms.Label lbl_BiosVersion_Value;
        private System.Windows.Forms.Label lbl_BiosReleaseDate_Value;
    }
}
