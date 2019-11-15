using DiscoveryLight.UI.Buttons;

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
            this.AnimationLine_Navigation = new WinformComponents.AnimationLine();
            this.cmd_Settings = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.toolTip_Description = new System.Windows.Forms.ToolTip(this.components);
            this.cmd_Connectivite = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_Reseau = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_Disque = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_Video = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_Son = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_MemoireRam = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_Processeur = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_CarteMere = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.cmd_Ordinateur = new DiscoveryLight.UI.Buttons.PanelLinkButton();
            this.SuspendLayout();
            // 
            // AnimationLine_Navigation
            // 
            this.AnimationLine_Navigation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationLine_Navigation.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AnimationLine_Navigation.Interval = 1;
            this.AnimationLine_Navigation.Location = new System.Drawing.Point(0, 0);
            this.AnimationLine_Navigation.Name = "AnimationLine_Navigation";
            this.AnimationLine_Navigation.Size = new System.Drawing.Size(3, 40);
            this.AnimationLine_Navigation.TabIndex = 12;
            this.AnimationLine_Navigation.Type = WinformComponents.AnimationLine.TYPE.Vertical;
            // 
            // cmd_Settings
            // 
            this.cmd_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmd_Settings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmd_Settings.BackgroundImage = global::DiscoveryLight.Properties.Resources.Performancs;
            this.cmd_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Settings.ButtonFor = "";
            this.cmd_Settings.Device = "Settings";
            this.cmd_Settings.FlatAppearance.BorderSize = 0;
            this.cmd_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Settings.Location = new System.Drawing.Point(0, 360);
            this.cmd_Settings.Name = "cmd_Settings";
            this.cmd_Settings.Size = new System.Drawing.Size(40, 40);
            this.cmd_Settings.TabIndex = 13;
            this.cmd_Settings.ToolDescription = this.toolTip_Description;
            this.cmd_Settings.UseVisualStyleBackColor = false;
            // 
            // cmd_Connectivite
            // 
            this.cmd_Connectivite.BackgroundImage = global::DiscoveryLight.Properties.Resources.Réglages;
            this.cmd_Connectivite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Connectivite.ButtonFor = "_All";
            this.cmd_Connectivite.Device = "All WMI Class";
            this.cmd_Connectivite.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Connectivite.FlatAppearance.BorderSize = 0;
            this.cmd_Connectivite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Connectivite.Location = new System.Drawing.Point(0, 320);
            this.cmd_Connectivite.Name = "cmd_Connectivite";
            this.cmd_Connectivite.Size = new System.Drawing.Size(40, 40);
            this.cmd_Connectivite.TabIndex = 11;
            this.cmd_Connectivite.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Connectivite, "All WMI Class");
            this.cmd_Connectivite.UseVisualStyleBackColor = true;
            // 
            // cmd_Reseau
            // 
            this.cmd_Reseau.BackgroundImage = global::DiscoveryLight.Properties.Resources.Ethernet;
            this.cmd_Reseau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Reseau.ButtonFor = "_Network";
            this.cmd_Reseau.Device = "Network Adapter";
            this.cmd_Reseau.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Reseau.FlatAppearance.BorderSize = 0;
            this.cmd_Reseau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Reseau.Location = new System.Drawing.Point(0, 280);
            this.cmd_Reseau.Name = "cmd_Reseau";
            this.cmd_Reseau.Size = new System.Drawing.Size(40, 40);
            this.cmd_Reseau.TabIndex = 10;
            this.cmd_Reseau.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Reseau, "Network Adapter");
            this.cmd_Reseau.UseVisualStyleBackColor = true;
            this.cmd_Reseau.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Disque
            // 
            this.cmd_Disque.BackgroundImage = global::DiscoveryLight.Properties.Resources.HardDisk;
            this.cmd_Disque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Disque.ButtonFor = "_PhysicalDisk";
            this.cmd_Disque.Device = "Physical Disk";
            this.cmd_Disque.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Disque.FlatAppearance.BorderSize = 0;
            this.cmd_Disque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Disque.Location = new System.Drawing.Point(0, 240);
            this.cmd_Disque.Name = "cmd_Disque";
            this.cmd_Disque.Size = new System.Drawing.Size(40, 40);
            this.cmd_Disque.TabIndex = 9;
            this.cmd_Disque.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Disque, "Physical Disk");
            this.cmd_Disque.UseVisualStyleBackColor = true;
            this.cmd_Disque.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Video
            // 
            this.cmd_Video.BackgroundImage = global::DiscoveryLight.Properties.Resources.Video;
            this.cmd_Video.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Video.ButtonFor = "_Video";
            this.cmd_Video.Device = "Video";
            this.cmd_Video.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Video.FlatAppearance.BorderSize = 0;
            this.cmd_Video.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Video.Location = new System.Drawing.Point(0, 200);
            this.cmd_Video.Name = "cmd_Video";
            this.cmd_Video.Size = new System.Drawing.Size(40, 40);
            this.cmd_Video.TabIndex = 8;
            this.cmd_Video.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Video, "Video");
            this.cmd_Video.UseVisualStyleBackColor = true;
            this.cmd_Video.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Son
            // 
            this.cmd_Son.BackgroundImage = global::DiscoveryLight.Properties.Resources.Sound;
            this.cmd_Son.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Son.ButtonFor = "_Audio";
            this.cmd_Son.Device = "Sound";
            this.cmd_Son.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Son.FlatAppearance.BorderSize = 0;
            this.cmd_Son.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Son.Location = new System.Drawing.Point(0, 160);
            this.cmd_Son.Name = "cmd_Son";
            this.cmd_Son.Size = new System.Drawing.Size(40, 40);
            this.cmd_Son.TabIndex = 7;
            this.cmd_Son.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Son, "Sound");
            this.cmd_Son.UseVisualStyleBackColor = true;
            this.cmd_Son.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_MemoireRam
            // 
            this.cmd_MemoireRam.BackgroundImage = global::DiscoveryLight.Properties.Resources.Ram;
            this.cmd_MemoireRam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_MemoireRam.ButtonFor = "_Memory";
            this.cmd_MemoireRam.Device = "Memory";
            this.cmd_MemoireRam.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_MemoireRam.FlatAppearance.BorderSize = 0;
            this.cmd_MemoireRam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_MemoireRam.Location = new System.Drawing.Point(0, 120);
            this.cmd_MemoireRam.Name = "cmd_MemoireRam";
            this.cmd_MemoireRam.Size = new System.Drawing.Size(40, 40);
            this.cmd_MemoireRam.TabIndex = 6;
            this.cmd_MemoireRam.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_MemoireRam, "Memory");
            this.cmd_MemoireRam.UseVisualStyleBackColor = true;
            this.cmd_MemoireRam.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Processeur
            // 
            this.cmd_Processeur.BackgroundImage = global::DiscoveryLight.Properties.Resources.Cpu;
            this.cmd_Processeur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Processeur.ButtonFor = "_CPU";
            this.cmd_Processeur.Device = "Processor";
            this.cmd_Processeur.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Processeur.FlatAppearance.BorderSize = 0;
            this.cmd_Processeur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Processeur.Location = new System.Drawing.Point(0, 80);
            this.cmd_Processeur.Name = "cmd_Processeur";
            this.cmd_Processeur.Size = new System.Drawing.Size(40, 40);
            this.cmd_Processeur.TabIndex = 5;
            this.cmd_Processeur.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Processeur, "Processor");
            this.cmd_Processeur.UseVisualStyleBackColor = true;
            this.cmd_Processeur.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_CarteMere
            // 
            this.cmd_CarteMere.BackgroundImage = global::DiscoveryLight.Properties.Resources.MainBoard;
            this.cmd_CarteMere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_CarteMere.ButtonFor = "_MainBoard";
            this.cmd_CarteMere.Device = "Mainboard";
            this.cmd_CarteMere.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_CarteMere.FlatAppearance.BorderSize = 0;
            this.cmd_CarteMere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_CarteMere.Location = new System.Drawing.Point(0, 40);
            this.cmd_CarteMere.Name = "cmd_CarteMere";
            this.cmd_CarteMere.Size = new System.Drawing.Size(40, 40);
            this.cmd_CarteMere.TabIndex = 4;
            this.cmd_CarteMere.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_CarteMere, "Mainboard");
            this.cmd_CarteMere.UseVisualStyleBackColor = true;
            this.cmd_CarteMere.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cmd_Ordinateur
            // 
            this.cmd_Ordinateur.AccessibleDescription = "";
            this.cmd_Ordinateur.AccessibleName = "";
            this.cmd_Ordinateur.BackgroundImage = global::DiscoveryLight.Properties.Resources.Pc;
            this.cmd_Ordinateur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmd_Ordinateur.ButtonFor = "_BaseHardware";
            this.cmd_Ordinateur.Device = "Base Pc Informations";
            this.cmd_Ordinateur.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmd_Ordinateur.FlatAppearance.BorderSize = 0;
            this.cmd_Ordinateur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_Ordinateur.Location = new System.Drawing.Point(0, 0);
            this.cmd_Ordinateur.Name = "cmd_Ordinateur";
            this.cmd_Ordinateur.Size = new System.Drawing.Size(40, 40);
            this.cmd_Ordinateur.TabIndex = 3;
            this.cmd_Ordinateur.ToolDescription = this.toolTip_Description;
            this.toolTip_Description.SetToolTip(this.cmd_Ordinateur, "Base Pc Informations");
            this.cmd_Ordinateur.UseVisualStyleBackColor = true;
            this.cmd_Ordinateur.Click += new System.EventHandler(this.ButtonClick);
            // 
            // _Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
            this.Size = new System.Drawing.Size(40, 400);
            this.Load += new System.EventHandler(this._Navigation_Load);
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
