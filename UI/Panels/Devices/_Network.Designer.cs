using DiscoveryLight.UI.Components;

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
            this.cmb_Blocks = new DataControlComboBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.NetworkDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._NetworkDeviceDataControl();
            this.NetworkDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._NetworkDevicePerformanceControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Blocks
            // 
            resources.ApplyResources(this.cmb_Blocks, "cmb_Blocks");
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Name = "cmb_Blocks";
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
            // NetworkDeviceDataControl
            // 
            resources.ApplyResources(this.NetworkDeviceDataControl, "NetworkDeviceDataControl");
            this.NetworkDeviceDataControl.ClassName = "_NetworkDeviceDataControl";
            this.NetworkDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._NetworkDeviceDataControl);
            this.NetworkDeviceDataControl.CurrentDevice = null;
            this.NetworkDeviceDataControl.CurrentSubDevice = null;
            this.NetworkDeviceDataControl.Name = "NetworkDeviceDataControl";
            this.NetworkDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.NetworkDeviceDataControl.TokenSource = cancellationTokenSource1;
            // 
            // NetworkDevicePerformanceControl
            // 
            resources.ApplyResources(this.NetworkDevicePerformanceControl, "NetworkDevicePerformanceControl");
            this.NetworkDevicePerformanceControl.ClassName = "_NetworkDevicePerformanceControl";
            this.NetworkDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._NetworkDevicePerformanceControl);
            this.NetworkDevicePerformanceControl.CurrentPerformance = null;
            this.NetworkDevicePerformanceControl.CurrentSubDevice = 0;
            this.NetworkDevicePerformanceControl.Name = "NetworkDevicePerformanceControl";
            this.NetworkDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.NetworkDevicePerformanceControl.TokenSource = cancellationTokenSource2;
            // 
            // _Network
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NetworkDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.NetworkDeviceDataControl);
            this.Name = "_Network";
            this.PanelIndex = 7;
            this.Load += new System.EventHandler(this._Network_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private DataControlComboBox cmb_Blocks;
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DeviceDataControls._NetworkDeviceDataControl NetworkDeviceDataControl;
        private DeviceControls.DevicePerformanceControls._NetworkDevicePerformanceControl NetworkDevicePerformanceControl;
    }
}
