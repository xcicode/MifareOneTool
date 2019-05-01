namespace MifareOneTool
{
    partial class FormMFF08
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMFF08));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClr = new System.Windows.Forms.Button();
            this.buttonLoadKey = new System.Windows.Forms.Button();
            this.keyfileBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKeyWrite = new System.Windows.Forms.Button();
            this.buttonWriteEmpty = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "说明";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "本工具由nfc-mfclassic做少许修改而来。可用于1K大小CUID卡0块损坏的修复。\r\n本工具可以修复：SAK写错（不认卡类型）、ATQA写错（不认卡大小）" +
                "，对于BCC写错暂时无能为力。\r\n请准备好你最后一次写入该卡导致0块损坏的卡数据文件（如果卡片有加密）。";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClr);
            this.groupBox2.Controls.Add(this.buttonLoadKey);
            this.groupBox2.Controls.Add(this.keyfileBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonKeyWrite);
            this.groupBox2.Controls.Add(this.buttonWriteEmpty);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // buttonClr
            // 
            this.buttonClr.Location = new System.Drawing.Point(585, 33);
            this.buttonClr.Name = "buttonClr";
            this.buttonClr.Size = new System.Drawing.Size(44, 23);
            this.buttonClr.TabIndex = 4;
            this.buttonClr.Text = "清除";
            this.buttonClr.UseVisualStyleBackColor = true;
            this.buttonClr.Click += new System.EventHandler(this.buttonClr_Click);
            // 
            // buttonLoadKey
            // 
            this.buttonLoadKey.Location = new System.Drawing.Point(504, 33);
            this.buttonLoadKey.Name = "buttonLoadKey";
            this.buttonLoadKey.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadKey.TabIndex = 1;
            this.buttonLoadKey.Text = "加载…";
            this.buttonLoadKey.UseVisualStyleBackColor = true;
            this.buttonLoadKey.Click += new System.EventHandler(this.buttonLoadKey_Click);
            // 
            // keyfileBox
            // 
            this.keyfileBox.Location = new System.Drawing.Point(237, 35);
            this.keyfileBox.Name = "keyfileBox";
            this.keyfileBox.Size = new System.Drawing.Size(261, 21);
            this.keyfileBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "最后一次写卡导致0块损坏的卡数据文件：";
            // 
            // buttonKeyWrite
            // 
            this.buttonKeyWrite.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonKeyWrite.Location = new System.Drawing.Point(121, 20);
            this.buttonKeyWrite.Name = "buttonKeyWrite";
            this.buttonKeyWrite.Size = new System.Drawing.Size(83, 74);
            this.buttonKeyWrite.TabIndex = 1;
            this.buttonKeyWrite.Text = "修复写入\r\n有密码\r\nCUID卡";
            this.buttonKeyWrite.UseVisualStyleBackColor = true;
            this.buttonKeyWrite.Click += new System.EventHandler(this.buttonKeyWrite_Click);
            // 
            // buttonWriteEmpty
            // 
            this.buttonWriteEmpty.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonWriteEmpty.Location = new System.Drawing.Point(8, 20);
            this.buttonWriteEmpty.Name = "buttonWriteEmpty";
            this.buttonWriteEmpty.Size = new System.Drawing.Size(83, 74);
            this.buttonWriteEmpty.TabIndex = 0;
            this.buttonWriteEmpty.Text = "修复写入\r\n无密空白\r\nCUID卡";
            this.buttonWriteEmpty.UseVisualStyleBackColor = true;
            this.buttonWriteEmpty.Click += new System.EventHandler(this.buttonWriteEmpty_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(635, 188);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.Black;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.ForeColor = System.Drawing.Color.Gold;
            this.logBox.Location = new System.Drawing.Point(3, 17);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.logBox.Size = new System.Drawing.Size(629, 168);
            this.logBox.TabIndex = 0;
            this.logBox.Text = resources.GetString("logBox.Text");
            // 
            // FormMFF08
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 424);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMFF08";
            this.Text = "MFF08 Tool-CUID修复工具";
            this.Load += new System.EventHandler(this.FormMFF08_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonLoadKey;
        private System.Windows.Forms.TextBox keyfileBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKeyWrite;
        private System.Windows.Forms.Button buttonWriteEmpty;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button buttonClr;
    }
}