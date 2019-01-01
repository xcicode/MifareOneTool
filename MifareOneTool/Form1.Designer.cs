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
            this.components = new System.ComponentModel.Container();
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
            this.buttonMfcuk = new System.Windows.Forms.Button();
            this.buttonHexTool = new System.Windows.Forms.Button();
            this.buttonTool1 = new System.Windows.Forms.Button();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonCmfWrite = new System.Windows.Forms.Button();
            this.buttonLockUfuid = new System.Windows.Forms.Button();
            this.buttonMfFormat = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonEMfoc = new System.Windows.Forms.Button();
            this.buttonEMfRead = new System.Windows.Forms.Button();
            this.buttonECmfoc = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonEscan = new System.Windows.Forms.Button();
            this.buttoEScanCard = new System.Windows.Forms.Button();
            this.buttonESelectKey = new System.Windows.Forms.Button();
            this.buttonEUpdate = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonECuidWrite = new System.Windows.Forms.Button();
            this.buttonEUIDWrite = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonEMfWrite = new System.Windows.Forms.Button();
            this.buttonEAdv = new System.Windows.Forms.Button();
            this.buttonEnAcr122u = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.buttonCLI);
            this.groupBox1.Controls.Add(this.buttonScanCard);
            this.groupBox1.Controls.Add(this.buttonListDev);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
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
            this.buttonCLI.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.buttonScanCard.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.buttonListDev.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.richTextBox1.Location = new System.Drawing.Point(12, 219);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(623, 290);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Hello,cardman!\n建议点击\"检测\"以加快后续运行速度\n";
            // 
            // buttonMfRead
            // 
            this.buttonMfRead.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonMfRead.Location = new System.Drawing.Point(6, 24);
            this.buttonMfRead.Name = "buttonMfRead";
            this.buttonMfRead.Size = new System.Drawing.Size(75, 23);
            this.buttonMfRead.TabIndex = 3;
            this.buttonMfRead.Text = "读M1卡";
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
            this.groupBox2.Location = new System.Drawing.Point(209, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 83);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功能";
            // 
            // buttonBmfWrite
            // 
            this.buttonBmfWrite.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.buttonBmfRead.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.buttonMfoc.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonMfoc.Location = new System.Drawing.Point(249, 53);
            this.buttonMfoc.Name = "buttonMfoc";
            this.buttonMfoc.Size = new System.Drawing.Size(75, 23);
            this.buttonMfoc.TabIndex = 8;
            this.buttonMfoc.Text = "MFOC读";
            this.toolTipHelp.SetToolTip(this.buttonMfoc, "按住Ctrl点击该按钮可添加已知密钥。");
            this.buttonMfoc.UseVisualStyleBackColor = true;
            this.buttonMfoc.Click += new System.EventHandler(this.buttonMfoc_Click);
            // 
            // buttonUidWrite
            // 
            this.buttonUidWrite.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.buttonUidFormat.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.buttonUidReset.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.buttonMfWrite.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonMfWrite.Location = new System.Drawing.Point(87, 24);
            this.buttonMfWrite.Name = "buttonMfWrite";
            this.buttonMfWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonMfWrite.TabIndex = 5;
            this.buttonMfWrite.Text = "写M1卡";
            this.buttonMfWrite.UseVisualStyleBackColor = true;
            this.buttonMfWrite.Click += new System.EventHandler(this.buttonMfWrite_Click);
            // 
            // buttonSelectKey
            // 
            this.buttonSelectKey.Font = new System.Drawing.Font("宋体", 8.5F);
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
            this.groupBox3.Location = new System.Drawing.Point(458, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 83);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "运行/终端";
            // 
            // buttonKill
            // 
            this.buttonKill.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonKill.Location = new System.Drawing.Point(6, 53);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(75, 23);
            this.buttonKill.TabIndex = 2;
            this.buttonKill.Text = "停运行";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // buttonConSave
            // 
            this.buttonConSave.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonConSave.Location = new System.Drawing.Point(87, 24);
            this.buttonConSave.Name = "buttonConSave";
            this.buttonConSave.Size = new System.Drawing.Size(75, 23);
            this.buttonConSave.TabIndex = 1;
            this.buttonConSave.Text = "存日志";
            this.buttonConSave.UseVisualStyleBackColor = true;
            this.buttonConSave.Click += new System.EventHandler(this.buttonConSave_Click);
            // 
            // buttonConClr
            // 
            this.buttonConClr.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonConClr.Location = new System.Drawing.Point(6, 24);
            this.buttonConClr.Name = "buttonConClr";
            this.buttonConClr.Size = new System.Drawing.Size(75, 23);
            this.buttonConClr.TabIndex = 0;
            this.buttonConClr.Text = "清终端";
            this.buttonConClr.UseVisualStyleBackColor = true;
            this.buttonConClr.Click += new System.EventHandler(this.buttonConClr_Click);
            // 
            // buttonMfcuk
            // 
            this.buttonMfcuk.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonMfcuk.Location = new System.Drawing.Point(122, 24);
            this.buttonMfcuk.Name = "buttonMfcuk";
            this.buttonMfcuk.Size = new System.Drawing.Size(70, 52);
            this.buttonMfcuk.TabIndex = 3;
            this.buttonMfcuk.Text = "MFCUK\r\n爆密钥";
            this.buttonMfcuk.UseVisualStyleBackColor = true;
            this.buttonMfcuk.Click += new System.EventHandler(this.buttonMfcuk_Click);
            // 
            // buttonHexTool
            // 
            this.buttonHexTool.Enabled = false;
            this.buttonHexTool.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonHexTool.Location = new System.Drawing.Point(6, 53);
            this.buttonHexTool.Name = "buttonHexTool";
            this.buttonHexTool.Size = new System.Drawing.Size(110, 23);
            this.buttonHexTool.TabIndex = 1;
            this.buttonHexTool.Text = "Hex工具";
            this.buttonHexTool.UseVisualStyleBackColor = true;
            // 
            // buttonTool1
            // 
            this.buttonTool1.Enabled = false;
            this.buttonTool1.Font = new System.Drawing.Font("宋体", 8.5F);
            this.buttonTool1.Location = new System.Drawing.Point(6, 24);
            this.buttonTool1.Name = "buttonTool1";
            this.buttonTool1.Size = new System.Drawing.Size(110, 23);
            this.buttonTool1.TabIndex = 0;
            this.buttonTool1.Text = "key.mfd工具";
            this.buttonTool1.UseVisualStyleBackColor = true;
            // 
            // toolTipHelp
            // 
            this.toolTipHelp.AutoPopDelay = 2000;
            this.toolTipHelp.InitialDelay = 500;
            this.toolTipHelp.ReshowDelay = 100;
            this.toolTipHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipHelp.ToolTipTitle = "提示";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonEnAcr122u);
            this.groupBox4.Controls.Add(this.buttonMfFormat);
            this.groupBox4.Controls.Add(this.buttonLockUfuid);
            this.groupBox4.Controls.Add(this.buttonCmfWrite);
            this.groupBox4.Controls.Add(this.buttonMfcuk);
            this.groupBox4.Controls.Add(this.buttonTool1);
            this.groupBox4.Controls.Add(this.buttonHexTool);
            this.groupBox4.Location = new System.Drawing.Point(3, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(449, 83);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "工具";
            // 
            // buttonCmfWrite
            // 
            this.buttonCmfWrite.Location = new System.Drawing.Point(198, 23);
            this.buttonCmfWrite.Name = "buttonCmfWrite";
            this.buttonCmfWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonCmfWrite.TabIndex = 4;
            this.buttonCmfWrite.Text = "CUID写";
            this.buttonCmfWrite.UseVisualStyleBackColor = true;
            this.buttonCmfWrite.Click += new System.EventHandler(this.buttonCmfWrite_Click);
            // 
            // buttonLockUfuid
            // 
            this.buttonLockUfuid.Location = new System.Drawing.Point(198, 52);
            this.buttonLockUfuid.Name = "buttonLockUfuid";
            this.buttonLockUfuid.Size = new System.Drawing.Size(75, 23);
            this.buttonLockUfuid.TabIndex = 5;
            this.buttonLockUfuid.Text = "锁Ufuid";
            this.buttonLockUfuid.UseVisualStyleBackColor = true;
            this.buttonLockUfuid.Click += new System.EventHandler(this.buttonLockUfuid_Click);
            // 
            // buttonMfFormat
            // 
            this.buttonMfFormat.Location = new System.Drawing.Point(279, 23);
            this.buttonMfFormat.Name = "buttonMfFormat";
            this.buttonMfFormat.Size = new System.Drawing.Size(75, 23);
            this.buttonMfFormat.TabIndex = 6;
            this.buttonMfFormat.Text = "清M1卡";
            this.buttonMfFormat.UseVisualStyleBackColor = true;
            this.buttonMfFormat.Click += new System.EventHandler(this.buttonMfFormat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 212);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "高级操作模式";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonEAdv);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "复制卡模式";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonESelectKey);
            this.groupBox5.Controls.Add(this.buttonECmfoc);
            this.groupBox5.Controls.Add(this.buttonEMfRead);
            this.groupBox5.Controls.Add(this.buttonEMfoc);
            this.groupBox5.Location = new System.Drawing.Point(140, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(128, 171);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "[2]读取原卡";
            // 
            // buttonEMfoc
            // 
            this.buttonEMfoc.Location = new System.Drawing.Point(6, 25);
            this.buttonEMfoc.Name = "buttonEMfoc";
            this.buttonEMfoc.Size = new System.Drawing.Size(116, 25);
            this.buttonEMfoc.TabIndex = 0;
            this.buttonEMfoc.Text = "[1]半加密破解";
            this.buttonEMfoc.UseVisualStyleBackColor = true;
            this.buttonEMfoc.Click += new System.EventHandler(this.buttonEMfoc_Click);
            // 
            // buttonEMfRead
            // 
            this.buttonEMfRead.Location = new System.Drawing.Point(6, 140);
            this.buttonEMfRead.Name = "buttonEMfRead";
            this.buttonEMfRead.Size = new System.Drawing.Size(116, 25);
            this.buttonEMfRead.TabIndex = 1;
            this.buttonEMfRead.Text = "已知密钥读";
            this.buttonEMfRead.UseVisualStyleBackColor = true;
            this.buttonEMfRead.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonECmfoc
            // 
            this.buttonECmfoc.Location = new System.Drawing.Point(6, 80);
            this.buttonECmfoc.Name = "buttonECmfoc";
            this.buttonECmfoc.Size = new System.Drawing.Size(116, 25);
            this.buttonECmfoc.TabIndex = 2;
            this.buttonECmfoc.Text = "知一密破解";
            this.buttonECmfoc.UseVisualStyleBackColor = true;
            this.buttonECmfoc.Click += new System.EventHandler(this.buttonECmfoc_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonEUpdate);
            this.groupBox6.Controls.Add(this.buttoEScanCard);
            this.groupBox6.Controls.Add(this.buttonEscan);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(128, 171);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "[1]检测";
            // 
            // buttonEscan
            // 
            this.buttonEscan.Location = new System.Drawing.Point(6, 25);
            this.buttonEscan.Name = "buttonEscan";
            this.buttonEscan.Size = new System.Drawing.Size(116, 25);
            this.buttonEscan.TabIndex = 0;
            this.buttonEscan.Text = "[1]检测连接";
            this.buttonEscan.UseVisualStyleBackColor = true;
            this.buttonEscan.Click += new System.EventHandler(this.buttonEscan_Click);
            // 
            // buttoEScanCard
            // 
            this.buttoEScanCard.Location = new System.Drawing.Point(6, 56);
            this.buttoEScanCard.Name = "buttoEScanCard";
            this.buttoEScanCard.Size = new System.Drawing.Size(116, 25);
            this.buttoEScanCard.TabIndex = 1;
            this.buttoEScanCard.Text = "[2]扫描卡片";
            this.buttoEScanCard.UseVisualStyleBackColor = true;
            this.buttoEScanCard.Click += new System.EventHandler(this.buttoEScanCard_Click);
            // 
            // buttonESelectKey
            // 
            this.buttonESelectKey.Location = new System.Drawing.Point(6, 109);
            this.buttonESelectKey.Name = "buttonESelectKey";
            this.buttonESelectKey.Size = new System.Drawing.Size(116, 25);
            this.buttonESelectKey.TabIndex = 2;
            this.buttonESelectKey.Text = "加载密钥…";
            this.buttonESelectKey.UseVisualStyleBackColor = true;
            this.buttonESelectKey.Click += new System.EventHandler(this.buttonESelectKey_Click);
            // 
            // buttonEUpdate
            // 
            this.buttonEUpdate.Location = new System.Drawing.Point(6, 140);
            this.buttonEUpdate.Name = "buttonEUpdate";
            this.buttonEUpdate.Size = new System.Drawing.Size(116, 25);
            this.buttonEUpdate.TabIndex = 4;
            this.buttonEUpdate.Text = "检查M1T更新";
            this.buttonEUpdate.UseVisualStyleBackColor = true;
            this.buttonEUpdate.Click += new System.EventHandler(this.buttonEUpdate_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonECuidWrite);
            this.groupBox7.Controls.Add(this.buttonEUIDWrite);
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Controls.Add(this.buttonEMfWrite);
            this.groupBox7.Location = new System.Drawing.Point(274, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(128, 171);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "[3]写入新卡";
            // 
            // buttonECuidWrite
            // 
            this.buttonECuidWrite.Location = new System.Drawing.Point(6, 56);
            this.buttonECuidWrite.Name = "buttonECuidWrite";
            this.buttonECuidWrite.Size = new System.Drawing.Size(116, 25);
            this.buttonECuidWrite.TabIndex = 2;
            this.buttonECuidWrite.Text = "写C/FUID卡";
            this.buttonECuidWrite.UseVisualStyleBackColor = true;
            this.buttonECuidWrite.Click += new System.EventHandler(this.buttonECuidWrite_Click);
            // 
            // buttonEUIDWrite
            // 
            this.buttonEUIDWrite.Location = new System.Drawing.Point(6, 25);
            this.buttonEUIDWrite.Name = "buttonEUIDWrite";
            this.buttonEUIDWrite.Size = new System.Drawing.Size(116, 25);
            this.buttonEUIDWrite.TabIndex = 2;
            this.buttonEUIDWrite.Text = "写(UF)UID卡";
            this.buttonEUIDWrite.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 25);
            this.button4.TabIndex = 1;
            this.button4.Text = "锁UFUID卡";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonEMfWrite
            // 
            this.buttonEMfWrite.Location = new System.Drawing.Point(6, 140);
            this.buttonEMfWrite.Name = "buttonEMfWrite";
            this.buttonEMfWrite.Size = new System.Drawing.Size(116, 25);
            this.buttonEMfWrite.TabIndex = 0;
            this.buttonEMfWrite.Text = "写入普通卡";
            this.buttonEMfWrite.UseVisualStyleBackColor = true;
            this.buttonEMfWrite.Click += new System.EventHandler(this.buttonEMfWrite_Click);
            // 
            // buttonEAdv
            // 
            this.buttonEAdv.Location = new System.Drawing.Point(408, 16);
            this.buttonEAdv.Name = "buttonEAdv";
            this.buttonEAdv.Size = new System.Drawing.Size(218, 40);
            this.buttonEAdv.TabIndex = 4;
            this.buttonEAdv.Text = "点此进入高级模式>>>";
            this.buttonEAdv.UseVisualStyleBackColor = true;
            this.buttonEAdv.Click += new System.EventHandler(this.buttonEAdv_Click);
            // 
            // buttonEnAcr122u
            // 
            this.buttonEnAcr122u.Location = new System.Drawing.Point(279, 52);
            this.buttonEnAcr122u.Name = "buttonEnAcr122u";
            this.buttonEnAcr122u.Size = new System.Drawing.Size(164, 23);
            this.buttonEnAcr122u.TabIndex = 7;
            this.buttonEnAcr122u.Text = "启用ACR122U支持";
            this.buttonEnAcr122u.UseVisualStyleBackColor = true;
            this.buttonEnAcr122u.Click += new System.EventHandler(this.buttonEnAcr122u_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.richTextBox1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonTool1;
        private System.Windows.Forms.Button buttonHexTool;
        private System.Windows.Forms.Button buttonMfcuk;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonLockUfuid;
        private System.Windows.Forms.Button buttonCmfWrite;
        private System.Windows.Forms.Button buttonMfFormat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonECmfoc;
        private System.Windows.Forms.Button buttonEMfRead;
        private System.Windows.Forms.Button buttonEMfoc;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonEscan;
        private System.Windows.Forms.Button buttoEScanCard;
        private System.Windows.Forms.Button buttonESelectKey;
        private System.Windows.Forms.Button buttonEUpdate;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonECuidWrite;
        private System.Windows.Forms.Button buttonEUIDWrite;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonEMfWrite;
        private System.Windows.Forms.Button buttonEAdv;
        private System.Windows.Forms.Button buttonEnAcr122u;
    }
}

