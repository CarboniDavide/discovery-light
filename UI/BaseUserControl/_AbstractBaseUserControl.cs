using System;
using System.Windows.Forms;

namespace DiscoveryLight.UI.BaseUserControl
{
    /// <summary>
    /// Main project class. Define what appened when control is loaded and closed
    /// </summary>
    public abstract class _AbstractBaseUserControl : UserControl
    {
        public abstract void onLoad(object sender, EventArgs e);
        public abstract void onDispose(object sender, EventArgs e);
    }

    public class _BaseUserControl : _AbstractBaseUserControl
    {
        public override void onDispose(object sender, EventArgs e) { }

        public override void onLoad(object sender, EventArgs e) { }

        public _BaseUserControl()
        {
            this.Load += onLoad;
            this.Disposed += onDispose;
        }

    }
}
