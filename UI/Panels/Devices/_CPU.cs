using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Data;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _CPU : DevicePanel
    {
        public _CPU() : base()
        {
            InitializeComponent();
            this.InitProperties(typeof(CPU));
            this.InitPerformance(new List<Type>(){ typeof(PERFORM_SYSTEM), typeof(PERFORM_CPU)});
            this.GraphComponents_Add(0);
            this.Start();
        }

        WinformComponents.ChartBar[] Charts;
        Label[] CpuId;

        int BarPosition;
        int LabelPosition;
        int Pas;
        int TailleBar;
        int TailleText;

        public override void ShowProperties()
        {
            var CurrentDevice = (CPU)this.CurrentDevice;
            int cpu_number = 0;
            lbl_Name_Value.Text = CurrentDevice.Block[cpu_number].Name;
            lbl_Size_Value.Text = CurrentDevice.Block[cpu_number].AddressSize;
            lbl_Description_Value.Text = CurrentDevice.Block[cpu_number].Description;
            lbl_Producteur_Value.Text = CurrentDevice.Block[cpu_number].Manufacturer;
            lbl_Revision_Value.Text = CurrentDevice.Block[cpu_number].Revision;
            lbl_Socket_Value.Text = CurrentDevice.Block[cpu_number].Socket;
            lbl_Core_Value.Text = CurrentDevice.Block[cpu_number].N_Core;
            lbl_Thread_Value.Text = CurrentDevice.Block[cpu_number].N_Thread;
            lbl_MaxSpeed_Value.Text = CurrentDevice.Block[cpu_number].MaxSpeed + " Mhz";
            lbl_L1CacheSize_Value.Text = CurrentDevice.Block[cpu_number].L1_Cache + " Kb";
            lbl_L2CacheSize_Value.Text = CurrentDevice.Block[cpu_number].L2_Cache + " Kb";
            lbl_L3CacheSize_Value.Text = CurrentDevice.Block[cpu_number].L3_Cache + " Kb";
        }

        public override void ShowPerformance()
        {
            var CurrentPerformanceSystem = (PERFORM_SYSTEM)CurrentPerformances.Where(d => d.GetType() == typeof(PERFORM_SYSTEM)).First();
            lbl_Threads_Value.Text = CurrentPerformanceSystem.Threads;
            lbl_Process_Value.Text = CurrentPerformanceSystem.Processes;
            var CurrentPerformanceCPU = (PERFORM_CPU)CurrentPerformances.Where(d => d.GetType() == typeof(PERFORM_CPU)).First();
            CurrentPerformanceCPU.SelectedCpu = "0";
            CurrentPerformanceCPU.SelectedThread = "_Total";
            if (CurrentPerformanceCPU.Cpu.Count == 0) return;
            lbl_CpuUsage_Value.Text = CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.MakeName()).First().Frequency + " Mhz";
            //Graphique ronde
            chartCpuUsage.FillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.MakeName()).First().DPCRate);
            var CurrentDevice = (CPU)this.CurrentDevice;
            for (int i = 0; i < Convert.ToUInt16(CurrentDevice.Block[0].N_Thread); i++)
                Charts[i].BarFillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + i).First().DPCRate);
        }

        private void GraphComponents_Add(int cpu_number)
        {
            var CurrentDevice = (CPU)this.CurrentDevice;
            // Création et insertion des élements grapique 

            // Tableau des grapiques rondes
            Charts = new WinformComponents.ChartBar[Convert.ToInt16(CurrentDevice.Block[cpu_number].N_Thread)];
            // Tableau des graphique à barre
            CpuId = new Label[Convert.ToInt16(CurrentDevice.Block[cpu_number].N_Thread)];

            // Calcul de l'épessuer entré les graphique à barre
            Pas = 160 / (Convert.ToInt16(CurrentDevice.Block[cpu_number].N_Thread));

            // Calcul de l'hauteur du caques graphique à barre
            TailleBar = Convert.ToInt16(160 / (Convert.ToInt16(CurrentDevice.Block[cpu_number].N_Thread)) / 1.6);

            TailleText = TailleBar / 2;

            if (TailleText > 14)
                TailleText = 14;

            // Poistion de départ
            BarPosition = 190;

            for (int i = 0; i < Convert.ToInt16(CurrentDevice.Block[cpu_number].N_Thread); i++)
            {
                // Création du graphique à barre 
                Charts[i] = new WinformComponents.ChartBar();
                // Création du label
                CpuId[i] = new Label();

                // Réglges du graphique
                Charts[i].Activated = true;
                Charts[i].BarBackColor = System.Drawing.Color.LightGray;
                Charts[i].BarFillColor = System.Drawing.Color.LightSeaGreen;
                Charts[i].BarFillSize = 25;
                Charts[i].Location = new System.Drawing.Point(370, BarPosition);
                Charts[i].Size = new System.Drawing.Size(190, TailleBar);
                Charts[i].Style = WinformComponents.ChartBar.STYLE.Horizontal;
                Charts[i].TextColor = System.Drawing.Color.White;
                Charts[i].TextVisible = true;
                // Régalges du label
                //LabelPosition = 190 + ()
                CpuId[i].Font = new System.Drawing.Font("Microsoft Sans Serif", TailleText, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                CpuId[i].Location = new System.Drawing.Point(370 + Charts[i].Width + 3, BarPosition);
                CpuId[i].Size = new System.Drawing.Size(100, TailleBar);
                CpuId[i].Text = "CPU " + i;
                CpuId[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // Insertion dans le panneau
                this.Controls.Add(Charts[i]);
                this.Controls.Add(CpuId[i]);

                //Mis à jour de la position
                BarPosition = BarPosition + Pas;
            }
        }
    }
}
