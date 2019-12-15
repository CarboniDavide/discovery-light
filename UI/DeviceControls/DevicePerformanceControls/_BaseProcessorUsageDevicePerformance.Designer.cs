namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _BaseProcessorUsageDevicePerformance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_BaseProcessorUsageDevicePerformance));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_ChartCPU = new System.Windows.Forms.Label();
            this.chartCPU = new WinformComponents.ChartCircle();
            this.SuspendLayout();
            // 
            // lbl_ChartCPU
            // 
            resources.ApplyResources(this.lbl_ChartCPU, "lbl_ChartCPU");
            this.lbl_ChartCPU.Name = "lbl_ChartCPU";
            // 
            // chartCPU
            // 
            this.chartCPU.Activated = true;
            resources.ApplyResources(this.chartCPU, "chartCPU");
            this.chartCPU.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartCPU.CircleFillColor = System.Drawing.Color.Orange;
            this.chartCPU.FillSize = 25;
            this.chartCPU.Name = "chartCPU";
            this.chartCPU.TextVisible = true;
            this.chartCPU.Thickness = 12;
            // 
            // _BaseProcessorUsageDevicePerformance
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ChartCPU);
            this.Controls.Add(this.chartCPU);
            this.Name = "_BaseProcessorUsageDevicePerformance";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_ChartCPU;
        private WinformComponents.ChartCircle chartCPU;
    }
}
