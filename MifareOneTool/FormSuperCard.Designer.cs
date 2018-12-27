namespace MifareOneTool
{
    partial class FormSuperCard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonWriteCFuid = new System.Windows.Forms.Button();
            this.buttonLockUfuid = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonWriteCFuid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CUID/FUID写入";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonLockUfuid);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UFUID封卡";
            // 
            // buttonWriteCFuid
            // 
            this.buttonWriteCFuid.Enabled = false;
            this.buttonWriteCFuid.Location = new System.Drawing.Point(6, 24);
            this.buttonWriteCFuid.Name = "buttonWriteCFuid";
            this.buttonWriteCFuid.Size = new System.Drawing.Size(246, 30);
            this.buttonWriteCFuid.TabIndex = 0;
            this.buttonWriteCFuid.Text = "执行！";
            this.buttonWriteCFuid.UseVisualStyleBackColor = true;
            // 
            // buttonLockUfuid
            // 
            this.buttonLockUfuid.Enabled = false;
            this.buttonLockUfuid.Location = new System.Drawing.Point(6, 24);
            this.buttonLockUfuid.Name = "buttonLockUfuid";
            this.buttonLockUfuid.Size = new System.Drawing.Size(246, 30);
            this.buttonLockUfuid.TabIndex = 1;
            this.buttonLockUfuid.Text = "执行！";
            this.buttonLockUfuid.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox1.Location = new System.Drawing.Point(12, 158);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(258, 323);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "等待中……\n";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(189, 487);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormSuperCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 522);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSuperCard";
            this.Text = "超级卡工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonWriteCFuid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonLockUfuid;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonExit;
    }
}