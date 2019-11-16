namespace DiscoveryLight.UI.Panels.Details
{
    partial class _WmiNameSpace
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
            this.lst_NameSpace = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_NameSpace
            // 
            this.lst_NameSpace.BackColor = System.Drawing.SystemColors.Control;
            this.lst_NameSpace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_NameSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_NameSpace.FormattingEnabled = true;
            this.lst_NameSpace.Location = new System.Drawing.Point(0, 0);
            this.lst_NameSpace.Name = "lst_NameSpace";
            this.lst_NameSpace.Size = new System.Drawing.Size(630, 327);
            this.lst_NameSpace.TabIndex = 0;
            this.lst_NameSpace.Click += new System.EventHandler(this.lst_NameSpace_Click);
            // 
            // _NameSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_NameSpace);
            this.Name = "_NameSpace";
            this.Size = new System.Drawing.Size(630, 327);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_NameSpace;
    }
}
