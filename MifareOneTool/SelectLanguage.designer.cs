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
            this.rbSelected.AccessibleDescription = "";
            this.rbSelected.AccessibleName = "";
            this.rbSelected.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbSelected.Location = new System.Drawing.Point(4, 40);
            this.rbSelected.Name = "rbSelected";
            this.rbSelected.Size = new System.Drawing.Size(209, 20);
            this.rbSelected.TabIndex = 2;
            this.rbSelected.Text = "Use the selected language";
            this.rbSelected.CheckedChanged += new System.EventHandler(this.OnStartup_CheckedChanged);
            // 
            // rbShow
            // 
            this.rbShow.AccessibleDescription = "";
            this.rbShow.AccessibleName = "";
            this.rbShow.Checked = true;
            this.rbShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbShow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbShow.Location = new System.Drawing.Point(4, 20);
            this.rbShow.Name = "rbShow";
            this.rbShow.Size = new System.Drawing.Size(209, 20);
            this.rbShow.TabIndex = 1;
            this.rbShow.TabStop = true;
            this.rbShow.Text = "Show this form again";
            this.rbShow.CheckedChanged += new System.EventHandler(this.OnStartup_CheckedChanged);
            // 
            // lblStartup
            // 
            this.lblStartup.AccessibleDescription = "";
            this.lblStartup.AccessibleName = "";
            this.lblStartup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStartup.Location = new System.Drawing.Point(4, 3);
            this.lblStartup.Name = "lblStartup";
            this.lblStartup.Size = new System.Drawing.Size(209, 17);
            this.lblStartup.TabIndex = 0;
            this.lblStartup.Text = "Next time ...";
            // 
            // rbDefault
            // 
            this.rbDefault.AccessibleDescription = "";
            this.rbDefault.AccessibleName = "";
            this.rbDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbDefault.Location = new System.Drawing.Point(4, 60);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(209, 20);
            this.rbDefault.TabIndex = 3;
            this.rbDefault.Text = "Use the default language";
            this.rbDefault.CheckedChanged += new System.EventHandler(this.OnStartup_CheckedChanged);
            // 
            // lstCultures
            // 
            this.lstCultures.AccessibleDescription = "";
            this.lstCultures.AccessibleName = "";
            this.lstCultures.DisplayMember = "NativeName";
            this.lstCultures.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lstCultures.IntegralHeight = false;
            this.lstCultures.ItemHeight = 16;
            this.lstCultures.Location = new System.Drawing.Point(4, 4);
            this.lstCultures.Name = "lstCultures";
            this.lstCultures.Size = new System.Drawing.Size(264, 220);
            this.lstCultures.TabIndex = 7;
            this.lstCultures.DoubleClick += new System.EventHandler(this.btOK_Click);
            // 
            // btOK
            // 
            this.btOK.AccessibleDescription = "";
            this.btOK.AccessibleName = "";
            this.btOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btOK.Location = new System.Drawing.Point(180, 316);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(90, 32);
            this.btOK.TabIndex = 8;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // Panel1
            // 
            this.Panel1.AccessibleDescription = "";
            this.Panel1.AccessibleName = "";
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.rbDefault);
            this.Panel1.Controls.Add(this.rbSelected);
            this.Panel1.Controls.Add(this.rbShow);
            this.Panel1.Controls.Add(this.lblStartup);
            this.Panel1.Location = new System.Drawing.Point(4, 228);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(264, 84);
            this.Panel1.TabIndex = 9;
            // 
            // SelectLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 352);
            this.Controls.Add(this.lstCultures);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectLanguage";
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