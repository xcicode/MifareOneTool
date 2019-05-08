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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Name = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClr);
            this.groupBox2.Controls.Add(this.buttonLoadKey);
            this.groupBox2.Controls.Add(this.keyfileBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonKeyWrite);
            this.groupBox2.Controls.Add(this.buttonWriteEmpty);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // buttonClr
            // 
            resources.ApplyResources(this.buttonClr, "buttonClr");
            this.buttonClr.Name = "buttonClr";
            this.buttonClr.UseVisualStyleBackColor = true;
            this.buttonClr.Click += new System.EventHandler(this.buttonClr_Click);
            // 
            // buttonLoadKey
            // 
            resources.ApplyResources(this.buttonLoadKey, "buttonLoadKey");
            this.buttonLoadKey.Name = "buttonLoadKey";
            this.buttonLoadKey.UseVisualStyleBackColor = true;
            this.buttonLoadKey.Click += new System.EventHandler(this.buttonLoadKey_Click);
            // 
            // keyfileBox
            // 
            resources.ApplyResources(this.keyfileBox, "keyfileBox");
            this.keyfileBox.Name = "keyfileBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // buttonKeyWrite
            // 
            resources.ApplyResources(this.buttonKeyWrite, "buttonKeyWrite");
            this.buttonKeyWrite.Name = "buttonKeyWrite";
            this.buttonKeyWrite.UseVisualStyleBackColor = true;
            this.buttonKeyWrite.Click += new System.EventHandler(this.buttonKeyWrite_Click);
            // 
            // buttonWriteEmpty
            // 
            resources.ApplyResources(this.buttonWriteEmpty, "buttonWriteEmpty");
            this.buttonWriteEmpty.Name = "buttonWriteEmpty";
            this.buttonWriteEmpty.UseVisualStyleBackColor = true;
            this.buttonWriteEmpty.Click += new System.EventHandler(this.buttonWriteEmpty_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logBox);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.logBox, "logBox");
            this.logBox.ForeColor = System.Drawing.Color.Gold;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            // 
            // FormMFF08
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMFF08";
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