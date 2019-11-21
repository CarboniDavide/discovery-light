namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _MemoryDevicePerformanceControl
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
            this.chartRamUsage = new WinformComponents.ChartCircle();
            this.lbl_CacheUsage = new System.Windows.Forms.Label();
            this.lbl_RamOut = new System.Windows.Forms.Label();
            this.lbl_PageIn = new System.Windows.Forms.Label();
            this.lbl_PageOut = new System.Windows.Forms.Label();
            this.lbl_PageRead = new System.Windows.Forms.Label();
            this.lbl_PageWrite = new System.Windows.Forms.Label();
            this.lbl_PagePersec = new System.Windows.Forms.Label();
            this.lbl_CacheUsageMax = new System.Windows.Forms.Label();
            this.lbl_CacheUsage_Value = new System.Windows.Forms.Label();
            this.lbl_PageWrite_Value = new System.Windows.Forms.Label();
            this.lbl_PageRead_Value = new System.Windows.Forms.Label();
            this.lbl_PageOut_Value = new System.Windows.Forms.Label();
            this.lbl_PageIn_Value = new System.Windows.Forms.Label();
            this.lbl_RamOut_Value = new System.Windows.Forms.Label();
            this.lbl_CacheUsageMax_Value = new System.Windows.Forms.Label();
            this.lbl_PagePersec_Value = new System.Windows.Forms.Label();
            this.lbl_Free = new System.Windows.Forms.Label();
            this.lbl_Free_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chartRamUsage
            // 
            this.chartRamUsage.Activated = true;
            this.chartRamUsage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chartRamUsage.CircleBackColor = System.Drawing.Color.LightGray;
            this.chartRamUsage.CircleFillColor = System.Drawing.Color.MediumOrchid;
            this.chartRamUsage.FillSize = 25;
            this.chartRamUsage.Location = new System.Drawing.Point(41, 18);
            this.chartRamUsage.Name = "chartRamUsage";
            this.chartRamUsage.Size = new System.Drawing.Size(90, 90);
            this.chartRamUsage.TabIndex = 66;
            this.chartRamUsage.TextVisible = true;
            this.chartRamUsage.Thickness = 10;
            // 
            // lbl_CacheUsage
            // 
            this.lbl_CacheUsage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_CacheUsage.AutoSize = true;
            this.lbl_CacheUsage.Location = new System.Drawing.Point(14, 183);
            this.lbl_CacheUsage.Name = "lbl_CacheUsage";
            this.lbl_CacheUsage.Size = new System.Drawing.Size(38, 13);
            this.lbl_CacheUsage.TabIndex = 77;
            this.lbl_CacheUsage.Text = "Cache";
            // 
            // lbl_RamOut
            // 
            this.lbl_RamOut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_RamOut.AutoSize = true;
            this.lbl_RamOut.Location = new System.Drawing.Point(14, 158);
            this.lbl_RamOut.Name = "lbl_RamOut";
            this.lbl_RamOut.Size = new System.Drawing.Size(44, 13);
            this.lbl_RamOut.TabIndex = 78;
            this.lbl_RamOut.Text = "Allowed";
            // 
            // lbl_PageIn
            // 
            this.lbl_PageIn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PageIn.AutoSize = true;
            this.lbl_PageIn.Location = new System.Drawing.Point(14, 233);
            this.lbl_PageIn.Name = "lbl_PageIn";
            this.lbl_PageIn.Size = new System.Drawing.Size(48, 13);
            this.lbl_PageIn.TabIndex = 79;
            this.lbl_PageIn.Text = "Pages in";
            // 
            // lbl_PageOut
            // 
            this.lbl_PageOut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PageOut.AutoSize = true;
            this.lbl_PageOut.Location = new System.Drawing.Point(14, 258);
            this.lbl_PageOut.Name = "lbl_PageOut";
            this.lbl_PageOut.Size = new System.Drawing.Size(55, 13);
            this.lbl_PageOut.TabIndex = 80;
            this.lbl_PageOut.Text = "Pages out";
            // 
            // lbl_PageRead
            // 
            this.lbl_PageRead.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PageRead.AutoSize = true;
            this.lbl_PageRead.Location = new System.Drawing.Point(14, 283);
            this.lbl_PageRead.Name = "lbl_PageRead";
            this.lbl_PageRead.Size = new System.Drawing.Size(61, 13);
            this.lbl_PageRead.TabIndex = 81;
            this.lbl_PageRead.Text = "Pages read";
            // 
            // lbl_PageWrite
            // 
            this.lbl_PageWrite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PageWrite.AutoSize = true;
            this.lbl_PageWrite.Location = new System.Drawing.Point(14, 308);
            this.lbl_PageWrite.Name = "lbl_PageWrite";
            this.lbl_PageWrite.Size = new System.Drawing.Size(62, 13);
            this.lbl_PageWrite.TabIndex = 82;
            this.lbl_PageWrite.Text = "Pages write";
            // 
            // lbl_PagePersec
            // 
            this.lbl_PagePersec.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PagePersec.AutoSize = true;
            this.lbl_PagePersec.Location = new System.Drawing.Point(14, 333);
            this.lbl_PagePersec.Name = "lbl_PagePersec";
            this.lbl_PagePersec.Size = new System.Drawing.Size(56, 13);
            this.lbl_PagePersec.TabIndex = 83;
            this.lbl_PagePersec.Text = "Pages p/s";
            // 
            // lbl_CacheUsageMax
            // 
            this.lbl_CacheUsageMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_CacheUsageMax.AutoSize = true;
            this.lbl_CacheUsageMax.Location = new System.Drawing.Point(14, 208);
            this.lbl_CacheUsageMax.Name = "lbl_CacheUsageMax";
            this.lbl_CacheUsageMax.Size = new System.Drawing.Size(66, 13);
            this.lbl_CacheUsageMax.TabIndex = 84;
            this.lbl_CacheUsageMax.Text = "Cache Peak";
            // 
            // lbl_CacheUsage_Value
            // 
            this.lbl_CacheUsage_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_CacheUsage_Value.Location = new System.Drawing.Point(92, 183);
            this.lbl_CacheUsage_Value.Name = "lbl_CacheUsage_Value";
            this.lbl_CacheUsage_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_CacheUsage_Value.TabIndex = 85;
            this.lbl_CacheUsage_Value.Text = "n/a";
            this.lbl_CacheUsage_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PageWrite_Value
            // 
            this.lbl_PageWrite_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_PageWrite_Value.Location = new System.Drawing.Point(92, 308);
            this.lbl_PageWrite_Value.Name = "lbl_PageWrite_Value";
            this.lbl_PageWrite_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_PageWrite_Value.TabIndex = 86;
            this.lbl_PageWrite_Value.Text = "n/a";
            this.lbl_PageWrite_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PageRead_Value
            // 
            this.lbl_PageRead_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_PageRead_Value.Location = new System.Drawing.Point(92, 283);
            this.lbl_PageRead_Value.Name = "lbl_PageRead_Value";
            this.lbl_PageRead_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_PageRead_Value.TabIndex = 87;
            this.lbl_PageRead_Value.Text = "n/a";
            this.lbl_PageRead_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PageOut_Value
            // 
            this.lbl_PageOut_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_PageOut_Value.Location = new System.Drawing.Point(92, 258);
            this.lbl_PageOut_Value.Name = "lbl_PageOut_Value";
            this.lbl_PageOut_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_PageOut_Value.TabIndex = 88;
            this.lbl_PageOut_Value.Text = "n/a";
            this.lbl_PageOut_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PageIn_Value
            // 
            this.lbl_PageIn_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_PageIn_Value.Location = new System.Drawing.Point(92, 233);
            this.lbl_PageIn_Value.Name = "lbl_PageIn_Value";
            this.lbl_PageIn_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_PageIn_Value.TabIndex = 89;
            this.lbl_PageIn_Value.Text = "n/a";
            this.lbl_PageIn_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_RamOut_Value
            // 
            this.lbl_RamOut_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_RamOut_Value.Location = new System.Drawing.Point(92, 158);
            this.lbl_RamOut_Value.Name = "lbl_RamOut_Value";
            this.lbl_RamOut_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_RamOut_Value.TabIndex = 90;
            this.lbl_RamOut_Value.Text = "n/a";
            this.lbl_RamOut_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CacheUsageMax_Value
            // 
            this.lbl_CacheUsageMax_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_CacheUsageMax_Value.Location = new System.Drawing.Point(92, 208);
            this.lbl_CacheUsageMax_Value.Name = "lbl_CacheUsageMax_Value";
            this.lbl_CacheUsageMax_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_CacheUsageMax_Value.TabIndex = 91;
            this.lbl_CacheUsageMax_Value.Text = "n/a";
            this.lbl_CacheUsageMax_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PagePersec_Value
            // 
            this.lbl_PagePersec_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_PagePersec_Value.Location = new System.Drawing.Point(92, 333);
            this.lbl_PagePersec_Value.Name = "lbl_PagePersec_Value";
            this.lbl_PagePersec_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_PagePersec_Value.TabIndex = 92;
            this.lbl_PagePersec_Value.Text = "n/a";
            this.lbl_PagePersec_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Free
            // 
            this.lbl_Free.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Free.AutoSize = true;
            this.lbl_Free.Location = new System.Drawing.Point(14, 133);
            this.lbl_Free.Name = "lbl_Free";
            this.lbl_Free.Size = new System.Drawing.Size(50, 13);
            this.lbl_Free.TabIndex = 93;
            this.lbl_Free.Text = "Available";
            // 
            // lbl_Free_Value
            // 
            this.lbl_Free_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Free_Value.Location = new System.Drawing.Point(92, 133);
            this.lbl_Free_Value.Name = "lbl_Free_Value";
            this.lbl_Free_Value.Size = new System.Drawing.Size(67, 13);
            this.lbl_Free_Value.TabIndex = 94;
            this.lbl_Free_Value.Text = "n/a";
            this.lbl_Free_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _MemoryDevicePerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Free_Value);
            this.Controls.Add(this.lbl_Free);
            this.Controls.Add(this.lbl_PagePersec_Value);
            this.Controls.Add(this.lbl_CacheUsageMax_Value);
            this.Controls.Add(this.lbl_RamOut_Value);
            this.Controls.Add(this.lbl_PageIn_Value);
            this.Controls.Add(this.lbl_PageOut_Value);
            this.Controls.Add(this.lbl_PageRead_Value);
            this.Controls.Add(this.lbl_PageWrite_Value);
            this.Controls.Add(this.lbl_CacheUsage_Value);
            this.Controls.Add(this.lbl_CacheUsageMax);
            this.Controls.Add(this.lbl_PagePersec);
            this.Controls.Add(this.lbl_PageWrite);
            this.Controls.Add(this.lbl_PageRead);
            this.Controls.Add(this.lbl_PageOut);
            this.Controls.Add(this.lbl_PageIn);
            this.Controls.Add(this.lbl_RamOut);
            this.Controls.Add(this.lbl_CacheUsage);
            this.Controls.Add(this.chartRamUsage);
            this.Name = "_MemoryDevicePerformanceControl";
            this.Size = new System.Drawing.Size(174, 360);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinformComponents.ChartCircle chartRamUsage;
        private System.Windows.Forms.Label lbl_CacheUsage;
        private System.Windows.Forms.Label lbl_RamOut;
        private System.Windows.Forms.Label lbl_PageIn;
        private System.Windows.Forms.Label lbl_PageOut;
        private System.Windows.Forms.Label lbl_PageRead;
        private System.Windows.Forms.Label lbl_PageWrite;
        private System.Windows.Forms.Label lbl_PagePersec;
        private System.Windows.Forms.Label lbl_CacheUsageMax;
        private System.Windows.Forms.Label lbl_CacheUsage_Value;
        private System.Windows.Forms.Label lbl_PageWrite_Value;
        private System.Windows.Forms.Label lbl_PageRead_Value;
        private System.Windows.Forms.Label lbl_PageOut_Value;
        private System.Windows.Forms.Label lbl_PageIn_Value;
        private System.Windows.Forms.Label lbl_RamOut_Value;
        private System.Windows.Forms.Label lbl_CacheUsageMax_Value;
        private System.Windows.Forms.Label lbl_PagePersec_Value;
        private System.Windows.Forms.Label lbl_Free;
        private System.Windows.Forms.Label lbl_Free_Value;
    }
}
