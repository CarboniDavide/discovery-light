namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _MotherBoardDeviceDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_MotherBoardDeviceDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_PrimaryBus = new System.Windows.Forms.Label();
            this.lbl_SecondaryBus = new System.Windows.Forms.Label();
            this.lbl_PrimaryBus_Value = new System.Windows.Forms.Label();
            this.lbl_SecondaryBus_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_PrimaryBus
            // 
            resources.ApplyResources(this.lbl_PrimaryBus, "lbl_PrimaryBus");
            this.lbl_PrimaryBus.Name = "lbl_PrimaryBus";
            // 
            // lbl_SecondaryBus
            // 
            resources.ApplyResources(this.lbl_SecondaryBus, "lbl_SecondaryBus");
            this.lbl_SecondaryBus.Name = "lbl_SecondaryBus";
            // 
            // lbl_PrimaryBus_Value
            // 
            resources.ApplyResources(this.lbl_PrimaryBus_Value, "lbl_PrimaryBus_Value");
            this.lbl_PrimaryBus_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_PrimaryBus_Value.Name = "lbl_PrimaryBus_Value";
            // 
            // lbl_SecondaryBus_Value
            // 
            resources.ApplyResources(this.lbl_SecondaryBus_Value, "lbl_SecondaryBus_Value");
            this.lbl_SecondaryBus_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_SecondaryBus_Value.Name = "lbl_SecondaryBus_Value";
            // 
            // _MotherBoardDeviceDataControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_SecondaryBus_Value);
            this.Controls.Add(this.lbl_PrimaryBus_Value);
            this.Controls.Add(this.lbl_SecondaryBus);
            this.Controls.Add(this.lbl_PrimaryBus);
            this.Name = "_MotherBoardDeviceDataControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_PrimaryBus;
        private System.Windows.Forms.Label lbl_SecondaryBus;
        private System.Windows.Forms.Label lbl_PrimaryBus_Value;
        private System.Windows.Forms.Label lbl_SecondaryBus_Value;
    }
}
