using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace MifareOneTool
{
    public partial class FormHTool : Form
    {
        public FormHTool()
        {
            InitializeComponent();
        }

        private S50 currentS50 = new S50();
        string currentFilename = "";
        int currentSector = -1;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int sectorIndex = dataGridView1.SelectedRows[0].Index;
                reloadEdit(sectorIndex);
                logAppend("显示扇区" + sectorIndex.ToString());
            }
        }
        private void logAppend(string msg)
        {
            richTextBox1.AppendText(msg + "\n");
            richTextBox1.ScrollToCaret();
        }
        private void reloadEdit(int sectorIndex)
        {
            currentSector = sectorIndex;
            if (sectorIndex == -1)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 1;
                this.keyBEdit.Text = "";
                this.keyAEdit.Text = "";
                this.block2Edit.Text = "";
                this.block1Edit.Text = "";
                this.block0Edit.Text = "";
                this.labelCurSec.Text = "当前选定扇区：？？";
                return;
            }
            labelCurSec.Text = "当前选定扇区：" + sectorIndex.ToString();
            block0Edit.Text = Form1.hex(currentS50.Sectors[sectorIndex].Block[0]);
            block1Edit.Text = Form1.hex(currentS50.Sectors[sectorIndex].Block[1]);
            block2Edit.Text = Form1.hex(currentS50.Sectors[sectorIndex].Block[2]);
            keyAEdit.Text = Form1.hex(currentS50.Sectors[sectorIndex].Block[3].Skip(0).Take(6).ToArray());
            keyBEdit.Text = Form1.hex(currentS50.Sectors[sectorIndex].Block[3].Skip(10).Take(6).ToArray());
            byte[] acbits = Utils.ReadAC(currentS50.Sectors[sectorIndex].Block[3].Skip(6).Take(4).ToArray());
            comboBox1.SelectedIndex = acbits[0] & 0x07;
            comboBox2.SelectedIndex = acbits[1] & 0x07;
            comboBox3.SelectedIndex = acbits[2] & 0x07;
            comboBox4.SelectedIndex = acbits[3] & 0x07;
            int res = currentS50.Sectors[sectorIndex].Verify();
            string msg = "";
            if ((res & 0x01) == 0x01)
            {
                currentS50.Sectors[sectorIndex].Block[0][4]
                    = (byte)(currentS50.Sectors[sectorIndex].Block[0][0]
                    ^ currentS50.Sectors[sectorIndex].Block[0][1]
                    ^ currentS50.Sectors[sectorIndex].Block[0][2]
                    ^ currentS50.Sectors[sectorIndex].Block[0][3]);
                block0Edit.Text = Form1.hex(currentS50.Sectors[sectorIndex].Block[0]);
                msg += "该扇区UID校验值错误，已经自动为您更正。\n";
            }
            if ((res & 0x02) == 0x02)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 1;
                msg += "该扇区访问控制位无效，写入将会损坏卡片，已重新设置。\n";
            }
            if ((res & 0x04) == 0x04)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 1;
                msg += "该扇区访问控制位损坏，写入将会损坏卡片，已重新设置。\n";
            }
            if (res != 0x00) { MessageBox.Show(msg.Trim()); }

            this.ValidateChildren();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadEdit(-1);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd;*.dump";
            ofd.Title = "请选择需要打开的MFD文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFilename = ofd.FileName;
            }
            else
            {
                return;
            }
            this.currentS50 = new S50();
            try
            {
                this.currentS50.LoadFromMfd(currentFilename);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "打开出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.currentS50 = new S50();
                return;
            }
            reloadList();
            logAppend("打开了" + ofd.FileName);
        }

        private void reloadList()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 16; i++)
            {
                Sector sec = currentS50.Sectors[i];
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = sec.Info(i);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.currentS50.ExportToMfd(currentFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "写入出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            logAppend("已保存到" + currentFilename + "。");
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = ".mfd";
            ofd.Title = "请选择MFD文件保存位置及文件名";
            ofd.OverwritePrompt = true;
            ofd.Filter = "MFD文件|*.mfd|DUMP文件|*.dump";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            else
            {
                return;
            }
            try
            {
                this.currentS50.ExportToMfd(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "写入出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            logAppend("已保存到" + filename + "。");
        }

        private void block0Edit_Validating(object sender, CancelEventArgs e)
        {
            const string pattern = @"[0-9A-Fa-f]{32}";
            TextBox tb = ((TextBox)sender);
            string content = tb.Text.Trim();
            if (!(Regex.IsMatch(content, pattern)&&content.Length==32))
            {
                tb.BackColor = Color.Tomato;
                //e.Cancel = true;
            }
            else
            {
                tb.BackColor = Color.Aquamarine;
                tb.Text = content;
            }
        }

        private void keyAEdit_Validating(object sender, CancelEventArgs e)
        {
            const string pattern = @"[0-9A-Fa-f]{12}";
            TextBox tb = ((TextBox)sender);
            string content = tb.Text.Trim();
            if (!(Regex.IsMatch(content, pattern) && content.Length == 12))
            {
                tb.BackColor = Color.Tomato;
                //e.Cancel = true;
            }
            else
            {
                tb.BackColor = Color.Aquamarine;
                tb.Text = content;
            }
        }

        private void buttonSaveSectorEdit_Click(object sender, EventArgs e)
        {
            if (currentSector >= 0 && currentSector <= 15)
            {
                this.ValidateChildren();
                if (block0Edit.BackColor != Color.Aquamarine
                    || block1Edit.BackColor != Color.Aquamarine
                    || block2Edit.BackColor != Color.Aquamarine
                    || keyAEdit.BackColor != Color.Aquamarine
                    || keyBEdit.BackColor != Color.Aquamarine)
                {
                    MessageBox.Show("当前扇区数据仍有错误，不能执行修改。");
                    return;
                }
                currentS50.Sectors[currentSector].Block[0] = Utils.Hex2Block(block0Edit.Text.Trim(),16);
                currentS50.Sectors[currentSector].Block[1] = Utils.Hex2Block(block1Edit.Text.Trim(), 16);
                currentS50.Sectors[currentSector].Block[2] = Utils.Hex2Block(block2Edit.Text.Trim(), 16);
                byte[] kA = Utils.Hex2Block(keyAEdit.Text.Trim(), 6);
                byte[] kB = Utils.Hex2Block(keyBEdit.Text.Trim(), 6);
                byte[] ac = new byte[4] { 
                    (byte)comboBox1.SelectedIndex, 
                    (byte)comboBox2.SelectedIndex, 
                    (byte)comboBox3.SelectedIndex, 
                    (byte)comboBox4.SelectedIndex };
                byte[] kC = Utils.GenAC(ac);
                List<byte> list3=new List<byte>(kA);
                list3.AddRange(kC);
                list3.AddRange(kB);
                byte[] block3 = list3.Take(16).ToArray();
                byte lastUC=currentS50.Sectors[currentSector].Block[3][9];
                currentS50.Sectors[currentSector].Block[3] = block3;
                currentS50.Sectors[currentSector].Block[3][9] = lastUC;
                for (int i = 0; i < 16; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = currentS50.Sectors[i].Info(i);
                }
                logAppend("已更新扇区" + currentSector.ToString());
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            ComboBox tb = ((ComboBox)sender);
            if (tb.SelectedIndex < 0 || tb.Text == "##文件中的值错误##")
            {
                tb.BackColor = Color.Tomato;
                //e.Cancel = true;
            }
            else
            {
                tb.BackColor = Color.Aquamarine;
            }
        }

        private void 检查全卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] res = currentS50.Verify();
            if (res[16] == 0)
            {
                MessageBox.Show("该文件一切正常。");
            }
            else
            {
                string msg = "该文件存在以下错误：\n";
                for (int i = 0; i < 16; i++)
                {
                    msg += "扇区" + i.ToString() + "：\n";
                    if ((res[i] & 0x01) == 0x01)
                    {
                        msg += "该扇区UID校验值错误，请点击打开扇区0来自动更正。\n";
                    }
                    if ((res[i] & 0x02) == 0x02)
                    {
                        msg += "该扇区访问控制位无效，写入将会损坏卡片，请重新设置。\n";
                    }
                    if ((res[i] & 0x04) == 0x04)
                    {
                        msg += "该扇区访问控制位损坏，写入将会损坏卡片，请重新设置。\n";
                    }
                    if (res[i] == 0)
                    {
                        msg += "该扇区一切正常。\n";
                    }
                }
                richTextBox1.Clear();
                richTextBox1.Text = msg ;
            }
        }

        private void 修改UIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadEdit(-1);
            byte[] buid = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(buid);
            string uid = Interaction.InputBox("请输入需要更改的UID卡号，共8位十六进制数，如E44A3BF1。", "请输入UID号", Form1.hex(buid), -1, -1).Trim();
            string pat = "[0-9A-Fa-f]{8}";
            if (!Regex.IsMatch(uid, pat))
            {
                MessageBox.Show("输入的UID号不合法", "InputError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            buid = Utils.Hex2Block(uid, 4);
            byte bcc=(byte)(buid[0]^buid[1]^buid[2]^buid[3]);
            currentS50.Sectors[0].Block[0][0] = buid[0];
            currentS50.Sectors[0].Block[0][1] = buid[1];
            currentS50.Sectors[0].Block[0][2] = buid[2];
            currentS50.Sectors[0].Block[0][3] = buid[3];
            currentS50.Sectors[0].Block[0][4] = bcc;
            logAppend("UID已改为" + Form1.hex(buid) + "，计算得到BCC=" + Form1.hex(new byte[]{bcc}));
            reloadEdit(0);
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadEdit(-1);
            this.currentS50 = new S50();
            reloadList();
            logAppend("已重置并新建卡。");
        }

        private void 检查并纠正全卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] defaultAC = new byte[] { 0xff, 0x07, 0x80, 0x69 };
            int[] res = currentS50.Verify();
            if (res[16] == 0)
            {
                MessageBox.Show("该文件一切正常。");
            }
            else
            {
                string msg = "该文件存在以下错误：\n";
                for (int i = 0; i < 16; i++)
                {
                    msg += "扇区" + i.ToString() + "：\n";
                    if ((res[i] & 0x01) == 0x01)
                    {
                        currentS50.Sectors[i].Block[0][4]
                            = (byte)(currentS50.Sectors[i].Block[0][0]
                            ^ currentS50.Sectors[i].Block[0][1]
                            ^ currentS50.Sectors[i].Block[0][2]
                            ^ currentS50.Sectors[i].Block[0][3]);
                        block0Edit.Text = Form1.hex(currentS50.Sectors[i].Block[0]);
                        msg += "该扇区UID校验值错误，已自动更正。\n";
                    }
                    if ((res[i] & 0x02) == 0x02)
                    {
                        for (int j = 6; j < 10; j++)
                        {
                            currentS50.Sectors[i].Block[3][j] = defaultAC[j - 6];
                        }
                        msg += "该扇区访问控制位无效，写入将会损坏卡片，已重新设置。\n";
                    }
                    if ((res[i] & 0x04) == 0x04)
                    {
                        for (int j = 6; j < 10; j++)
                        {
                            currentS50.Sectors[i].Block[3][j] = defaultAC[j - 6];
                        }
                        msg += "该扇区访问控制位损坏，写入将会损坏卡片，已重新设置。\n";
                    }
                    if (res[i] == 0)
                    {
                        msg += "该扇区一切正常。\n";
                    }
                }
                richTextBox1.Clear();
                richTextBox1.Text=msg;
            }
        }

        private void 导出为MCT格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = ".txt";
            ofd.Title = "请选择MCT.txt文件保存位置及文件名";
            ofd.OverwritePrompt = true;
            ofd.Filter = "txt文件|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            else
            {
                return;
            }
            try
            {
                this.currentS50.ExportToMctTxt(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "写入出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            logAppend("已导出MCT文件" + filename + "。");
        }

        private void 导出密钥字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = ".dic";
            ofd.Title = "请选择密钥字典文件保存位置及文件名";
            ofd.OverwritePrompt = true;
            ofd.Filter = "字典文件|*.dic";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            else
            {
                return;
            }
            File.WriteAllLines(filename, this.currentS50.KeyListStr().ToArray());
            logAppend("已导出密钥字典文件" + filename + "。");
        }

        private void 导入MCT格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadEdit(-1);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MCT格式|*.*";
            ofd.Title = "请选择需要打开的MCT格式文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFilename = ofd.FileName;
            }
            else
            {
                return;
            }
            this.currentS50 = new S50();
            try
            {
                this.currentS50.LoadFromMctTxt(currentFilename);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, "打开出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.currentS50 = new S50();
                return;
            }
            reloadList();
            logAppend("打开了" + ofd.FileName);
        }

        private void 列出全卡密钥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                sb.AppendLine("#扇区 " + i.ToString());
                sb.AppendLine("[A] " + Utils.Hex2Str(this.currentS50.Sectors[i].KeyA));
                sb.AppendLine("[B] " + Utils.Hex2Str(this.currentS50.Sectors[i].KeyB));
            }
            richTextBox1.Clear();
            richTextBox1.Text = sb.ToString();
        }

        private void FormHTool_Load(object sender, EventArgs e)
        {
            新建ToolStripMenuItem_Click(sender, e);
        }
    }
}
