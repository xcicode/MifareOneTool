using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MifareOneTool
{
    public partial class FormHardNes : Form
    {
        public FormHardNes()
        {
            InitializeComponent();
        }

        static int getBlock(int sector)
        {//可能有bug
            int trailer_block = 0;
            if (sector < 32)
            {
                trailer_block = sector * 4 + 3;
            }
            else
            {
                trailer_block = 128 + 16 * (sector - 32) + 15;
            }
            return trailer_block;
        }

        public string GetArg()
        {
            string arg = "";
            arg += keyEdit.Text.ToUpper() + " ";
            arg += getBlock(Convert.ToInt32(sector1.Text.Trim())).ToString() + " ";
            arg += (radioKey1A.Checked ? "A" : "B") + " ";
            arg += getBlock(Convert.ToInt32(sector2.Text.Trim())).ToString() + " ";
            arg += radioKey2A.Checked ? "A" : "B";
            return arg;
        }

        public string GetFileAfter()
        {
            string a = "_";
            a += string.Format("{0:D3}", getBlock(Convert.ToInt32(sector2.Text.Trim())));
            a += radioKey2A.Checked ? "A" : "B";
            a += ".txt";
            return a;
        }

        public bool collectOnly()
        {
            return checkBoxColOnly.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool error = false;
            const string pattern = @"[0-9A-Fa-f]{12}";
            TextBox tb = keyEdit;
            string content = tb.Text.Trim();
            if (!(Regex.IsMatch(content, pattern) && content.Length == 12))
            {
                tb.BackColor = Color.Tomato;
                error = true;
            }
            else
            {
                tb.BackColor = Color.Aquamarine;
                tb.Text = content;
            }
            int sec1, sec2;
            if (!int.TryParse(sector1.Text, out sec1))
            {
                sector1.BackColor = Color.Tomato;
                error = true;
            }
            else
            {
                if (sec1 >= 0)
                {
                    sector1.BackColor = Color.Aquamarine;
                }
                else
                {
                    sector1.BackColor = Color.Tomato;
                    error = true;
                }
            }
            if (!int.TryParse(sector2.Text, out sec2))
            {
                sector2.BackColor = Color.Tomato;
                error = true;
            }
            else
            {
                if (sec2 >= 0)
                {
                    sector2.BackColor = Color.Aquamarine;
                }
                else
                {
                    sector2.BackColor = Color.Tomato;
                    error = true;
                }
            }
            if (error)
            {
                MessageBox.Show("设置错误，请修改。");
                return;
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
