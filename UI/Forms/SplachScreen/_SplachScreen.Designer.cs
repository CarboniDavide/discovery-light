namespace DiscoveryLight.UI.Forms.SplachScreen
{
    partial class _SplachScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_SplachScreen));
            this.chgBar_Devices = new WinformComponents.ChartBar();
            this.picBox_Components = new System.Windows.Forms.PictureBox();
            this.lbl_Company = new System.Windows.Forms.LinkLabel();
            this.lbl_LoadIDeviceInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Components)).BeginInit();
            this.SuspendLayout();
            // 
            // chgBar_Devices
            // 
            this.chgBar_Devices.Activated = true;
            this.chgBar_Devices.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chgBar_Devices.BarBackColor = System.Drawing.Color.Transparent;
            this.chgBar_Devices.BarFillColor = System.Drawing.SystemColors.Highlight;
            this.chgBar_Devices.BarFillSize = 50;
            this.chgBar_Devices.ChartText = WinformComponents.ChartBar.ContentType.None;
            this.chgBar_Devices.CustomText = null;
            this.chgBar_Devices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chgBar_Devices.Location = new System.Drawing.Point(0, 334);
            this.chgBar_Devices.Margin = new System.Windows.Forms.Padding(4);
            this.chgBar_Devices.Name = "chgBar_Devices";
            this.chgBar_Devices.Size = new System.Drawing.Size(561, 3);
            this.chgBar_Devices.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chgBar_Devices.TabIndex = 1;
            this.chgBar_Devices.TextColor = System.Drawing.Color.White;
            this.chgBar_Devices.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // picBox_Components
            // 
            this.picBox_Components.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox_Components.BackgroundImage = global::DiscoveryLight.Properties.Resources.LogoEntry;
            this.picBox_Components.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBox_Components.Location = new System.Drawing.Point(12, 8);
            this.picBox_Components.Name = "picBox_Components";
            this.picBox_Components.Size = new System.Drawing.Size(537, 313);
            this.picBox_Components.TabIndex = 0;
            this.picBox_Components.TabStop = false;
            // 
            // lbl_Company
            // 
            this.lbl_Company.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Company.AutoSize = true;
            this.lbl_Company.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Company.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbl_Company.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Company.Location = new System.Drawing.Point(305, 258);
            this.lbl_Company.Name = "lbl_Company";
            this.lbl_Company.Size = new System.Drawing.Size(88, 13);
            this.lbl_Company.TabIndex = 3;
            this.lbl_Company.TabStop = true;
            this.lbl_Company.Text = "Carboni Software";
            this.lbl_Company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LoadIDeviceInfo
            // 
            this.lbl_LoadIDeviceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_LoadIDeviceInfo.Location = new System.Drawing.Point(9, 311);
            this.lbl_LoadIDeviceInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LoadIDeviceInfo.Name = "lbl_LoadIDeviceInfo";
            this.lbl_LoadIDeviceInfo.Size = new System.Drawing.Size(540, 14);
            this.lbl_LoadIDeviceInfo.TabIndex = 4;
            this.lbl_LoadIDeviceInfo.Text = "Loading devices";
            this.lbl_LoadIDeviceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _SplachScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(561, 337);
            this.Controls.Add(this.lbl_LoadIDeviceInfo);
            this.Controls.Add(this.lbl_Company);
            this.Controls.Add(this.chgBar_Devices);
            this.Controls.Add(this.picBox_Components);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "_SplachScreen";
            this.Text = "Discovery";
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Components)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_Components;
        private WinformComponents.ChartBar chgBar_Devices;
        private System.Windows.Forms.LinkLabel lbl_Company;
        private System.Windows.Forms.Label lbl_LoadIDeviceInfo;
    }
}