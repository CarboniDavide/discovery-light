using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.UI.DeviceControls.DevicePerformanceControls;

namespace DiscoveryLight.UI.Panels.Devices
{

    public abstract class AbstractDevicePanel: UserControl
    {
        public abstract void StopLoadedTask();
        public abstract void StartAllTask();

    }
    public class DevicePanel: AbstractDevicePanel
    {
        private int panelIndex;
        private Control parentContainer;

        public int PanelIndex { get => panelIndex; set => panelIndex = value; }
        public Control ParentContainer { get => parentContainer; set => parentContainer = value; }

        public override void StopLoadedTask(){
            foreach (Control c in this.Controls)
                if (c.GetType().BaseType.FullName == typeof(DevicePerformanceControl).ToString()){
                    var t = (DevicePerformanceControl)c;
                    t.StopPerformance();
                }
        }

        public override void StartAllTask()
        {
            foreach (Control c in this.Controls)
                if (c.GetType().BaseType.FullName == typeof(DevicePerformanceControl).ToString())
                {
                    var t = (DevicePerformanceControl)c;
                    t.RunPerformance();
                }
        }

        private void onCreate(object sender, EventArgs e)
        {
            StartAllTask();
        }

        private void onRemove(object sender, EventArgs e)
        {
            StopLoadedTask();
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DevicePanel() {
            //get parent container
            this.Disposed += onRemove;
            this.Load += onCreate;
        }
    }
}
