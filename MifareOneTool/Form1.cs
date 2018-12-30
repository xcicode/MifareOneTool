using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Reflection;

namespace MifareOneTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Process process = new Process();
        private bool lprocess = false;

        private void buttonListDev_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(list_dev);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void default_rpt(object sender, ProgressChangedEventArgs e)
        {
            logAppend((string)e.UserState);
            if (e.ProgressPercentage == 100)
            {
                Text = "MifareOne Tool - 运行完毕";
            }
            else if (e.ProgressPercentage == 101)
            {
                SaveFileDialog ofd = new SaveFileDialog();
                ofd.AddExtension = true;
                ofd.DefaultExt = ".mfd";
                ofd.Title = "请选择MFD文件保存位置及文件名";
                ofd.OverwritePrompt = true;
                ofd.Filter = "MFD文件|*.mfd";
                if (File.Exists(omfd) && new FileInfo(omfd).Length > 1)
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(ofd.FileName))
                        {
                            File.Delete(ofd.FileName);
                        }
                        File.Move(omfd, ofd.FileName);
                        logAppend("##已保存-" + ofd.FileName + "##");
                    }
                    else
                    {
                        File.Delete(omfd);
                        logAppend("##未保存##");
                    }
                }
                else
                {
                    File.Delete(omfd);
                    logAppend("##缓存文件异常##");
                }
                omfd = "";
                Text = "MifareOne Tool - 运行完毕";
            }
        }

        private void logAppend(string msg)
        {
            richTextBox1.AppendText(msg + "\n");
            richTextBox1.ScrollToCaret();
        }

        void list_dev(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-scan-device.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Add(0, linkLabel1.Text.Length, "https://github.com/xcicode/MifareOneTool/releases/latest");
            logAppend("#软件版本 " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void buttonScanCard_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(list_tag);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void list_tag(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-list.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        string omfd = "";

        private void buttonMfRead_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = "MfRead.tmp";
            string kt = "a";
            string nn = "";
            switch (MessageBox.Show("使用KeyA（是）或KeyB（否），还是不使用（用于全新白卡）（取消）？", "KeyA/B/N", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
            {
                case DialogResult.No:
                    kt = "b";
                    break;

                case DialogResult.Cancel:
                    nn = "x";
                    break;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_read);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt,nn });
            omfd = rmfd;
            
        }

        void mf_read(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "r " + args[1] + " u \"" + args[0] + "\"";
            if (keymfd != "" && args[2] == "")
            {
                psi.Arguments += " \"" + keymfd + "\" f";
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(101, "##运行完毕##");
            }
            else
            {
                b.ReportProgress(100, "##运行出错##");
                File.Delete(args[0]);
            }
        }

        private void buttonCLI_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.WorkingDirectory = "nfc-bin";
            Process.Start(psi);
        }

        private string keymfd = "";

        private void buttonSelectKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd";
            ofd.Title = "请选择一个包含目标卡密钥的MFD文件（通常是已经破解出的该卡的MFD文件）";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                keymfd = ofd.FileName;
                buttonSelectKey.Text = "K=" + ofd.SafeFileName;
            }
            else
            {
                keymfd = "";
                buttonSelectKey.Text = "选择key.mfd";
            }
        }

        private void buttonMfWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd";
            ofd.Title = "请选择需要写入的MFD文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            string kt = "a";
            string nn = "";
            switch (MessageBox.Show("使用KeyA（是）或KeyB（否），还是不使用（用于全新白卡）（取消）？", "KeyA/B/N", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
            {
                case DialogResult.No:
                kt = "b";
                break;

                case DialogResult.Cancel:
                    nn="x";
                    break;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_write);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt,nn });
        }

        void mf_write(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "w " + args[1] + " u \"" + args[0] + "\"";
            if (keymfd != "" && args[2]=="")
            {
                psi.Arguments += " \"" + keymfd + "\" f";
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void buttonMfoc_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
                string rmfd = "Mfoc.tmp";
                string key = "";
                if (Control.ModifierKeys == Keys.Control)
                {
                    string[] ks = Interaction.InputBox("请输入已知的Key，以英文半角逗号分隔。", "请输入已知Key", "FFFFFFFFFFFF", -1, -1).Trim().Split(',');
                    if (ks.Length > 0)
                    {
                        foreach(string k in ks){
                            string pat = "[0-9A-Fa-f]{12}";
                            if (Regex.IsMatch(k, pat))
                            {
                                key += "-k " + k.Substring(0, 12) + " ";
                            }
                        }
                    }                    
                }
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += new DoWorkEventHandler(mfoc);
                bgw.WorkerReportsProgress = true;
                bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
                bgw.RunWorkerAsync(new string[] { rmfd, key });
                omfd = rmfd;
        }

        void mfoc(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/mfoc.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = args[1] + " -O \"" + args[0] + "\"";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(101, "##运行完毕##");
            }
            else
            {
                b.ReportProgress(100, "##运行出错##");
                File.Delete(args[0]);
            }
        }

        private void buttonUidReset_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(reset_uid);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        string hex(byte[] bytes)
        {
            StringBuilder ret = new StringBuilder();
            foreach (byte b in bytes)
            {
                //{0:X2} 大写
                ret.AppendFormat("{0:x2}", b);
            }
            return ret.ToString();
        }

        void reset_uid(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfsetuid.exe");
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] uid = new byte[4];
            rng.GetNonZeroBytes(uid);
            psi.Arguments = hex(uid) + "2B0804006263646566676869";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void buttonUidFormat_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            if (MessageBox.Show("该操作将会清空UID卡内全部数据！！！\n清空后不可恢复！请确认是否要继续操作？", "危险操作警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            { return; }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(format_uid);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void format_uid(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfsetuid.exe");
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] uid = new byte[4];
            rng.GetNonZeroBytes(uid);
            psi.Arguments = "-f " + hex(uid) + "2B0804006263646566676869";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void buttonBmfRead_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = "BmfRead.tmp";

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bmf_read);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd });
            omfd = rmfd;
        }

        void bmf_read(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "R A u \"" + args[0] + "\"";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(101, "##运行完毕##");
            }
            else
            {
                b.ReportProgress(100, "##运行出错##");
                File.Delete(args[0]);
            }
        }

        private void buttonBmfWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd";
            ofd.Title = "请选择需要写入的MFD文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bmf_write);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd });
        }

        void bmf_write(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "W A u \"" + args[0] + "\"";
            if (keymfd != "")
            {
                psi.Arguments += " \"" + keymfd + "\" f";
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void buttonConClr_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonConSave_Click(object sender, EventArgs e)
        {
            string logtext = richTextBox1.Text;
            File.WriteAllText("m1t.log", logtext, Encoding.UTF8);
            MessageBox.Show("终端内容已保存至m1t.log文件", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            if (lprocess)
            {
                if (process.HasExited == false)
                {
                    process.Kill();
                    Form1.ActiveForm.Text = "MifareOne Tool - 已终止";
                }
            }
        }

        private void buttonUidWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            byte[] buid = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(buid);
            string uid = Interaction.InputBox("请输入需要写入的UID卡号，共8位十六进制数，如E44A3BF1。", "请输入UID号", hex(buid), -1, -1).Trim();
            string pat = "[0-9A-Fa-f]{8}";
            if (!Regex.IsMatch(uid, pat))
            {
                MessageBox.Show("输入的UID号不合法", "InputError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(set_uid);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(uid);
        }

        void set_uid(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfsetuid.exe");
            psi.Arguments = "" + ((string)e.Argument).Substring(0, 8) + "2B0804006263646566676869";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/xcicode/MifareOneTool/releases/latest");
        }

        private void buttonMfcuk_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } 
            Text = "MifareOne Tool - 运行中";
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(Mfcuk);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void Mfcuk(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ProcessStartInfo psi = new ProcessStartInfo("cmd");
            psi.Arguments = "/k mfcuk.exe -v 3 -C -R -1 -s 250 -S 250";
            psi.WorkingDirectory = "nfc-bin";
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process=Process.Start(psi);
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void buttonCmfWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd";
            ofd.Title = "请选择需要写入的MFD文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            string kt = "a";
            string nn = "";
            switch (MessageBox.Show("使用KeyA（是）或KeyB（否），还是不使用（用于全新白卡）（取消）？", "KeyA/B/N", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
            {
                case DialogResult.No:
                    kt = "b";
                    break;

                case DialogResult.Cancel:
                    nn = "x";
                    break;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(cmf_write);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt, nn });
        }

        void cmf_write(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "c " + args[1] + " u \"" + args[0] + "\"";
            if (keymfd != "" && args[2] == "")
            {
                psi.Arguments += " \"" + keymfd + "\" f";
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void buttonLockUfuid_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            if (MessageBox.Show("该操作将会锁死UFUID卡片！！！\n锁死后不可恢复！无法再次更改0块！请确认是否要继续操作？", "危险操作警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            { return; }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(lock_ufuid);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void lock_ufuid(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfsetuid.exe");
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] uid = new byte[4];
            rng.GetNonZeroBytes(uid);
            psi.Arguments = "-l";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }

        private void buttonMfFormat_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } 
            if (keymfd=="") { MessageBox.Show("未选择有效key.mfd。", "无密钥", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = keymfd;
            string kt = "a";
            switch (MessageBox.Show("使用KeyA（是）或KeyB（否）？", "KeyA/B", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                case DialogResult.No:
                    kt = "b";
                    break;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_format);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt});
        }

        void mf_format(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "f " + args[1] + " u \"" + args[0] + "\"";
            psi.Arguments += " \"" + keymfd + "\" f";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100, "##运行完毕##");
        }
    }
}
