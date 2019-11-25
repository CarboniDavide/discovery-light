namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _CpuDevicePerformanceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_CpuDevicePerformanceControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.chartCpuUsage = new WinformComponents.ChartCircle();
            this.lbl_CpuSpeed_Value = new System.Windows.Forms.Label();
            this.lbl_CpuSpeed = new System.Windows.Forms.Label();
            this.pnl_Threads = new System.Windows.Forms.Panel();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCpuUsage
            // 
            resources.ApplyResources(this.chartCpuUsage, "chartCpuUsage");
            this.chartCpuUsage.Activated = true;
            this.chartCpuUsage.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartCpuUsage.CircleFillColor = System.Drawing.Color.DeepSkyBlue;
            this.chartCpuUsage.FillSize = 25;
            this.chartCpuUsage.Name = "chartCpuUsage";
            this.chartCpuUsage.TextVisible = true;
            this.chartCpuUsage.Thickness = 10;
            // 
            // lbl_CpuSpeed_Value
            // 
            resources.ApplyResources(this.lbl_CpuSpeed_Value, "lbl_CpuSpeed_Value");
            this.lbl_CpuSpeed_Value.Name = "lbl_CpuSpeed_Value";
            // 
            // lbl_CpuSpeed
            // 
            resources.ApplyResources(this.lbl_CpuSpeed, "lbl_CpuSpeed");
            this.lbl_CpuSpeed.Name = "lbl_CpuSpeed";
            // 
            // pnl_Threads
            // 
            resources.ApplyResources(this.pnl_Threads, "pnl_Threads");
            this.pnl_Threads.Name = "pnl_Threads";
            // 
            // pic_Divisor_002
            // 
            resources.ApplyResources(this.pic_Divisor_002, "pic_Divisor_002");
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.TabStop = false;
            // 
            // _CpuDevicePerformanceControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_Threads);
            this.Controls.Add(this.lbl_CpuSpeed_Value);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.lbl_CpuSpeed);
            this.Controls.Add(this.chartCpuUsage);
            this.Name = "_CpuDevicePerformanceControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformComponents.ChartCircle chartCpuUsage;
        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private System.Windows.Forms.Label lbl_CpuSpeed_Value;
        private System.Windows.Forms.Label lbl_CpuSpeed;
        private System.Windows.Forms.Panel pnl_Threads;
    }
}
