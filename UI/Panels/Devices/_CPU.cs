﻿using System;
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
using WinformComponents;

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
            lbl_CpuUsage_Value.Text = CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + "_Total").First().Frequency + " Mhz";
            chartCpuUsage.FillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + "_Total").First().DPCRate);
            int i = 0;
            foreach (WinformComponents.ChartBar ctrl in pnl_Threads.Controls.Find(typeof(WinformComponents.ChartBar).ToString(), false))
            {
                ctrl.BarFillSize = Convert.ToInt16(CurrentPerformanceCPU.Cpu.Where(d => d.Name == CurrentPerformanceCPU.SelectedCpu + "," + i).First().DPCRate);
                i++;
            }
        }

        private void GraphComponents_Add()
        {
            int BarPosition;
            int Step;
            int BarSize;
            int TextSize;

            var CurrentSubDevice = (CPU.Block)this.CurrentSubDevice;
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
            var CurrentPerformanceCPU = (PERFORM_CPU)CurrentPerformances.Where(d => d.GetType() == typeof(PERFORM_CPU)).First();
            CurrentPerformanceCPU.SelectedCpu = this.CurrentSubDevice.DeviceID;
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
