namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _CPU
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
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.CpuDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._CpuDevicePerformanceControl();
            this.CpuDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._CpuDeviceDataControl();
            this.SystemDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._SystemDevicePerformanceControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Divisor_001
            // 
            this.pic_Divisor_001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_001.Location = new System.Drawing.Point(347, 0);
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.Size = new System.Drawing.Size(2, 360);
            this.pic_Divisor_001.TabIndex = 46;
            this.pic_Divisor_001.TabStop = false;
            // 
            // cmb_Blocks
            // 
            this.cmb_Blocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmb_Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Location = new System.Drawing.Point(364, 20);
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.Size = new System.Drawing.Size(252, 21);
            this.cmb_Blocks.TabIndex = 67;
            this.cmb_Blocks.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            // 
            // CpuDevicePerformanceControl
            // 
            this.CpuDevicePerformanceControl.CurrentPerformance = null;
            this.CpuDevicePerformanceControl.CurrentSubDevice = 0;
            this.CpuDevicePerformanceControl.Location = new System.Drawing.Point(349, 56);
            this.CpuDevicePerformanceControl.Name = "CpuDevicePerformanceControl";
            this.CpuDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.CpuDevicePerformanceControl.Size = new System.Drawing.Size(281, 301);
            this.CpuDevicePerformanceControl.TabIndex = 69;
            this.CpuDevicePerformanceControl.TokenSource = cancellationTokenSource1;
            // 
            // CpuDeviceDataControl
            // 
            this.CpuDeviceDataControl.CurrentDevice = null;
            this.CpuDeviceDataControl.CurrentSubDevice = null;
            this.CpuDeviceDataControl.DeviceName = null;
            this.CpuDeviceDataControl.DeviceType = null;
            this.CpuDeviceDataControl.Location = new System.Drawing.Point(0, 0);
            this.CpuDeviceDataControl.Name = "CpuDeviceDataControl";
            this.CpuDeviceDataControl.Size = new System.Drawing.Size(341, 360);
            this.CpuDeviceDataControl.TabIndex = 68;
            // 
            // SystemDevicePerformanceControl
            // 
            this.SystemDevicePerformanceControl.BackColor = System.Drawing.Color.Transparent;
            this.SystemDevicePerformanceControl.CurrentPerformance = null;
            this.SystemDevicePerformanceControl.CurrentSubDevice = 0;
            this.SystemDevicePerformanceControl.Location = new System.Drawing.Point(489, 95);
            this.SystemDevicePerformanceControl.Name = "SystemDevicePerformanceControl";
            this.SystemDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.SystemDevicePerformanceControl.Size = new System.Drawing.Size(117, 48);
            this.SystemDevicePerformanceControl.TabIndex = 70;
            this.SystemDevicePerformanceControl.TokenSource = cancellationTokenSource2;
            // 
            // _CPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SystemDevicePerformanceControl);
            this.Controls.Add(this.CpuDevicePerformanceControl);
            this.Controls.Add(this.CpuDeviceDataControl);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_CPU";
            this.PanelIndex = 2;
            this.PanelName = "Processor";
            this.Size = new System.Drawing.Size(630, 360);
            this.Load += new System.EventHandler(this._CPU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private System.Windows.Forms.ComboBox cmb_Blocks;
        private DeviceControls.DeviceDataControls._CpuDeviceDataControl CpuDeviceDataControl;
        private DeviceControls.DevicePerformanceControls._CpuDevicePerformanceControl CpuDevicePerformanceControl;
        private DeviceControls.DevicePerformanceControls._SystemDevicePerformanceControl SystemDevicePerformanceControl;
    }
}
