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

namespace MifareOneTool
{
    public partial class FormMFF08 : Form
    {
        public FormMFF08()
        {
            InitializeComponent();
        }

        private void buttonLoadKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd|DUMP文件|*.dump";
            ofd.Title = "请选择最后一次写卡导致0块损坏的卡数据文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                keyfileBox.Text = ofd.FileName;
            }
        }

        private void buttonClr_Click(object sender, EventArgs e)
        {
            keyfileBox.Text = "";
        }

        bool lprocess = false;
        Process process;

        private void logAppend(string msg)
        {
            logBox.AppendText(msg + "\n");
            logBox.ScrollToCaret();
        }

        void default_rpt(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                logAppend((string)e.UserState);
                groupBox2.Enabled = true;
            }
            else if (e.ProgressPercentage == 1)
            {
                groupBox2.Enabled = false;
            }
            else
            {
                logAppend((string)e.UserState);
            }
            Application.DoEvents();

        }

        private void buttonWriteEmpty_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            S50 empty = new S50();
            empty.ExportToMfd("mff08_empty.kmf");
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(cmf_write);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { "mff08_empty.kmf", "A", "x", "" });
        }

        void cmf_write(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/mff08.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "c " + args[1] + " u \"" + args[0] + "\"";
            if (args[3] != "" && args[2] == "")
            {
                psi.Arguments += " \"" + args[3] + "\" f";
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            b.ReportProgress(1);
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

        private void buttonKeyWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show("有任务运行中，不可执行。", "设备忙", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            S50 empty = new S50();
            empty.ExportToMfd("mff08_empty.kmf");
            if (keyfileBox.Text == "")
            {
                MessageBox.Show("您没有给定最后一次写卡导致0块损坏的卡数据文件来作为写卡时的密钥源。\n操作终止。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(cmf_write);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { "mff08_empty.kmf", "C", "", keyfileBox.Text });
        }

        private void FormMFF08_Load(object sender, EventArgs e)
        {
            if (!File.Exists("nfc-bin/mff08.exe"))
            {
                MessageBox.Show("无法找到MFF08程序文件。\n操作终止。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
