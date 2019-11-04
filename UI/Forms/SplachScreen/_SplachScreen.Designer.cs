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
            this.chgBar_Components = new WinformComponents.ChartBar();
            this.picBox_Logo = new System.Windows.Forms.PictureBox();
            this.picBox_Components = new System.Windows.Forms.PictureBox();
            this.lbl_Company = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Components)).BeginInit();
            this.SuspendLayout();
            // 
            // chgBar_Components
            // 
            this.chgBar_Components.Activated = true;
            this.chgBar_Components.BarBackColor = System.Drawing.Color.Transparent;
            this.chgBar_Components.BarFillColor = System.Drawing.SystemColors.Highlight;
            this.chgBar_Components.BarFillSize = 50;
            this.chgBar_Components.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chgBar_Components.Location = new System.Drawing.Point(0, 332);
            this.chgBar_Components.Name = "chgBar_Components";
            this.chgBar_Components.Size = new System.Drawing.Size(561, 5);
            this.chgBar_Components.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chgBar_Components.TabIndex = 1;
            this.chgBar_Components.TextColor = System.Drawing.Color.White;
            this.chgBar_Components.TextVisible = false;
            // 
            // picBox_Logo
            // 
            this.picBox_Logo.BackgroundImage = global::DiscoveryLight.Properties.Resources.CS;
            this.picBox_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBox_Logo.Location = new System.Drawing.Point(26, 282);
            this.picBox_Logo.Name = "picBox_Logo";
            this.picBox_Logo.Size = new System.Drawing.Size(35, 30);
            this.picBox_Logo.TabIndex = 2;
            this.picBox_Logo.TabStop = false;
            // 
            // picBox_Components
            // 
            this.picBox_Components.BackgroundImage = global::DiscoveryLight.Properties.Resources.LogoEntry;
            this.picBox_Components.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBox_Components.Location = new System.Drawing.Point(12, 12);
            this.picBox_Components.Name = "picBox_Components";
            this.picBox_Components.Size = new System.Drawing.Size(537, 313);
            this.picBox_Components.TabIndex = 0;
            this.picBox_Components.TabStop = false;
            // 
            // lbl_Company
            // 
            this.lbl_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Company.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbl_Company.LinkColor = System.Drawing.Color.Black;
            this.lbl_Company.Location = new System.Drawing.Point(60, 282);
            this.lbl_Company.Name = "lbl_Company";
            this.lbl_Company.Size = new System.Drawing.Size(76, 30);
            this.lbl_Company.TabIndex = 3;
            this.lbl_Company.TabStop = true;
            this.lbl_Company.Text = "CARBONI SOFTWARE";
            this.lbl_Company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _SplachScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(561, 337);
            this.Controls.Add(this.lbl_Company);
            this.Controls.Add(this.picBox_Logo);
            this.Controls.Add(this.chgBar_Components);
            this.Controls.Add(this.picBox_Components);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "_SplachScreen";
            this.Text = "Discovery";
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Components)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_Components;
        private WinformComponents.ChartBar chgBar_Components;
        private System.Windows.Forms.PictureBox picBox_Logo;
        private System.Windows.Forms.LinkLabel lbl_Company;
    }
}