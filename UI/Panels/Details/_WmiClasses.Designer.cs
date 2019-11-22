namespace DiscoveryLight.UI.Panels.Details
{
    partial class _WmiClasses
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
            this.lst_WmiClassName = new System.Windows.Forms.ComboBox();
            this.lbl_WmiClassName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_WmiClassName
            // 
            this.lst_WmiClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_WmiClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lst_WmiClassName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lst_WmiClassName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_WmiClassName.FormattingEnabled = true;
            this.lst_WmiClassName.Location = new System.Drawing.Point(85, 14);
            this.lst_WmiClassName.Name = "lst_WmiClassName";
            this.lst_WmiClassName.Size = new System.Drawing.Size(531, 21);
            this.lst_WmiClassName.Sorted = true;
            this.lst_WmiClassName.TabIndex = 7;
            this.lst_WmiClassName.SelectedIndexChanged += new System.EventHandler(this.OnChangeIndex);
            // 
            // lbl_WmiClassName
            // 
            this.lbl_WmiClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_WmiClassName.AutoSize = true;
            this.lbl_WmiClassName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WmiClassName.Location = new System.Drawing.Point(17, 17);
            this.lbl_WmiClassName.Name = "lbl_WmiClassName";
            this.lbl_WmiClassName.Size = new System.Drawing.Size(57, 13);
            this.lbl_WmiClassName.TabIndex = 6;
            this.lbl_WmiClassName.Text = "Wmi Name";
            // 
            // _WmiClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_WmiClassName);
            this.Controls.Add(this.lbl_WmiClassName);
            this.Name = "_WmiClasses";
            this.Size = new System.Drawing.Size(630, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_WmiClassName;
        public System.Windows.Forms.ComboBox lst_WmiClassName;
    }
}
