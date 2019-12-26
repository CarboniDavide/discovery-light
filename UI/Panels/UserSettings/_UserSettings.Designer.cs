using DiscoveryLight.UI.Components;

namespace DiscoveryLight.UI.Panels.UserSettings
{
    partial class _UserSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_UserSettings));
            this.lbl_TitleLanguage = new System.Windows.Forms.Label();
            this.lbl_It = new System.Windows.Forms.Label();
            this.lbl_Fr = new System.Windows.Forms.Label();
            this.lbl_Eng = new System.Windows.Forms.Label();
            this.rdb_It = new DiscoveryLight.UI.Components.LanguageLinkRadio();
            this.rdb_Eng = new DiscoveryLight.UI.Components.LanguageLinkRadio();
            this.rdb_Fr = new DiscoveryLight.UI.Components.LanguageLinkRadio();
            this.lbl_TitleDivers = new System.Windows.Forms.Label();
            this.rdb_Germ = new DiscoveryLight.UI.Components.LanguageLinkRadio();
            this.lbl_Germ = new System.Windows.Forms.Label();
            this.lbl_Freq_Title = new System.Windows.Forms.Label();
            this.nmr_Freq = new System.Windows.Forms.NumericUpDown();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.anm_PanelSet = new WinformComponents.AnimationComponents();
            this.pic_Divisor_002 = new System.Windows.Forms.PictureBox();
            this.pic_Divisor_001 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmd_Apply = new System.Windows.Forms.Button();
            this.lbl_InfoRestart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Freq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TitleLanguage
            // 
            resources.ApplyResources(this.lbl_TitleLanguage, "lbl_TitleLanguage");
            this.lbl_TitleLanguage.Name = "lbl_TitleLanguage";
            // 
            // lbl_It
            // 
            resources.ApplyResources(this.lbl_It, "lbl_It");
            this.lbl_It.Name = "lbl_It";
            // 
            // lbl_Fr
            // 
            resources.ApplyResources(this.lbl_Fr, "lbl_Fr");
            this.lbl_Fr.Name = "lbl_Fr";
            // 
            // lbl_Eng
            // 
            resources.ApplyResources(this.lbl_Eng, "lbl_Eng");
            this.lbl_Eng.Name = "lbl_Eng";
            // 
            // rdb_It
            // 
            resources.ApplyResources(this.rdb_It, "rdb_It");
            this.rdb_It.Language = "it-IT";
            this.rdb_It.Name = "rdb_It";
            this.rdb_It.RadioFor = "Italiano";
            this.rdb_It.TabStop = true;
            this.rdb_It.UseVisualStyleBackColor = true;
            this.rdb_It.CheckedChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // rdb_Eng
            // 
            resources.ApplyResources(this.rdb_Eng, "rdb_Eng");
            this.rdb_Eng.Language = "en-EN";
            this.rdb_Eng.Name = "rdb_Eng";
            this.rdb_Eng.RadioFor = "English";
            this.rdb_Eng.TabStop = true;
            this.rdb_Eng.UseVisualStyleBackColor = true;
            this.rdb_Eng.CheckedChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // rdb_Fr
            // 
            resources.ApplyResources(this.rdb_Fr, "rdb_Fr");
            this.rdb_Fr.Language = "fr-FR";
            this.rdb_Fr.Name = "rdb_Fr";
            this.rdb_Fr.RadioFor = "Français";
            this.rdb_Fr.TabStop = true;
            this.rdb_Fr.UseVisualStyleBackColor = true;
            this.rdb_Fr.CheckedChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // lbl_TitleDivers
            // 
            resources.ApplyResources(this.lbl_TitleDivers, "lbl_TitleDivers");
            this.lbl_TitleDivers.Name = "lbl_TitleDivers";
            // 
            // rdb_Germ
            // 
            resources.ApplyResources(this.rdb_Germ, "rdb_Germ");
            this.rdb_Germ.Language = "de-DE";
            this.rdb_Germ.Name = "rdb_Germ";
            this.rdb_Germ.RadioFor = "German";
            this.rdb_Germ.TabStop = true;
            this.rdb_Germ.UseVisualStyleBackColor = true;
            this.rdb_Germ.CheckedChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // lbl_Germ
            // 
            resources.ApplyResources(this.lbl_Germ, "lbl_Germ");
            this.lbl_Germ.Name = "lbl_Germ";
            // 
            // lbl_Freq_Title
            // 
            resources.ApplyResources(this.lbl_Freq_Title, "lbl_Freq_Title");
            this.lbl_Freq_Title.Name = "lbl_Freq_Title";
            // 
            // nmr_Freq
            // 
            this.nmr_Freq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.nmr_Freq, "nmr_Freq");
            this.nmr_Freq.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nmr_Freq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_Freq.Name = "nmr_Freq";
            this.nmr_Freq.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmr_Freq.ValueChanged += new System.EventHandler(this.nmr_Freq_ValueChanged);
            // 
            // cmd_Close
            // 
            resources.ApplyResources(this.cmd_Close, "cmd_Close");
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // anm_PanelSet
            // 
            this.anm_PanelSet.Animation = WinformComponents.AnimationComponents.ANIMATION.Dinamic;
            this.anm_PanelSet.CloseBearingSize = 5;
            this.anm_PanelSet.CloseSpeed = 10;
            this.anm_PanelSet.CloseStep = 25;
            this.anm_PanelSet.Is_Opened = false;
            this.anm_PanelSet.Is_Operating = false;
            this.anm_PanelSet.Magnetic = false;
            this.anm_PanelSet.Object = this;
            this.anm_PanelSet.OnLoad = WinformComponents.AnimationComponents.ON_LOAD.Is_Closed;
            this.anm_PanelSet.OpenBearingSize = 5;
            this.anm_PanelSet.OpenSpeed = 10;
            this.anm_PanelSet.OpenStep = 20;
            this.anm_PanelSet.Position = WinformComponents.AnimationComponents.POSITION.In_The_Left;
            this.anm_PanelSet.Size = 265;
            // 
            // pic_Divisor_002
            // 
            this.pic_Divisor_002.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.pic_Divisor_002, "pic_Divisor_002");
            this.pic_Divisor_002.Name = "pic_Divisor_002";
            this.pic_Divisor_002.TabStop = false;
            // 
            // pic_Divisor_001
            // 
            this.pic_Divisor_001.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.pic_Divisor_001, "pic_Divisor_001");
            this.pic_Divisor_001.Name = "pic_Divisor_001";
            this.pic_Divisor_001.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // cmd_Apply
            // 
            resources.ApplyResources(this.cmd_Apply, "cmd_Apply");
            this.cmd_Apply.Name = "cmd_Apply";
            this.cmd_Apply.UseVisualStyleBackColor = true;
            this.cmd_Apply.Click += new System.EventHandler(this.cmd_Apply_Click);
            // 
            // lbl_InfoRestart
            // 
            this.lbl_InfoRestart.BackColor = System.Drawing.Color.Bisque;
            resources.ApplyResources(this.lbl_InfoRestart, "lbl_InfoRestart");
            this.lbl_InfoRestart.Name = "lbl_InfoRestart";
            // 
            // _UserSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.lbl_InfoRestart);
            this.Controls.Add(this.cmd_Apply);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_TitleDivers);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.nmr_Freq);
            this.Controls.Add(this.lbl_Freq_Title);
            this.Controls.Add(this.rdb_Germ);
            this.Controls.Add(this.lbl_Germ);
            this.Controls.Add(this.pic_Divisor_002);
            this.Controls.Add(this.rdb_Fr);
            this.Controls.Add(this.rdb_Eng);
            this.Controls.Add(this.rdb_It);
            this.Controls.Add(this.lbl_Eng);
            this.Controls.Add(this.lbl_Fr);
            this.Controls.Add(this.lbl_It);
            this.Controls.Add(this.lbl_TitleLanguage);
            this.Controls.Add(this.pic_Divisor_001);
            this.DoubleBuffered = true;
            this.Name = "_UserSettings";
            this.Load += new System.EventHandler(this._UserSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmr_Freq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Divisor_001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TitleLanguage;
        private System.Windows.Forms.Label lbl_It;
        private System.Windows.Forms.Label lbl_Fr;
        private System.Windows.Forms.Label lbl_Eng;
        private LanguageLinkRadio rdb_It;
        private LanguageLinkRadio rdb_Eng;
        private LanguageLinkRadio rdb_Fr;
        private System.Windows.Forms.PictureBox pic_Divisor_001;
        private System.Windows.Forms.Label lbl_TitleDivers;
        private System.Windows.Forms.PictureBox pic_Divisor_002;
        private LanguageLinkRadio rdb_Germ;
        private System.Windows.Forms.Label lbl_Germ;
        private System.Windows.Forms.Label lbl_Freq_Title;
        private System.Windows.Forms.NumericUpDown nmr_Freq;
        private System.Windows.Forms.Button cmd_Close;
        public WinformComponents.AnimationComponents anm_PanelSet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmd_Apply;
        private System.Windows.Forms.Label lbl_InfoRestart;
    }
}
