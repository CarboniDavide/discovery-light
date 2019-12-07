namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _Memory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Memory));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource2 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource3 = new System.Threading.CancellationTokenSource();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.lbl_TitleComboBox = new System.Windows.Forms.Label();
            this.MemoryDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._MemoryDevicePerformanceControl();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_003 = new System.Windows.Forms.PictureBox();
            this.PhysicalMemoryArrayDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._PhysicalMemoryArrayDataControl();
            this.PhysicalMemoryDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._PhysicalMemoryDataControl();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).BeginInit();
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
            // lbl_TitleComboBox
            // 
            resources.ApplyResources(this.lbl_TitleComboBox, "lbl_TitleComboBox");
            this.lbl_TitleComboBox.Name = "lbl_TitleComboBox";
            // 
            // MemoryDevicePerformanceControl
            // 
            this.MemoryDevicePerformanceControl.ClassName = "_MemoryDevicePerformanceControl";
            this.MemoryDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._MemoryDevicePerformanceControl);
            this.MemoryDevicePerformanceControl.CurrentPerformance = null;
            this.MemoryDevicePerformanceControl.CurrentSubDevice = 0;
            resources.ApplyResources(this.MemoryDevicePerformanceControl, "MemoryDevicePerformanceControl");
            this.MemoryDevicePerformanceControl.Name = "MemoryDevicePerformanceControl";
            this.MemoryDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.MemoryDevicePerformanceControl.TokenSource = cancellationTokenSource1;
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
            this.pic_Divisor_003.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_003.Name = "pic_Divisor_003";
            this.pic_Divisor_003.TabStop = false;
            // 
            // PhysicalMemoryArrayDataControl
            // 
            resources.ApplyResources(this.PhysicalMemoryArrayDataControl, "PhysicalMemoryArrayDataControl");
            this.PhysicalMemoryArrayDataControl.ClassName = "_PhysicalMemoryArrayDataControl";
            this.PhysicalMemoryArrayDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._PhysicalMemoryArrayDataControl);
            this.PhysicalMemoryArrayDataControl.CurrentDevice = null;
            this.PhysicalMemoryArrayDataControl.CurrentSubDevice = null;
            this.PhysicalMemoryArrayDataControl.Name = "PhysicalMemoryArrayDataControl";
            this.PhysicalMemoryArrayDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.PhysicalMemoryArrayDataControl.TokenSource = cancellationTokenSource2;
            // 
            // PhysicalMemoryDataControl
            // 
            resources.ApplyResources(this.PhysicalMemoryDataControl, "PhysicalMemoryDataControl");
            this.PhysicalMemoryDataControl.ClassName = "_PhysicalMemoryDataControl";
            this.PhysicalMemoryDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._PhysicalMemoryDataControl);
            this.PhysicalMemoryDataControl.CurrentDevice = null;
            this.PhysicalMemoryDataControl.CurrentSubDevice = null;
            this.PhysicalMemoryDataControl.Name = "PhysicalMemoryDataControl";
            this.PhysicalMemoryDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.PhysicalMemoryDataControl.TokenSource = cancellationTokenSource3;
            // 
            // pic_Divisor_001
            // 
            resources.ApplyResources(this.pic_Divisor_001, "pic_Divisor_001");
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.TabStop = false;
            // 
            // _Memory
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.PhysicalMemoryDataControl);
            this.Controls.Add(this.PhysicalMemoryArrayDataControl);
            this.Controls.Add(this.MemoryDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBox);
            this.Controls.Add(this.pic_Divisor_003);
            this.Name = "_Memory";
            this.PanelIndex = 3;
            this.Load += new System.EventHandler(this._Memory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Divisor_003;
        private System.Windows.Forms.ComboBox cmb_Blocks;
        private System.Windows.Forms.Label lbl_TitleComboBox;
        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private DeviceControls.DevicePerformanceControls._MemoryDevicePerformanceControl MemoryDevicePerformanceControl;
        private DeviceControls.DeviceDataControls._PhysicalMemoryArrayDataControl PhysicalMemoryArrayDataControl;
        private DeviceControls.DeviceDataControls._PhysicalMemoryDataControl PhysicalMemoryDataControl;
        private System.Windows.Forms.PictureBox pic_Divisor_001;
    }
}
