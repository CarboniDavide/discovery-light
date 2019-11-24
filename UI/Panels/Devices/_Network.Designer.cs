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
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.lbl_TitleComboBock = new System.Windows.Forms.Label();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.NetworkDevicePerformanceControl = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._NetworkDevicePerformanceControl();
            this.NetworkDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._NetworkDeviceDataControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Divisor_002
            // 
            this.pic_Divisor_002.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Divisor_002.Location = new System.Drawing.Point(480, 0);
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.Size = new System.Drawing.Size(2, 360);
            this.pic_Divisor_002.TabIndex = 181;
            this.pic_Divisor_002.TabStop = false;
            // 
            // lbl_TitleComboBock
            // 
            this.lbl_TitleComboBock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_TitleComboBock.AutoSize = true;
            this.lbl_TitleComboBock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TitleComboBock.Location = new System.Drawing.Point(17, 325);
            this.lbl_TitleComboBock.Name = "lbl_TitleComboBock";
            this.lbl_TitleComboBock.Size = new System.Drawing.Size(57, 20);
            this.lbl_TitleComboBock.TabIndex = 212;
            this.lbl_TitleComboBock.Text = "Device";
            // 
            // cmb_Blocks
            // 
            this.cmb_Blocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmb_Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Location = new System.Drawing.Point(77, 327);
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.Size = new System.Drawing.Size(394, 21);
            this.cmb_Blocks.TabIndex = 213;
            this.cmb_Blocks.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            // 
            // pic_Divisor_001
            // 
            this.pic_Divisor_001.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_001.Location = new System.Drawing.Point(21, 317);
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.Size = new System.Drawing.Size(450, 1);
            this.pic_Divisor_001.TabIndex = 216;
            this.pic_Divisor_001.TabStop = false;
            // 
            // NetworkDevicePerformanceControl
            // 
            this.NetworkDevicePerformanceControl.CurrentPerformance = null;
            this.NetworkDevicePerformanceControl.CurrentSubDevice = 0;
            this.NetworkDevicePerformanceControl.Location = new System.Drawing.Point(486, 10);
            this.NetworkDevicePerformanceControl.Name = "NetworkDevicePerformanceControl";
            this.NetworkDevicePerformanceControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.NetworkDevicePerformanceControl.Size = new System.Drawing.Size(139, 338);
            this.NetworkDevicePerformanceControl.TabIndex = 218;
            this.NetworkDevicePerformanceControl.TokenSource = cancellationTokenSource1;
            // 
            // NetworkDeviceDataControl
            // 
            this.NetworkDeviceDataControl.CurrentDevice = null;
            this.NetworkDeviceDataControl.CurrentSubDevice = null;
            this.NetworkDeviceDataControl.DeviceName = null;
            this.NetworkDeviceDataControl.DeviceType = null;
            this.NetworkDeviceDataControl.Location = new System.Drawing.Point(0, 25);
            this.NetworkDeviceDataControl.Name = "NetworkDeviceDataControl";
            this.NetworkDeviceDataControl.Size = new System.Drawing.Size(480, 260);
            this.NetworkDeviceDataControl.TabIndex = 219;
            // 
            // _Network
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NetworkDeviceDataControl);
            this.Controls.Add(this.NetworkDevicePerformanceControl);
            this.Controls.Add(this.pic_Divisor_001);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBock);
            this.Controls.Add(this.pic_Divisor_002);
            this.Name = "_Network";
            this.PanelIndex = 7;
            this.PanelName = "Network";
            this.Size = new System.Drawing.Size(630, 360);
            this.Load += new System.EventHandler(this._Network_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
