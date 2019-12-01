namespace DiscoveryLight.UI.Panels.Details
{
    partial class _MessageResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_MessageResult));
            this.lbl_MessageResult = new System.Windows.Forms.Label();
            this.pic_ImageResult = new System.Windows.Forms.PictureBox();
            this.lbl_ClasseName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ImageResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_MessageResult
            // 
            resources.ApplyResources(this.lbl_MessageResult, "lbl_MessageResult");
            this.lbl_MessageResult.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_MessageResult.Name = "lbl_MessageResult";
            // 
            // pic_ImageResult
            // 
            resources.ApplyResources(this.pic_ImageResult, "pic_ImageResult");
            this.pic_ImageResult.BackgroundImage = global::DiscoveryLight.Properties.Resources.ic_notfound;
            this.pic_ImageResult.Name = "pic_ImageResult";
            this.pic_ImageResult.TabStop = false;
            // 
            // lbl_ClasseName
            // 
            resources.ApplyResources(this.lbl_ClasseName, "lbl_ClasseName");
            this.lbl_ClasseName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_ClasseName.Name = "lbl_ClasseName";
            // 
            // _MessageResult
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ClasseName);
            this.Controls.Add(this.lbl_MessageResult);
            this.Controls.Add(this.pic_ImageResult);
            this.Name = "_MessageResult";
            ((System.ComponentModel.ISupportInitialize)(this.pic_ImageResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_ImageResult;
        public System.Windows.Forms.Label lbl_ClasseName;
        public System.Windows.Forms.Label lbl_MessageResult;
    }
}
