namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _SystemSlotDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_SystemSlotDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_SlotNumber = new System.Windows.Forms.Label();
            this.lbl_SlotNumber_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_SlotNumber
            // 
            resources.ApplyResources(this.lbl_SlotNumber, "lbl_SlotNumber");
            this.lbl_SlotNumber.Name = "lbl_SlotNumber";
            // 
            // lbl_SlotNumber_Value
            // 
            resources.ApplyResources(this.lbl_SlotNumber_Value, "lbl_SlotNumber_Value");
            this.lbl_SlotNumber_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_SlotNumber_Value.Name = "lbl_SlotNumber_Value";
            // 
            // _SystemSlotDataControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_SlotNumber_Value);
            this.Controls.Add(this.lbl_SlotNumber);
            this.Name = "_SystemSlotDataControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_SlotNumber;
        private System.Windows.Forms.Label lbl_SlotNumber_Value;
    }
}
