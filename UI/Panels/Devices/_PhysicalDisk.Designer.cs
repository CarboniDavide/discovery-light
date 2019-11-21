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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.lbl_TilteComboBox = new System.Windows.Forms.Label();
            this.PhysicalDiskDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._PhysicalDiskDevicePerformanceControl();
            this.PhysicalDiskDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._PhysicalDiskDeviceDataControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(470, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 360);
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // pic_Divisor_001
            // 
            this.pic_Divisor_001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_001.Location = new System.Drawing.Point(11, 317);
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.Size = new System.Drawing.Size(450, 1);
            this.pic_Divisor_001.TabIndex = 169;
            this.pic_Divisor_001.TabStop = false;
            // 
            // cmb_Blocks
            // 
            this.cmb_Blocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmb_Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Location = new System.Drawing.Point(76, 327);
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.Size = new System.Drawing.Size(385, 21);
            this.cmb_Blocks.TabIndex = 166;
            this.cmb_Blocks.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            // 
            // lbl_TilteComboBox
            // 
            this.lbl_TilteComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_TilteComboBox.AutoSize = true;
            this.lbl_TilteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TilteComboBox.Location = new System.Drawing.Point(11, 327);
            this.lbl_TilteComboBox.Name = "lbl_TilteComboBox";
            this.lbl_TilteComboBox.Size = new System.Drawing.Size(57, 20);
            this.lbl_TilteComboBox.TabIndex = 165;
            this.lbl_TilteComboBox.Text = "Device";
            // 
            // PhysicalDiskDevicePerformanceControl
            // 
            this.PhysicalDiskDevicePerformanceControl.CurrentPerformance = null;
            this.PhysicalDiskDevicePerformanceControl.CurrentSubDevice = 0;
            this.PhysicalDiskDevicePerformanceControl.Location = new System.Drawing.Point(477, 3);
            this.PhysicalDiskDevicePerformanceControl.Name = "PhysicalDiskDevicePerformanceControl";
            this.PhysicalDiskDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00");
            this.PhysicalDiskDevicePerformanceControl.Size = new System.Drawing.Size(153, 357);
            this.PhysicalDiskDevicePerformanceControl.TabIndex = 171;
            this.PhysicalDiskDevicePerformanceControl.TokenSource = null;
            // 
            // PhysicalDiskDeviceDataControl
            // 
            this.PhysicalDiskDeviceDataControl.CurrentDevice = null;
            this.PhysicalDiskDeviceDataControl.CurrentSubDevice = null;
            this.PhysicalDiskDeviceDataControl.DeviceName = null;
            this.PhysicalDiskDeviceDataControl.DeviceType = null;
            this.PhysicalDiskDeviceDataControl.Location = new System.Drawing.Point(3, 7);
            this.PhysicalDiskDeviceDataControl.Name = "PhysicalDiskDeviceDataControl";
            this.PhysicalDiskDeviceDataControl.Size = new System.Drawing.Size(465, 303);
            this.PhysicalDiskDeviceDataControl.TabIndex = 170;
            // 
            // _PhysicalDisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PhysicalDiskDevicePerformanceControl);
            this.Controls.Add(this.PhysicalDiskDeviceDataControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TilteComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "_PhysicalDisk";
            this.PanelIndex = 6;
            this.Size = new System.Drawing.Size(630, 360);
            this.Load += new System.EventHandler(this._PhysicalDisk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private System.Windows.Forms.ComboBox cmb_Blocks;
        private System.Windows.Forms.Label lbl_TilteComboBox;
        private DeviceControls.DeviceDataControls._PhysicalDiskDeviceDataControl PhysicalDiskDeviceDataControl;
        private DeviceControls.DevicePerformanceControls._PhysicalDiskDevicePerformanceControl PhysicalDiskDevicePerformanceControl;
    }
}
