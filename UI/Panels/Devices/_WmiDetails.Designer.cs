namespace DiscoveryLight.UI.Panels.Devices
{
    partial class _WmiDetails
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
            this.lbl_Namespace = new System.Windows.Forms.Label();
            this.lbl_WmiClassName = new System.Windows.Forms.Label();
            this.lst_Details = new System.Windows.Forms.ListBox();
            this.cmb_Namespace = new System.Windows.Forms.ComboBox();
            this.cmb_WmiClassName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_Namespace
            // 
            this.lbl_Namespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Namespace.AutoSize = true;
            this.lbl_Namespace.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Namespace.Location = new System.Drawing.Point(10, 20);
            this.lbl_Namespace.Name = "lbl_Namespace";
            this.lbl_Namespace.Size = new System.Drawing.Size(67, 13);
            this.lbl_Namespace.TabIndex = 0;
            this.lbl_Namespace.Text = "Namespcace";
            // 
            // lbl_WmiClassName
            // 
            this.lbl_WmiClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_WmiClassName.AutoSize = true;
            this.lbl_WmiClassName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WmiClassName.Location = new System.Drawing.Point(16, 70);
            this.lbl_WmiClassName.Name = "lbl_WmiClassName";
            this.lbl_WmiClassName.Size = new System.Drawing.Size(57, 13);
            this.lbl_WmiClassName.TabIndex = 1;
            this.lbl_WmiClassName.Text = "Wmi Name";
            // 
            // lst_Details
            // 
            this.lst_Details.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_Details.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_Details.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Details.FormattingEnabled = true;
            this.lst_Details.Location = new System.Drawing.Point(0, 116);
            this.lst_Details.Name = "lst_Details";
            this.lst_Details.Size = new System.Drawing.Size(630, 247);
            this.lst_Details.TabIndex = 3;
            // 
            // cmb_Namespace
            // 
            this.cmb_Namespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Namespace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Namespace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Namespace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Namespace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Namespace.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Namespace.FormattingEnabled = true;
            this.cmb_Namespace.Location = new System.Drawing.Point(82, 17);
            this.cmb_Namespace.Name = "cmb_Namespace";
            this.cmb_Namespace.Size = new System.Drawing.Size(531, 21);
            this.cmb_Namespace.TabIndex = 4;
            this.cmb_Namespace.SelectedIndexChanged += new System.EventHandler(this.cmb_Namespace_SelectedIndexChanged);
            // 
            // cmb_WmiClassName
            // 
            this.cmb_WmiClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_WmiClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_WmiClassName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_WmiClassName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_WmiClassName.FormattingEnabled = true;
            this.cmb_WmiClassName.Location = new System.Drawing.Point(81, 67);
            this.cmb_WmiClassName.Name = "cmb_WmiClassName";
            this.cmb_WmiClassName.Size = new System.Drawing.Size(531, 21);
            this.cmb_WmiClassName.Sorted = true;
            this.cmb_WmiClassName.TabIndex = 5;
            this.cmb_WmiClassName.SelectedIndexChanged += new System.EventHandler(this.cmb_WmiClassName_SelectedIndexChanged);
            // 
            // _WmiDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cmb_WmiClassName);
            this.Controls.Add(this.cmb_Namespace);
            this.Controls.Add(this.lst_Details);
            this.Controls.Add(this.lbl_WmiClassName);
            this.Controls.Add(this.lbl_Namespace);
            this.Name = "_WmiDetails";
            this.Size = new System.Drawing.Size(630, 360);
            this.Load += new System.EventHandler(this._WmiDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Namespace;
        private System.Windows.Forms.Label lbl_WmiClassName;
        private System.Windows.Forms.ListBox lst_Details;
        private System.Windows.Forms.ComboBox cmb_Namespace;
        private System.Windows.Forms.ComboBox cmb_WmiClassName;
    }
}
