namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _BaseHardware
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
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.BasePcDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl();
            this.BasePcDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BasePcDeviceDataControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Divisor_001
            // 
            this.pic_Divisor_001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_001.Location = new System.Drawing.Point(450, 0);
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.Size = new System.Drawing.Size(2, 360);
            this.pic_Divisor_001.TabIndex = 22;
            this.pic_Divisor_001.TabStop = false;
            // 
            // BasePcDevicePerformanceControl
            // 
            this.BasePcDevicePerformanceControl.CurrentPerformance = null;
            this.BasePcDevicePerformanceControl.CurrentSubDevice = 0;
            this.BasePcDevicePerformanceControl.Location = new System.Drawing.Point(476, 0);
            this.BasePcDevicePerformanceControl.Name = "BasePcDevicePerformanceControl";
            this.BasePcDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00");
            this.BasePcDevicePerformanceControl.Size = new System.Drawing.Size(127, 360);
            this.BasePcDevicePerformanceControl.TabIndex = 24;
            this.BasePcDevicePerformanceControl.TokenSource = null;
            // 
            // BasePcDeviceDataControl
            // 
            this.BasePcDeviceDataControl.CurrentDevice = null;
            this.BasePcDeviceDataControl.CurrentSubDevice = null;
            this.BasePcDeviceDataControl.DeviceName = null;
            this.BasePcDeviceDataControl.DeviceType = null;
            this.BasePcDeviceDataControl.Location = new System.Drawing.Point(19, 0);
            this.BasePcDeviceDataControl.Name = "BasePcDeviceDataControl";
            this.BasePcDeviceDataControl.Size = new System.Drawing.Size(416, 360);
            this.BasePcDeviceDataControl.TabIndex = 23;
            // 
            // _BaseHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BasePcDevicePerformanceControl);
            this.Controls.Add(this.BasePcDeviceDataControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_BaseHardware";
            this.Size = new System.Drawing.Size(630, 360);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DeviceDataControls._BasePcDeviceDataControl BasePcDeviceDataControl;
        private DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl BasePcDevicePerformanceControl;
    }
}
