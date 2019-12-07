namespace DiscoveryLight.UI.DeviceControls.DeviceDataControls
{
    partial class _BaseBoardDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_BaseBoardDataControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_Manufacturer = new System.Windows.Forms.Label();
            this.lbl_Model = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_Manufacturer_Value = new System.Windows.Forms.Label();
            this.lbl_Model_Value = new System.Windows.Forms.Label();
            this.lbl_Version_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Manufacturer
            // 
            resources.ApplyResources(this.lbl_Manufacturer, "lbl_Manufacturer");
            this.lbl_Manufacturer.Name = "lbl_Manufacturer";
            // 
            // lbl_Model
            // 
            resources.ApplyResources(this.lbl_Model, "lbl_Model");
            this.lbl_Model.Name = "lbl_Model";
            // 
            // lbl_Version
            // 
            resources.ApplyResources(this.lbl_Version, "lbl_Version");
            this.lbl_Version.Name = "lbl_Version";
            // 
            // lbl_Manufacturer_Value
            // 
            resources.ApplyResources(this.lbl_Manufacturer_Value, "lbl_Manufacturer_Value");
            this.lbl_Manufacturer_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Manufacturer_Value.Name = "lbl_Manufacturer_Value";
            // 
            // lbl_Model_Value
            // 
            resources.ApplyResources(this.lbl_Model_Value, "lbl_Model_Value");
            this.lbl_Model_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Model_Value.Name = "lbl_Model_Value";
            // 
            // lbl_Version_Value
            // 
            resources.ApplyResources(this.lbl_Version_Value, "lbl_Version_Value");
            this.lbl_Version_Value.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Version_Value.Name = "lbl_Version_Value";
            // 
            // _BaseBoard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Version_Value);
            this.Controls.Add(this.lbl_Model_Value);
            this.Controls.Add(this.lbl_Manufacturer_Value);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.lbl_Model);
            this.Controls.Add(this.lbl_Manufacturer);
            this.Name = "_BaseBoard";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Manufacturer;
        private System.Windows.Forms.Label lbl_Model;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label lbl_Manufacturer_Value;
        private System.Windows.Forms.Label lbl_Model_Value;
        private System.Windows.Forms.Label lbl_Version_Value;
    }
}
