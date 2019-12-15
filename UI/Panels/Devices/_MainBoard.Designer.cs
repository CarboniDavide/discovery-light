namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _MainBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_MainBoard));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource2 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource3 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource4 = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationTokenSource cancellationTokenSource5 = new System.Threading.CancellationTokenSource();
            this.lbl_Bios_Titre = new System.Windows.Forms.Label();
            this.WindowsScoreDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._WindowsScoreDevicePerformanceControl();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.BaseBoardDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BaseBoardDataControl();
            this.MotherBoardDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._MotherBoardDeviceDataControl();
            this.SystemSlotDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._SystemSlotDataControl();
            this.BiosDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BiosDeviceDataControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Bios_Titre
            // 
            resources.ApplyResources(this.lbl_Bios_Titre, "lbl_Bios_Titre");
            this.lbl_Bios_Titre.Name = "lbl_Bios_Titre";
            // 
            // WindowsScoreDevicePerformanceControl
            // 
            this.WindowsScoreDevicePerformanceControl.ClassName = "_WindowsScoreDevicePerformanceControl";
            this.WindowsScoreDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._WindowsScoreDevicePerformanceControl);
            resources.ApplyResources(this.WindowsScoreDevicePerformanceControl, "WindowsScoreDevicePerformanceControl");
            this.WindowsScoreDevicePerformanceControl.Name = "WindowsScoreDevicePerformanceControl";
            this.WindowsScoreDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.WindowsScoreDevicePerformanceControl.TokenSource = cancellationTokenSource1;
            // 
            // pic_Divisor_002
            // 
            resources.ApplyResources(this.pic_Divisor_002, "pic_Divisor_002");
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.TabStop = false;
            // 
            // pic_Divisor_001
            // 
            resources.ApplyResources(this.pic_Divisor_001, "pic_Divisor_001");
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.TabStop = false;
            // 
            // BaseBoardDataControl
            // 
            resources.ApplyResources(this.BaseBoardDataControl, "BaseBoardDataControl");
            this.BaseBoardDataControl.ClassName = "_BaseBoardDataControl";
            this.BaseBoardDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._BaseBoardDataControl);
            this.BaseBoardDataControl.CurrentDevice = null;
            this.BaseBoardDataControl.CurrentSubDevice = null;
            this.BaseBoardDataControl.Name = "BaseBoardDataControl";
            this.BaseBoardDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.BaseBoardDataControl.TokenSource = cancellationTokenSource2;
            // 
            // MotherBoardDeviceDataControl
            // 
            resources.ApplyResources(this.MotherBoardDeviceDataControl, "MotherBoardDeviceDataControl");
            this.MotherBoardDeviceDataControl.ClassName = "_MotherBoardDeviceDataControl";
            this.MotherBoardDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._MotherBoardDeviceDataControl);
            this.MotherBoardDeviceDataControl.CurrentDevice = null;
            this.MotherBoardDeviceDataControl.CurrentSubDevice = null;
            this.MotherBoardDeviceDataControl.Name = "MotherBoardDeviceDataControl";
            this.MotherBoardDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.MotherBoardDeviceDataControl.TokenSource = cancellationTokenSource3;
            // 
            // SystemSlotDataControl
            // 
            resources.ApplyResources(this.SystemSlotDataControl, "SystemSlotDataControl");
            this.SystemSlotDataControl.ClassName = "_SystemSlotDataControl";
            this.SystemSlotDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._SystemSlotDataControl);
            this.SystemSlotDataControl.CurrentDevice = null;
            this.SystemSlotDataControl.CurrentSubDevice = null;
            this.SystemSlotDataControl.Name = "SystemSlotDataControl";
            this.SystemSlotDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.SystemSlotDataControl.TokenSource = cancellationTokenSource4;
            // 
            // BiosDeviceDataControl
            // 
            resources.ApplyResources(this.BiosDeviceDataControl, "BiosDeviceDataControl");
            this.BiosDeviceDataControl.ClassName = "_BiosDeviceDataControl";
            this.BiosDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._BiosDeviceDataControl);
            this.BiosDeviceDataControl.CurrentDevice = null;
            this.BiosDeviceDataControl.CurrentSubDevice = null;
            this.BiosDeviceDataControl.Name = "BiosDeviceDataControl";
            this.BiosDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.BiosDeviceDataControl.TokenSource = cancellationTokenSource5;
            // 
            // _MainBoard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BiosDeviceDataControl);
            this.Controls.Add(this.SystemSlotDataControl);
            this.Controls.Add(this.MotherBoardDeviceDataControl);
            this.Controls.Add(this.BaseBoardDataControl);
            this.Controls.Add(this.WindowsScoreDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.lbl_Bios_Titre);
            this.Name = "_MainBoard";
            this.PanelIndex = 1;
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private System.Windows.Forms.Label lbl_Bios_Titre;
        private DeviceControls.DevicePerformanceControls._WindowsScoreDevicePerformanceControl WindowsScoreDevicePerformanceControl;
        private DeviceControls.DeviceDataControls._BaseBoardDataControl BaseBoardDataControl;
        private DeviceControls.DeviceDataControls._MotherBoardDeviceDataControl MotherBoardDeviceDataControl;
        private DeviceControls.DeviceDataControls._SystemSlotDataControl SystemSlotDataControl;
        private DeviceControls.DeviceDataControls._BiosDeviceDataControl BiosDeviceDataControl;
    }
}
