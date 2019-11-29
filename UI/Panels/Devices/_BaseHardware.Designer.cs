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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_BaseHardware));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource2 = new System.Threading.CancellationTokenSource();
            this.BasePcDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl();
            this.BasePcDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BasePcDeviceDataControl();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // BasePcDevicePerformanceControl
            // 
            this.BasePcDevicePerformanceControl.ClassName = "_BasePcDevicePerformanceControl";
            this.BasePcDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl);
            this.BasePcDevicePerformanceControl.CurrentPerformance = null;
            this.BasePcDevicePerformanceControl.CurrentSubDevice = 0;
            resources.ApplyResources(this.BasePcDevicePerformanceControl, "BasePcDevicePerformanceControl");
            this.BasePcDevicePerformanceControl.Name = "BasePcDevicePerformanceControl";
            this.BasePcDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.BasePcDevicePerformanceControl.TokenSource = cancellationTokenSource1;
            // 
            // BasePcDeviceDataControl
            // 
            resources.ApplyResources(this.BasePcDeviceDataControl, "BasePcDeviceDataControl");
            this.BasePcDeviceDataControl.ClassName = "_BasePcDeviceDataControl";
            this.BasePcDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._BasePcDeviceDataControl);
            this.BasePcDeviceDataControl.CurrentDevice = null;
            this.BasePcDeviceDataControl.CurrentSubDevice = null;
            this.BasePcDeviceDataControl.Name = "BasePcDeviceDataControl";
            this.BasePcDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.BasePcDeviceDataControl.TokenSource = cancellationTokenSource2;
            // 
            // pic_Divisor_001
            // 
            resources.ApplyResources(this.pic_Divisor_001, "pic_Divisor_001");
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.TabStop = false;
            // 
            // _BaseHardware
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BasePcDevicePerformanceControl);
            this.Controls.Add(this.BasePcDeviceDataControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_BaseHardware";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DeviceDataControls._BasePcDeviceDataControl BasePcDeviceDataControl;
        private DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl BasePcDevicePerformanceControl;
    }
}
