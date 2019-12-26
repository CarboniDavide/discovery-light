using DiscoveryLight.UI.Forms.Main;
using DiscoveryLight.UI.Panels.Devices;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DiscoveryLight.UI.Panels.Slider
{
    /// <summary>
    /// Slider images.
    /// Manage animation when a new panel is required.
    /// </summary>
    public partial class _Slider : UserControl
    {
        public _Slider()
        {
            InitializeComponent();
        }

        DevicePanel CurrentPanel;      // current loaded panel
        DevicePanel NewPanel;          // the new panel to add and rendered 
        Action MoveAction;             // slide animation

        /// <summary>
        /// Add a new panel into the slider.
        /// </summary>
        /// <param name="panel"></param>
        public void AddSlide(DevicePanel panel)
        {
            NewPanel = panel;
            if (this.Controls.Count == 0)          // if no panel exists add and return
            {
                CurrentPanel = panel;
                this.Controls.Add(CurrentPanel);
                return;
            }

            CurrentPanel = this.Controls[0] as DevicePanel;      // get first panel in control list
            if (!PanelSetPosition()) return;                     // if new location are not required for the new panel return
            this.Controls.Add(NewPanel);                         // add the new panel
            Start();                                             // start slider animation   
        }

        /// <summary>
        /// Remove panel from slider
        /// </summary>
        public void RemoveSlide()
        {
            this.Controls.Remove(CurrentPanel);
            CurrentPanel.Dispose();
        }

        /// <summary>
        /// Define a new position for the new panel: bottom or top
        /// </summary>
        /// <returns></returns>
        public Boolean PanelSetPosition()
        {
            if (this.NewPanel.PanelIndex == this.CurrentPanel.PanelIndex) return false;  // not action if the same panel is required

            if (this.NewPanel.PanelIndex > this.CurrentPanel.PanelIndex)   // set the new panel in the top
            {
                MoveAction = MoveDown;                                                   // set action to the animation
                this.Height = NewPanel.Height * 2;                                        // get space in top to host the new panel  
                this.Location = new Point(this.Location.X, -NewPanel.Height);            // get a new location
                this.Controls[0].Location = new Point(this.Location.X, NewPanel.Height); // change location to the old panel   
                NewPanel.Location = new Point(CurrentPanel.Location.X, 0);               // set panel with the location       
            }
            else
            {
                MoveAction = MoveUp;                                                             // set action to the animation   
                this.Height = NewPanel.Height * 2;                                               // get space in bottom to host the new panel    
                this.Location = new Point(this.Location.X, 0);                                   // get a new location
                this.Controls[0].Location = new Point(this.Location.X, 0);                       // change location to the old panel
                NewPanel.Location = new Point(CurrentPanel.Location.X, CurrentPanel.Height);     // set panel with the location  
            }

            return true; // yes a new location has been required
        }

        /// <summary>
        /// Invoke the required animation. (In the bottom or in the top)
        /// </summary>
        public void Start()
        {
            MoveAction.Invoke();
        }

        /// <summary>
        /// Animation Move Up action
        /// </summary>
        public void MoveUp()
        {
            MoveOBject.MoveObject(-NewPanel.Height);
        }

        /// <summary>
        /// Animation Move Down action
        /// </summary>
        public void MoveDown()
        {
            MoveOBject.MoveObject(0);
        }

        /// <summary>
        /// Raise a new event when animation is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFinish(object sender, EventArgs e)
        {
            RemoveSlide();
        }

        public void SetMainTitle(object sender, EventArgs e)
        {
            _Footer Footer = this.Parent.Parent.Controls.Cast<Control>().Where(d => d.GetType().FullName.Equals(typeof(_Footer).FullName)).FirstOrDefault() as _Footer;
            if (Footer == null) return;
            Footer.SetMainTitle();
        }

        private void _Slider_Load(object sender, EventArgs e)
        {
            this.MoveOBject.OnFinishMoving += OnFinish;

            this.ControlAdded += new ControlEventHandler(SetMainTitle);
        }
    }
}
