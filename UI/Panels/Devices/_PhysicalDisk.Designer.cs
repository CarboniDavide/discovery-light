using DiscoveryLight.UI.Components;

namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _PhysicalDisk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_PhysicalDisk));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource2 = new System.Threading.CancellationTokenSource();
            this.lbl_TilteComboBox = new System.Windows.Forms.Label();
            this.cmb_Blocks = new DataControlComboBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.PhysicalDiskDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._PhysicalDiskDeviceDataControl();
            this.PhysicalDiskDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._PhysicalDiskDevicePerformanceControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TilteComboBox
            // 
            resources.ApplyResources(this.lbl_TilteComboBox, "lbl_TilteComboBox");
            this.lbl_TilteComboBox.Name = "lbl_TilteComboBox";
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
            // PhysicalDiskDeviceDataControl
            // 
            resources.ApplyResources(this.PhysicalDiskDeviceDataControl, "PhysicalDiskDeviceDataControl");
            this.PhysicalDiskDeviceDataControl.ClassName = "_PhysicalDiskDeviceDataControl";
            this.PhysicalDiskDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._PhysicalDiskDeviceDataControl);
            this.PhysicalDiskDeviceDataControl.CurrentDevice = null;
            this.PhysicalDiskDeviceDataControl.CurrentSubDevice = null;
            this.PhysicalDiskDeviceDataControl.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.PhysicalDiskDeviceDataControl.Name = "PhysicalDiskDeviceDataControl";
            this.PhysicalDiskDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.PhysicalDiskDeviceDataControl.TokenSource = cancellationTokenSource1;
            // 
            // PhysicalDiskDevicePerformanceControl
            // 
            resources.ApplyResources(this.PhysicalDiskDevicePerformanceControl, "PhysicalDiskDevicePerformanceControl");
            this.PhysicalDiskDevicePerformanceControl.ClassName = "_PhysicalDiskDevicePerformanceControl";
            this.PhysicalDiskDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._PhysicalDiskDevicePerformanceControl);
            this.PhysicalDiskDevicePerformanceControl.Name = "PhysicalDiskDevicePerformanceControl";
            this.PhysicalDiskDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.PhysicalDiskDevicePerformanceControl.TokenSource = cancellationTokenSource2;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // _PhysicalDisk
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PhysicalDiskDevicePerformanceControl);
            this.Controls.Add(this.PhysicalDiskDeviceDataControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TilteComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "_PhysicalDisk";
            this.PanelIndex = 6;
            this.Load += new System.EventHandler(this._PhysicalDisk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_TilteComboBox;
        private DataControlComboBox cmb_Blocks;
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private DeviceControls.DeviceDataControls._PhysicalDiskDeviceDataControl PhysicalDiskDeviceDataControl;
        private DeviceControls.DevicePerformanceControls._PhysicalDiskDevicePerformanceControl PhysicalDiskDevicePerformanceControl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
