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
            this.SubNavigation = new DiscoveryLight.UI.Panels.Details._SubNavigation();
            this.SubPanelContainer = new DiscoveryLight.UI.Panels.Details._SubPanelContainer();
            this.SuspendLayout();
            // 
            // SubNavigation
            // 
            this.SubNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubNavigation.Location = new System.Drawing.Point(0, 0);
            this.SubNavigation.Name = "SubNavigation";
            this.SubNavigation.Size = new System.Drawing.Size(630, 33);
            this.SubNavigation.TabIndex = 0;
            // 
            // SubPanelContainer
            // 
            this.SubPanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubPanelContainer.Location = new System.Drawing.Point(0, 33);
            this.SubPanelContainer.Name = "SubPanelContainer";
            this.SubPanelContainer.Size = new System.Drawing.Size(630, 327);
            this.SubPanelContainer.TabIndex = 1;
            // 
            // _Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SubPanelContainer);
            this.Controls.Add(this.SubNavigation);
            this.Name = "_Details";
            this.Size = new System.Drawing.Size(630, 360);
            this.ResumeLayout(false);

        }

        #endregion

        private _SubNavigation SubNavigation;
        private _SubPanelContainer SubPanelContainer;
    }
}
