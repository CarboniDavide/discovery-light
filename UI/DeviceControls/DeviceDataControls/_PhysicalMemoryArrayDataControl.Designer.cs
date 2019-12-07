namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _PhysicalMemoryArrayDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_PhysicalMemoryArrayDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_Type_Value = new System.Windows.Forms.Label();
            this.lbl_Block_Value = new System.Windows.Forms.Label();
            this.lbl_Size_Value = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.lbl_Block = new System.Windows.Forms.Label();
            this.lbl_Size = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Type_Value
            // 
            resources.ApplyResources(this.lbl_Type_Value, "lbl_Type_Value");
            this.lbl_Type_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Type_Value.Name = "lbl_Type_Value";
            // 
            // lbl_Block_Value
            // 
            resources.ApplyResources(this.lbl_Block_Value, "lbl_Block_Value");
            this.lbl_Block_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Block_Value.Name = "lbl_Block_Value";
            // 
            // lbl_Size_Value
            // 
            resources.ApplyResources(this.lbl_Size_Value, "lbl_Size_Value");
            this.lbl_Size_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Size_Value.Name = "lbl_Size_Value";
            // 
            // lbl_Type
            // 
            resources.ApplyResources(this.lbl_Type, "lbl_Type");
            this.lbl_Type.Name = "lbl_Type";
            // 
            // lbl_Block
            // 
            resources.ApplyResources(this.lbl_Block, "lbl_Block");
            this.lbl_Block.Name = "lbl_Block";
            // 
            // lbl_Size
            // 
            resources.ApplyResources(this.lbl_Size, "lbl_Size");
            this.lbl_Size.Name = "lbl_Size";
            // 
            // _PhysicalMemoryArrayDataControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Type_Value);
            this.Controls.Add(this.lbl_Block_Value);
            this.Controls.Add(this.lbl_Size_Value);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_Block);
            this.Controls.Add(this.lbl_Size);
            this.Name = "_PhysicalMemoryArrayDataControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_Type_Value;
        private System.Windows.Forms.Label lbl_Block_Value;
        private System.Windows.Forms.Label lbl_Size_Value;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.Label lbl_Block;
        private System.Windows.Forms.Label lbl_Size;
    }
}
