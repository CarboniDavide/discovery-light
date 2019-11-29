namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _BasePcDevicePerformanceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_BasePcDevicePerformanceControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_ChartRAM = new System.Windows.Forms.Label();
            this.lbl_ChartHD = new System.Windows.Forms.Label();
            this.lbl_ChartCPU = new System.Windows.Forms.Label();
            this.chartCPU = new WinformComponents.ChartCircle();
            this.chartHD = new WinformComponents.ChartCircle();
            this.chartRAM = new WinformComponents.ChartCircle();
            this.SuspendLayout();
            // 
            // lbl_ChartRAM
            // 
            resources.ApplyResources(this.lbl_ChartRAM, "lbl_ChartRAM");
            this.lbl_ChartRAM.Name = "lbl_ChartRAM";
            // 
            // lbl_ChartHD
            // 
            resources.ApplyResources(this.lbl_ChartHD, "lbl_ChartHD");
            this.lbl_ChartHD.Name = "lbl_ChartHD";
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
            // chartHD
            // 
            this.chartHD.Activated = true;
            resources.ApplyResources(this.chartHD, "chartHD");
            this.chartHD.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartHD.CircleFillColor = System.Drawing.Color.SeaGreen;
            this.chartHD.FillSize = 25;
            this.chartHD.Name = "chartHD";
            this.chartHD.TextVisible = true;
            this.chartHD.Thickness = 12;
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
            // _BasePcDevicePerformanceControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ChartCPU);
            this.Controls.Add(this.lbl_ChartHD);
            this.Controls.Add(this.lbl_ChartRAM);
            this.Controls.Add(this.chartCPU);
            this.Controls.Add(this.chartHD);
            this.Controls.Add(this.chartRAM);
            this.Name = "_BasePcDevicePerformanceControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion

        private WinformComponents.ChartCircle chartRAM;
        private WinformComponents.ChartCircle chartHD;
        private System.Windows.Forms.Label lbl_ChartRAM;
        private System.Windows.Forms.Label lbl_ChartHD;
        private System.Windows.Forms.Label lbl_ChartCPU;
        private WinformComponents.ChartCircle chartCPU;
    }
}
