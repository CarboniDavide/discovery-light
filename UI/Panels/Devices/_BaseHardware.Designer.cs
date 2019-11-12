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
            this._BasePcDevicePerformanceControl1 = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl();
            this._BasePcDeviceDataControl1 = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BasePcDeviceDataControl();
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
            // _BasePcDevicePerformanceControl1
            // 
            this._BasePcDevicePerformanceControl1.CurrentPerformance = null;
            this._BasePcDevicePerformanceControl1.CurrentSubDevice = 0;
            this._BasePcDevicePerformanceControl1.Location = new System.Drawing.Point(476, 0);
            this._BasePcDevicePerformanceControl1.Name = "_BasePcDevicePerformanceControl1";
            this._BasePcDevicePerformanceControl1.Period = System.TimeSpan.Parse("00:00:00");
            this._BasePcDevicePerformanceControl1.Size = new System.Drawing.Size(127, 360);
            this._BasePcDevicePerformanceControl1.TabIndex = 24;
            this._BasePcDevicePerformanceControl1.TokenSource = null;
            // 
            // _BasePcDeviceDataControl1
            // 
            this._BasePcDeviceDataControl1.CurrentDevice = null;
            this._BasePcDeviceDataControl1.CurrentSubDevice = null;
            this._BasePcDeviceDataControl1.DeviceName = null;
            this._BasePcDeviceDataControl1.DeviceType = null;
            this._BasePcDeviceDataControl1.Location = new System.Drawing.Point(19, 0);
            this._BasePcDeviceDataControl1.Name = "_BasePcDeviceDataControl1";
            this._BasePcDeviceDataControl1.Size = new System.Drawing.Size(416, 360);
            this._BasePcDeviceDataControl1.TabIndex = 23;
            // 
            // _BaseHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._BasePcDevicePerformanceControl1);
            this.Controls.Add(this._BasePcDeviceDataControl1);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_BaseHardware";
            this.Size = new System.Drawing.Size(630, 360);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DeviceDataControls._BasePcDeviceDataControl _BasePcDeviceDataControl1;
        private DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl _BasePcDevicePerformanceControl1;
    }
}
