namespace DiscoveryLight.UI.Panels.Details
{
    partial class _Classes
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
            this.lst_Classe = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_Classe
            // 
            this.lst_Classe.BackColor = System.Drawing.SystemColors.Control;
            this.lst_Classe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_Classe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_Classe.FormattingEnabled = true;
            this.lst_Classe.Location = new System.Drawing.Point(0, 0);
            this.lst_Classe.Name = "lst_Classe";
            this.lst_Classe.Size = new System.Drawing.Size(630, 360);
            this.lst_Classe.TabIndex = 0;
            // 
            // _Classes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_Classe);
            this.Name = "_Classes";
            this.Size = new System.Drawing.Size(630, 360);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_Classe;
    }
}
