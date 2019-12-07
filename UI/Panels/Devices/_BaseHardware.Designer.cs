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
            System.Threading.CancellationTokenSource cancellationTokenSource3 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource4 = new System.Threading.CancellationTokenSource();
            this.BasePcDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.ComputerSystem = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemDataControl();
            this.OperatingSystem = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._OperatingSystemDataControl();
            this.ComputerSystemProduct = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemProductDataControl();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_003 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).BeginInit();
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
            // pic_Divisor_001
            // 
            resources.ApplyResources(this.pic_Divisor_001, "pic_Divisor_001");
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.TabStop = false;
            // 
            // ComputerSystem
            // 
            this.ComputerSystem.ClassName = "_ComputerSystem";
            this.ComputerSystem.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemDataControl);
            this.ComputerSystem.CurrentDevice = null;
            this.ComputerSystem.CurrentSubDevice = null;
            resources.ApplyResources(this.ComputerSystem, "ComputerSystem");
            this.ComputerSystem.Name = "ComputerSystem";
            this.ComputerSystem.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.ComputerSystem.TokenSource = cancellationTokenSource2;
            // 
            // OperatingSystem
            // 
            this.OperatingSystem.ClassName = "_OperatingSystem";
            this.OperatingSystem.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._OperatingSystemDataControl);
            this.OperatingSystem.CurrentDevice = null;
            this.OperatingSystem.CurrentSubDevice = null;
            resources.ApplyResources(this.OperatingSystem, "OperatingSystem");
            this.OperatingSystem.Name = "OperatingSystem";
            this.OperatingSystem.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.OperatingSystem.TokenSource = cancellationTokenSource3;
            // 
            // ComputerSystemProduct
            // 
            this.ComputerSystemProduct.ClassName = "_ComputerSystemProduct";
            this.ComputerSystemProduct.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemProductDataControl);
            this.ComputerSystemProduct.CurrentDevice = null;
            this.ComputerSystemProduct.CurrentSubDevice = null;
            resources.ApplyResources(this.ComputerSystemProduct, "ComputerSystemProduct");
            this.ComputerSystemProduct.Name = "ComputerSystemProduct";
            this.ComputerSystemProduct.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.ComputerSystemProduct.TokenSource = cancellationTokenSource4;
            // 
            // pic_Divisor_002
            // 
            resources.ApplyResources(this.pic_Divisor_002, "pic_Divisor_002");
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.TabStop = false;
            // 
            // pic_Divisor_003
            // 
            resources.ApplyResources(this.pic_Divisor_003, "pic_Divisor_003");
            this.pic_Divisor_003.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_003.Name = "pic_Divisor_003";
            this.pic_Divisor_003.TabStop = false;
            // 
            // _BaseHardware
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pic_Divisor_003);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.ComputerSystemProduct);
            this.Controls.Add(this.OperatingSystem);
            this.Controls.Add(this.ComputerSystem);
            this.Controls.Add(this.BasePcDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_BaseHardware";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DevicePerformanceControls._BasePcDevicePerformanceControl BasePcDevicePerformanceControl;
        private DeviceControls.DeviceDataControls._ComputerSystemDataControl ComputerSystem;
        private DeviceControls.DeviceDataControls._OperatingSystemDataControl OperatingSystem;
        private DeviceControls.DeviceDataControls._ComputerSystemProductDataControl ComputerSystemProduct;
        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private System.Windows.Forms.PictureBox pic_Divisor_003;
    }
}
