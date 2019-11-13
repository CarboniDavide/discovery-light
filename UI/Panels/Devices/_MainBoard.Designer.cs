﻿namespace DiscoveryLight.UI.Panels.Devices
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
            this.lbl_Bios_Titre = new System.Windows.Forms.Label();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this._MainBoardDeviceDataControl1 = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._MainBoardDeviceDataControl();
            this._BiosDeviceDataControl1 = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._BiosDeviceDataControl();
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
            // _MainBoardDeviceDataControl1
            // 
            this._MainBoardDeviceDataControl1.CurrentDevice = null;
            this._MainBoardDeviceDataControl1.CurrentSubDevice = null;
            this._MainBoardDeviceDataControl1.DeviceName = null;
            this._MainBoardDeviceDataControl1.DeviceType = null;
            this._MainBoardDeviceDataControl1.Location = new System.Drawing.Point(92, 27);
            this._MainBoardDeviceDataControl1.Name = "_MainBoardDeviceDataControl1";
            this._MainBoardDeviceDataControl1.Size = new System.Drawing.Size(333, 153);
            this._MainBoardDeviceDataControl1.TabIndex = 30;
            // 
            // _BiosDeviceDataControl1
            // 
            this._BiosDeviceDataControl1.CurrentDevice = null;
            this._BiosDeviceDataControl1.CurrentSubDevice = null;
            this._BiosDeviceDataControl1.DeviceName = null;
            this._BiosDeviceDataControl1.DeviceType = null;
            this._BiosDeviceDataControl1.Location = new System.Drawing.Point(92, 216);
            this._BiosDeviceDataControl1.Name = "_BiosDeviceDataControl1";
            this._BiosDeviceDataControl1.Size = new System.Drawing.Size(333, 99);
            this._BiosDeviceDataControl1.TabIndex = 29;
            // 
            // WindowsScoreDevicePerformanceControl
            // 
            this.WindowsScoreDevicePerformanceControl.CurrentPerformance = null;
            this.WindowsScoreDevicePerformanceControl.CurrentSubDevice = 0;
            this.WindowsScoreDevicePerformanceControl.Location = new System.Drawing.Point(465, 0);
            this.WindowsScoreDevicePerformanceControl.Name = "WindowsScoreDevicePerformanceControl";
            this.WindowsScoreDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00");
            this.WindowsScoreDevicePerformanceControl.Size = new System.Drawing.Size(155, 360);
            this.WindowsScoreDevicePerformanceControl.TabIndex = 28;
            this.WindowsScoreDevicePerformanceControl.TokenSource = null;
            // 
            // _MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._MainBoardDeviceDataControl1);
            this.Controls.Add(this._BiosDeviceDataControl1);
            this.Controls.Add(this.WindowsScoreDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.lbl_Bios_Titre);
            this.Name = "_MainBoard";
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
        private DeviceControls.DeviceDataControls._BiosDeviceDataControl _BiosDeviceDataControl1;
        private DeviceControls.DeviceDataControls._MainBoardDeviceDataControl _MainBoardDeviceDataControl1;
    }
}
