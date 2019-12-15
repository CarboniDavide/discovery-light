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
            System.Threading.CancellationTokenSource cancellationTokenSource5 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource6 = new System.Threading.CancellationTokenSource();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.ComputerSystem = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemDataControl();
            this.OperatingSystem = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._OperatingSystemDataControl();
            this.ComputerSystemProduct = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemProductDataControl();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_003 = new System.Windows.Forms.PictureBox();
            this._BaseFreeRamDevicePerformance = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BaseFreeRamDevicePerformance();
            this._BaseFreeStorageDevicePerformance = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BaseFreeStorageDevicePerformance();
            this._BaseProcessorUsageDevicePerformance = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BaseProcessorUsageDevicePerformance();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).BeginInit();
            this.SuspendLayout();
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
            resources.ApplyResources(this.ComputerSystem, "ComputerSystem");
            this.ComputerSystem.ClassName = "_ComputerSystem";
            this.ComputerSystem.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemDataControl);
            this.ComputerSystem.CurrentDevice = null;
            this.ComputerSystem.CurrentSubDevice = null;
            this.ComputerSystem.Name = "ComputerSystem";
            this.ComputerSystem.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.ComputerSystem.TokenSource = cancellationTokenSource1;
            // 
            // OperatingSystem
            // 
            resources.ApplyResources(this.OperatingSystem, "OperatingSystem");
            this.OperatingSystem.ClassName = "_OperatingSystem";
            this.OperatingSystem.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._OperatingSystemDataControl);
            this.OperatingSystem.CurrentDevice = null;
            this.OperatingSystem.CurrentSubDevice = null;
            this.OperatingSystem.Name = "OperatingSystem";
            this.OperatingSystem.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.OperatingSystem.TokenSource = cancellationTokenSource2;
            // 
            // ComputerSystemProduct
            // 
            resources.ApplyResources(this.ComputerSystemProduct, "ComputerSystemProduct");
            this.ComputerSystemProduct.ClassName = "_ComputerSystemProduct";
            this.ComputerSystemProduct.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._ComputerSystemProductDataControl);
            this.ComputerSystemProduct.CurrentDevice = null;
            this.ComputerSystemProduct.CurrentSubDevice = null;
            this.ComputerSystemProduct.Name = "ComputerSystemProduct";
            this.ComputerSystemProduct.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.ComputerSystemProduct.TokenSource = cancellationTokenSource3;
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
            // _BaseFreeRamDevicePerformance
            // 
            resources.ApplyResources(this._BaseFreeRamDevicePerformance, "_BaseFreeRamDevicePerformance");
            this._BaseFreeRamDevicePerformance.ClassName = "BaseFreeRamDevicePerformance";
            this._BaseFreeRamDevicePerformance.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BaseFreeRamDevicePerformance);
            this._BaseFreeRamDevicePerformance.CurrentDevice = null;
            this._BaseFreeRamDevicePerformance.CurrentSubDevice = null;
            this._BaseFreeRamDevicePerformance.Name = "_BaseFreeRamDevicePerformance";
            this._BaseFreeRamDevicePerformance.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this._BaseFreeRamDevicePerformance.TokenSource = cancellationTokenSource4;
            // 
            // _BaseFreeStorageDevicePerformance
            // 
            resources.ApplyResources(this._BaseFreeStorageDevicePerformance, "_BaseFreeStorageDevicePerformance");
            this._BaseFreeStorageDevicePerformance.ClassName = "BaseFreeStorageDevicePerformance";
            this._BaseFreeStorageDevicePerformance.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BaseFreeStorageDevicePerformance);
            this._BaseFreeStorageDevicePerformance.CurrentDevice = null;
            this._BaseFreeStorageDevicePerformance.CurrentSubDevice = null;
            this._BaseFreeStorageDevicePerformance.Name = "_BaseFreeStorageDevicePerformance";
            this._BaseFreeStorageDevicePerformance.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this._BaseFreeStorageDevicePerformance.TokenSource = cancellationTokenSource5;
            // 
            // _BaseProcessorUsageDevicePerformance
            // 
            resources.ApplyResources(this._BaseProcessorUsageDevicePerformance, "_BaseProcessorUsageDevicePerformance");
            this._BaseProcessorUsageDevicePerformance.ClassName = "_BaseProcessorUsageDevicePerformance";
            this._BaseProcessorUsageDevicePerformance.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._BaseProcessorUsageDevicePerformance);
            this._BaseProcessorUsageDevicePerformance.CurrentDevice = null;
            this._BaseProcessorUsageDevicePerformance.CurrentSubDevice = null;
            this._BaseProcessorUsageDevicePerformance.Name = "_BaseProcessorUsageDevicePerformance";
            this._BaseProcessorUsageDevicePerformance.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this._BaseProcessorUsageDevicePerformance.TokenSource = cancellationTokenSource6;
            // 
            // _BaseHardware
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._BaseProcessorUsageDevicePerformance);
            this.Controls.Add(this._BaseFreeStorageDevicePerformance);
            this.Controls.Add(this._BaseFreeRamDevicePerformance);
            this.Controls.Add(this.pic_Divisor_003);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.ComputerSystemProduct);
            this.Controls.Add(this.OperatingSystem);
            this.Controls.Add(this.ComputerSystem);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_BaseHardware";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DeviceDataControls._ComputerSystemDataControl ComputerSystem;
        private DeviceControls.DeviceDataControls._OperatingSystemDataControl OperatingSystem;
        private DeviceControls.DeviceDataControls._ComputerSystemProductDataControl ComputerSystemProduct;
        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private System.Windows.Forms.PictureBox pic_Divisor_003;
        private DeviceControls.DevicePerformanceControls._BaseFreeRamDevicePerformance _BaseFreeRamDevicePerformance;
        private DeviceControls.DevicePerformanceControls._BaseFreeStorageDevicePerformance _BaseFreeStorageDevicePerformance;
        private DeviceControls.DevicePerformanceControls._BaseProcessorUsageDevicePerformance _BaseProcessorUsageDevicePerformance;
    }
}
