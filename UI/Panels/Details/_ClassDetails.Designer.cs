namespace DiscoveryLight.UI.Panels.Details
{
    partial class _ClassDetails
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
            this.lst_Details = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_Details
            // 
            this.lst_Details.BackColor = System.Drawing.SystemColors.Control;
            this.lst_Details.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_Details.FormattingEnabled = true;
            this.lst_Details.Location = new System.Drawing.Point(0, 0);
            this.lst_Details.Name = "lst_Details";
            this.lst_Details.Size = new System.Drawing.Size(630, 327);
            this.lst_Details.TabIndex = 0;
            // 
            // _ClassDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_Details);
            this.Name = "_ClassDetails";
            this.Size = new System.Drawing.Size(630, 327);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_Details;
    }
}
