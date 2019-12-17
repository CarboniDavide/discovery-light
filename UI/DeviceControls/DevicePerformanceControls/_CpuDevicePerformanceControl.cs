using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Performance;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Commun;
using DiscoveryLight.UI.Charts;
using DiscoveryLight.Core.Device;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _CpuDevicePerformanceControl : DeviceControl
    {
        public _CpuDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _CpuDevicePerformanceControl() : base() 
        {
            InitializeComponent();
        }


        protected override void update()
        {
            base.update();
            CurrentDevice.UpdateCollection();
        }

        protected override void show()
        {
            base.show();
            var CurrentPerformanceCPU = (PERFORM_CPU.Device)this.CurrentSubDevice;
            lbl_CpuSpeed_Value.Text = DataConvert.AsDefaultValue(CurrentPerformanceCPU.Frequency.AsString(), "N/A", "{0:N0}") + " Mhz";
            chartCpuUsage.FillSize = ChartPerform.FillOrDefault( x=> Convert.ToInt16(x), CurrentPerformanceCPU.PercentProcessorTime.AsString());
            int i = 0;
            String currentCpu = CurrentSubDevice.Name.AsSubString(0, 1);
            foreach (WinformComponents.ChartBar ctrl in pnl_Threads.Controls.Find(typeof(WinformComponents.ChartBar).ToString(), false))
            {
                ctrl.BarFillSize = ChartPerform.FillOrDefault(x=> Convert.ToInt16(x), (CurrentDevice.Devices.Where(d => d.Name.AsString() == currentCpu + "," + i).First() as PERFORM_CPU.Device).PercentProcessorTime.AsString());
                i++;
            }
        }

        // perform cpu threads chart bar dynamically
        public void GraphComponents_Add()
        {
            Processor cpu = new Processor();
            cpu.UpdateCollection();
            GraphComponents_Add((Processor.Device)cpu.Devices.Where(b => b.DeviceID.Equals(this.CurrentSubDevice.ToString())).FirstOrDefault());
        }

        // perform cpu threads chart bar dynamically
        public void GraphComponents_Add(_Device Device)
        {
            GraphComponents_Clear();
            int BarPosition;
            int Step;
            int BarSize;
            int TextSize;
            
            var CurrentSubDevice = (Processor.Device)Device;

            // define height between each chart bar
            Step = pnl_Threads.Height / (Convert.ToInt16(CurrentSubDevice.NumberOfLogicalProcessors.AsString()));

            // define each char bar height
            BarSize = Convert.ToInt16(pnl_Threads.Height / (Convert.ToInt16(CurrentSubDevice.NumberOfLogicalProcessors.AsString())) / 1.6);

            TextSize = BarSize / 2;

            if (TextSize > 14)
                TextSize = 14;

            // Start location
            BarPosition = 0;

            // make all thread
            for (int i = 0; i < Convert.ToInt16(CurrentSubDevice.NumberOfLogicalProcessors.AsString()); i++)
            {
                WinformComponents.ChartBar chart = new WinformComponents.ChartBar();
                Label label = new Label();

                // chart bar component
                chart.Activated = true;
                chart.BarBackColor = System.Drawing.Color.LightGray;
                chart.BarFillColor = System.Drawing.Color.Coral;
                chart.BarFillSize = 25;
                chart.Location = new System.Drawing.Point(10, BarPosition);
                chart.Size = new System.Drawing.Size(190, BarSize);
                chart.Style = WinformComponents.ChartBar.STYLE.Horizontal;
                chart.TextColor = System.Drawing.Color.White;
                chart.Name = typeof(WinformComponents.ChartBar).ToString();

                // label component
                label.Font = new System.Drawing.Font("Tahoma", TextSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.Location = new System.Drawing.Point(chart.Width + 15, BarPosition);
                label.Size = new System.Drawing.Size(100, BarSize);
                label.Text = "TH " + i;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // add the new components in control
                this.pnl_Threads.Controls.Add(chart);
                this.pnl_Threads.Controls.Add(label);

                // update position to the next chart bar
                BarPosition = BarPosition + Step;
            }
        }

        private void GraphComponents_Clear()
        {
            this.pnl_Threads.Controls.Clear(); // remove all thread from control
        }
    }
}
