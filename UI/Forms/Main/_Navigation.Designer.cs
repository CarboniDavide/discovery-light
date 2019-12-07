using DiscoveryLight.UI.Components;

namespace DiscoveryLight.UI.Forms.Main
{
    partial class _Navigation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Navigation));
            this.AnimationLine_Navigation = new WinformComponents.AnimationLine();
            this.toolTip_Description = new System.Windows.Forms.ToolTip(this.components);
            this.cmd_Connectivite = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_Reseau = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_Disque = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_Video = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_Son = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_MemoireRam = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_Processeur = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_CarteMere = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_Ordinateur = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.cmd_Settings = new DiscoveryLight.UI.Components.PanelLinkButton();
            this.SuspendLayout();
            // 
            // AnimationLine_Navigation
            // 
            resources.ApplyResources(this.AnimationLine_Navigation, "AnimationLine_Navigation");
            this.AnimationLine_Navigation.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AnimationLine_Navigation.Interval = 1;
            this.AnimationLine_Navigation.Name = "AnimationLine_Navigation";
            this.AnimationLine_Navigation.Type = WinformComponents.AnimationLine.TYPE.Vertical;
            // 
            // cmd_Connectivite
            // 
            this.cmd_Connectivite.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_Connectivite.BackgroundImage = global::DiscoveryLight.Properties.Resources.Réglages;
            resources.ApplyResources(this.cmd_Connectivite, "cmd_Connectivite");
            this.cmd_Connectivite.ButtonFor = "_All";
            this.cmd_Connectivite.Device = "All WMI Class";
            this.cmd_Connectivite.FlatAppearance.BorderSize = 0;
            this.cmd_Connectivite.Name = "cmd_Connectivite";
            this.cmd_Connectivite.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Connectivite, resources.GetString("cmd_Connectivite.ToolTip"));
            this.cmd_Connectivite.UseVisualStyleBackColor = false;
            this.cmd_Connectivite.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Reseau
            // 
            this.cmd_Reseau.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_Reseau.BackgroundImage = global::DiscoveryLight.Properties.Resources.Ethernet;
            resources.ApplyResources(this.cmd_Reseau, "cmd_Reseau");
            this.cmd_Reseau.ButtonFor = "_Network";
            this.cmd_Reseau.Device = "Network Adapter";
            this.cmd_Reseau.FlatAppearance.BorderSize = 0;
            this.cmd_Reseau.Name = "cmd_Reseau";
            this.cmd_Reseau.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Reseau, resources.GetString("cmd_Reseau.ToolTip"));
            this.cmd_Reseau.UseVisualStyleBackColor = false;
            this.cmd_Reseau.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Disque
            // 
            this.cmd_Disque.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_Disque.BackgroundImage = global::DiscoveryLight.Properties.Resources.HardDisk;
            resources.ApplyResources(this.cmd_Disque, "cmd_Disque");
            this.cmd_Disque.ButtonFor = "_PhysicalDisk";
            this.cmd_Disque.Device = "Physical Disk";
            this.cmd_Disque.FlatAppearance.BorderSize = 0;
            this.cmd_Disque.Name = "cmd_Disque";
            this.cmd_Disque.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Disque, resources.GetString("cmd_Disque.ToolTip"));
            this.cmd_Disque.UseVisualStyleBackColor = false;
            this.cmd_Disque.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Video
            // 
            this.cmd_Video.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_Video.BackgroundImage = global::DiscoveryLight.Properties.Resources.Video;
            resources.ApplyResources(this.cmd_Video, "cmd_Video");
            this.cmd_Video.ButtonFor = "_Video";
            this.cmd_Video.Device = "Video";
            this.cmd_Video.FlatAppearance.BorderSize = 0;
            this.cmd_Video.Name = "cmd_Video";
            this.cmd_Video.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Video, resources.GetString("cmd_Video.ToolTip"));
            this.cmd_Video.UseVisualStyleBackColor = false;
            this.cmd_Video.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Son
            // 
            this.cmd_Son.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_Son.BackgroundImage = global::DiscoveryLight.Properties.Resources.Sound;
            resources.ApplyResources(this.cmd_Son, "cmd_Son");
            this.cmd_Son.ButtonFor = "_Audio";
            this.cmd_Son.Device = "Sound";
            this.cmd_Son.FlatAppearance.BorderSize = 0;
            this.cmd_Son.Name = "cmd_Son";
            this.cmd_Son.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Son, resources.GetString("cmd_Son.ToolTip"));
            this.cmd_Son.UseVisualStyleBackColor = false;
            this.cmd_Son.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_MemoireRam
            // 
            this.cmd_MemoireRam.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_MemoireRam.BackgroundImage = global::DiscoveryLight.Properties.Resources.Ram;
            resources.ApplyResources(this.cmd_MemoireRam, "cmd_MemoireRam");
            this.cmd_MemoireRam.ButtonFor = "_Memory";
            this.cmd_MemoireRam.Device = "Memory";
            this.cmd_MemoireRam.FlatAppearance.BorderSize = 0;
            this.cmd_MemoireRam.Name = "cmd_MemoireRam";
            this.cmd_MemoireRam.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_MemoireRam, resources.GetString("cmd_MemoireRam.ToolTip"));
            this.cmd_MemoireRam.UseVisualStyleBackColor = false;
            this.cmd_MemoireRam.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Processeur
            // 
            this.cmd_Processeur.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_Processeur.BackgroundImage = global::DiscoveryLight.Properties.Resources.Cpu;
            resources.ApplyResources(this.cmd_Processeur, "cmd_Processeur");
            this.cmd_Processeur.ButtonFor = "_CPU";
            this.cmd_Processeur.Device = "Processor";
            this.cmd_Processeur.FlatAppearance.BorderSize = 0;
            this.cmd_Processeur.Name = "cmd_Processeur";
            this.cmd_Processeur.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Processeur, resources.GetString("cmd_Processeur.ToolTip"));
            this.cmd_Processeur.UseVisualStyleBackColor = false;
            this.cmd_Processeur.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_CarteMere
            // 
            this.cmd_CarteMere.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_CarteMere.BackgroundImage = global::DiscoveryLight.Properties.Resources.MainBoard;
            resources.ApplyResources(this.cmd_CarteMere, "cmd_CarteMere");
            this.cmd_CarteMere.ButtonFor = "_MainBoard";
            this.cmd_CarteMere.Device = "Mainboard";
            this.cmd_CarteMere.FlatAppearance.BorderSize = 0;
            this.cmd_CarteMere.Name = "cmd_CarteMere";
            this.cmd_CarteMere.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_CarteMere, resources.GetString("cmd_CarteMere.ToolTip"));
            this.cmd_CarteMere.UseVisualStyleBackColor = false;
            this.cmd_CarteMere.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Ordinateur
            // 
            resources.ApplyResources(this.cmd_Ordinateur, "cmd_Ordinateur");
            this.cmd_Ordinateur.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cmd_Ordinateur.BackgroundImage = global::DiscoveryLight.Properties.Resources.Pc;
            this.cmd_Ordinateur.ButtonFor = "_BaseHardware";
            this.cmd_Ordinateur.Device = "Base Pc Informations";
            this.cmd_Ordinateur.FlatAppearance.BorderSize = 0;
            this.cmd_Ordinateur.Name = "cmd_Ordinateur";
            this.cmd_Ordinateur.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Ordinateur, resources.GetString("cmd_Ordinateur.ToolTip"));
            this.cmd_Ordinateur.UseVisualStyleBackColor = false;
            this.cmd_Ordinateur.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Settings
            // 
            resources.ApplyResources(this.cmd_Settings, "cmd_Settings");
            this.cmd_Settings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmd_Settings.BackgroundImage = global::DiscoveryLight.Properties.Resources.Performancs;
            this.cmd_Settings.ButtonFor = "Settings";
            this.cmd_Settings.Device = "Settings";
            this.cmd_Settings.FlatAppearance.BorderSize = 0;
            this.cmd_Settings.Name = "cmd_Settings";
            this.cmd_Settings.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Settings, resources.GetString("cmd_Settings.ToolTip"));
            this.cmd_Settings.UseVisualStyleBackColor = false;
            this.cmd_Settings.Click += new System.EventHandler(this.ButtonClick);
            // 
            // _Navigation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.AnimationLine_Navigation);
            this.Controls.Add(this.cmd_Connectivite);
            this.Controls.Add(this.cmd_Reseau);
            this.Controls.Add(this.cmd_Disque);
            this.Controls.Add(this.cmd_Video);
            this.Controls.Add(this.cmd_Son);
            this.Controls.Add(this.cmd_MemoireRam);
            this.Controls.Add(this.cmd_Processeur);
            this.Controls.Add(this.cmd_CarteMere);
            this.Controls.Add(this.cmd_Ordinateur);
            this.Controls.Add(this.cmd_Settings);
            this.Name = "_Navigation";
            this.ResumeLayout(false);

        }

        #endregion

        private PanelLinkButton cmd_Ordinateur;
        private PanelLinkButton cmd_CarteMere;
        private PanelLinkButton cmd_Processeur;
        private PanelLinkButton cmd_MemoireRam;
        private PanelLinkButton cmd_Son;
        private PanelLinkButton cmd_Video;
        private PanelLinkButton cmd_Disque;
        private PanelLinkButton cmd_Reseau;
        private PanelLinkButton cmd_Connectivite;
        private PanelLinkButton cmd_Settings;
        public WinformComponents.AnimationLine AnimationLine_Navigation;
        private System.Windows.Forms.ToolTip toolTip_Description;
    }
}
