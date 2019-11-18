namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _PhysicalDiskDevicePerformanceControl
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
            this.chartDiskFree = new WinformComponents.ChartCircle();
            this.lbl_Read = new System.Windows.Forms.Label();
            this.lbl_Write = new System.Windows.Forms.Label();
            this.lbl_Transfer = new System.Windows.Forms.Label();
            this.lbl_Read_Value = new System.Windows.Forms.Label();
            this.lbl_Write_Value = new System.Windows.Forms.Label();
            this.lbl_Transfer_Value = new System.Windows.Forms.Label();
            this.lbl_Free = new System.Windows.Forms.Label();
            this.lbl_Free_Value = new System.Windows.Forms.Label();
            this.chartReadTime = new WinformComponents.ChartBar();
            this.chartIdleTime = new WinformComponents.ChartBar();
            this.chartDiskTime = new WinformComponents.ChartBar();
            this.chartWriteTime = new WinformComponents.ChartBar();
            this.lbl_Title_Chart_Read = new System.Windows.Forms.Label();
            this.lbl_Title_Chart_Write = new System.Windows.Forms.Label();
            this.lbl_Title_Chart_Disk = new System.Windows.Forms.Label();
            this.lbl_Title_Chart_Idle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chartDiskFree
            // 
            this.chartDiskFree.Activated = true;
            this.chartDiskFree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chartDiskFree.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartDiskFree.CircleFillColor = System.Drawing.Color.MediumSeaGreen;
            this.chartDiskFree.FillSize = 25;
            this.chartDiskFree.Location = new System.Drawing.Point(23, 12);
            this.chartDiskFree.Name = "chartDiskFree";
            this.chartDiskFree.Size = new System.Drawing.Size(90, 90);
            this.chartDiskFree.TabIndex = 115;
            this.chartDiskFree.TextVisible = true;
            this.chartDiskFree.Thickness = 10;
            // 
            // lbl_Read
            // 
            this.lbl_Read.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Read.AutoSize = true;
            this.lbl_Read.Location = new System.Drawing.Point(3, 149);
            this.lbl_Read.Name = "lbl_Read";
            this.lbl_Read.Size = new System.Drawing.Size(43, 13);
            this.lbl_Read.TabIndex = 124;
            this.lbl_Read.Text = "Read/s";
            // 
            // lbl_Write
            // 
            this.lbl_Write.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Write.AutoSize = true;
            this.lbl_Write.Location = new System.Drawing.Point(3, 133);
            this.lbl_Write.Name = "lbl_Write";
            this.lbl_Write.Size = new System.Drawing.Size(42, 13);
            this.lbl_Write.TabIndex = 125;
            this.lbl_Write.Text = "Write/s";
            // 
            // lbl_Transfer
            // 
            this.lbl_Transfer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Transfer.AutoSize = true;
            this.lbl_Transfer.Location = new System.Drawing.Point(3, 165);
            this.lbl_Transfer.Name = "lbl_Transfer";
            this.lbl_Transfer.Size = new System.Drawing.Size(56, 13);
            this.lbl_Transfer.TabIndex = 131;
            this.lbl_Transfer.Text = "Transfer/s";
            // 
            // lbl_Read_Value
            // 
            this.lbl_Read_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Read_Value.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Read_Value.Location = new System.Drawing.Point(77, 149);
            this.lbl_Read_Value.Name = "lbl_Read_Value";
            this.lbl_Read_Value.Size = new System.Drawing.Size(63, 13);
            this.lbl_Read_Value.TabIndex = 132;
            this.lbl_Read_Value.Text = "n/a";
            this.lbl_Read_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Write_Value
            // 
            this.lbl_Write_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Write_Value.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Write_Value.Location = new System.Drawing.Point(77, 133);
            this.lbl_Write_Value.Name = "lbl_Write_Value";
            this.lbl_Write_Value.Size = new System.Drawing.Size(63, 13);
            this.lbl_Write_Value.TabIndex = 137;
            this.lbl_Write_Value.Text = "n/a";
            this.lbl_Write_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Transfer_Value
            // 
            this.lbl_Transfer_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Transfer_Value.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Transfer_Value.Location = new System.Drawing.Point(77, 165);
            this.lbl_Transfer_Value.Name = "lbl_Transfer_Value";
            this.lbl_Transfer_Value.Size = new System.Drawing.Size(63, 13);
            this.lbl_Transfer_Value.TabIndex = 138;
            this.lbl_Transfer_Value.Text = "n/a";
            this.lbl_Transfer_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Free
            // 
            this.lbl_Free.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Free.AutoSize = true;
            this.lbl_Free.Location = new System.Drawing.Point(3, 117);
            this.lbl_Free.Name = "lbl_Free";
            this.lbl_Free.Size = new System.Drawing.Size(50, 13);
            this.lbl_Free.TabIndex = 140;
            this.lbl_Free.Text = "Available";
            // 
            // lbl_Free_Value
            // 
            this.lbl_Free_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Free_Value.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Free_Value.Location = new System.Drawing.Point(77, 117);
            this.lbl_Free_Value.Name = "lbl_Free_Value";
            this.lbl_Free_Value.Size = new System.Drawing.Size(63, 13);
            this.lbl_Free_Value.TabIndex = 141;
            this.lbl_Free_Value.Text = "n/a";
            this.lbl_Free_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chartReadTime
            // 
            this.chartReadTime.Activated = true;
            this.chartReadTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartReadTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartReadTime.BarFillColor = System.Drawing.Color.LightSalmon;
            this.chartReadTime.BarFillSize = 25;
            this.chartReadTime.Location = new System.Drawing.Point(5, 205);
            this.chartReadTime.Name = "chartReadTime";
            this.chartReadTime.Size = new System.Drawing.Size(135, 24);
            this.chartReadTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartReadTime.TabIndex = 170;
            this.chartReadTime.TextColor = System.Drawing.Color.White;
            // 
            // chartIdleTime
            // 
            this.chartIdleTime.Activated = true;
            this.chartIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartIdleTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartIdleTime.BarFillColor = System.Drawing.Color.LightSeaGreen;
            this.chartIdleTime.BarFillSize = 25;
            this.chartIdleTime.Location = new System.Drawing.Point(5, 330);
            this.chartIdleTime.Name = "chartIdleTime";
            this.chartIdleTime.Size = new System.Drawing.Size(135, 24);
            this.chartIdleTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartIdleTime.TabIndex = 172;
            this.chartIdleTime.TextColor = System.Drawing.Color.White;
            // 
            // chartDiskTime
            // 
            this.chartDiskTime.Activated = true;
            this.chartDiskTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartDiskTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartDiskTime.BarFillColor = System.Drawing.Color.DarkSeaGreen;
            this.chartDiskTime.BarFillSize = 25;
            this.chartDiskTime.Location = new System.Drawing.Point(5, 289);
            this.chartDiskTime.Name = "chartDiskTime";
            this.chartDiskTime.Size = new System.Drawing.Size(135, 24);
            this.chartDiskTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartDiskTime.TabIndex = 173;
            this.chartDiskTime.TextColor = System.Drawing.Color.White;
            // 
            // chartWriteTime
            // 
            this.chartWriteTime.Activated = true;
            this.chartWriteTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartWriteTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartWriteTime.BarFillColor = System.Drawing.Color.DodgerBlue;
            this.chartWriteTime.BarFillSize = 25;
            this.chartWriteTime.Location = new System.Drawing.Point(6, 248);
            this.chartWriteTime.Name = "chartWriteTime";
            this.chartWriteTime.Size = new System.Drawing.Size(134, 24);
            this.chartWriteTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartWriteTime.TabIndex = 174;
            this.chartWriteTime.TextColor = System.Drawing.Color.White;
            // 
            // lbl_Title_Chart_Read
            // 
            this.lbl_Title_Chart_Read.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Title_Chart_Read.AutoSize = true;
            this.lbl_Title_Chart_Read.Location = new System.Drawing.Point(3, 191);
            this.lbl_Title_Chart_Read.Name = "lbl_Title_Chart_Read";
            this.lbl_Title_Chart_Read.Size = new System.Drawing.Size(55, 13);
            this.lbl_Title_Chart_Read.TabIndex = 175;
            this.lbl_Title_Chart_Read.Text = "Read time";
            // 
            // lbl_Title_Chart_Write
            // 
            this.lbl_Title_Chart_Write.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Title_Chart_Write.AutoSize = true;
            this.lbl_Title_Chart_Write.Location = new System.Drawing.Point(3, 234);
            this.lbl_Title_Chart_Write.Name = "lbl_Title_Chart_Write";
            this.lbl_Title_Chart_Write.Size = new System.Drawing.Size(54, 13);
            this.lbl_Title_Chart_Write.TabIndex = 176;
            this.lbl_Title_Chart_Write.Text = "Write time";
            // 
            // lbl_Title_Chart_Disk
            // 
            this.lbl_Title_Chart_Disk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Title_Chart_Disk.AutoSize = true;
            this.lbl_Title_Chart_Disk.Location = new System.Drawing.Point(3, 275);
            this.lbl_Title_Chart_Disk.Name = "lbl_Title_Chart_Disk";
            this.lbl_Title_Chart_Disk.Size = new System.Drawing.Size(50, 13);
            this.lbl_Title_Chart_Disk.TabIndex = 177;
            this.lbl_Title_Chart_Disk.Text = "Disk time";
            // 
            // lbl_Title_Chart_Idle
            // 
            this.lbl_Title_Chart_Idle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Title_Chart_Idle.AutoSize = true;
            this.lbl_Title_Chart_Idle.Location = new System.Drawing.Point(4, 317);
            this.lbl_Title_Chart_Idle.Name = "lbl_Title_Chart_Idle";
            this.lbl_Title_Chart_Idle.Size = new System.Drawing.Size(46, 13);
            this.lbl_Title_Chart_Idle.TabIndex = 178;
            this.lbl_Title_Chart_Idle.Text = "Idle time";
            // 
            // _PhysicalDiskDevicePerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Title_Chart_Idle);
            this.Controls.Add(this.lbl_Title_Chart_Disk);
            this.Controls.Add(this.lbl_Title_Chart_Write);
            this.Controls.Add(this.lbl_Title_Chart_Read);
            this.Controls.Add(this.chartWriteTime);
            this.Controls.Add(this.chartDiskTime);
            this.Controls.Add(this.chartIdleTime);
            this.Controls.Add(this.chartReadTime);
            this.Controls.Add(this.lbl_Free_Value);
            this.Controls.Add(this.lbl_Free);
            this.Controls.Add(this.lbl_Transfer_Value);
            this.Controls.Add(this.lbl_Write_Value);
            this.Controls.Add(this.lbl_Read_Value);
            this.Controls.Add(this.lbl_Transfer);
            this.Controls.Add(this.lbl_Write);
            this.Controls.Add(this.lbl_Read);
            this.Controls.Add(this.chartDiskFree);
            this.Name = "_PhysicalDiskDevicePerformanceControl";
            this.Size = new System.Drawing.Size(153, 360);
            this.Load += new System.EventHandler(this._PhysicalDiskDevicePerformanceControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformComponents.ChartCircle chartDiskFree;
        private System.Windows.Forms.Label lbl_Read;
        private System.Windows.Forms.Label lbl_Write;
        private System.Windows.Forms.Label lbl_Transfer;
        private System.Windows.Forms.Label lbl_Read_Value;
        private System.Windows.Forms.Label lbl_Write_Value;
        private System.Windows.Forms.Label lbl_Transfer_Value;
        private System.Windows.Forms.Label lbl_Free;
        private System.Windows.Forms.Label lbl_Free_Value;
        private WinformComponents.ChartBar chartReadTime;
        private WinformComponents.ChartBar chartIdleTime;
        private WinformComponents.ChartBar chartDiskTime;
        private WinformComponents.ChartBar chartWriteTime;
        private System.Windows.Forms.Label lbl_Title_Chart_Read;
        private System.Windows.Forms.Label lbl_Title_Chart_Write;
        private System.Windows.Forms.Label lbl_Title_Chart_Disk;
        private System.Windows.Forms.Label lbl_Title_Chart_Idle;
    }
}
