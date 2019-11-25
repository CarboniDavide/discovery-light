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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_SystemDevicePerformanceControl));
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.lbl_Process = new System.Windows.Forms.Label();
            this.lbl_Thread = new System.Windows.Forms.Label();
            this.lbl_Process_Value = new System.Windows.Forms.Label();
            this.lbl_Threads_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Process
            // 
            resources.ApplyResources(this.lbl_Process, "lbl_Process");
            this.lbl_Process.Name = "lbl_Process";
            // 
            // lbl_Thread
            // 
            resources.ApplyResources(this.lbl_Thread, "lbl_Thread");
            this.lbl_Thread.Name = "lbl_Thread";
            // 
            // lbl_Process_Value
            // 
            resources.ApplyResources(this.lbl_Process_Value, "lbl_Process_Value");
            this.lbl_Process_Value.Name = "lbl_Process_Value";
            // 
            // lbl_Threads_Value
            // 
            resources.ApplyResources(this.lbl_Threads_Value, "lbl_Threads_Value");
            this.lbl_Threads_Value.Name = "lbl_Threads_Value";
            // 
            // _SystemDevicePerformanceControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbl_Threads_Value);
            this.Controls.Add(this.lbl_Process_Value);
            this.Controls.Add(this.lbl_Thread);
            this.Controls.Add(this.lbl_Process);
            this.Name = "_SystemDevicePerformanceControl";
            this.Period = System.TimeSpan.Parse("00:00:00.5000000");
            this.TokenSource = cancellationTokenSource1;
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
