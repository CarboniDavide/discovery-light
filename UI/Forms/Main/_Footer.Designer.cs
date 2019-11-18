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
            this.chartBar = new WinformComponents.ChartBar();
            this.SuspendLayout();
            // 
            // chartBar
            // 
            this.chartBar.Activated = true;
            this.chartBar.Alignment = System.Drawing.ContentAlignment.MiddleRight;
            this.chartBar.BarBackColor = System.Drawing.Color.Transparent;
            this.chartBar.BarFillColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chartBar.BarFillSize = 0;
            this.chartBar.ChartText = WinformComponents.ChartBar.ContentType.CustomText;
            this.chartBar.CustomText = "N/A";
            this.chartBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBar.Location = new System.Drawing.Point(0, 0);
            this.chartBar.Name = "chartBar";
            this.chartBar.Padding = new System.Windows.Forms.Padding(10);
            this.chartBar.Size = new System.Drawing.Size(560, 40);
            this.chartBar.Style = WinformComponents.ChartBar.STYLE.Horizontal;
            this.chartBar.TabIndex = 0;
            this.chartBar.TextColor = System.Drawing.Color.Crimson;
            this.chartBar.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // _Footer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.chartBar);
            this.Name = "_Footer";
            this.Size = new System.Drawing.Size(560, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformComponents.ChartBar chartBar;
    }
}
