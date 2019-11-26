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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Audio));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.cmb_Blocks = new System.Windows.Forms.ComboBox();
            this.lbl_TitleComboBox = new System.Windows.Forms.Label();
            this.AudioDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._AudioDeviceDataControl();
            this.pic_Divisor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).BeginInit();
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
            // AudioDeviceDataControl
            // 
            this.AudioDeviceDataControl.ClassName = "_AudioDeviceDataControl";
            this.AudioDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._AudioDeviceDataControl);
            this.AudioDeviceDataControl.CurrentDevice = null;
            this.AudioDeviceDataControl.CurrentSubDevice = null;
            resources.ApplyResources(this.AudioDeviceDataControl, "AudioDeviceDataControl");
            this.AudioDeviceDataControl.Name = "AudioDeviceDataControl";
            this.AudioDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.AudioDeviceDataControl.TokenSource = cancellationTokenSource1;
            // 
            // pic_Divisor
            // 
            resources.ApplyResources(this.pic_Divisor, "pic_Divisor");
            this.pic_Divisor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor.Name = "pic_Divisor";
            this.pic_Divisor.TabStop = false;
            // 
            // _Audio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AudioDeviceDataControl);
            this.Controls.Add(this.pic_Divisor);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBox);
            this.Name = "_Audio";
            this.PanelIndex = 4;
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Blocks;
        private System.Windows.Forms.Label lbl_TitleComboBox;
        private System.Windows.Forms.PictureBox pic_Divisor;
        private DeviceControls.DeviceDataControls._AudioDeviceDataControl AudioDeviceDataControl;
    }
}
