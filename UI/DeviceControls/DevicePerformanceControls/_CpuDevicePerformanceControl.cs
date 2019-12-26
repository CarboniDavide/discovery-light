using DiscoveryLight.Core.Commun;
using DiscoveryLight.Core.Device;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _CpuDevicePerformanceControl : DevicePerformanceControl
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

            String currentCpu = (CurrentDevice as DevicePerformance).DeviceRelated;

            lbl_CpuSpeed_Value.Text = MobPropertyDataConvert.AsDefaultValue((CurrentDevice.SubDevices.Where(d => d.Name.AsString().Equals(currentCpu + ",_Total")).First() as PERFORM_CPU.SubDevice).Frequency, "N/A", "{0:N0}") + " Mhz";
            chartCpuUsage.FillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsInt16(), (CurrentDevice.SubDevices.Where(d => d.Name.AsString().Equals(currentCpu + ",_Total")).First() as PERFORM_CPU.SubDevice).PercentProcessorTime);
            int i = 0;
            foreach (WinformComponents.ChartBar ctrl in pnl_Threads.Controls.Find(typeof(WinformComponents.ChartBar).ToString(), false))
            {
                ctrl.BarFillSize = MobPropertyChartConvert.FillOrDefault(x => x.AsInt16(), (CurrentDevice.SubDevices.Where(d => d.Name.AsString() == currentCpu + "," + i).First() as PERFORM_CPU.SubDevice).PercentProcessorTime);
                i++;
            }
        }

        // perform cpu threads chart bar dynamically
        public void GraphComponents_Add()
        {
            Processor cpu = new Processor();
            cpu.UpdateCollection();
            GraphComponents_Add((Processor.SubDevice)cpu.SubDevices.Where(b => b.DeviceID.Equals(this.CurrentSubDevice.ToString())).FirstOrDefault());
        }

        // perform cpu threads chart bar dynamically
        public void GraphComponents_Add(_SubDevice Device)
        {
            GraphComponents_Clear();
            int BarPosition;
            int Step;
            int BarSize;
            int TextSize;

            var CurrentSubDevice = (Processor.SubDevice)Device;

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
