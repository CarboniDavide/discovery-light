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
            this.InitSubDevicesID();
            this.Start();
        }

        WinformComponents.ChartBar[] Charts;
        Label[] CpuId;

        public override void ShowProperties()
        {
            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
            lbl_Name_Value.Text = CurrentSubDevice.Name;
            lbl_Size_Value.Text = CurrentSubDevice.AddressSize;
            lbl_Description_Value.Text = CurrentSubDevice.Description;
            lbl_Producteur_Value.Text = CurrentSubDevice.Manufacturer;
            lbl_Revision_Value.Text = CurrentSubDevice.Revision;
            lbl_Socket_Value.Text = CurrentSubDevice.Socket;
            lbl_Core_Value.Text = CurrentSubDevice.N_Core;
            lbl_Thread_Value.Text = CurrentSubDevice.N_Thread;
            lbl_MaxSpeed_Value.Text = CurrentSubDevice.MaxSpeed + " Mhz";
            lbl_L1CacheSize_Value.Text = CurrentSubDevice.L1_Cache + " Kb";
            lbl_L2CacheSize_Value.Text = CurrentSubDevice.L2_Cache + " Kb";
            lbl_L3CacheSize_Value.Text = CurrentSubDevice.L3_Cache + " Kb";
        }

        public override void ShowPerformance()
        {
            var CurrentPerformanceSystem = (PERFORM_SYSTEM)CurrentPerformances.Where(d => d.GetType() == typeof(PERFORM_SYSTEM)).First();
            lbl_Threads_Value.Text = CurrentPerformanceSystem.Threads;
            lbl_Process_Value.Text = CurrentPerformanceSystem.Processes;
            var CurrentPerformanceCPU = (PERFORM_CPU)CurrentPerformances.Where(d => d.GetType() == typeof(PERFORM_CPU)).First();
            CurrentPerformanceCPU.SelectedCpu = this.CurrentSubDevice.DeviceID;
            CurrentPerformanceCPU.SelectedThread = "_Total";
            if (CurrentPerformanceCPU.Cpu.Count == 0) return;
            lbl_CpuUsage_Value.Text = CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.MakeName()).First().Frequency + " Mhz";
            //Graphique ronde
            chartCpuUsage.FillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.MakeName()).First().DPCRate);
            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
            for (int i = 0; i < Convert.ToUInt16(CurrentSubDevice.N_Thread); i++)
                Charts[i].BarFillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + i).First().DPCRate);
        }

        private void GraphComponents_Add()
        {
            int BarPosition;
            int Step;
            int BarSize;
            int TextSize;

            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
            // Création et insertion des élements grapique 

            // Tableau des grapiques rondes
            Charts = new WinformComponents.ChartBar[Convert.ToInt16(CurrentSubDevice.N_Thread)];
            // Tableau des graphique à barre
            CpuId = new Label[Convert.ToInt16(CurrentSubDevice.N_Thread)];

            // Calcul de l'épessuer entré les graphique à barre
            Step = 160 / (Convert.ToInt16(CurrentSubDevice.N_Thread));

            // Calcul de l'hauteur du caques graphique à barre
            BarSize = Convert.ToInt16(160 / (Convert.ToInt16(CurrentSubDevice.N_Thread)) / 1.6);

            TextSize = BarSize / 2;

            if (TextSize > 14)
                TextSize = 14;

            // Poistion de départ
            BarPosition = 190;

            for (int i = 0; i < Convert.ToInt16(CurrentSubDevice.N_Thread); i++)
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
                Charts[i].Size = new System.Drawing.Size(190, BarSize);
                Charts[i].Style = WinformComponents.ChartBar.STYLE.Horizontal;
                Charts[i].TextColor = System.Drawing.Color.White;
                Charts[i].TextVisible = true;
                // Régalges du label
                //LabelPosition = 190 + ()
                CpuId[i].Font = new System.Drawing.Font("Microsoft Sans Serif", TextSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                CpuId[i].Location = new System.Drawing.Point(370 + Charts[i].Width + 3, BarPosition);
                CpuId[i].Size = new System.Drawing.Size(100, BarSize);
                CpuId[i].Text = "TH " + i;
                CpuId[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                // Insertion dans le panneau
                this.Controls.Add(Charts[i]);
                this.Controls.Add(CpuId[i]);

                //Mis à jour de la position
                BarPosition = BarPosition + Step;
            }
        }

        private void Clear()
        {
            // Suppression des élements graphique et des label dans le panneau

            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
            for (int i = 0; i < Convert.ToInt16(CurrentSubDevice.N_Thread); i++)
            {
                if (Charts != null && CpuId != null)
                {
                    this.Controls.Remove(Charts[i]);
                    this.Controls.Remove(CpuId[i]);
                }
            }
        }

        private void ChargeListOfSubDevicesInit()
        {
            var CurrentDevice = (CPU)this.CurrentDevice;
            foreach (CPU.Block block in CurrentDevice.Blocks)
                this.cmb_Blocks.Items.Add(block.DeviceID + " - " + block.Name);
        }

        private void ChangeSubDevice(object sender, EventArgs e)
        {
            this.Clear();
            this.CurrentSubDevice = this.CurrentDevice.Blocks.Where(d => d.DeviceID.Equals(this.cmb_Blocks.SelectedIndex.ToString())).First();
            this.GraphComponents_Add();
        }

        private void InitSubDevicesID()
        {
            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
            this.ChargeListOfSubDevicesInit();
            this.cmb_Blocks.SelectedIndex = 0;
        }
    }
}
