namespace DiscoveryLight.UI.Panels.Slider
{
    partial class _Slider
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
            this.MoveOBject = new WinformComponents.MoveOBject();
            this.SuspendLayout();
            // 
            // MoveOBject
            // 
            this.MoveOBject.Interval = 10;
            this.MoveOBject.IsOperating = false;
            this.MoveOBject.Object = this;
            this.MoveOBject.Type = WinformComponents.MoveOBject.TYPE.Vertical;
            // 
            // _Slider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "_Slider";
            this.Size = new System.Drawing.Size(630, 360);
            this.Load += new System.EventHandler(this._Slider_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformComponents.MoveOBject MoveOBject;
    }
}
