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
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_Bios_Titre = new System.Windows.Forms.Label();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.MainBoardDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._MainBoardDeviceDataControl();
            this.BiosDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BiosDeviceDataControl();
            this.WindowsScoreDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._WindowsScoreDevicePerformanceControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Bios_Titre
            // 
            this.lbl_Bios_Titre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_Bios_Titre.AutoSize = true;
            this.lbl_Bios_Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bios_Titre.Location = new System.Drawing.Point(10, 187);
            this.lbl_Bios_Titre.Name = "lbl_Bios_Titre";
            this.lbl_Bios_Titre.Size = new System.Drawing.Size(40, 20);
            this.lbl_Bios_Titre.TabIndex = 5;
            this.lbl_Bios_Titre.Text = "Bios";
            // 
            // pic_Divisor_002
            // 
            this.pic_Divisor_002.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_002.Location = new System.Drawing.Point(450, 0);
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.Size = new System.Drawing.Size(2, 360);
            this.pic_Divisor_002.TabIndex = 27;
            this.pic_Divisor_002.TabStop = false;
            // 
            // pic_Divisor_001
            // 
            this.pic_Divisor_001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_001.Location = new System.Drawing.Point(70, 198);
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.Size = new System.Drawing.Size(320, 1);
            this.pic_Divisor_001.TabIndex = 11;
            this.pic_Divisor_001.TabStop = false;
            // 
            // MainBoardDeviceDataControl
            // 
            this.MainBoardDeviceDataControl.CurrentDevice = null;
            this.MainBoardDeviceDataControl.CurrentSubDevice = null;
            this.MainBoardDeviceDataControl.Location = new System.Drawing.Point(92, 27);
            this.MainBoardDeviceDataControl.Name = "MainBoardDeviceDataControl";
            this.MainBoardDeviceDataControl.Size = new System.Drawing.Size(333, 153);
            this.MainBoardDeviceDataControl.TabIndex = 30;
            // 
            // BiosDeviceDataControl
            // 
            this.BiosDeviceDataControl.CurrentDevice = null;
            this.BiosDeviceDataControl.CurrentSubDevice = null;
            this.BiosDeviceDataControl.Location = new System.Drawing.Point(92, 216);
            this.BiosDeviceDataControl.Name = "BiosDeviceDataControl";
            this.BiosDeviceDataControl.Size = new System.Drawing.Size(333, 99);
            this.BiosDeviceDataControl.TabIndex = 29;
            // 
            // WindowsScoreDevicePerformanceControl
            // 
            this.WindowsScoreDevicePerformanceControl.CurrentPerformance = null;
            this.WindowsScoreDevicePerformanceControl.CurrentSubDevice = 0;
            this.WindowsScoreDevicePerformanceControl.Location = new System.Drawing.Point(465, 0);
            this.WindowsScoreDevicePerformanceControl.Name = "WindowsScoreDevicePerformanceControl";
            this.WindowsScoreDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.WindowsScoreDevicePerformanceControl.Size = new System.Drawing.Size(155, 360);
            this.WindowsScoreDevicePerformanceControl.TabIndex = 28;
            this.WindowsScoreDevicePerformanceControl.TokenSource = cancellationTokenSource1;
            // 
            // _MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainBoardDeviceDataControl);
            this.Controls.Add(this.BiosDeviceDataControl);
            this.Controls.Add(this.WindowsScoreDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.lbl_Bios_Titre);
            this.Name = "_MainBoard";
            this.PanelIndex = 1;
            this.PanelName = "Motherboard";
            this.Size = new System.Drawing.Size(630, 360);
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
