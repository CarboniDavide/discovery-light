namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _NetworkDevicePerformanceControl
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
            this.lbl_PacketsReceived = new System.Windows.Forms.Label();
            this.lbl_BytesSent = new System.Windows.Forms.Label();
            this.lbl_PacketsSent = new System.Windows.Forms.Label();
            this.lbl_PacketsReceived_Value = new System.Windows.Forms.Label();
            this.lbl_BytesSent_Value = new System.Windows.Forms.Label();
            this.lbl_PacketsSent_Value = new System.Windows.Forms.Label();
            this.lbl_BytesReceived = new System.Windows.Forms.Label();
            this.lbl_BytesReceived_Value = new System.Windows.Forms.Label();
            this.chartBytesReceived = new WinformComponents.ChartBar();
            this.chartPacketsSent = new WinformComponents.ChartBar();
            this.chartPacketsReceived = new WinformComponents.ChartBar();
            this.chartBytesSent = new WinformComponents.ChartBar();
            this.lbl_Titre_Chart_BytesReceived = new System.Windows.Forms.Label();
            this.lbl_Titre_Chart_BytesSent = new System.Windows.Forms.Label();
            this.lbl_Titre_Chart_PacketsReceived = new System.Windows.Forms.Label();
            this.lbl_Titre_Chart_PacketsSent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_PacketsReceived
            // 
            this.lbl_PacketsReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PacketsReceived.AutoSize = true;
            this.lbl_PacketsReceived.Location = new System.Drawing.Point(6, 85);
            this.lbl_PacketsReceived.Name = "lbl_PacketsReceived";
            this.lbl_PacketsReceived.Size = new System.Drawing.Size(103, 13);
            this.lbl_PacketsReceived.TabIndex = 182;
            this.lbl_PacketsReceived.Text = "Packets received /s";
            // 
            // lbl_BytesSent
            // 
            this.lbl_BytesSent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_BytesSent.AutoSize = true;
            this.lbl_BytesSent.Location = new System.Drawing.Point(6, 45);
            this.lbl_BytesSent.Name = "lbl_BytesSent";
            this.lbl_BytesSent.Size = new System.Drawing.Size(66, 13);
            this.lbl_BytesSent.TabIndex = 183;
            this.lbl_BytesSent.Text = "Bites sent /s";
            // 
            // lbl_PacketsSent
            // 
            this.lbl_PacketsSent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PacketsSent.AutoSize = true;
            this.lbl_PacketsSent.Location = new System.Drawing.Point(6, 125);
            this.lbl_PacketsSent.Name = "lbl_PacketsSent";
            this.lbl_PacketsSent.Size = new System.Drawing.Size(82, 13);
            this.lbl_PacketsSent.TabIndex = 184;
            this.lbl_PacketsSent.Text = "Packets sent /s";
            // 
            // lbl_PacketsReceived_Value
            // 
            this.lbl_PacketsReceived_Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PacketsReceived_Value.AutoSize = true;
            this.lbl_PacketsReceived_Value.Location = new System.Drawing.Point(6, 100);
            this.lbl_PacketsReceived_Value.Name = "lbl_PacketsReceived_Value";
            this.lbl_PacketsReceived_Value.Size = new System.Drawing.Size(27, 13);
            this.lbl_PacketsReceived_Value.TabIndex = 185;
            this.lbl_PacketsReceived_Value.Text = "N/A";
            // 
            // lbl_BytesSent_Value
            // 
            this.lbl_BytesSent_Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_BytesSent_Value.AutoSize = true;
            this.lbl_BytesSent_Value.Location = new System.Drawing.Point(6, 60);
            this.lbl_BytesSent_Value.Name = "lbl_BytesSent_Value";
            this.lbl_BytesSent_Value.Size = new System.Drawing.Size(27, 13);
            this.lbl_BytesSent_Value.TabIndex = 186;
            this.lbl_BytesSent_Value.Text = "N/A";
            // 
            // lbl_PacketsSent_Value
            // 
            this.lbl_PacketsSent_Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_PacketsSent_Value.AutoSize = true;
            this.lbl_PacketsSent_Value.Location = new System.Drawing.Point(6, 140);
            this.lbl_PacketsSent_Value.Name = "lbl_PacketsSent_Value";
            this.lbl_PacketsSent_Value.Size = new System.Drawing.Size(27, 13);
            this.lbl_PacketsSent_Value.TabIndex = 187;
            this.lbl_PacketsSent_Value.Text = "N/A";
            // 
            // lbl_BytesReceived
            // 
            this.lbl_BytesReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_BytesReceived.AutoSize = true;
            this.lbl_BytesReceived.Location = new System.Drawing.Point(6, 5);
            this.lbl_BytesReceived.Name = "lbl_BytesReceived";
            this.lbl_BytesReceived.Size = new System.Drawing.Size(85, 13);
            this.lbl_BytesReceived.TabIndex = 188;
            this.lbl_BytesReceived.Text = "Byte received /s";
            // 
            // lbl_BytesReceived_Value
            // 
            this.lbl_BytesReceived_Value.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_BytesReceived_Value.AutoSize = true;
            this.lbl_BytesReceived_Value.Location = new System.Drawing.Point(6, 20);
            this.lbl_BytesReceived_Value.Name = "lbl_BytesReceived_Value";
            this.lbl_BytesReceived_Value.Size = new System.Drawing.Size(27, 13);
            this.lbl_BytesReceived_Value.TabIndex = 189;
            this.lbl_BytesReceived_Value.Text = "N/A";
            // 
            // chartBytesReceived
            // 
            this.chartBytesReceived.Activated = true;
            this.chartBytesReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartBytesReceived.BarBackColor = System.Drawing.Color.LightGray;
            this.chartBytesReceived.BarFillColor = System.Drawing.Color.LightSalmon;
            this.chartBytesReceived.BarFillSize = 25;
            this.chartBytesReceived.Location = new System.Drawing.Point(6, 181);
            this.chartBytesReceived.Name = "chartBytesReceived";
            this.chartBytesReceived.Size = new System.Drawing.Size(105, 24);
            this.chartBytesReceived.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartBytesReceived.TabIndex = 217;
            this.chartBytesReceived.TextColor = System.Drawing.Color.White;
            this.chartBytesReceived.TextVisible = true;
            // 
            // chartPacketsSent
            // 
            this.chartPacketsSent.Activated = true;
            this.chartPacketsSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPacketsSent.BarBackColor = System.Drawing.Color.LightGray;
            this.chartPacketsSent.BarFillColor = System.Drawing.Color.LightSeaGreen;
            this.chartPacketsSent.BarFillSize = 25;
            this.chartPacketsSent.Location = new System.Drawing.Point(6, 309);
            this.chartPacketsSent.Name = "chartPacketsSent";
            this.chartPacketsSent.Size = new System.Drawing.Size(105, 24);
            this.chartPacketsSent.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartPacketsSent.TabIndex = 219;
            this.chartPacketsSent.TextColor = System.Drawing.Color.White;
            this.chartPacketsSent.TextVisible = true;
            // 
            // chartPacketsReceived
            // 
            this.chartPacketsReceived.Activated = true;
            this.chartPacketsReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPacketsReceived.BarBackColor = System.Drawing.Color.LightGray;
            this.chartPacketsReceived.BarFillColor = System.Drawing.Color.DodgerBlue;
            this.chartPacketsReceived.BarFillSize = 25;
            this.chartPacketsReceived.Location = new System.Drawing.Point(6, 266);
            this.chartPacketsReceived.Name = "chartPacketsReceived";
            this.chartPacketsReceived.Size = new System.Drawing.Size(105, 24);
            this.chartPacketsReceived.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartPacketsReceived.TabIndex = 220;
            this.chartPacketsReceived.TextColor = System.Drawing.Color.White;
            this.chartPacketsReceived.TextVisible = true;
            // 
            // chartBytesSent
            // 
            this.chartBytesSent.Activated = true;
            this.chartBytesSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chartBytesSent.BarBackColor = System.Drawing.Color.LightGray;
            this.chartBytesSent.BarFillColor = System.Drawing.Color.DarkKhaki;
            this.chartBytesSent.BarFillSize = 25;
            this.chartBytesSent.Location = new System.Drawing.Point(6, 224);
            this.chartBytesSent.Name = "chartBytesSent";
            this.chartBytesSent.Size = new System.Drawing.Size(105, 24);
            this.chartBytesSent.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartBytesSent.TabIndex = 221;
            this.chartBytesSent.TextColor = System.Drawing.Color.White;
            this.chartBytesSent.TextVisible = true;
            // 
            // lbl_Titre_Chart_BytesReceived
            // 
            this.lbl_Titre_Chart_BytesReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Titre_Chart_BytesReceived.AutoSize = true;
            this.lbl_Titre_Chart_BytesReceived.Location = new System.Drawing.Point(6, 165);
            this.lbl_Titre_Chart_BytesReceived.Name = "lbl_Titre_Chart_BytesReceived";
            this.lbl_Titre_Chart_BytesReceived.Size = new System.Drawing.Size(72, 13);
            this.lbl_Titre_Chart_BytesReceived.TabIndex = 222;
            this.lbl_Titre_Chart_BytesReceived.Text = "Byte received";
            // 
            // lbl_Titre_Chart_BytesSent
            // 
            this.lbl_Titre_Chart_BytesSent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Titre_Chart_BytesSent.AutoSize = true;
            this.lbl_Titre_Chart_BytesSent.Location = new System.Drawing.Point(6, 208);
            this.lbl_Titre_Chart_BytesSent.Name = "lbl_Titre_Chart_BytesSent";
            this.lbl_Titre_Chart_BytesSent.Size = new System.Drawing.Size(56, 13);
            this.lbl_Titre_Chart_BytesSent.TabIndex = 223;
            this.lbl_Titre_Chart_BytesSent.Text = "Bytes sent";
            // 
            // lbl_Titre_Chart_PacketsReceived
            // 
            this.lbl_Titre_Chart_PacketsReceived.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Titre_Chart_PacketsReceived.AutoSize = true;
            this.lbl_Titre_Chart_PacketsReceived.Location = new System.Drawing.Point(6, 252);
            this.lbl_Titre_Chart_PacketsReceived.Name = "lbl_Titre_Chart_PacketsReceived";
            this.lbl_Titre_Chart_PacketsReceived.Size = new System.Drawing.Size(90, 13);
            this.lbl_Titre_Chart_PacketsReceived.TabIndex = 224;
            this.lbl_Titre_Chart_PacketsReceived.Text = "Packets received";
            // 
            // lbl_Titre_Chart_PacketsSent
            // 
            this.lbl_Titre_Chart_PacketsSent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Titre_Chart_PacketsSent.AutoSize = true;
            this.lbl_Titre_Chart_PacketsSent.Location = new System.Drawing.Point(6, 294);
            this.lbl_Titre_Chart_PacketsSent.Name = "lbl_Titre_Chart_PacketsSent";
            this.lbl_Titre_Chart_PacketsSent.Size = new System.Drawing.Size(69, 13);
            this.lbl_Titre_Chart_PacketsSent.TabIndex = 225;
            this.lbl_Titre_Chart_PacketsSent.Text = "Packets sent";
            // 
            // _NetworkDevicePerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Titre_Chart_PacketsSent);
            this.Controls.Add(this.lbl_Titre_Chart_PacketsReceived);
            this.Controls.Add(this.lbl_Titre_Chart_BytesSent);
            this.Controls.Add(this.lbl_Titre_Chart_BytesReceived);
            this.Controls.Add(this.chartBytesSent);
            this.Controls.Add(this.chartPacketsReceived);
            this.Controls.Add(this.chartPacketsSent);
            this.Controls.Add(this.chartBytesReceived);
            this.Controls.Add(this.lbl_BytesReceived_Value);
            this.Controls.Add(this.lbl_BytesReceived);
            this.Controls.Add(this.lbl_PacketsSent_Value);
            this.Controls.Add(this.lbl_BytesSent_Value);
            this.Controls.Add(this.lbl_PacketsReceived_Value);
            this.Controls.Add(this.lbl_PacketsSent);
            this.Controls.Add(this.lbl_BytesSent);
            this.Controls.Add(this.lbl_PacketsReceived);
            this.Name = "_NetworkDevicePerformanceControl";
            this.Size = new System.Drawing.Size(118, 338);
            this.Load += new System.EventHandler(this._NetworkDevicePerformanceControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_PacketsReceived;
        private System.Windows.Forms.Label lbl_BytesSent;
        private System.Windows.Forms.Label lbl_PacketsSent;
        private System.Windows.Forms.Label lbl_PacketsReceived_Value;
        private System.Windows.Forms.Label lbl_BytesSent_Value;
        private System.Windows.Forms.Label lbl_PacketsSent_Value;
        private System.Windows.Forms.Label lbl_BytesReceived;
        private System.Windows.Forms.Label lbl_BytesReceived_Value;
        private WinformComponents.ChartBar chartBytesReceived;
        private WinformComponents.ChartBar chartPacketsSent;
        private WinformComponents.ChartBar chartPacketsReceived;
        private WinformComponents.ChartBar chartBytesSent;
        private System.Windows.Forms.Label lbl_Titre_Chart_BytesReceived;
        private System.Windows.Forms.Label lbl_Titre_Chart_BytesSent;
        private System.Windows.Forms.Label lbl_Titre_Chart_PacketsReceived;
        private System.Windows.Forms.Label lbl_Titre_Chart_PacketsSent;
    }
}
