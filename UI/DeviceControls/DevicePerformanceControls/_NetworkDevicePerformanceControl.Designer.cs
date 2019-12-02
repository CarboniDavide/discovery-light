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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_NetworkDevicePerformanceControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_PacketsReceived_Value = new System.Windows.Forms.Label();
            this.lbl_BytesSent_Value = new System.Windows.Forms.Label();
            this.lbl_PacketsSent_Value = new System.Windows.Forms.Label();
            this.lbl_BytesReceived_Value = new System.Windows.Forms.Label();
            this.chartBytesReceived = new WinformComponents.ChartBar();
            this.chartPacketsSent = new WinformComponents.ChartBar();
            this.chartPacketsReceived = new WinformComponents.ChartBar();
            this.chartBytesSent = new WinformComponents.ChartBar();
            this.lbl_Titre_Chart_BytesReceived = new System.Windows.Forms.Label();
            this.lbl_Titre_Chart_BytesSent = new System.Windows.Forms.Label();
            this.lbl_Titre_Chart_PacketsReceived = new System.Windows.Forms.Label();
            this.lbl_Titre_Chart_PacketsSent = new System.Windows.Forms.Label();
            this.pic_Received = new System.Windows.Forms.PictureBox();
            this.pic_Sent = new System.Windows.Forms.PictureBox();
            this.pic_Sep = new System.Windows.Forms.PictureBox();
            this.lbl_TotalReceived = new System.Windows.Forms.Label();
            this.lbl_TotalSent = new System.Windows.Forms.Label();
            this.lbl_TotalSent_Value = new System.Windows.Forms.Label();
            this.lbl_TotalReceived_Value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Received)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Sent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Sep)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_PacketsReceived_Value
            // 
            resources.ApplyResources(this.lbl_PacketsReceived_Value, "lbl_PacketsReceived_Value");
            this.lbl_PacketsReceived_Value.Name = "lbl_PacketsReceived_Value";
            // 
            // lbl_BytesSent_Value
            // 
            resources.ApplyResources(this.lbl_BytesSent_Value, "lbl_BytesSent_Value");
            this.lbl_BytesSent_Value.Name = "lbl_BytesSent_Value";
            // 
            // lbl_PacketsSent_Value
            // 
            resources.ApplyResources(this.lbl_PacketsSent_Value, "lbl_PacketsSent_Value");
            this.lbl_PacketsSent_Value.Name = "lbl_PacketsSent_Value";
            // 
            // lbl_BytesReceived_Value
            // 
            resources.ApplyResources(this.lbl_BytesReceived_Value, "lbl_BytesReceived_Value");
            this.lbl_BytesReceived_Value.Name = "lbl_BytesReceived_Value";
            // 
            // chartBytesReceived
            // 
            resources.ApplyResources(this.chartBytesReceived, "chartBytesReceived");
            this.chartBytesReceived.Activated = true;
            this.chartBytesReceived.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartBytesReceived.BarBackColor = System.Drawing.Color.LightGray;
            this.chartBytesReceived.BarFillColor = System.Drawing.Color.LightSalmon;
            this.chartBytesReceived.BarFillSize = 25;
            this.chartBytesReceived.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartBytesReceived.CustomText = null;
            this.chartBytesReceived.Name = "chartBytesReceived";
            this.chartBytesReceived.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartBytesReceived.TextColor = System.Drawing.Color.White;
            this.chartBytesReceived.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chartPacketsSent
            // 
            resources.ApplyResources(this.chartPacketsSent, "chartPacketsSent");
            this.chartPacketsSent.Activated = true;
            this.chartPacketsSent.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartPacketsSent.BarBackColor = System.Drawing.Color.LightGray;
            this.chartPacketsSent.BarFillColor = System.Drawing.Color.LightSeaGreen;
            this.chartPacketsSent.BarFillSize = 25;
            this.chartPacketsSent.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartPacketsSent.CustomText = null;
            this.chartPacketsSent.Name = "chartPacketsSent";
            this.chartPacketsSent.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartPacketsSent.TextColor = System.Drawing.Color.White;
            this.chartPacketsSent.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chartPacketsReceived
            // 
            resources.ApplyResources(this.chartPacketsReceived, "chartPacketsReceived");
            this.chartPacketsReceived.Activated = true;
            this.chartPacketsReceived.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartPacketsReceived.BarBackColor = System.Drawing.Color.LightGray;
            this.chartPacketsReceived.BarFillColor = System.Drawing.Color.DodgerBlue;
            this.chartPacketsReceived.BarFillSize = 25;
            this.chartPacketsReceived.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartPacketsReceived.CustomText = null;
            this.chartPacketsReceived.Name = "chartPacketsReceived";
            this.chartPacketsReceived.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartPacketsReceived.TextColor = System.Drawing.Color.White;
            this.chartPacketsReceived.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chartBytesSent
            // 
            resources.ApplyResources(this.chartBytesSent, "chartBytesSent");
            this.chartBytesSent.Activated = true;
            this.chartBytesSent.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.chartBytesSent.BarBackColor = System.Drawing.Color.LightGray;
            this.chartBytesSent.BarFillColor = System.Drawing.Color.DarkKhaki;
            this.chartBytesSent.BarFillSize = 25;
            this.chartBytesSent.ChartText = WinformComponents.ChartBar.ContentType.FillSize;
            this.chartBytesSent.CustomText = null;
            this.chartBytesSent.Name = "chartBytesSent";
            this.chartBytesSent.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartBytesSent.TextColor = System.Drawing.Color.White;
            this.chartBytesSent.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lbl_Titre_Chart_BytesReceived
            // 
            resources.ApplyResources(this.lbl_Titre_Chart_BytesReceived, "lbl_Titre_Chart_BytesReceived");
            this.lbl_Titre_Chart_BytesReceived.Name = "lbl_Titre_Chart_BytesReceived";
            // 
            // lbl_Titre_Chart_BytesSent
            // 
            resources.ApplyResources(this.lbl_Titre_Chart_BytesSent, "lbl_Titre_Chart_BytesSent");
            this.lbl_Titre_Chart_BytesSent.Name = "lbl_Titre_Chart_BytesSent";
            // 
            // lbl_Titre_Chart_PacketsReceived
            // 
            resources.ApplyResources(this.lbl_Titre_Chart_PacketsReceived, "lbl_Titre_Chart_PacketsReceived");
            this.lbl_Titre_Chart_PacketsReceived.Name = "lbl_Titre_Chart_PacketsReceived";
            // 
            // lbl_Titre_Chart_PacketsSent
            // 
            resources.ApplyResources(this.lbl_Titre_Chart_PacketsSent, "lbl_Titre_Chart_PacketsSent");
            this.lbl_Titre_Chart_PacketsSent.Name = "lbl_Titre_Chart_PacketsSent";
            // 
            // pic_Received
            // 
            resources.ApplyResources(this.pic_Received, "pic_Received");
            this.pic_Received.BackColor = System.Drawing.Color.LightGreen;
            this.pic_Received.BackgroundImage = global::DiscoveryLight.Properties.Resources.Down;
            this.pic_Received.Name = "pic_Received";
            this.pic_Received.TabStop = false;
            // 
            // pic_Sent
            // 
            resources.ApplyResources(this.pic_Sent, "pic_Sent");
            this.pic_Sent.BackColor = System.Drawing.Color.Tomato;
            this.pic_Sent.BackgroundImage = global::DiscoveryLight.Properties.Resources.Up;
            this.pic_Sent.Name = "pic_Sent";
            this.pic_Sent.TabStop = false;
            // 
            // pic_Sep
            // 
            resources.ApplyResources(this.pic_Sep, "pic_Sep");
            this.pic_Sep.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Sep.Name = "pic_Sep";
            this.pic_Sep.TabStop = false;
            // 
            // lbl_TotalReceived
            // 
            resources.ApplyResources(this.lbl_TotalReceived, "lbl_TotalReceived");
            this.lbl_TotalReceived.Name = "lbl_TotalReceived";
            // 
            // lbl_TotalSent
            // 
            resources.ApplyResources(this.lbl_TotalSent, "lbl_TotalSent");
            this.lbl_TotalSent.Name = "lbl_TotalSent";
            // 
            // lbl_TotalSent_Value
            // 
            resources.ApplyResources(this.lbl_TotalSent_Value, "lbl_TotalSent_Value");
            this.lbl_TotalSent_Value.Name = "lbl_TotalSent_Value";
            // 
            // lbl_TotalReceived_Value
            // 
            resources.ApplyResources(this.lbl_TotalReceived_Value, "lbl_TotalReceived_Value");
            this.lbl_TotalReceived_Value.Name = "lbl_TotalReceived_Value";
            // 
            // _NetworkDevicePerformanceControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_TotalReceived_Value);
            this.Controls.Add(this.lbl_TotalSent_Value);
            this.Controls.Add(this.lbl_TotalSent);
            this.Controls.Add(this.lbl_TotalReceived);
            this.Controls.Add(this.pic_Received);
            this.Controls.Add(this.pic_Sent);
            this.Controls.Add(this.pic_Sep);
            this.Controls.Add(this.lbl_Titre_Chart_PacketsSent);
            this.Controls.Add(this.lbl_Titre_Chart_PacketsReceived);
            this.Controls.Add(this.lbl_Titre_Chart_BytesSent);
            this.Controls.Add(this.lbl_Titre_Chart_BytesReceived);
            this.Controls.Add(this.chartBytesSent);
            this.Controls.Add(this.chartPacketsReceived);
            this.Controls.Add(this.chartPacketsSent);
            this.Controls.Add(this.chartBytesReceived);
            this.Controls.Add(this.lbl_BytesReceived_Value);
            this.Controls.Add(this.lbl_PacketsSent_Value);
            this.Controls.Add(this.lbl_BytesSent_Value);
            this.Controls.Add(this.lbl_PacketsReceived_Value);
            this.Name = "_NetworkDevicePerformanceControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
            ((System.ComponentModel.ISupportInitialize)(this.pic_Received)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Sent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Sep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_PacketsReceived_Value;
        private System.Windows.Forms.Label lbl_BytesSent_Value;
        private System.Windows.Forms.Label lbl_PacketsSent_Value;
        private System.Windows.Forms.Label lbl_BytesReceived_Value;
        private WinformComponents.ChartBar chartBytesReceived;
        private WinformComponents.ChartBar chartPacketsSent;
        private WinformComponents.ChartBar chartPacketsReceived;
        private WinformComponents.ChartBar chartBytesSent;
        private System.Windows.Forms.Label lbl_Titre_Chart_BytesReceived;
        private System.Windows.Forms.Label lbl_Titre_Chart_BytesSent;
        private System.Windows.Forms.Label lbl_Titre_Chart_PacketsReceived;
        private System.Windows.Forms.Label lbl_Titre_Chart_PacketsSent;
        private System.Windows.Forms.PictureBox pic_Sep;
        private System.Windows.Forms.PictureBox pic_Sent;
        private System.Windows.Forms.PictureBox pic_Received;
        private System.Windows.Forms.Label lbl_TotalReceived;
        private System.Windows.Forms.Label lbl_TotalSent;
        private System.Windows.Forms.Label lbl_TotalSent_Value;
        private System.Windows.Forms.Label lbl_TotalReceived_Value;
    }
}
