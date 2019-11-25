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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_PhysicalDiskDevicePerformanceControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
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
            resources.ApplyResources(this.chartDiskFree, "chartDiskFree");
            this.chartDiskFree.Activated = true;
            this.chartDiskFree.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartDiskFree.CircleFillColor = System.Drawing.Color.MediumSeaGreen;
            this.chartDiskFree.FillSize = 25;
            this.chartDiskFree.Name = "chartDiskFree";
            this.chartDiskFree.TextVisible = true;
            this.chartDiskFree.Thickness = 10;
            // 
            // lbl_Read
            // 
            resources.ApplyResources(this.lbl_Read, "lbl_Read");
            this.lbl_Read.Name = "lbl_Read";
            // 
            // lbl_Write
            // 
            resources.ApplyResources(this.lbl_Write, "lbl_Write");
            this.lbl_Write.Name = "lbl_Write";
            // 
            // lbl_Transfer
            // 
            resources.ApplyResources(this.lbl_Transfer, "lbl_Transfer");
            this.lbl_Transfer.Name = "lbl_Transfer";
            // 
            // lbl_Read_Value
            // 
            resources.ApplyResources(this.lbl_Read_Value, "lbl_Read_Value");
            this.lbl_Read_Value.Name = "lbl_Read_Value";
            // 
            // lbl_Write_Value
            // 
            resources.ApplyResources(this.lbl_Write_Value, "lbl_Write_Value");
            this.lbl_Write_Value.Name = "lbl_Write_Value";
            // 
            // lbl_Transfer_Value
            // 
            resources.ApplyResources(this.lbl_Transfer_Value, "lbl_Transfer_Value");
            this.lbl_Transfer_Value.Name = "lbl_Transfer_Value";
            // 
            // lbl_Free
            // 
            resources.ApplyResources(this.lbl_Free, "lbl_Free");
            this.lbl_Free.Name = "lbl_Free";
            // 
            // lbl_Free_Value
            // 
            resources.ApplyResources(this.lbl_Free_Value, "lbl_Free_Value");
            this.lbl_Free_Value.Name = "lbl_Free_Value";
            // 
            // chartReadTime
            // 
            resources.ApplyResources(this.chartReadTime, "chartReadTime");
            this.chartReadTime.Activated = true;
            this.chartReadTime.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartReadTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartReadTime.BarFillColor = System.Drawing.Color.LightSalmon;
            this.chartReadTime.BarFillSize = 25;
            this.chartReadTime.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartReadTime.CustomText = null;
            this.chartReadTime.Name = "chartReadTime";
            this.chartReadTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartReadTime.TextColor = System.Drawing.Color.White;
            this.chartReadTime.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chartIdleTime
            // 
            resources.ApplyResources(this.chartIdleTime, "chartIdleTime");
            this.chartIdleTime.Activated = true;
            this.chartIdleTime.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartIdleTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartIdleTime.BarFillColor = System.Drawing.Color.LightSeaGreen;
            this.chartIdleTime.BarFillSize = 25;
            this.chartIdleTime.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartIdleTime.CustomText = null;
            this.chartIdleTime.Name = "chartIdleTime";
            this.chartIdleTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartIdleTime.TextColor = System.Drawing.Color.White;
            this.chartIdleTime.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chartDiskTime
            // 
            resources.ApplyResources(this.chartDiskTime, "chartDiskTime");
            this.chartDiskTime.Activated = true;
            this.chartDiskTime.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartDiskTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartDiskTime.BarFillColor = System.Drawing.Color.DarkSeaGreen;
            this.chartDiskTime.BarFillSize = 25;
            this.chartDiskTime.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartDiskTime.CustomText = null;
            this.chartDiskTime.Name = "chartDiskTime";
            this.chartDiskTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartDiskTime.TextColor = System.Drawing.Color.White;
            this.chartDiskTime.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chartWriteTime
            // 
            resources.ApplyResources(this.chartWriteTime, "chartWriteTime");
            this.chartWriteTime.Activated = true;
            this.chartWriteTime.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartWriteTime.BarBackColor = System.Drawing.Color.LightGray;
            this.chartWriteTime.BarFillColor = System.Drawing.Color.DodgerBlue;
            this.chartWriteTime.BarFillSize = 25;
            this.chartWriteTime.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartWriteTime.CustomText = null;
            this.chartWriteTime.Name = "chartWriteTime";
            this.chartWriteTime.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartWriteTime.TextColor = System.Drawing.Color.White;
            this.chartWriteTime.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lbl_Title_Chart_Read
            // 
            resources.ApplyResources(this.lbl_Title_Chart_Read, "lbl_Title_Chart_Read");
            this.lbl_Title_Chart_Read.Name = "lbl_Title_Chart_Read";
            // 
            // lbl_Title_Chart_Write
            // 
            resources.ApplyResources(this.lbl_Title_Chart_Write, "lbl_Title_Chart_Write");
            this.lbl_Title_Chart_Write.Name = "lbl_Title_Chart_Write";
            // 
            // lbl_Title_Chart_Disk
            // 
            resources.ApplyResources(this.lbl_Title_Chart_Disk, "lbl_Title_Chart_Disk");
            this.lbl_Title_Chart_Disk.Name = "lbl_Title_Chart_Disk";
            // 
            // lbl_Title_Chart_Idle
            // 
            resources.ApplyResources(this.lbl_Title_Chart_Idle, "lbl_Title_Chart_Idle");
            this.lbl_Title_Chart_Idle.Name = "lbl_Title_Chart_Idle";
            // 
            // _PhysicalDiskDevicePerformanceControl
            // 
            resources.ApplyResources(this, "$this");
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
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
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
