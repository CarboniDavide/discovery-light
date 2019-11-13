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
            this.lbl_CpuSpeed_Value = new System.Windows.Forms.Label();
            this.lbl_CpuSpeed = new System.Windows.Forms.Label();
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
            this.chartCpuUsage.CircleFillColor = System.Drawing.Color.DeepSkyBlue;
            this.chartCpuUsage.FillSize = 25;
            this.chartCpuUsage.Location = new System.Drawing.Point(21, 17);
            this.chartCpuUsage.Name = "chartCpuUsage";
            this.chartCpuUsage.Size = new System.Drawing.Size(90, 90);
            this.chartCpuUsage.TabIndex = 64;
            this.chartCpuUsage.TextVisible = true;
            this.chartCpuUsage.Thickness = 10;
            // 
            // lbl_CpuSpeed_Value
            // 
            this.lbl_CpuSpeed_Value.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_CpuSpeed_Value.AutoSize = true;
            this.lbl_CpuSpeed_Value.Location = new System.Drawing.Point(195, 93);
            this.lbl_CpuSpeed_Value.Name = "lbl_CpuSpeed_Value";
            this.lbl_CpuSpeed_Value.Size = new System.Drawing.Size(24, 13);
            this.lbl_CpuSpeed_Value.TabIndex = 78;
            this.lbl_CpuSpeed_Value.Text = "n/a";
            // 
            // lbl_CpuSpeed
            // 
            this.lbl_CpuSpeed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_CpuSpeed.AutoSize = true;
            this.lbl_CpuSpeed.Location = new System.Drawing.Point(140, 93);
            this.lbl_CpuSpeed.Name = "lbl_CpuSpeed";
            this.lbl_CpuSpeed.Size = new System.Drawing.Size(38, 13);
            this.lbl_CpuSpeed.TabIndex = 74;
            this.lbl_CpuSpeed.Text = "Speed";
            // 
            // pnl_Threads
            // 
            this.pnl_Threads.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnl_Threads.Location = new System.Drawing.Point(9, 142);
            this.pnl_Threads.Name = "pnl_Threads";
            this.pnl_Threads.Size = new System.Drawing.Size(262, 160);
            this.pnl_Threads.TabIndex = 79;
            // 
            // pic_Divisor_002
            // 
            this.pic_Divisor_002.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pic_Divisor_002.Location = new System.Drawing.Point(135, 43);
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.Size = new System.Drawing.Size(5, 63);
            this.pic_Divisor_002.TabIndex = 75;
            this.pic_Divisor_002.TabStop = false;
            // 
            // _SystemDevicePerformanceControl1
            // 
            this._SystemDevicePerformanceControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._SystemDevicePerformanceControl1.BackColor = System.Drawing.Color.Transparent;
            this._SystemDevicePerformanceControl1.CurrentPerformance = null;
            this._SystemDevicePerformanceControl1.CurrentSubDevice = 0;
            this._SystemDevicePerformanceControl1.Location = new System.Drawing.Point(141, 39);
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
            this.Controls.Add(this.lbl_CpuSpeed_Value);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.lbl_CpuSpeed);
            this.Controls.Add(this.chartCpuUsage);
            this.Name = "_CpuDevicePerformanceControl";
            this.Size = new System.Drawing.Size(281, 308);
            this.Load += new System.EventHandler(this._CpuDevicePerformanceControl_Load);
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
        private _SystemDevicePerformanceControl _SystemDevicePerformanceControl1;
    }
}
