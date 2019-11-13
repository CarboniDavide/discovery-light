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
            this.lbl_ChartRAM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ChartRAM.AutoSize = true;
            this.lbl_ChartRAM.Location = new System.Drawing.Point(50, 104);
            this.lbl_ChartRAM.Name = "lbl_ChartRAM";
            this.lbl_ChartRAM.Size = new System.Drawing.Size(31, 13);
            this.lbl_ChartRAM.TabIndex = 26;
            this.lbl_ChartRAM.Text = "RAM";
            // 
            // lbl_ChartHD
            // 
            this.lbl_ChartHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ChartHD.AutoSize = true;
            this.lbl_ChartHD.Location = new System.Drawing.Point(37, 211);
            this.lbl_ChartHD.Name = "lbl_ChartHD";
            this.lbl_ChartHD.Size = new System.Drawing.Size(59, 13);
            this.lbl_ChartHD.TabIndex = 27;
            this.lbl_ChartHD.Text = "STORAGE";
            // 
            // lbl_ChartCPU
            // 
            this.lbl_ChartCPU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ChartCPU.AutoSize = true;
            this.lbl_ChartCPU.Location = new System.Drawing.Point(50, 324);
            this.lbl_ChartCPU.Name = "lbl_ChartCPU";
            this.lbl_ChartCPU.Size = new System.Drawing.Size(29, 13);
            this.lbl_ChartCPU.TabIndex = 28;
            this.lbl_ChartCPU.Text = "CPU";
            // 
            // chartCPU
            // 
            this.chartCPU.Activated = true;
            this.chartCPU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartCPU.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartCPU.CircleFillColor = System.Drawing.Color.Orange;
            this.chartCPU.FillSize = 25;
            this.chartCPU.Location = new System.Drawing.Point(29, 251);
            this.chartCPU.Name = "chartCPU";
            this.chartCPU.Size = new System.Drawing.Size(70, 70);
            this.chartCPU.TabIndex = 25;
            this.chartCPU.TextVisible = true;
            this.chartCPU.Thickness = 10;
            // 
            // chartHD
            // 
            this.chartHD.Activated = true;
            this.chartHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartHD.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartHD.CircleFillColor = System.Drawing.Color.SeaGreen;
            this.chartHD.FillSize = 25;
            this.chartHD.Location = new System.Drawing.Point(29, 138);
            this.chartHD.Name = "chartHD";
            this.chartHD.Size = new System.Drawing.Size(70, 70);
            this.chartHD.TabIndex = 24;
            this.chartHD.TextVisible = true;
            this.chartHD.Thickness = 10;
            // 
            // chartRAM
            // 
            this.chartRAM.Activated = true;
            this.chartRAM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartRAM.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartRAM.CircleFillColor = System.Drawing.Color.RoyalBlue;
            this.chartRAM.FillSize = 25;
            this.chartRAM.Location = new System.Drawing.Point(29, 30);
            this.chartRAM.Name = "chartRAM";
            this.chartRAM.Size = new System.Drawing.Size(70, 70);
            this.chartRAM.TabIndex = 23;
            this.chartRAM.TextVisible = true;
            this.chartRAM.Thickness = 10;
            // 
            // _BasePcDevicePerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ChartCPU);
            this.Controls.Add(this.lbl_ChartHD);
            this.Controls.Add(this.lbl_ChartRAM);
            this.Controls.Add(this.chartCPU);
            this.Controls.Add(this.chartHD);
            this.Controls.Add(this.chartRAM);
            this.Name = "_BasePcDevicePerformanceControl";
            this.Size = new System.Drawing.Size(127, 360);
            this.Load += new System.EventHandler(this._BasePcDevicePerformanceControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
