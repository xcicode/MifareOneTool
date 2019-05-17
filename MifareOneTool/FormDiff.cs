using MifareOneTool.Properties;
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
            ofd.Filter = Resources.MFD文件_mfd_dump;
            ofd.Title = Resources.请选择需要打开的MFD文件_比较A;
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
                MessageBox.Show(ioe.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ofd.Filter = Resources.MFD文件_mfd_dump;
            ofd.Title = Resources.请选择需要打开的MFD文件_比较B;
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
                MessageBox.Show(ioe.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                logAppend(Resources.AB文件中一个或两个无效);
            }
        }
        private string Compare()
        {
            StringBuilder stb = new StringBuilder();
            int diffCount = 0;
            for (int i = 0; i < 16; i++)
            {
                stb.AppendLine(Resources.res1);
                stb.AppendLine(Resources.扇区0 + i.ToString());
                for (int a = 0; a < 4; a++)
                {
                    string res = "";
                    for (int b = 0; b < 16; b++)
                    {
                        if (sa.Sectors[i].Block[a][b] == sb.Sectors[i].Block[a][b])
                        {
                            res += Resources.res2;
                        }
                        else
                        {
                            res += Resources.res3;
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
            return Resources.共找到 + diffCount.ToString() + Resources._个块不同 + stb.ToString();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
