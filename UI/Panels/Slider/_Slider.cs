using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.UI.Panels.Devices;

namespace DiscoveryLight.UI.Panels.Slider
{
    public partial class _Slider : UserControl
    {
        public _Slider()
        {
            InitializeComponent();
        }

        DevicePanel CurrentPanel;
        DevicePanel NewPanel;
        Action MoveAction;

        public void AddSlide(DevicePanel panel)
        {
            NewPanel = panel;
            if (this.Controls.Count == 0)
            {
                CurrentPanel = panel;
                this.Controls.Add(CurrentPanel);
                return;
            }

            CurrentPanel = this.Controls[0] as DevicePanel;
            if (!PanelSetPosition()) return;
            this.Controls.Add(NewPanel);
            Start();
        }

        public void RemoveSlide()
        {
            this.Controls.Remove(CurrentPanel);
            CurrentPanel.Dispose();
        }

        public Boolean PanelSetPosition()
        {
            if (this.NewPanel.PanelIndex == this.CurrentPanel.PanelIndex) return false;

            if (this.NewPanel.PanelIndex > this.CurrentPanel.PanelIndex)
            {
                MoveAction = MoveDown;
                this.Height = NewPanel.Height *2;
                this.Location = new Point(this.Location.X, -NewPanel.Height);
                this.Controls[0].Location = new Point(this.Location.X, NewPanel.Height);
                NewPanel.Location = new Point(CurrentPanel.Location.X, 0);
            }
            else
            {
                MoveAction = MoveUp;
                this.Height = NewPanel.Height * 2;
                this.Location = new Point(this.Location.X, 0);
                NewPanel.Location = new Point(CurrentPanel.Location.X, CurrentPanel.Height);
            }

            return true;
        }

        public void Start()
        {
            MoveAction.Invoke();
        }

        public void MoveUp()
        {
            MoveOBject.MoveObject(-NewPanel.Height);
        }

        public void MoveDown()
        {
            MoveOBject.MoveObject(0);
        }

        private void OnFinish(object sender, EventArgs e)
        {
            RemoveSlide();
        }

        private void _Slider_Load(object sender, EventArgs e)
        {
            this.MoveOBject.OnFinishMoving += OnFinish;
        }
    }
}
