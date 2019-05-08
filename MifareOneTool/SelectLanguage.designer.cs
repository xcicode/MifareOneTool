namespace MultiLang
{
    partial class SelectLanguage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectLanguage));
            this.rbSelected = new System.Windows.Forms.RadioButton();
            this.rbShow = new System.Windows.Forms.RadioButton();
            this.lblStartup = new System.Windows.Forms.Label();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.lstCultures = new System.Windows.Forms.ListBox();
            this.btOK = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbSelected
            // 
            resources.ApplyResources(this.rbSelected, "rbSelected");
            this.rbSelected.Name = "rbSelected";
            this.rbSelected.CheckedChanged += new System.EventHandler(this.OnStartup_CheckedChanged);
            // 
            // rbShow
            // 
            resources.ApplyResources(this.rbShow, "rbShow");
            this.rbShow.Checked = true;
            this.rbShow.Name = "rbShow";
            this.rbShow.TabStop = true;
            this.rbShow.CheckedChanged += new System.EventHandler(this.OnStartup_CheckedChanged);
            // 
            // lblStartup
            // 
            resources.ApplyResources(this.lblStartup, "lblStartup");
            this.lblStartup.Name = "lblStartup";
            // 
            // rbDefault
            // 
            resources.ApplyResources(this.rbDefault, "rbDefault");
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.CheckedChanged += new System.EventHandler(this.OnStartup_CheckedChanged);
            // 
            // lstCultures
            // 
            resources.ApplyResources(this.lstCultures, "lstCultures");
            this.lstCultures.DisplayMember = "NativeName";
            this.lstCultures.Name = "lstCultures";
            this.lstCultures.DoubleClick += new System.EventHandler(this.btOK_Click);
            // 
            // btOK
            // 
            resources.ApplyResources(this.btOK, "btOK");
            this.btOK.Name = "btOK";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // Panel1
            // 
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.rbDefault);
            this.Panel1.Controls.Add(this.rbSelected);
            this.Panel1.Controls.Add(this.rbShow);
            this.Panel1.Controls.Add(this.lblStartup);
            this.Panel1.Name = "Panel1";
            // 
            // SelectLanguage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstCultures);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectLanguage";
            this.Load += new System.EventHandler(this.SelectLanguage_Load);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RadioButton rbSelected;
        internal System.Windows.Forms.RadioButton rbShow;
        internal System.Windows.Forms.Label lblStartup;
        internal System.Windows.Forms.RadioButton rbDefault;
        internal System.Windows.Forms.ListBox lstCultures;
        internal System.Windows.Forms.Button btOK;
        internal System.Windows.Forms.Panel Panel1;
    }
}