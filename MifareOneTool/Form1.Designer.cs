namespace MifareOneTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonCLI = new System.Windows.Forms.Button();
            this.buttonScanCard = new System.Windows.Forms.Button();
            this.buttonListDev = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonMfRead = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonBmfWrite = new System.Windows.Forms.Button();
            this.buttonBmfRead = new System.Windows.Forms.Button();
            this.buttonMfoc = new System.Windows.Forms.Button();
            this.buttonUidWrite = new System.Windows.Forms.Button();
            this.buttonUidFormat = new System.Windows.Forms.Button();
            this.buttonUidReset = new System.Windows.Forms.Button();
            this.buttonMfWrite = new System.Windows.Forms.Button();
            this.buttonSelectKey = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonKill = new System.Windows.Forms.Button();
            this.buttonConSave = new System.Windows.Forms.Button();
            this.buttonConClr = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonGuide = new System.Windows.Forms.Button();
            this.buttonHexTool = new System.Windows.Forms.Button();
            this.buttonMfcuk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.buttonCLI);
            this.groupBox1.Controls.Add(this.buttonScanCard);
            this.groupBox1.Controls.Add(this.buttonListDev);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备控制";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(112, 57);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(67, 15);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "检查更新";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonCLI
            // 
            this.buttonCLI.Location = new System.Drawing.Point(102, 24);
            this.buttonCLI.Name = "buttonCLI";
            this.buttonCLI.Size = new System.Drawing.Size(90, 23);
            this.buttonCLI.TabIndex = 11;
            this.buttonCLI.Text = "手动CLI";
            this.buttonCLI.UseVisualStyleBackColor = true;
            this.buttonCLI.Click += new System.EventHandler(this.buttonCLI_Click);
            // 
            // buttonScanCard
            // 
            this.buttonScanCard.Location = new System.Drawing.Point(6, 53);
            this.buttonScanCard.Name = "buttonScanCard";
            this.buttonScanCard.Size = new System.Drawing.Size(90, 23);
            this.buttonScanCard.TabIndex = 1;
            this.buttonScanCard.Text = "手动扫描";
            this.buttonScanCard.UseVisualStyleBackColor = true;
            this.buttonScanCard.Click += new System.EventHandler(this.buttonScanCard_Click);
            // 
            // buttonListDev
            // 
            this.buttonListDev.Location = new System.Drawing.Point(6, 24);
            this.buttonListDev.Name = "buttonListDev";
            this.buttonListDev.Size = new System.Drawing.Size(90, 23);
            this.buttonListDev.TabIndex = 0;
            this.buttonListDev.Text = "检测";
            this.buttonListDev.UseVisualStyleBackColor = true;
            this.buttonListDev.Click += new System.EventHandler(this.buttonListDev_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox1.Location = new System.Drawing.Point(12, 101);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(623, 293);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Hello,cardman!\n建议点击\"检测\"以加快后续运行速度\n";
            // 
            // buttonMfRead
            // 
            this.buttonMfRead.Location = new System.Drawing.Point(6, 24);
            this.buttonMfRead.Name = "buttonMfRead";
            this.buttonMfRead.Size = new System.Drawing.Size(75, 23);
            this.buttonMfRead.TabIndex = 3;
            this.buttonMfRead.Text = "读卡";
            this.buttonMfRead.UseVisualStyleBackColor = true;
            this.buttonMfRead.Click += new System.EventHandler(this.buttonMfRead_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonBmfWrite);
            this.groupBox2.Controls.Add(this.buttonBmfRead);
            this.groupBox2.Controls.Add(this.buttonMfoc);
            this.groupBox2.Controls.Add(this.buttonUidWrite);
            this.groupBox2.Controls.Add(this.buttonUidFormat);
            this.groupBox2.Controls.Add(this.buttonUidReset);
            this.groupBox2.Controls.Add(this.buttonMfWrite);
            this.groupBox2.Controls.Add(this.buttonSelectKey);
            this.groupBox2.Controls.Add(this.buttonMfRead);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 83);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能";
            // 
            // buttonBmfWrite
            // 
            this.buttonBmfWrite.Location = new System.Drawing.Point(330, 53);
            this.buttonBmfWrite.Name = "buttonBmfWrite";
            this.buttonBmfWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonBmfWrite.TabIndex = 10;
            this.buttonBmfWrite.Text = "UID写";
            this.buttonBmfWrite.UseVisualStyleBackColor = true;
            this.buttonBmfWrite.Click += new System.EventHandler(this.buttonBmfWrite_Click);
            // 
            // buttonBmfRead
            // 
            this.buttonBmfRead.Location = new System.Drawing.Point(330, 24);
            this.buttonBmfRead.Name = "buttonBmfRead";
            this.buttonBmfRead.Size = new System.Drawing.Size(75, 23);
            this.buttonBmfRead.TabIndex = 9;
            this.buttonBmfRead.Text = "UID读";
            this.buttonBmfRead.UseVisualStyleBackColor = true;
            this.buttonBmfRead.Click += new System.EventHandler(this.buttonBmfRead_Click);
            // 
            // buttonMfoc
            // 
            this.buttonMfoc.Location = new System.Drawing.Point(249, 53);
            this.buttonMfoc.Name = "buttonMfoc";
            this.buttonMfoc.Size = new System.Drawing.Size(75, 23);
            this.buttonMfoc.TabIndex = 8;
            this.buttonMfoc.Text = "MFOC";
            this.buttonMfoc.UseVisualStyleBackColor = true;
            this.buttonMfoc.Click += new System.EventHandler(this.buttonMfoc_Click);
            // 
            // buttonUidWrite
            // 
            this.buttonUidWrite.Location = new System.Drawing.Point(168, 53);
            this.buttonUidWrite.Name = "buttonUidWrite";
            this.buttonUidWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonUidWrite.TabIndex = 5;
            this.buttonUidWrite.Text = "UID写号";
            this.buttonUidWrite.UseVisualStyleBackColor = true;
            this.buttonUidWrite.Click += new System.EventHandler(this.buttonUidWrite_Click);
            // 
            // buttonUidFormat
            // 
            this.buttonUidFormat.Location = new System.Drawing.Point(249, 24);
            this.buttonUidFormat.Name = "buttonUidFormat";
            this.buttonUidFormat.Size = new System.Drawing.Size(75, 23);
            this.buttonUidFormat.TabIndex = 7;
            this.buttonUidFormat.Text = "UID全格";
            this.buttonUidFormat.UseVisualStyleBackColor = true;
            this.buttonUidFormat.Click += new System.EventHandler(this.buttonUidFormat_Click);
            // 
            // buttonUidReset
            // 
            this.buttonUidReset.Location = new System.Drawing.Point(168, 24);
            this.buttonUidReset.Name = "buttonUidReset";
            this.buttonUidReset.Size = new System.Drawing.Size(75, 23);
            this.buttonUidReset.TabIndex = 6;
            this.buttonUidReset.Text = "UID重置";
            this.buttonUidReset.UseVisualStyleBackColor = true;
            this.buttonUidReset.Click += new System.EventHandler(this.buttonUidReset_Click);
            // 
            // buttonMfWrite
            // 
            this.buttonMfWrite.Location = new System.Drawing.Point(87, 24);
            this.buttonMfWrite.Name = "buttonMfWrite";
            this.buttonMfWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonMfWrite.TabIndex = 5;
            this.buttonMfWrite.Text = "写卡";
            this.buttonMfWrite.UseVisualStyleBackColor = true;
            this.buttonMfWrite.Click += new System.EventHandler(this.buttonMfWrite_Click);
            // 
            // buttonSelectKey
            // 
            this.buttonSelectKey.Location = new System.Drawing.Point(6, 53);
            this.buttonSelectKey.Name = "buttonSelectKey";
            this.buttonSelectKey.Size = new System.Drawing.Size(156, 23);
            this.buttonSelectKey.TabIndex = 4;
            this.buttonSelectKey.Text = "选择key.mfd";
            this.buttonSelectKey.UseVisualStyleBackColor = true;
            this.buttonSelectKey.Click += new System.EventHandler(this.buttonSelectKey_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonKill);
            this.groupBox3.Controls.Add(this.buttonConSave);
            this.groupBox3.Controls.Add(this.buttonConClr);
            this.groupBox3.Location = new System.Drawing.Point(641, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 83);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "运行/终端";
            // 
            // buttonKill
            // 
            this.buttonKill.Location = new System.Drawing.Point(6, 53);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(75, 23);
            this.buttonKill.TabIndex = 2;
            this.buttonKill.Text = "停止运行";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // buttonConSave
            // 
            this.buttonConSave.Location = new System.Drawing.Point(87, 24);
            this.buttonConSave.Name = "buttonConSave";
            this.buttonConSave.Size = new System.Drawing.Size(75, 23);
            this.buttonConSave.TabIndex = 1;
            this.buttonConSave.Text = "保存日志";
            this.buttonConSave.UseVisualStyleBackColor = true;
            this.buttonConSave.Click += new System.EventHandler(this.buttonConSave_Click);
            // 
            // buttonConClr
            // 
            this.buttonConClr.Location = new System.Drawing.Point(6, 24);
            this.buttonConClr.Name = "buttonConClr";
            this.buttonConClr.Size = new System.Drawing.Size(75, 23);
            this.buttonConClr.TabIndex = 0;
            this.buttonConClr.Text = "清空终端";
            this.buttonConClr.UseVisualStyleBackColor = true;
            this.buttonConClr.Click += new System.EventHandler(this.buttonConClr_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonMfcuk);
            this.groupBox4.Controls.Add(this.buttonHexTool);
            this.groupBox4.Controls.Add(this.buttonGuide);
            this.groupBox4.Location = new System.Drawing.Point(641, 101);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 293);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "工具";
            // 
            // buttonGuide
            // 
            this.buttonGuide.Enabled = false;
            this.buttonGuide.Location = new System.Drawing.Point(6, 24);
            this.buttonGuide.Name = "buttonGuide";
            this.buttonGuide.Size = new System.Drawing.Size(156, 45);
            this.buttonGuide.TabIndex = 0;
            this.buttonGuide.Text = "向导模式";
            this.buttonGuide.UseVisualStyleBackColor = true;
            this.buttonGuide.Click += new System.EventHandler(this.buttonGuide_Click);
            // 
            // buttonHexTool
            // 
            this.buttonHexTool.Location = new System.Drawing.Point(6, 75);
            this.buttonHexTool.Name = "buttonHexTool";
            this.buttonHexTool.Size = new System.Drawing.Size(156, 45);
            this.buttonHexTool.TabIndex = 1;
            this.buttonHexTool.Text = "Hex工具";
            this.buttonHexTool.UseVisualStyleBackColor = true;
            // 
            // buttonMfcuk
            // 
            this.buttonMfcuk.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonMfcuk.Location = new System.Drawing.Point(6, 126);
            this.buttonMfcuk.Name = "buttonMfcuk";
            this.buttonMfcuk.Size = new System.Drawing.Size(156, 45);
            this.buttonMfcuk.TabIndex = 3;
            this.buttonMfcuk.Text = "全加密密钥恢复\r\nMFCUK";
            this.buttonMfcuk.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 406);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MifareOne Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonScanCard;
        private System.Windows.Forms.Button buttonListDev;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonMfRead;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonUidWrite;
        private System.Windows.Forms.Button buttonUidFormat;
        private System.Windows.Forms.Button buttonUidReset;
        private System.Windows.Forms.Button buttonMfWrite;
        private System.Windows.Forms.Button buttonSelectKey;
        private System.Windows.Forms.Button buttonCLI;
        private System.Windows.Forms.Button buttonBmfWrite;
        private System.Windows.Forms.Button buttonBmfRead;
        private System.Windows.Forms.Button buttonMfoc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonConSave;
        private System.Windows.Forms.Button buttonConClr;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonGuide;
        private System.Windows.Forms.Button buttonHexTool;
        private System.Windows.Forms.Button buttonMfcuk;
    }
}

