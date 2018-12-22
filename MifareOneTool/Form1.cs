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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = false;
            }else{
                button2.Enabled = true;
            }
        }

        private void lockBtn(bool locks)
        {
            //if (locks)
            //{
            //    button1.Enabled = false;
            //    button2.Enabled = false;
            //}
            //else
            //{
            //    button1.Enabled = true;
            //    button2.Enabled = true;
            //}
            ;//do nothing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(list_dev);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void default_rpt(object sender, ProgressChangedEventArgs e)
        {
            logAppend((string)e.UserState);
        }

        private void logAppend(string msg){
            richTextBox1.AppendText(msg + "\n");
            richTextBox1.ScrollToCaret();
        }

        void list_dev(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi=new ProcessStartInfo("nfc-bin/nfc-scan-device.exe");
            psi.CreateNoWindow=true;
            psi.UseShellExecute=false;
            psi.RedirectStandardOutput=true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b=(BackgroundWorker)sender;
            process=Process.Start(psi);
            process.OutputDataReceived += (s, _e)=> b.ReportProgress(0,_e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0,_e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            b.ReportProgress(100,"##运行完毕##");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string rmfd = "";
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = ".mfd";
            ofd.OverwritePrompt = true;
            ofd.Filter = "MFD文件|*.mfd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            string kt = "a";
            if (MessageBox.Show("使用KeyA（是）或KeyB（否）？", "KeyA/B", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                kt = "b";
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_read);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] {rmfd,kt});
        }

        void mf_read(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "r " + args[1] + " u \"" + args[0] + "\"";
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

        private void button12_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.WorkingDirectory = "nfc-bin";
            Process.Start(psi);
        }

        private string keymfd = "";

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                keymfd = ofd.FileName;
                button4.Text = "K=" + ofd.SafeFileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd";
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
            if (MessageBox.Show("使用KeyA（是）或KeyB（否）？", "KeyA/B", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                kt = "b";
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_write);
                bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt });
        }

        void mf_write(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "w " + args[1] + " u \"" + args[0] + "\"";
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string rmfd = "";
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = ".mfd";
            ofd.OverwritePrompt = true;
            ofd.Filter = "MFD文件|*.mfd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mfoc);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(rmfd);
        }

        void mfoc(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/mfoc.exe");
            string arg = (string)e.Argument;
            psi.Arguments = "-O \"" + arg + "\"";
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
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
            byte[] uid=new byte[4];
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string rmfd = "";
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = ".mfd";
            ofd.OverwritePrompt = true;
            ofd.Filter = "MFD文件|*.mfd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bmf_read);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd});
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
            b.ReportProgress(100, "##运行完毕##");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd";
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
    }
}
