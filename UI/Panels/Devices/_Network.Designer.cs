namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _Network
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Network));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource2 = new System.Threading.CancellationTokenSource();
            this.lbl_TitleComboBock = new System.Windows.Forms.Label();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.NetworkDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._NetworkDevicePerformanceControl();
            this.NetworkDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._NetworkDeviceDataControl();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TitleComboBock
            // 
            resources.ApplyResources(this.lbl_TitleComboBock, "lbl_TitleComboBock");
            this.lbl_TitleComboBock.Name = "lbl_TitleComboBock";
            // 
            // cmb_Blocks
            // 
            resources.ApplyResources(this.cmb_Blocks, "cmb_Blocks");
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            // 
            // NetworkDevicePerformanceControl
            // 
            this.NetworkDevicePerformanceControl.ClassName = "_NetworkDevicePerformanceControl";
            this.NetworkDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._NetworkDevicePerformanceControl);
            this.NetworkDevicePerformanceControl.CurrentPerformance = null;
            this.NetworkDevicePerformanceControl.CurrentSubDevice = 0;
            resources.ApplyResources(this.NetworkDevicePerformanceControl, "NetworkDevicePerformanceControl");
            this.NetworkDevicePerformanceControl.Name = "NetworkDevicePerformanceControl";
            this.NetworkDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.NetworkDevicePerformanceControl.TokenSource = cancellationTokenSource1;
            // 
            // NetworkDeviceDataControl
            // 
            this.NetworkDeviceDataControl.ClassName = "_NetworkDeviceDataControl";
            this.NetworkDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._NetworkDeviceDataControl);
            this.NetworkDeviceDataControl.CurrentDevice = null;
            this.NetworkDeviceDataControl.CurrentSubDevice = null;
            resources.ApplyResources(this.NetworkDeviceDataControl, "NetworkDeviceDataControl");
            this.NetworkDeviceDataControl.Name = "NetworkDeviceDataControl";
            this.NetworkDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.NetworkDeviceDataControl.TokenSource = cancellationTokenSource2;
            // 
            // pic_Divisor_001
            // 
            resources.ApplyResources(this.pic_Divisor_001, "pic_Divisor_001");
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.TabStop = false;
            // 
            // pic_Divisor_002
            // 
            resources.ApplyResources(this.pic_Divisor_002, "pic_Divisor_002");
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.TabStop = false;
            // 
            // _Network
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NetworkDeviceDataControl);
            this.Controls.Add(this.NetworkDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBock);
            this.Controls.Add(this.pic_Divisor_002);
            this.Name = "_Network";
            this.PanelIndex = 7;
            this.Load += new System.EventHandler(this._Network_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private System.Windows.Forms.Label lbl_TitleComboBock;
        private System.Windows.Forms.ComboBox cmb_Blocks;
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DevicePerformanceControls._NetworkDevicePerformanceControl NetworkDevicePerformanceControl;
        private DeviceControls.DeviceDataControls._NetworkDeviceDataControl NetworkDeviceDataControl;
    }
}
