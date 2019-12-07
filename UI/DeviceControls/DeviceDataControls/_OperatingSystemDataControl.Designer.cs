namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _OperatingSystemDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_OperatingSystemDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_SystemOS = new System.Windows.Forms.Label();
            this.lbl_Producer = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_Architectur = new System.Windows.Forms.Label();
            this.lbl_Version_Value = new System.Windows.Forms.Label();
            this.lbl_Architectur_Value = new System.Windows.Forms.Label();
            this.lbl_SystemOS_Value = new System.Windows.Forms.Label();
            this.lbl_Producer_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_SystemOS
            // 
            resources.ApplyResources(this.lbl_SystemOS, "lbl_SystemOS");
            this.lbl_SystemOS.Name = "lbl_SystemOS";
            // 
            // lbl_Producer
            // 
            resources.ApplyResources(this.lbl_Producer, "lbl_Producer");
            this.lbl_Producer.Name = "lbl_Producer";
            // 
            // lbl_Version
            // 
            resources.ApplyResources(this.lbl_Version, "lbl_Version");
            this.lbl_Version.Name = "lbl_Version";
            // 
            // lbl_Architectur
            // 
            resources.ApplyResources(this.lbl_Architectur, "lbl_Architectur");
            this.lbl_Architectur.Name = "lbl_Architectur";
            // 
            // lbl_Version_Value
            // 
            resources.ApplyResources(this.lbl_Version_Value, "lbl_Version_Value");
            this.lbl_Version_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Version_Value.Name = "lbl_Version_Value";
            // 
            // lbl_Architectur_Value
            // 
            resources.ApplyResources(this.lbl_Architectur_Value, "lbl_Architectur_Value");
            this.lbl_Architectur_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Architectur_Value.Name = "lbl_Architectur_Value";
            // 
            // lbl_SystemOS_Value
            // 
            resources.ApplyResources(this.lbl_SystemOS_Value, "lbl_SystemOS_Value");
            this.lbl_SystemOS_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_SystemOS_Value.Name = "lbl_SystemOS_Value";
            // 
            // lbl_Producer_Value
            // 
            resources.ApplyResources(this.lbl_Producer_Value, "lbl_Producer_Value");
            this.lbl_Producer_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Producer_Value.Name = "lbl_Producer_Value";
            // 
            // _OperatingSystem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Producer_Value);
            this.Controls.Add(this.lbl_SystemOS_Value);
            this.Controls.Add(this.lbl_Architectur_Value);
            this.Controls.Add(this.lbl_Version_Value);
            this.Controls.Add(this.lbl_Architectur);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.lbl_Producer);
            this.Controls.Add(this.lbl_SystemOS);
            this.Name = "_OperatingSystem";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_SystemOS;
        private System.Windows.Forms.Label lbl_Producer;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label lbl_Architectur;
        private System.Windows.Forms.Label lbl_Version_Value;
        private System.Windows.Forms.Label lbl_Architectur_Value;
        private System.Windows.Forms.Label lbl_SystemOS_Value;
        private System.Windows.Forms.Label lbl_Producer_Value;
    }
}
