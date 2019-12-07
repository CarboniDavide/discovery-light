namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _ComputerSystemProductDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_ComputerSystemProductDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_NumberID = new System.Windows.Forms.Label();
            this.lbl_NumberID_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_NumberID
            // 
            resources.ApplyResources(this.lbl_NumberID, "lbl_NumberID");
            this.lbl_NumberID.Name = "lbl_NumberID";
            // 
            // lbl_NumberID_Value
            // 
            resources.ApplyResources(this.lbl_NumberID_Value, "lbl_NumberID_Value");
            this.lbl_NumberID_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_NumberID_Value.Name = "lbl_NumberID_Value";
            // 
            // _ComputerSystemProductDataControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_NumberID_Value);
            this.Controls.Add(this.lbl_NumberID);
            this.Name = "_ComputerSystemProductDataControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_NumberID;
        private System.Windows.Forms.Label lbl_NumberID_Value;
    }
}
