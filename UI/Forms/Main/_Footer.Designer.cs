namespace DiscoveryLight.UI.Forms.Main
{
    partial class _Footer
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
            this.ChartBar = new WinformComponents.ChartBar();
            this.SuspendLayout();
            // 
            // ChartBar
            // 
            this.ChartBar.Activated = true;
            this.ChartBar.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ChartBar.BarBackColor = System.Drawing.Color.Transparent;
            this.ChartBar.BarFillColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ChartBar.BarFillSize = 0;
            this.ChartBar.ChartText = WinformComponents.ChartBar.ContentType.CustomText;
            this.ChartBar.CustomText = "N/A";
            this.ChartBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartBar.Location = new System.Drawing.Point(0, 0);
            this.ChartBar.Name = "ChartBar";
            this.ChartBar.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.ChartBar.Size = new System.Drawing.Size(560, 40);
            this.ChartBar.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.ChartBar.TabIndex = 0;
            this.ChartBar.TextColor = System.Drawing.SystemColors.WindowFrame;
            this.ChartBar.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // _Footer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.ChartBar);
            this.Name = "_Footer";
            this.Size = new System.Drawing.Size(560, 40);
            this.ResumeLayout(false);

        }

        #endregion

        public WinformComponents.ChartBar ChartBar;
    }
}
