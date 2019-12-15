namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _BaseFreeStorageDevicePerformance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_BaseFreeStorageDevicePerformance));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_ChartHD = new System.Windows.Forms.Label();
            this.chartHD = new WinformComponents.ChartCircle();
            this.SuspendLayout();
            // 
            // lbl_ChartHD
            // 
            resources.ApplyResources(this.lbl_ChartHD, "lbl_ChartHD");
            this.lbl_ChartHD.Name = "lbl_ChartHD";
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
            // _BaseFreeStorageDevicePerformance
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ChartHD);
            this.Controls.Add(this.chartHD);
            this.Name = "_BaseFreeStorageDevicePerformance";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            this.ResumeLayout(false);

        }

        #endregion
        private WinformComponents.ChartCircle chartHD;
        private System.Windows.Forms.Label lbl_ChartHD;
    }
}
