namespace DiscoveryLight.UI.Panels.Details
{
    partial class _Details
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
            this.Navigation = new DiscoveryLight.UI.Panels.Details._Navigation();
            this.Container = new DiscoveryLight.UI.Panels.Details._Container();
            this.SuspendLayout();
            // 
            // Navigation
            // 
            this.Navigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.Navigation.Location = new System.Drawing.Point(0, 0);
            this.Navigation.Name = "Navigation";
            this.Navigation.Size = new System.Drawing.Size(630, 33);
            this.Navigation.TabIndex = 0;
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 33);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(630, 327);
            this.Container.TabIndex = 1;
            // 
            // _Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Container);
            this.Controls.Add(this.Navigation);
            this.Name = "_Details";
            this.Size = new System.Drawing.Size(630, 360);
            this.ResumeLayout(false);

        }

        #endregion

        private _Navigation Navigation;
        private _Container Container;
    }
}
