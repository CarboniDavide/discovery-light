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

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _CpuDevicePerformanceControl : DevicePerformanceControl
    {
        public _CpuDevicePerformanceControl(): base()
        {
            InitializeComponent();
        }

        public override void ShowPerformance()
        {
            base.ShowPerformance();
            var CurrentPerformanceCPU = (PERFORM_CPU)this.CurrentPerformance;
            lbl_CpuUsage_Value.Text = CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + "_Total").First().Frequency + " Mhz";
            chartCpuUsage.FillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + "_Total").First().DPCRate);
            int i = 0;
            foreach (WinformComponents.ChartBar ctrl in pnl_Threads.Controls.Find(typeof(WinformComponents.ChartBar).ToString(), false))
            {
                ctrl.BarFillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + i).First().DPCRate);
                i++;
            }
        }

        public void GraphComponents_Add()
        {
            Clear();
            int BarPosition;
            int Step;
            int BarSize;
            int TextSize;

            CPU cpu= new CPU();
            cpu.GetDriveInfo();
            var CurrentSubDevice = (CPU.Block)cpu.Blocks.Where(b => b.DeviceID.Equals(this.CurrentSubDevice.ToString())).FirstOrDefault();
            // Création et insertion des élements grapique

            // Calcul de l'épessuer entré les graphique à barre
            Step = pnl_Threads.Height / (Convert.ToInt16(CurrentSubDevice.N_Thread));

            // Calcul de l'hauteur du caques graphique à barre
            BarSize = Convert.ToInt16(pnl_Threads.Height / (Convert.ToInt16(CurrentSubDevice.N_Thread)) / 1.6);

            TextSize = BarSize / 2;

            if (TextSize > 14)
                TextSize = 14;

            // Poistion de départ
            BarPosition = 0;

            for (int i = 0; i < Convert.ToInt16(CurrentSubDevice.N_Thread); i++)
            {
                WinformComponents.ChartBar chart = new WinformComponents.ChartBar();
                Label label = new Label();

                chart.Activated = true;
                chart.BarBackColor = System.Drawing.Color.LightGray;
                chart.BarFillColor = System.Drawing.Color.LightSeaGreen;
                chart.BarFillSize = 25;
                chart.Location = new System.Drawing.Point(10, BarPosition);
                chart.Size = new System.Drawing.Size(190, BarSize);
                chart.Style = WinformComponents.ChartBar.STYLE.Horizontal;
                chart.TextColor = System.Drawing.Color.White;
                chart.TextVisible = true;
                chart.Name = typeof(WinformComponents.ChartBar).ToString();

                label.Font = new System.Drawing.Font("Microsoft Sans Serif", TextSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.Location = new System.Drawing.Point(chart.Width + 15, BarPosition);
                label.Size = new System.Drawing.Size(100, BarSize);
                label.Text = "TH " + i;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // Insertion dans le panneau
                this.pnl_Threads.Controls.Add(chart);
                this.pnl_Threads.Controls.Add(label);

                //Mis à jour de la position
                BarPosition = BarPosition + Step;
            }
        }

        private void Clear()
        {
            this.pnl_Threads.Controls.Clear();
        }

        private void _CpuDevicePerformanceControl_Load(object sender, EventArgs e)
        {
            if (Program.Performances == null) return;
            InitPerformace(Program.Performances.Where(d => d.Properties.GetType() == typeof(PERFORM_CPU)).First().Properties);
        }
    }
}
