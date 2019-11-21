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
    public partial class _SystemDevicePerformanceControl : DevicePerformanceControl
    {
        public _SystemDevicePerformanceControl(DevicePerformance Performance) : base(Performance)
        {
            InitializeComponent();
        }

        public _SystemDevicePerformanceControl() : base() 
        {
            InitializeComponent();
        }

        public override void ShowPerformance()
        {
            base.ShowPerformance();
            var CurrentPerformance = (PERFORM_SYSTEM)this.CurrentPerformance;
            lbl_Threads_Value.Text = CurrentPerformance.Threads;
            lbl_Process_Value.Text = CurrentPerformance.Processes;
        }
    }
}
