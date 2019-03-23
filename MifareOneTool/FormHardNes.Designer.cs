namespace MifareOneTool
{
    partial class FormHardNes
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioKey1B = new System.Windows.Forms.RadioButton();
            this.radioKey1A = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sector1 = new System.Windows.Forms.TextBox();
            this.keyEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioKey2B = new System.Windows.Forms.RadioButton();
            this.radioKey2A = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxColOnly = new System.Windows.Forms.CheckBox();
            this.sector2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 150);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "执行!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(170, 150);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 20);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioKey1B);
            this.groupBox1.Controls.Add(this.radioKey1A);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.sector1);
            this.groupBox1.Controls.Add(this.keyEdit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(278, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目标卡-已知信息";
            // 
            // radioKey1B
            // 
            this.radioKey1B.AutoSize = true;
            this.radioKey1B.Location = new System.Drawing.Point(194, 32);
            this.radioKey1B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioKey1B.Name = "radioKey1B";
            this.radioKey1B.Size = new System.Drawing.Size(47, 16);
            this.radioKey1B.TabIndex = 15;
            this.radioKey1B.Text = "KeyB";
            this.radioKey1B.UseVisualStyleBackColor = true;
            // 
            // radioKey1A
            // 
            this.radioKey1A.AutoSize = true;
            this.radioKey1A.Checked = true;
            this.radioKey1A.Location = new System.Drawing.Point(145, 32);
            this.radioKey1A.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioKey1A.Name = "radioKey1A";
            this.radioKey1A.Size = new System.Drawing.Size(47, 16);
            this.radioKey1A.TabIndex = 14;
            this.radioKey1A.TabStop = true;
            this.radioKey1A.Text = "KeyA";
            this.radioKey1A.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "扇区号";
            // 
            // sector1
            // 
            this.sector1.Location = new System.Drawing.Point(101, 31);
            this.sector1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sector1.Name = "sector1";
            this.sector1.Size = new System.Drawing.Size(36, 21);
            this.sector1.TabIndex = 11;
            this.sector1.Text = "0";
            // 
            // keyEdit
            // 
            this.keyEdit.Location = new System.Drawing.Point(7, 31);
            this.keyEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.keyEdit.Name = "keyEdit";
            this.keyEdit.Size = new System.Drawing.Size(91, 21);
            this.keyEdit.TabIndex = 10;
            this.keyEdit.Text = "ffffffffffff";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "已知的Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "连续工作时请注意设备散热！";
            // 
            // radioKey2B
            // 
            this.radioKey2B.AutoSize = true;
            this.radioKey2B.Location = new System.Drawing.Point(194, 32);
            this.radioKey2B.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioKey2B.Name = "radioKey2B";
            this.radioKey2B.Size = new System.Drawing.Size(47, 16);
            this.radioKey2B.TabIndex = 15;
            this.radioKey2B.Text = "KeyB";
            this.radioKey2B.UseVisualStyleBackColor = true;
            // 
            // radioKey2A
            // 
            this.radioKey2A.AutoSize = true;
            this.radioKey2A.Checked = true;
            this.radioKey2A.Location = new System.Drawing.Point(145, 32);
            this.radioKey2A.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioKey2A.Name = "radioKey2A";
            this.radioKey2A.Size = new System.Drawing.Size(47, 16);
            this.radioKey2A.TabIndex = 14;
            this.radioKey2A.TabStop = true;
            this.radioKey2A.Text = "KeyA";
            this.radioKey2A.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "扇区号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxColOnly);
            this.groupBox2.Controls.Add(this.radioKey2B);
            this.groupBox2.Controls.Add(this.radioKey2A);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.sector2);
            this.groupBox2.Location = new System.Drawing.Point(9, 79);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(278, 65);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标扇区解密设置";
            // 
            // checkBoxColOnly
            // 
            this.checkBoxColOnly.AutoSize = true;
            this.checkBoxColOnly.Location = new System.Drawing.Point(5, 19);
            this.checkBoxColOnly.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxColOnly.Name = "checkBoxColOnly";
            this.checkBoxColOnly.Size = new System.Drawing.Size(96, 16);
            this.checkBoxColOnly.TabIndex = 17;
            this.checkBoxColOnly.Text = "只采集不计算";
            this.checkBoxColOnly.UseVisualStyleBackColor = true;
            // 
            // sector2
            // 
            this.sector2.Location = new System.Drawing.Point(101, 31);
            this.sector2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sector2.Name = "sector2";
            this.sector2.Size = new System.Drawing.Size(36, 21);
            this.sector2.TabIndex = 11;
            // 
            // FormHardNes
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(296, 179);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHardNes";
            this.Text = "初始化HardNested解密";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioKey1B;
        private System.Windows.Forms.RadioButton radioKey1A;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox keyEdit;
        private System.Windows.Forms.RadioButton radioKey2B;
        private System.Windows.Forms.RadioButton radioKey2A;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox sector2;
        private System.Windows.Forms.TextBox sector1;
        private System.Windows.Forms.CheckBox checkBoxColOnly;
    }
}