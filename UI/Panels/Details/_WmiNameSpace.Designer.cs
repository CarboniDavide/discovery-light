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
            this.lst_NameSpaces = new System.Windows.Forms.ComboBox();
            this.lbl_Namespace = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_NameSpaces
            // 
            this.lst_NameSpaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_NameSpaces.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lst_NameSpaces.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lst_NameSpaces.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_NameSpaces.FormattingEnabled = true;
            this.lst_NameSpaces.Location = new System.Drawing.Point(85, 14);
            this.lst_NameSpaces.Name = "lst_NameSpaces";
            this.lst_NameSpaces.Size = new System.Drawing.Size(531, 21);
            this.lst_NameSpaces.TabIndex = 6;
            this.lst_NameSpaces.SelectedIndexChanged += new System.EventHandler(this.OnChangeIndex);
            // 
            // lbl_Namespace
            // 
            this.lbl_Namespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Namespace.AutoSize = true;
            this.lbl_Namespace.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Namespace.Location = new System.Drawing.Point(13, 17);
            this.lbl_Namespace.Name = "lbl_Namespace";
            this.lbl_Namespace.Size = new System.Drawing.Size(67, 13);
            this.lbl_Namespace.TabIndex = 5;
            this.lbl_Namespace.Text = "Namespcace";
            // 
            // _WmiNameSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_NameSpaces);
            this.Controls.Add(this.lbl_Namespace);
            this.Name = "_WmiNameSpace";
            this.Size = new System.Drawing.Size(630, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Namespace;
        public System.Windows.Forms.ComboBox lst_NameSpaces;
    }
}
