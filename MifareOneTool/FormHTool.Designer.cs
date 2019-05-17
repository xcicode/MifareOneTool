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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHTool));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.keyAEdit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.keyBEdit = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelCurSec = new System.Windows.Forms.Label();
            this.buttonSaveSectorEdit = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.block0Edit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.block1Edit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.block2Edit = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.s50BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s50BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.工具ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            resources.ApplyResources(this.文件ToolStripMenuItem, "文件ToolStripMenuItem");
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            // 
            // 新建ToolStripMenuItem
            // 
            resources.ApplyResources(this.新建ToolStripMenuItem, "新建ToolStripMenuItem");
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            resources.ApplyResources(this.打开ToolStripMenuItem, "打开ToolStripMenuItem");
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            resources.ApplyResources(this.保存ToolStripMenuItem, "保存ToolStripMenuItem");
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            resources.ApplyResources(this.另存为ToolStripMenuItem, "另存为ToolStripMenuItem");
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // 退出ToolStripMenuItem
            // 
            resources.ApplyResources(this.退出ToolStripMenuItem, "退出ToolStripMenuItem");
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            resources.ApplyResources(this.工具ToolStripMenuItem, "工具ToolStripMenuItem");
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
            // 
            // 修改UIDToolStripMenuItem
            // 
            resources.ApplyResources(this.修改UIDToolStripMenuItem, "修改UIDToolStripMenuItem");
            this.修改UIDToolStripMenuItem.Name = "修改UIDToolStripMenuItem";
            this.修改UIDToolStripMenuItem.Click += new System.EventHandler(this.修改UIDToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // 检查全卡ToolStripMenuItem
            // 
            resources.ApplyResources(this.检查全卡ToolStripMenuItem, "检查全卡ToolStripMenuItem");
            this.检查全卡ToolStripMenuItem.Name = "检查全卡ToolStripMenuItem";
            this.检查全卡ToolStripMenuItem.Click += new System.EventHandler(this.检查全卡ToolStripMenuItem_Click);
            // 
            // 检查并纠正全卡ToolStripMenuItem
            // 
            resources.ApplyResources(this.检查并纠正全卡ToolStripMenuItem, "检查并纠正全卡ToolStripMenuItem");
            this.检查并纠正全卡ToolStripMenuItem.Name = "检查并纠正全卡ToolStripMenuItem";
            this.检查并纠正全卡ToolStripMenuItem.Click += new System.EventHandler(this.检查并纠正全卡ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // 导入MCT格式ToolStripMenuItem
            // 
            resources.ApplyResources(this.导入MCT格式ToolStripMenuItem, "导入MCT格式ToolStripMenuItem");
            this.导入MCT格式ToolStripMenuItem.Name = "导入MCT格式ToolStripMenuItem";
            this.导入MCT格式ToolStripMenuItem.Click += new System.EventHandler(this.导入MCT格式ToolStripMenuItem_Click);
            // 
            // 导出为MCT格式ToolStripMenuItem
            // 
            resources.ApplyResources(this.导出为MCT格式ToolStripMenuItem, "导出为MCT格式ToolStripMenuItem");
            this.导出为MCT格式ToolStripMenuItem.Name = "导出为MCT格式ToolStripMenuItem";
            this.导出为MCT格式ToolStripMenuItem.Click += new System.EventHandler(this.导出为MCT格式ToolStripMenuItem_Click);
            // 
            // 导出密钥字典ToolStripMenuItem
            // 
            resources.ApplyResources(this.导出密钥字典ToolStripMenuItem, "导出密钥字典ToolStripMenuItem");
            this.导出密钥字典ToolStripMenuItem.Name = "导出密钥字典ToolStripMenuItem";
            this.导出密钥字典ToolStripMenuItem.Click += new System.EventHandler(this.导出密钥字典ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // 列出全卡密钥ToolStripMenuItem
            // 
            resources.ApplyResources(this.列出全卡密钥ToolStripMenuItem, "列出全卡密钥ToolStripMenuItem");
            this.列出全卡密钥ToolStripMenuItem.Name = "列出全卡密钥ToolStripMenuItem";
            this.列出全卡密钥ToolStripMenuItem.Click += new System.EventHandler(this.列出全卡密钥ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.Color.SkyBlue;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackColor = System.Drawing.Color.DodgerBlue;
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.comboBox1);
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.comboBox2);
            this.flowLayoutPanel3.Controls.Add(this.label8);
            this.flowLayoutPanel3.Controls.Add(this.comboBox3);
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.comboBox4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2"),
            resources.GetString("comboBox1.Items3"),
            resources.GetString("comboBox1.Items4"),
            resources.GetString("comboBox1.Items5"),
            resources.GetString("comboBox1.Items6"),
            resources.GetString("comboBox1.Items7")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboBox2
            // 
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            resources.GetString("comboBox2.Items"),
            resources.GetString("comboBox2.Items1"),
            resources.GetString("comboBox2.Items2"),
            resources.GetString("comboBox2.Items3"),
            resources.GetString("comboBox2.Items4"),
            resources.GetString("comboBox2.Items5"),
            resources.GetString("comboBox2.Items6"),
            resources.GetString("comboBox2.Items7")});
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // comboBox3
            // 
            resources.ApplyResources(this.comboBox3, "comboBox3");
            this.comboBox3.BackColor = System.Drawing.Color.AliceBlue;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            resources.GetString("comboBox3.Items"),
            resources.GetString("comboBox3.Items1"),
            resources.GetString("comboBox3.Items2"),
            resources.GetString("comboBox3.Items3"),
            resources.GetString("comboBox3.Items4"),
            resources.GetString("comboBox3.Items5"),
            resources.GetString("comboBox3.Items6"),
            resources.GetString("comboBox3.Items7")});
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // comboBox4
            // 
            resources.ApplyResources(this.comboBox4, "comboBox4");
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.DropDownWidth = 400;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            resources.GetString("comboBox4.Items"),
            resources.GetString("comboBox4.Items1"),
            resources.GetString("comboBox4.Items2"),
            resources.GetString("comboBox4.Items3"),
            resources.GetString("comboBox4.Items4"),
            resources.GetString("comboBox4.Items5"),
            resources.GetString("comboBox4.Items6"),
            resources.GetString("comboBox4.Items7")});
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.keyAEdit, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.keyBEdit, 1, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // keyAEdit
            // 
            resources.ApplyResources(this.keyAEdit, "keyAEdit");
            this.keyAEdit.BackColor = System.Drawing.Color.White;
            this.keyAEdit.Name = "keyAEdit";
            this.keyAEdit.TextChanged += new System.EventHandler(this.keyAEdit_TextChanged);
            this.keyAEdit.Validating += new System.ComponentModel.CancelEventHandler(this.keyAEdit_Validating);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // keyBEdit
            // 
            resources.ApplyResources(this.keyBEdit, "keyBEdit");
            this.keyBEdit.BackColor = System.Drawing.Color.White;
            this.keyBEdit.Name = "keyBEdit";
            this.keyBEdit.Validating += new System.ComponentModel.CancelEventHandler(this.keyAEdit_Validating);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.labelCurSec);
            this.flowLayoutPanel1.Controls.Add(this.buttonSaveSectorEdit);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // labelCurSec
            // 
            resources.ApplyResources(this.labelCurSec, "labelCurSec");
            this.labelCurSec.Name = "labelCurSec";
            // 
            // buttonSaveSectorEdit
            // 
            resources.ApplyResources(this.buttonSaveSectorEdit, "buttonSaveSectorEdit");
            this.buttonSaveSectorEdit.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSaveSectorEdit.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonSaveSectorEdit.ForeColor = System.Drawing.Color.White;
            this.buttonSaveSectorEdit.Name = "buttonSaveSectorEdit";
            this.buttonSaveSectorEdit.UseVisualStyleBackColor = false;
            this.buttonSaveSectorEdit.Click += new System.EventHandler(this.buttonSaveSectorEdit_Click);
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.block0Edit);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.block1Edit);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.block2Edit);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // block0Edit
            // 
            resources.ApplyResources(this.block0Edit, "block0Edit");
            this.block0Edit.BackColor = System.Drawing.Color.White;
            this.block0Edit.Name = "block0Edit";
            this.block0Edit.Validating += new System.ComponentModel.CancelEventHandler(this.block0Edit_Validating);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // block1Edit
            // 
            resources.ApplyResources(this.block1Edit, "block1Edit");
            this.block1Edit.BackColor = System.Drawing.Color.White;
            this.block1Edit.Name = "block1Edit";
            this.block1Edit.Validating += new System.ComponentModel.CancelEventHandler(this.block0Edit_Validating);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // block2Edit
            // 
            resources.ApplyResources(this.block2Edit, "block2Edit");
            this.block2Edit.BackColor = System.Drawing.Color.White;
            this.block2Edit.Name = "block2Edit";
            this.block2Edit.Validating += new System.ComponentModel.CancelEventHandler(this.block0Edit_Validating);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackColor = System.Drawing.Color.DodgerBlue;
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // s50BindingSource
            // 
            this.s50BindingSource.DataSource = typeof(MifareOneTool.S50);
            // 
            // FormHTool
            // 
            this.AcceptButton = this.buttonSaveSectorEdit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormHTool";
            this.Load += new System.EventHandler(this.FormHTool_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}