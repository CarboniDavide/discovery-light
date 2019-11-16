namespace DiscoveryLight.UI.Panels.Details
{
    partial class _SubNavigation
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
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.cmd_NameSpace = new System.Windows.Forms.Button();
            this.cmd_Classe = new System.Windows.Forms.Button();
            this.cmd_Details = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Divisor_001
            // 
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pic_Divisor_001.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pic_Divisor_001.Location = new System.Drawing.Point(0, 32);
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.Size = new System.Drawing.Size(426, 1);
            this.pic_Divisor_001.TabIndex = 219;
            this.pic_Divisor_001.TabStop = false;
            // 
            // cmd_NameSpace
            // 
            this.cmd_NameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_NameSpace.AutoSize = true;
            this.cmd_NameSpace.BackColor = System.Drawing.Color.LimeGreen;
            this.cmd_NameSpace.FlatAppearance.BorderSize = 0;
            this.cmd_NameSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_NameSpace.Location = new System.Drawing.Point(3, 3);
            this.cmd_NameSpace.Name = "cmd_NameSpace";
            this.cmd_NameSpace.Size = new System.Drawing.Size(99, 27);
            this.cmd_NameSpace.TabIndex = 220;
            this.cmd_NameSpace.Text = "Name Space";
            this.cmd_NameSpace.UseVisualStyleBackColor = false;
            this.cmd_NameSpace.Click += new System.EventHandler(this.cmd_NameSpace_Click);
            // 
            // cmd_Classe
            // 
            this.cmd_Classe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Classe.AutoSize = true;
            this.cmd_Classe.BackColor = System.Drawing.Color.LimeGreen;
            this.cmd_Classe.FlatAppearance.BorderSize = 0;
            this.cmd_Classe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Classe.Location = new System.Drawing.Point(105, 3);
            this.cmd_Classe.Name = "cmd_Classe";
            this.cmd_Classe.Size = new System.Drawing.Size(79, 27);
            this.cmd_Classe.TabIndex = 221;
            this.cmd_Classe.Text = "Classes";
            this.cmd_Classe.UseVisualStyleBackColor = false;
            this.cmd_Classe.Click += new System.EventHandler(this.cmd_Classe_Click);
            // 
            // cmd_Details
            // 
            this.cmd_Details.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Details.AutoSize = true;
            this.cmd_Details.BackColor = System.Drawing.Color.LimeGreen;
            this.cmd_Details.FlatAppearance.BorderSize = 0;
            this.cmd_Details.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Details.Location = new System.Drawing.Point(187, 3);
            this.cmd_Details.Name = "cmd_Details";
            this.cmd_Details.Size = new System.Drawing.Size(79, 27);
            this.cmd_Details.TabIndex = 222;
            this.cmd_Details.Text = "Details";
            this.cmd_Details.UseVisualStyleBackColor = false;
            // 
            // _Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmd_Details);
            this.Controls.Add(this.cmd_Classe);
            this.Controls.Add(this.cmd_NameSpace);
            this.Controls.Add(this.pic_Divisor_001);
            this.Name = "_Navigation";
            this.Size = new System.Drawing.Size(426, 33);
            this.Load += new System.EventHandler(this._Navigation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Divisor_001;
        public System.Windows.Forms.Button cmd_NameSpace;
        public System.Windows.Forms.Button cmd_Classe;
        public System.Windows.Forms.Button cmd_Details;
    }
}
