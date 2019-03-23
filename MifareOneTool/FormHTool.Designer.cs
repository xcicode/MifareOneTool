namespace MifareOneTool
{
    partial class FormHTool
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改UIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.检查全卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查并纠正全卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.导入MCT格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出为MCT格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出密钥字典ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.列出全卡密钥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSaveSectorEdit = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.keyBEdit = new System.Windows.Forms.TextBox();
            this.keyAEdit = new System.Windows.Forms.TextBox();
            this.block2Edit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.block1Edit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.block0Edit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurSec = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.s50BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s50BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.工具ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(628, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改UIDToolStripMenuItem,
            this.toolStripSeparator2,
            this.检查全卡ToolStripMenuItem,
            this.检查并纠正全卡ToolStripMenuItem,
            this.toolStripSeparator3,
            this.导入MCT格式ToolStripMenuItem,
            this.导出为MCT格式ToolStripMenuItem,
            this.导出密钥字典ToolStripMenuItem,
            this.toolStripSeparator4,
            this.列出全卡密钥ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 修改UIDToolStripMenuItem
            // 
            this.修改UIDToolStripMenuItem.Name = "修改UIDToolStripMenuItem";
            this.修改UIDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.修改UIDToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.修改UIDToolStripMenuItem.Text = "修改UID";
            this.修改UIDToolStripMenuItem.Click += new System.EventHandler(this.修改UIDToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // 检查全卡ToolStripMenuItem
            // 
            this.检查全卡ToolStripMenuItem.Name = "检查全卡ToolStripMenuItem";
            this.检查全卡ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.检查全卡ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.检查全卡ToolStripMenuItem.Text = "检查全卡";
            this.检查全卡ToolStripMenuItem.Click += new System.EventHandler(this.检查全卡ToolStripMenuItem_Click);
            // 
            // 检查并纠正全卡ToolStripMenuItem
            // 
            this.检查并纠正全卡ToolStripMenuItem.Name = "检查并纠正全卡ToolStripMenuItem";
            this.检查并纠正全卡ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.检查并纠正全卡ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.检查并纠正全卡ToolStripMenuItem.Text = "检查并纠正全卡";
            this.检查并纠正全卡ToolStripMenuItem.Click += new System.EventHandler(this.检查并纠正全卡ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(209, 6);
            // 
            // 导入MCT格式ToolStripMenuItem
            // 
            this.导入MCT格式ToolStripMenuItem.Name = "导入MCT格式ToolStripMenuItem";
            this.导入MCT格式ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.导入MCT格式ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.导入MCT格式ToolStripMenuItem.Text = "导入MCT格式";
            this.导入MCT格式ToolStripMenuItem.Click += new System.EventHandler(this.导入MCT格式ToolStripMenuItem_Click);
            // 
            // 导出为MCT格式ToolStripMenuItem
            // 
            this.导出为MCT格式ToolStripMenuItem.Name = "导出为MCT格式ToolStripMenuItem";
            this.导出为MCT格式ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.导出为MCT格式ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.导出为MCT格式ToolStripMenuItem.Text = "导出为MCT格式";
            this.导出为MCT格式ToolStripMenuItem.Click += new System.EventHandler(this.导出为MCT格式ToolStripMenuItem_Click);
            // 
            // 导出密钥字典ToolStripMenuItem
            // 
            this.导出密钥字典ToolStripMenuItem.Name = "导出密钥字典ToolStripMenuItem";
            this.导出密钥字典ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.导出密钥字典ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.导出密钥字典ToolStripMenuItem.Text = "导出密钥字典";
            this.导出密钥字典ToolStripMenuItem.Click += new System.EventHandler(this.导出密钥字典ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(209, 6);
            // 
            // 列出全卡密钥ToolStripMenuItem
            // 
            this.列出全卡密钥ToolStripMenuItem.Name = "列出全卡密钥ToolStripMenuItem";
            this.列出全卡密钥ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.列出全卡密钥ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.列出全卡密钥ToolStripMenuItem.Text = "列出全卡密钥";
            this.列出全卡密钥ToolStripMenuItem.Click += new System.EventHandler(this.列出全卡密钥ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(9, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(188, 327);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扇区列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(2, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(184, 309);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "扇区";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSaveSectorEdit);
            this.groupBox2.Controls.Add(this.comboBox4);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.keyBEdit);
            this.groupBox2.Controls.Add(this.keyAEdit);
            this.groupBox2.Controls.Add(this.block2Edit);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.block1Edit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.block0Edit);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.labelCurSec);
            this.groupBox2.Location = new System.Drawing.Point(201, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(219, 327);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "扇区信息";
            // 
            // buttonSaveSectorEdit
            // 
            this.buttonSaveSectorEdit.Location = new System.Drawing.Point(110, 13);
            this.buttonSaveSectorEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSaveSectorEdit.Name = "buttonSaveSectorEdit";
            this.buttonSaveSectorEdit.Size = new System.Drawing.Size(104, 20);
            this.buttonSaveSectorEdit.TabIndex = 20;
            this.buttonSaveSectorEdit.Text = "修改扇区(Enter)";
            this.buttonSaveSectorEdit.UseVisualStyleBackColor = true;
            this.buttonSaveSectorEdit.Click += new System.EventHandler(this.buttonSaveSectorEdit_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.DropDownWidth = 400;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "[不可逆]KeyA:A写/AC:A只读/KeyB:A读写",
            "KeyA:A写/AC:A读写/KeyB:A读写",
            "[不可逆]KeyA:不能读写/AC:A只读/KeyB:A读",
            "KeyA:B写/AC:A只读B读写/KeyB:B写",
            "[不可逆]KeyA:B写/AC:AB只读/KeyB:B写",
            "KeyA:不能读写/AC:A只读B读写/KeyB:不能读写",
            "[不可逆]KeyA:不能读写/AC:AB只读/KeyB:不能读写",
            "[不可逆]KeyA:不能读写/AC:AB只读/KeyB:不能读写(重复了?)"});
            this.comboBox4.Location = new System.Drawing.Point(4, 303);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(211, 20);
            this.comboBox4.TabIndex = 19;
            this.comboBox4.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "KeyAB读写及增减值",
            "[只读]KeyAB读及减值/不可写及增值",
            "[只读]KeyAB读/不可写及增减值",
            "KeyB读写/不可增减值",
            "KeyAB读/KeyB写/不可增减值",
            "[只读]KeyB读/不可写及增减值",
            "KeyAB读及减值/KeyB写及增值",
            "[只读]锁死该扇区"});
            this.comboBox3.Location = new System.Drawing.Point(4, 268);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(211, 20);
            this.comboBox3.TabIndex = 18;
            this.comboBox3.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "KeyAB读写及增减值",
            "[只读]KeyAB读及减值/不可写及增值",
            "[只读]KeyAB读/不可写及增减值",
            "KeyB读写/不可增减值",
            "KeyAB读/KeyB写/不可增减值",
            "[只读]KeyB读/不可写及增减值",
            "KeyAB读及减值/KeyB写及增值",
            "[只读]锁死该扇区"});
            this.comboBox2.Location = new System.Drawing.Point(4, 233);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(211, 20);
            this.comboBox2.TabIndex = 17;
            this.comboBox2.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "KeyAB读写及增减值",
            "[只读]KeyAB读及减值/不可写及增值",
            "[只读]KeyAB读/不可写及增减值",
            "KeyB读写/不可增减值",
            "KeyAB读/KeyB写/不可增减值",
            "[只读]KeyB读/不可写及增减值",
            "KeyAB读及减值/KeyB写及增值",
            "[只读]锁死该扇区"});
            this.comboBox1.Location = new System.Drawing.Point(4, 198);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 20);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 289);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "Key/ACbits权限";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 254);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "2块权限";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 218);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "1块权限";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "0块权限";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "KeyB";
            // 
            // keyBEdit
            // 
            this.keyBEdit.Location = new System.Drawing.Point(124, 161);
            this.keyBEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.keyBEdit.Name = "keyBEdit";
            this.keyBEdit.Size = new System.Drawing.Size(91, 21);
            this.keyBEdit.TabIndex = 10;
            this.keyBEdit.Validating += new System.ComponentModel.CancelEventHandler(this.keyAEdit_Validating);
            // 
            // keyAEdit
            // 
            this.keyAEdit.Location = new System.Drawing.Point(4, 161);
            this.keyAEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.keyAEdit.Name = "keyAEdit";
            this.keyAEdit.Size = new System.Drawing.Size(91, 21);
            this.keyAEdit.TabIndex = 9;
            this.keyAEdit.TextChanged += new System.EventHandler(this.keyAEdit_TextChanged);
            this.keyAEdit.Validating += new System.ComponentModel.CancelEventHandler(this.keyAEdit_Validating);
            // 
            // block2Edit
            // 
            this.block2Edit.Location = new System.Drawing.Point(4, 124);
            this.block2Edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.block2Edit.Name = "block2Edit";
            this.block2Edit.Size = new System.Drawing.Size(211, 21);
            this.block2Edit.TabIndex = 8;
            this.block2Edit.Validating += new System.ComponentModel.CancelEventHandler(this.block0Edit_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "KeyA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "第2块";
            // 
            // block1Edit
            // 
            this.block1Edit.Location = new System.Drawing.Point(4, 87);
            this.block1Edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.block1Edit.Name = "block1Edit";
            this.block1Edit.Size = new System.Drawing.Size(211, 21);
            this.block1Edit.TabIndex = 4;
            this.block1Edit.Validating += new System.ComponentModel.CancelEventHandler(this.block0Edit_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "第1块";
            // 
            // block0Edit
            // 
            this.block0Edit.Location = new System.Drawing.Point(4, 50);
            this.block0Edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.block0Edit.Name = "block0Edit";
            this.block0Edit.Size = new System.Drawing.Size(211, 21);
            this.block0Edit.TabIndex = 2;
            this.block0Edit.Validating += new System.ComponentModel.CancelEventHandler(this.block0Edit_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "第0块";
            // 
            // labelCurSec
            // 
            this.labelCurSec.AutoSize = true;
            this.labelCurSec.Location = new System.Drawing.Point(4, 17);
            this.labelCurSec.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurSec.Name = "labelCurSec";
            this.labelCurSec.Size = new System.Drawing.Size(113, 12);
            this.labelCurSec.TabIndex = 0;
            this.labelCurSec.Text = "当前选定扇区：？？";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(424, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(195, 327);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输出";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.Cyan;
            this.richTextBox1.Location = new System.Drawing.Point(4, 19);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(187, 304);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "欢迎使用M1T的集成编辑器S50HTool！\n打开文件请点左上角文件-打开或Ctrl+O\n";
            // 
            // s50BindingSource
            // 
            this.s50BindingSource.DataSource = typeof(MifareOneTool.S50);
            // 
            // FormHTool
            // 
            this.AcceptButton = this.buttonSaveSectorEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 362);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormHTool";
            this.Text = "S50HTool-beta";
            this.Load += new System.EventHandler(this.FormHTool_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.s50BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改UIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查全卡ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.BindingSource s50BindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCurSec;
        private System.Windows.Forms.TextBox block0Edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox block1Edit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox keyBEdit;
        private System.Windows.Forms.TextBox keyAEdit;
        private System.Windows.Forms.TextBox block2Edit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveSectorEdit;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查并纠正全卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 导出为MCT格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出密钥字典ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入MCT格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 列出全卡密钥ToolStripMenuItem;
    }
}