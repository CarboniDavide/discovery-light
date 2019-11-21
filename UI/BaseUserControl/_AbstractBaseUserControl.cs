﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscoveryLight.UI.BaseUserControl
{
    public abstract class _AbstractBaseUserControl : UserControl
    {
        public abstract void onLoad(object sender, EventArgs e);
        public abstract void onDispose(object sender, EventArgs e);
    }

    public class _BaseUserControl:_AbstractBaseUserControl
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
