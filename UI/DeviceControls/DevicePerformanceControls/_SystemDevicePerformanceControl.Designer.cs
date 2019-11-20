namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    partial class _SystemDevicePerformanceControl
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
            this.lbl_Process = new System.Windows.Forms.Label();
            this.lbl_Thread = new System.Windows.Forms.Label();
            this.lbl_Process_Value = new System.Windows.Forms.Label();
            this.lbl_Threads_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Process
            // 
            this.lbl_Process.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Process.AutoSize = true;
            this.lbl_Process.Location = new System.Drawing.Point(-1, 4);
            this.lbl_Process.Name = "lbl_Process";
            this.lbl_Process.Size = new System.Drawing.Size(45, 13);
            this.lbl_Process.TabIndex = 72;
            this.lbl_Process.Text = "Process";
            // 
            // lbl_Thread
            // 
            this.lbl_Thread.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Thread.AutoSize = true;
            this.lbl_Thread.Location = new System.Drawing.Point(-1, 29);
            this.lbl_Thread.Name = "lbl_Thread";
            this.lbl_Thread.Size = new System.Drawing.Size(41, 13);
            this.lbl_Thread.TabIndex = 73;
            this.lbl_Thread.Text = "Thread";
            // 
            // lbl_Process_Value
            // 
            this.lbl_Process_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Process_Value.Location = new System.Drawing.Point(54, 4);
            this.lbl_Process_Value.Name = "lbl_Process_Value";
            this.lbl_Process_Value.Size = new System.Drawing.Size(86, 13);
            this.lbl_Process_Value.TabIndex = 76;
            this.lbl_Process_Value.Text = "n/a";
            this.lbl_Process_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Threads_Value
            // 
            this.lbl_Threads_Value.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Threads_Value.Location = new System.Drawing.Point(54, 29);
            this.lbl_Threads_Value.Name = "lbl_Threads_Value";
            this.lbl_Threads_Value.Size = new System.Drawing.Size(86, 13);
            this.lbl_Threads_Value.TabIndex = 77;
            this.lbl_Threads_Value.Text = "n/a";
            this.lbl_Threads_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _SystemDevicePerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbl_Threads_Value);
            this.Controls.Add(this.lbl_Process_Value);
            this.Controls.Add(this.lbl_Thread);
            this.Controls.Add(this.lbl_Process);
            this.Name = "_SystemDevicePerformanceControl";
            this.Size = new System.Drawing.Size(140, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Process;
        private System.Windows.Forms.Label lbl_Thread;
        private System.Windows.Forms.Label lbl_Process_Value;
        private System.Windows.Forms.Label lbl_Threads_Value;
    }
}
