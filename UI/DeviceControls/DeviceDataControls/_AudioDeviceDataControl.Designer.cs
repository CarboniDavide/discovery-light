namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _AudioDeviceDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_AudioDeviceDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_Manufacturer = new System.Windows.Forms.Label();
            this.lbl_PowerManagment = new System.Windows.Forms.Label();
            this.lbl_Name_Value = new System.Windows.Forms.Label();
            this.lbl_Manufacturer_Value = new System.Windows.Forms.Label();
            this.lbl_PowerManagment_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Manufacturer
            // 
            resources.ApplyResources(this.lbl_Manufacturer, "lbl_Manufacturer");
            this.lbl_Manufacturer.Name = "lbl_Manufacturer";
            // 
            // lbl_PowerManagment
            // 
            resources.ApplyResources(this.lbl_PowerManagment, "lbl_PowerManagment");
            this.lbl_PowerManagment.Name = "lbl_PowerManagment";
            // 
            // lbl_Name_Value
            // 
            resources.ApplyResources(this.lbl_Name_Value, "lbl_Name_Value");
            this.lbl_Name_Value.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Name_Value.Name = "lbl_Name_Value";
            // 
            // lbl_Manufacturer_Value
            // 
            resources.ApplyResources(this.lbl_Manufacturer_Value, "lbl_Manufacturer_Value");
            this.lbl_Manufacturer_Value.Name = "lbl_Manufacturer_Value";
            // 
            // lbl_PowerManagment_Value
            // 
            resources.ApplyResources(this.lbl_PowerManagment_Value, "lbl_PowerManagment_Value");
            this.lbl_PowerManagment_Value.Name = "lbl_PowerManagment_Value";
            // 
            // _AudioDeviceDataControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_PowerManagment_Value);
            this.Controls.Add(this.lbl_Manufacturer_Value);
            this.Controls.Add(this.lbl_Name_Value);
            this.Controls.Add(this.lbl_PowerManagment);
            this.Controls.Add(this.lbl_Manufacturer);
            this.Name = "_AudioDeviceDataControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_Manufacturer;
        private System.Windows.Forms.Label lbl_PowerManagment;
        private System.Windows.Forms.Label lbl_Name_Value;
        private System.Windows.Forms.Label lbl_Manufacturer_Value;
        private System.Windows.Forms.Label lbl_PowerManagment_Value;
    }
}
