namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _BaseFreeRamDevicePerformance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_BaseFreeRamDevicePerformance));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_ChartRAM = new System.Windows.Forms.Label();
            this.chartRAM = new WinformComponents.ChartCircle();
            this.SuspendLayout();
            // 
            // lbl_ChartRAM
            // 
            resources.ApplyResources(this.lbl_ChartRAM, "lbl_ChartRAM");
            this.lbl_ChartRAM.Name = "lbl_ChartRAM";
            // 
            // chartRAM
            // 
            this.chartRAM.Activated = true;
            resources.ApplyResources(this.chartRAM, "chartRAM");
            this.chartRAM.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartRAM.CircleFillColor = System.Drawing.Color.RoyalBlue;
            this.chartRAM.FillSize = 25;
            this.chartRAM.Name = "chartRAM";
            this.chartRAM.TextVisible = true;
            this.chartRAM.Thickness = 12;
            // 
            // _BaseFreeRamDevicePerformance
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ChartRAM);
            this.Controls.Add(this.chartRAM);
            this.Name = "_BaseFreeRamDevicePerformance";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion

        private WinformComponents.ChartCircle chartRAM;
        private System.Windows.Forms.Label lbl_ChartRAM;
    }
}
