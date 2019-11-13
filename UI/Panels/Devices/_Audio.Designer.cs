namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _Audio
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
            this.AudioDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._AudioDeviceDataControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Blocks
            // 
            this.cmb_Blocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmb_Blocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Location = new System.Drawing.Point(126, 327);
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.Size = new System.Drawing.Size(405, 21);
            this.cmb_Blocks.TabIndex = 121;
            // 
            // lbl_TitleComboBox
            // 
            this.lbl_TitleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_TitleComboBox.AutoSize = true;
            this.lbl_TitleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TitleComboBox.Location = new System.Drawing.Point(77, 326);
            this.lbl_TitleComboBox.Name = "lbl_TitleComboBox";
            this.lbl_TitleComboBox.Size = new System.Drawing.Size(50, 20);
            this.lbl_TitleComboBox.TabIndex = 119;
            this.lbl_TitleComboBox.Text = "Audio";
            // 
            // pic_Divisor
            // 
            this.pic_Divisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pic_Divisor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor.Location = new System.Drawing.Point(81, 311);
            this.pic_Divisor.Name = "pic_Divisor";
            this.pic_Divisor.Size = new System.Drawing.Size(450, 1);
            this.pic_Divisor.TabIndex = 143;
            this.pic_Divisor.TabStop = false;
            // 
            // AudioDeviceDataControl
            // 
            this.AudioDeviceDataControl.CurrentDevice = null;
            this.AudioDeviceDataControl.CurrentSubDevice = null;
            this.AudioDeviceDataControl.DeviceName = null;
            this.AudioDeviceDataControl.DeviceType = null;
            this.AudioDeviceDataControl.Location = new System.Drawing.Point(0, 3);
            this.AudioDeviceDataControl.Name = "AudioDeviceDataControl";
            this.AudioDeviceDataControl.Size = new System.Drawing.Size(630, 234);
            this.AudioDeviceDataControl.TabIndex = 144;
            // 
            // _Audio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AudioDeviceDataControl);
            this.Controls.Add(this.pic_Divisor);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBox);
            this.Name = "_Audio";
            this.Size = new System.Drawing.Size(630, 360);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Blocks;
        private System.Windows.Forms.Label lbl_TitleComboBox;
        private System.Windows.Forms.PictureBox pic_Divisor;
        private DeviceControls.DeviceDataControls._AudioDeviceDataControl AudioDeviceDataControl;
    }
}
