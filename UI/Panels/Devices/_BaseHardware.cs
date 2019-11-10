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
using System.Threading;

namespace DiscoveryLight.UI.Panels.Devices
{
    public partial class _BaseHardware : DevicePanel
    {
        public _BaseHardware()
        {
            InitializeComponent();
            this.InitProperties(typeof(PC));
            this.InitPerformance(typeof(PERFORM_PC));
            this.Start();
        }
        
        public override void ShowProperties() {
            var CurrentDevice = (PC)this.CurrentDevice;
            lbl_Name_Value.Text = CurrentDevice.Name;
            lbl_Type_Value.Text = CurrentDevice.Type;
            lbl_Manufaturer_Value.Text = CurrentDevice.Manufacturer;
            lbl_Model_Value.Text = CurrentDevice.Model;
            lbl_NumberID_Value.Text = CurrentDevice.IDNumber;
            lbl_User_Value.Text = CurrentDevice.User;
            lbl_Domain_Value.Text = CurrentDevice.Domaine;
            lbl_Version_Value.Text = CurrentDevice.SystemOS_Version;
            lbl_SystemOS_Value.Text = CurrentDevice.SystemOS;
            lbl_Producer_Value.Text = CurrentDevice.SystemOS_Brand;
            lbl_Architectur_Value.Text = CurrentDevice.SystemOS_Architecture;
        }

        public override void ShowPerformance()
        {
            var CurrentPerformance = (PERFORM_PC)this.CurrentPerformance;
            chartRAM.FillSize = (int)CurrentPerformance.Per_RamSizeUsed;
            chartHD.FillSize = (int)(100 - CurrentPerformance.Per_DiskSizeFree);
            chartCPU.FillSize = (int)CurrentPerformance.Per_CpuUsage;
        }

        private void lbl_ChartHD_Click(object sender, EventArgs e)
        {

        }
    }
}
