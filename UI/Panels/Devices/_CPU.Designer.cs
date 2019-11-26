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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_CPU));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource2 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource3 = new System.Threading.CancellationTokenSource();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.CpuDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._CpuDevicePerformanceControl();
            this.CpuDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._CpuDeviceDataControl();
            this.SystemDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._SystemDevicePerformanceControl();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Blocks
            // 
            resources.ApplyResources(this.cmb_Blocks, "cmb_Blocks");
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            // 
            // CpuDevicePerformanceControl
            // 
            this.CpuDevicePerformanceControl.ClassName = "_CpuDevicePerformanceControl";
            this.CpuDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._CpuDevicePerformanceControl);
            this.CpuDevicePerformanceControl.CurrentPerformance = null;
            this.CpuDevicePerformanceControl.CurrentSubDevice = 0;
            resources.ApplyResources(this.CpuDevicePerformanceControl, "CpuDevicePerformanceControl");
            this.CpuDevicePerformanceControl.Name = "CpuDevicePerformanceControl";
            this.CpuDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.CpuDevicePerformanceControl.TokenSource = cancellationTokenSource1;
            // 
            // CpuDeviceDataControl
            // 
            this.CpuDeviceDataControl.ClassName = "_CpuDeviceDataControl";
            this.CpuDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._CpuDeviceDataControl);
            this.CpuDeviceDataControl.CurrentDevice = null;
            this.CpuDeviceDataControl.CurrentSubDevice = null;
            resources.ApplyResources(this.CpuDeviceDataControl, "CpuDeviceDataControl");
            this.CpuDeviceDataControl.Name = "CpuDeviceDataControl";
            this.CpuDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.CpuDeviceDataControl.TokenSource = cancellationTokenSource2;
            // 
            // SystemDevicePerformanceControl
            // 
            this.SystemDevicePerformanceControl.BackColor = System.Drawing.Color.Transparent;
            this.SystemDevicePerformanceControl.ClassName = "_SystemDevicePerformanceControl";
            this.SystemDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._SystemDevicePerformanceControl);
            this.SystemDevicePerformanceControl.CurrentPerformance = null;
            this.SystemDevicePerformanceControl.CurrentSubDevice = 0;
            resources.ApplyResources(this.SystemDevicePerformanceControl, "SystemDevicePerformanceControl");
            this.SystemDevicePerformanceControl.Name = "SystemDevicePerformanceControl";
            this.SystemDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.SystemDevicePerformanceControl.TokenSource = cancellationTokenSource3;
            // 
            // pic_Divisor_001
            // 
            resources.ApplyResources(this.pic_Divisor_001, "pic_Divisor_001");
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.TabStop = false;
            // 
            // _CPU
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SystemDevicePerformanceControl);
            this.Controls.Add(this.CpuDevicePerformanceControl);
            this.Controls.Add(this.CpuDeviceDataControl);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_CPU";
            this.PanelIndex = 2;
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
