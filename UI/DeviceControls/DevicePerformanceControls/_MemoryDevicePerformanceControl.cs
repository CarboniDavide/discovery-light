﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscoveryLight.Core.Device.Performance;

namespace DiscoveryLight.UI.DeviceControls.DevicePerformanceControls
{
    public partial class _MemoryDevicePerformanceControl : DevicePerformanceControl
    {
        public _MemoryDevicePerformanceControl()
        {
            InitializeComponent();
        }

        public override void ShowPerformance()
        {
            var CurrentPerformanceCPU = (PERFORM_RAM)this.CurrentPerformance;
            lbl_CacheUsage_Value.Text = (Convert.ToUInt64(CurrentPerformanceCPU.CacheUsage) / 1048576).ToString() + " MB";
            lbl_CacheUsageMax_Value.Text = (Convert.ToUInt64(CurrentPerformanceCPU.MaxCacheUsage) / 1048576).ToString() + " MB";
            lbl_RamOut_Value.Text = (Convert.ToUInt64(CurrentPerformanceCPU.MemoryOut) / 1048576).ToString() + " MB";
            lbl_Free_Value.Text = CurrentPerformanceCPU.Free + " MB";
            lbl_PageIn_Value.Text = CurrentPerformanceCPU.PageIn.ToString();
            lbl_PageOut_Value.Text = CurrentPerformanceCPU.PageOut.ToString();
            lbl_PageWrite_Value.Text = CurrentPerformanceCPU.PageWrite.ToString();
            lbl_PageRead_Value.Text = CurrentPerformanceCPU.PageRead.ToString();
            lbl_PagePersec_Value.Text = CurrentPerformanceCPU.PagePerSec.ToString();
            chartRamUsage.FillSize = (int)(100 - CurrentPerformanceCPU.PerUsage);
        }

        private void _MemoryDevicePerformanceControl_Load(object sender, EventArgs e)
        {
            if (Program.Performances == null) return;
            InitPerformace(Program.Performances.Where(d => d.Properties.GetType() == typeof(PERFORM_RAM)).First().Properties);
        }
    }
}
