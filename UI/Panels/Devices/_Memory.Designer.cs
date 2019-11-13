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
            this.pic_Divisor_003 = new System.Windows.Forms.PictureBox();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.lbl_TitleComboBox = new System.Windows.Forms.Label();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.MemoryDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._MemoryDeviceDataControl();
            this.MemoryDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._MemoryDevicePerformanceControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Divisor_003
            // 
            this.pic_Divisor_003.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_003.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_003.Location = new System.Drawing.Point(450, 0);
            this.pic_Divisor_003.Name = "pic_Divisor_003";
            this.pic_Divisor_003.Size = new System.Drawing.Size(2, 360);
            this.pic_Divisor_003.TabIndex = 71;
            this.pic_Divisor_003.TabStop = false;
            // 
            // cmb_Blocks
            // 
            this.cmb_Blocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmb_Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Location = new System.Drawing.Point(377, 333);
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.Size = new System.Drawing.Size(43, 21);
            this.cmb_Blocks.TabIndex = 74;
            this.cmb_Blocks.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            // 
            // lbl_TitleComboBox
            // 
            this.lbl_TitleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_TitleComboBox.AutoSize = true;
            this.lbl_TitleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TitleComboBox.Location = new System.Drawing.Point(320, 334);
            this.lbl_TitleComboBox.Name = "lbl_TitleComboBox";
            this.lbl_TitleComboBox.Size = new System.Drawing.Size(40, 20);
            this.lbl_TitleComboBox.TabIndex = 72;
            this.lbl_TitleComboBox.Text = "Bloc";
            // 
            // pic_Divisor_002
            // 
            this.pic_Divisor_002.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_002.Location = new System.Drawing.Point(20, 326);
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.Size = new System.Drawing.Size(400, 1);
            this.pic_Divisor_002.TabIndex = 217;
            this.pic_Divisor_002.TabStop = false;
            // 
            // MemoryDeviceDataControl
            // 
            this.MemoryDeviceDataControl.CurrentDevice = null;
            this.MemoryDeviceDataControl.CurrentSubDevice = null;
            this.MemoryDeviceDataControl.DeviceName = null;
            this.MemoryDeviceDataControl.DeviceType = null;
            this.MemoryDeviceDataControl.Location = new System.Drawing.Point(0, 0);
            this.MemoryDeviceDataControl.Name = "MemoryDeviceDataControl";
            this.MemoryDeviceDataControl.Size = new System.Drawing.Size(444, 324);
            this.MemoryDeviceDataControl.TabIndex = 218;
            // 
            // MemoryDevicePerformanceControl
            // 
            this.MemoryDevicePerformanceControl.CurrentPerformance = null;
            this.MemoryDevicePerformanceControl.CurrentSubDevice = 0;
            this.MemoryDevicePerformanceControl.Location = new System.Drawing.Point(453, 0);
            this.MemoryDevicePerformanceControl.Name = "MemoryDevicePerformanceControl";
            this.MemoryDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00");
            this.MemoryDevicePerformanceControl.Size = new System.Drawing.Size(174, 360);
            this.MemoryDevicePerformanceControl.TabIndex = 219;
            this.MemoryDevicePerformanceControl.TokenSource = null;
            // 
            // _Memory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MemoryDevicePerformanceControl);
            this.Controls.Add(this.MemoryDeviceDataControl);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBox);
            this.Controls.Add(this.pic_Divisor_003);
            this.Name = "_Memory";
            this.Size = new System.Drawing.Size(630, 360);
            this.Load += new System.EventHandler(this._Memory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Divisor_003;
        private System.Windows.Forms.ComboBox cmb_Blocks;
        private System.Windows.Forms.Label lbl_TitleComboBox;
        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private DeviceControls.DeviceDataControls._MemoryDeviceDataControl MemoryDeviceDataControl;
        private DeviceControls.DevicePerformanceControls._MemoryDevicePerformanceControl MemoryDevicePerformanceControl;
    }
}
