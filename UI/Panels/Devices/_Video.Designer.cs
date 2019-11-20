namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _Video
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
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.lbl_TitleComboBox = new System.Windows.Forms.Label();
            this.pic_Divisor = new System.Windows.Forms.PictureBox();
            this.VideoDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._VideoDeviceDataControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Blocks
            // 
            this.cmb_Blocks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmb_Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Location = new System.Drawing.Point(139, 329);
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.Size = new System.Drawing.Size(393, 21);
            this.cmb_Blocks.TabIndex = 121;
            this.cmb_Blocks.SelectedIndexChanged += new System.EventHandler(this.ChangeSubDevice);
            // 
            // lbl_TitleComboBox
            // 
            this.lbl_TitleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_TitleComboBox.AutoSize = true;
            this.lbl_TitleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TitleComboBox.Location = new System.Drawing.Point(83, 329);
            this.lbl_TitleComboBox.Name = "lbl_TitleComboBox";
            this.lbl_TitleComboBox.Size = new System.Drawing.Size(50, 20);
            this.lbl_TitleComboBox.TabIndex = 119;
            this.lbl_TitleComboBox.Text = "Video";
            // 
            // pic_Divisor
            // 
            this.pic_Divisor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pic_Divisor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor.Location = new System.Drawing.Point(82, 319);
            this.pic_Divisor.Name = "pic_Divisor";
            this.pic_Divisor.Size = new System.Drawing.Size(450, 1);
            this.pic_Divisor.TabIndex = 142;
            this.pic_Divisor.TabStop = false;
            // 
            // VideoDeviceDataControl
            // 
            this.VideoDeviceDataControl.CurrentDevice = null;
            this.VideoDeviceDataControl.CurrentSubDevice = null;
            this.VideoDeviceDataControl.DeviceName = null;
            this.VideoDeviceDataControl.DeviceType = null;
            this.VideoDeviceDataControl.Location = new System.Drawing.Point(0, 0);
            this.VideoDeviceDataControl.Name = "VideoDeviceDataControl";
            this.VideoDeviceDataControl.Size = new System.Drawing.Size(630, 317);
            this.VideoDeviceDataControl.TabIndex = 143;
            // 
            // _Video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VideoDeviceDataControl);
            this.Controls.Add(this.pic_Divisor);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBox);
            this.Name = "_Video";
            this.PanelIndex = 5;
            this.Size = new System.Drawing.Size(630, 360);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Blocks;
        private System.Windows.Forms.Label lbl_TitleComboBox;
        private System.Windows.Forms.PictureBox pic_Divisor;
        private DeviceControls.DeviceDataControls._VideoDeviceDataControl VideoDeviceDataControl;
    }
}
