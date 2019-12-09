using DiscoveryLight.UI.Components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Video));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.cmb_Blocks = new DiscoveryLight.UI.Components.DataControlComboBox();
            this.lbl_TitleComboBox = new System.Windows.Forms.Label();
            this.pic_Divisor = new System.Windows.Forms.PictureBox();
            this.VideoDeviceDataControl = new DiscoveryLight.UI.DeviceControls.DeviceDataControls._VideoControllerDataControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Blocks
            // 
            this.cmb_Blocks.Action = null;
            resources.ApplyResources(this.cmb_Blocks, "cmb_Blocks");
            this.cmb_Blocks.Blocks = null;
            this.cmb_Blocks.CurrentDeviceControl = null;
            this.cmb_Blocks.FormattingEnabled = true;
            this.cmb_Blocks.Name = "cmb_Blocks";
            this.cmb_Blocks.RelatedPerformance = null;
            // 
            // lbl_TitleComboBox
            // 
            resources.ApplyResources(this.lbl_TitleComboBox, "lbl_TitleComboBox");
            this.lbl_TitleComboBox.Name = "lbl_TitleComboBox";
            // 
            // pic_Divisor
            // 
            resources.ApplyResources(this.pic_Divisor, "pic_Divisor");
            this.pic_Divisor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor.Name = "pic_Divisor";
            this.pic_Divisor.TabStop = false;
            // 
            // VideoDeviceDataControl
            // 
            resources.ApplyResources(this.VideoDeviceDataControl, "VideoDeviceDataControl");
            this.VideoDeviceDataControl.ClassName = "_VideoDeviceDataControl";
            this.VideoDeviceDataControl.ClassType = typeof(DiscoveryLight.UI.DeviceControls.DeviceDataControls._VideoControllerDataControl);
            this.VideoDeviceDataControl.CurrentDevice = null;
            this.VideoDeviceDataControl.CurrentSubDevice = null;
            this.VideoDeviceDataControl.Name = "VideoDeviceDataControl";
            this.VideoDeviceDataControl.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.VideoDeviceDataControl.TokenSource = cancellationTokenSource1;
            // 
            // _Video
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VideoDeviceDataControl);
            this.Controls.Add(this.pic_Divisor);
            this.Controls.Add(this.cmb_Blocks);
            this.Controls.Add(this.lbl_TitleComboBox);
            this.Name = "_Video";
            this.PanelIndex = 5;
            this.Load += new System.EventHandler(this._Video_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataControlComboBox cmb_Blocks;
        private System.Windows.Forms.Label lbl_TitleComboBox;
        private System.Windows.Forms.PictureBox pic_Divisor;
        private DeviceControls.DeviceDataControls._VideoControllerDataControl VideoDeviceDataControl;
    }
}
