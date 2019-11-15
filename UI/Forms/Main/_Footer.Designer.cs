namespace DiscoveryLight.UI.Forms.Main
{
    partial class _Footer
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
            this.lbl_DeviceName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_DeviceName
            // 
            this.lbl_DeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DeviceName.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lbl_DeviceName.ForeColor = System.Drawing.Color.Salmon;
            this.lbl_DeviceName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_DeviceName.Location = new System.Drawing.Point(227, 0);
            this.lbl_DeviceName.Name = "lbl_DeviceName";
            this.lbl_DeviceName.Size = new System.Drawing.Size(333, 40);
            this.lbl_DeviceName.TabIndex = 5;
            this.lbl_DeviceName.Text = "N/A";
            this.lbl_DeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Footer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.lbl_DeviceName);
            this.Name = "_Footer";
            this.Size = new System.Drawing.Size(560, 40);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_DeviceName;
    }
}
