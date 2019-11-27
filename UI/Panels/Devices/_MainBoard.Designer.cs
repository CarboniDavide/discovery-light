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
            this.lbl_Bios_Titre = new System.Windows.Forms.Label();
            this.MainBoardDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._MainBoardDeviceDataControl();
            this.BiosDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BiosDeviceDataControl();
            this.WindowsScoreDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._WindowsScoreDevicePerformanceControl();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Bios_Titre
            // 
            resources.ApplyResources(this.lbl_Bios_Titre, "lbl_Bios_Titre");
            this.lbl_Bios_Titre.Name = "lbl_Bios_Titre";
            // 
            // MainBoardDeviceDataControl
            // 
            this.MainBoardDeviceDataControl.ClassName = "_MainBoardDeviceDataControl";
            this.MainBoardDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._MainBoardDeviceDataControl);
            this.MainBoardDeviceDataControl.CurrentDevice = null;
            this.MainBoardDeviceDataControl.CurrentSubDevice = null;
            resources.ApplyResources(this.MainBoardDeviceDataControl, "MainBoardDeviceDataControl");
            this.MainBoardDeviceDataControl.Name = "MainBoardDeviceDataControl";
            this.MainBoardDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.MainBoardDeviceDataControl.TokenSource = cancellationTokenSource1;
            // 
            // BiosDeviceDataControl
            // 
            this.BiosDeviceDataControl.ClassName = "_BiosDeviceDataControl";
            this.BiosDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._BiosDeviceDataControl);
            this.BiosDeviceDataControl.CurrentDevice = null;
            this.BiosDeviceDataControl.CurrentSubDevice = null;
            resources.ApplyResources(this.BiosDeviceDataControl, "BiosDeviceDataControl");
            this.BiosDeviceDataControl.Name = "BiosDeviceDataControl";
            this.BiosDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.BiosDeviceDataControl.TokenSource = cancellationTokenSource2;
            // 
            // WindowsScoreDevicePerformanceControl
            // 
            this.WindowsScoreDevicePerformanceControl.ClassName = "_WindowsScoreDevicePerformanceControl";
            this.WindowsScoreDevicePerformanceControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._WindowsScoreDevicePerformanceControl);
            this.WindowsScoreDevicePerformanceControl.CurrentPerformance = null;
            this.WindowsScoreDevicePerformanceControl.CurrentSubDevice = 0;
            resources.ApplyResources(this.WindowsScoreDevicePerformanceControl, "WindowsScoreDevicePerformanceControl");
            this.WindowsScoreDevicePerformanceControl.Name = "WindowsScoreDevicePerformanceControl";
            this.WindowsScoreDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.WindowsScoreDevicePerformanceControl.TokenSource = cancellationTokenSource3;
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
            // _MainBoard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainBoardDeviceDataControl);
            this.Controls.Add(this.BiosDeviceDataControl);
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
        private DeviceControls.DeviceDataControls._BiosDeviceDataControl BiosDeviceDataControl;
        private DeviceControls.DeviceDataControls._MainBoardDeviceDataControl MainBoardDeviceDataControl;
    }
}
