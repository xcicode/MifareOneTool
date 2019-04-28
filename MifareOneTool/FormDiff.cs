using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MifareOneTool
{
    public partial class FormDiff : Form
    {
        public FormDiff()
        {
            InitializeComponent();
        }

        private S50 sa = new S50();
        private S50 sb = new S50();
        private string fa = "";
        private string fb = "";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd;*.dump";
            ofd.Title = "请选择需要打开的MFD文件(比较A)";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fa = ofd.FileName;
            }
            else
            {
                return;
            }
            sa = new S50();
            try
            {
                sa.LoadFromMfd(fa);
                button1.Text = "A=" + ofd.SafeFileName;
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "打开出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sa = new S50();
                return;
            }
        }

        private void FormDiff_Load(object sender, EventArgs e)
        {
        }
        private void logAppend(string msg)
        {
            richTextBox1.AppendText(msg + "\n");
            richTextBox1.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd;*.dump";
            ofd.Title = "请选择需要打开的MFD文件(比较B)";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fb = ofd.FileName;
            }
            else
            {
                return;
            }
            sb = new S50();
            try
            {
                sb.LoadFromMfd(fb);
                button2.Text = "B=" + ofd.SafeFileName;
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "打开出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sb = new S50();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(fa) && File.Exists(fb))
            {
                richTextBox1.Clear();
                richTextBox1.Text = Compare();
            }
            else
            {
                logAppend("AB文件中一个或两个无效。");
            }
        }
        private string Compare()
        {
            StringBuilder stb = new StringBuilder();
            int diffCount = 0;
            for (int i = 0; i < 16; i++)
            {
                stb.AppendLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                stb.AppendLine("扇区 " + i.ToString());
                for (int a = 0; a < 4; a++)
                {
                    string res = "";
                    for (int b = 0; b < 16; b++)
                    {
                        if (sa.Sectors[i].Block[a][b] == sb.Sectors[i].Block[a][b])
                        {
                            res += "-- ";
                        }
                        else
                        {
                            res += "## ";
                        }
                    }
                    stb.AppendLine("A: " + Utils.Hex2StrWithSpan(sa.Sectors[i].Block[a]));
                    stb.AppendLine("B: " + Utils.Hex2StrWithSpan(sb.Sectors[i].Block[a]));
                    stb.AppendLine("   " + res);
                    if (res.Contains("##"))
                    {
                        diffCount++;
                    }
                }

            }
            return "共找到 " + diffCount.ToString() + " 个块不同\n" + stb.ToString();
        }
    }
}
