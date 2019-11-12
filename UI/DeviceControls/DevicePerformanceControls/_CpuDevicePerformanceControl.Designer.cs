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
            this.chartCpuUsage = new WinformComponents.ChartCircle();
            this.lbl_CpuUsage_Value = new System.Windows.Forms.Label();
            this.lbl_CpuUsage = new System.Windows.Forms.Label();
            this.pnl_Threads = new System.Windows.Forms.Panel();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this._SystemDevicePerformanceControl1 = new DiscoveryLight.UI.DeviceControls.DevicePerformanceControls._SystemDevicePerformanceControl();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCpuUsage
            // 
            this.chartCpuUsage.Activated = true;
            this.chartCpuUsage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chartCpuUsage.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartCpuUsage.CircleFillColor = System.Drawing.Color.YellowGreen;
            this.chartCpuUsage.FillSize = 25;
            this.chartCpuUsage.Location = new System.Drawing.Point(21, 5);
            this.chartCpuUsage.Name = "chartCpuUsage";
            this.chartCpuUsage.Size = new System.Drawing.Size(90, 90);
            this.chartCpuUsage.TabIndex = 64;
            this.chartCpuUsage.TextVisible = true;
            this.chartCpuUsage.Thickness = 10;
            // 
            // lbl_CpuUsage_Value
            // 
            this.lbl_CpuUsage_Value.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_CpuUsage_Value.AutoSize = true;
            this.lbl_CpuUsage_Value.Location = new System.Drawing.Point(195, 81);
            this.lbl_CpuUsage_Value.Name = "lbl_CpuUsage_Value";
            this.lbl_CpuUsage_Value.Size = new System.Drawing.Size(24, 13);
            this.lbl_CpuUsage_Value.TabIndex = 78;
            this.lbl_CpuUsage_Value.Text = "n/a";
            // 
            // lbl_CpuUsage
            // 
            this.lbl_CpuUsage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_CpuUsage.AutoSize = true;
            this.lbl_CpuUsage.Location = new System.Drawing.Point(140, 81);
            this.lbl_CpuUsage.Name = "lbl_CpuUsage";
            this.lbl_CpuUsage.Size = new System.Drawing.Size(41, 13);
            this.lbl_CpuUsage.TabIndex = 74;
            this.lbl_CpuUsage.Text = "Utilisée";
            // 
            // pnl_Threads
            // 
            this.pnl_Threads.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnl_Threads.Location = new System.Drawing.Point(7, 117);
            this.pnl_Threads.Name = "pnl_Threads";
            this.pnl_Threads.Size = new System.Drawing.Size(267, 160);
            this.pnl_Threads.TabIndex = 79;
            // 
            // pic_Divisor_002
            // 
            this.pic_Divisor_002.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pic_Divisor_002.Location = new System.Drawing.Point(135, 31);
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.Size = new System.Drawing.Size(5, 63);
            this.pic_Divisor_002.TabIndex = 75;
            this.pic_Divisor_002.TabStop = false;
            // 
            // _SystemDevicePerformanceControl1
            // 
            this._SystemDevicePerformanceControl1.BackColor = System.Drawing.Color.Transparent;
            this._SystemDevicePerformanceControl1.CurrentPerformance = null;
            this._SystemDevicePerformanceControl1.CurrentSubDevice = 0;
            this._SystemDevicePerformanceControl1.Location = new System.Drawing.Point(141, 27);
            this._SystemDevicePerformanceControl1.Name = "_SystemDevicePerformanceControl1";
            this._SystemDevicePerformanceControl1.Period = System.TimeSpan.Parse("00:00:00");
            this._SystemDevicePerformanceControl1.Size = new System.Drawing.Size(140, 48);
            this._SystemDevicePerformanceControl1.TabIndex = 80;
            this._SystemDevicePerformanceControl1.TokenSource = null;
            // 
            // _CpuDevicePerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._SystemDevicePerformanceControl1);
            this.Controls.Add(this.pnl_Threads);
            this.Controls.Add(this.lbl_CpuUsage_Value);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.lbl_CpuUsage);
            this.Controls.Add(this.chartCpuUsage);
            this.Name = "_CpuDevicePerformanceControl";
            this.Size = new System.Drawing.Size(281, 286);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformComponents.ChartCircle chartCpuUsage;
        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private System.Windows.Forms.Label lbl_CpuUsage_Value;
        private System.Windows.Forms.Label lbl_CpuUsage;
        private System.Windows.Forms.Panel pnl_Threads;
        private _SystemDevicePerformanceControl _SystemDevicePerformanceControl1;
    }
}
