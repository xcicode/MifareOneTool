using MifareOneTool.Properties;
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
using System.Runtime.InteropServices;

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
        private bool running = false;

        private void buttonListDev_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            if (Properties.Settings.Default.NewScan)
            { File.Delete("libnfc.conf"); }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(list_dev);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void writeConfig(string devstr, bool autoscan = true, bool intscan = false)
        {
            string cfg = "allow_autoscan = " + (autoscan ? "true" : "false") + "\n";
            cfg += "allow_intrusive_scan = " + (intscan ? "true" : "false") + "\n";
            cfg += "device.name = \"NFC-Device\"\n";
            cfg += "device.connstring = \"" + devstr + "\"";
            File.WriteAllText("libnfc.conf", cfg);
            curDevice.Text = Resources.设备串口 + devstr.Replace("pn532_uart:", "").Replace(":115200", "");
        }

        void default_rpt(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                logAppend((string)e.UserState);
                logAppend("");
                Text = Resources.MifareOne_Tool_运行完毕;
            }
            else if (e.ProgressPercentage == 101)
            {
                logAppend((string)e.UserState);
                if (lastuid != "")
                {
                    if (File.Exists(omfd) && new FileInfo(omfd).Length > 1)
                    {
                        Directory.CreateDirectory("auto_keys");
                        string filename = "auto_keys\\" + lastuid + "_" + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-") + ".mfd";
                        if (File.Exists(filename))
                        {
                            File.Delete(filename);
                        }
                        File.Move(omfd, filename);
                        logAppend(Resources._已自动保存 + filename + "##");
                    }
                    else
                    {
                        File.Delete(omfd);
                        logAppend(Resources._缓存文件异常);
                    }
                    lastuid = "";
                }
                else
                {
                    SaveFileDialog ofd = new SaveFileDialog();
                    ofd.AddExtension = true;
                    //ofd.DefaultExt = ".mfd";
                    ofd.Title = Resources.请选择MFD文件保存位置及文件名;
                    ofd.OverwritePrompt = true;
                    ofd.Filter = Resources.DUMP文件_dump_MFD文件_mfd;
                    if (File.Exists(omfd) && new FileInfo(omfd).Length > 1)
                    {
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            if (File.Exists(ofd.FileName))
                            {
                                File.Delete(ofd.FileName);
                            }
                            File.Move(omfd, ofd.FileName);
                            logAppend(Resources._已保存 + ofd.FileName + "##");
                        }
                        else
                        {
                            File.Delete(omfd);
                            logAppend(Resources._未保存);
                        }
                    }
                    else
                    {
                        File.Delete(omfd);
                        logAppend(Resources._缓存文件异常);
                    }
                }
                omfd = "";
                logAppend("");
                Text = Resources.MifareOne_Tool_运行完毕;
            }
            else if (e.ProgressPercentage == 102)
            {
                logAppend((string)e.UserState);
                logAppend(Resources._Nonce收集完毕);
                logAppend(Resources.您可以上传到云计算服务节点进行计算);
                logAppend("");

                Text = Resources.MifareOne_Tool_运行完毕;
            }
            else if (e.ProgressPercentage == 103)
            {
                logAppend(Resources.识别了以下设备);
                List<string> myReaders = (List<string>)(e.UserState);
                foreach (string reader in myReaders)
                {
                    logAppend(reader);
                }
                if (myReaders.Count > 0)
                {
                    logAppend(Resources.将自动选择首个设备 + myReaders.First());
                    writeConfig(myReaders.First());
                    SetDeviceCombo.Items.Clear();
                    SetDeviceCombo.Items.AddRange(myReaders.ToArray());
                    SetDeviceCombo.SelectedIndex = 0;
                }
                else
                {
                    logAppend(Resources.没有发现任何有效的NFC设备);
                    logAppend(Resources.请检查接线是否正确_驱动是否正常安装_设备电源是否已经打开_);
                }
            }
            else
            {
                logAppend((string)e.UserState);
            }
            Application.DoEvents();
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
            b.ReportProgress(0, Resources.开始执行检测设备); running = true;
            List<string> myReader = new List<string>();
            process.OutputDataReceived += (s, _e) =>
            {
                b.ReportProgress(0, _e.Data);
                if (Properties.Settings.Default.NewScan)
                {
                    if (!string.IsNullOrEmpty(_e.Data))
                    {
                        Match m = Regex.Match(_e.Data, "pn532_uart:COM\\d+:115200");
                        if (m.Success)
                        {
                            myReader.Add(m.Value);
                        }
                    }
                }
            };
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false;
            running = false;
            b.ReportProgress(103, myReader);
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logAppend(Resources._软件版本 + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            localVersionLabel.Text = Resources.本地版本 + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Directory.CreateDirectory("auto_keys");
            checkBoxAutoABN.Checked = Properties.Settings.Default.AutoABN;
            checkBoxWriteProtect.Checked = Properties.Settings.Default.WriteCheck;
            checkBoxAutoLoadKey.Checked = Properties.Settings.Default.AutoLoadUidKey;
            richTextBox1.ForeColor = Properties.Settings.Default.MainCLIColor;
            buttonCLIColor.ForeColor = Properties.Settings.Default.MainCLIColor;
            checkBoxDefIsAdv.Checked = Properties.Settings.Default.DefIsAdv;
            checkBoxHardLowCost.Checked = Properties.Settings.Default.HardLowCost;
            checkBoxNewScan.Checked = Properties.Settings.Default.NewScan;
            checkBoxCuidKeyOver.Checked = Properties.Settings.Default.CuidKeyOver;
            if (Properties.Settings.Default.DefIsAdv)
            {
                tabControl1.SelectedIndex = 1;
            }
            //File.Delete("libnfc.conf");//用户COM口一般不常变化
            checkBoxMultiDev.Checked = Properties.Settings.Default.MultiMode;
            if (Properties.Settings.Default.MultiMode)
            {
                if (File.Exists("libnfc.conf"))
                {
                    string[] conf = File.ReadAllLines("libnfc.conf");
                    foreach (string line in conf)
                    {
                        if (line.StartsWith("device.connstring = \"pn532_uart:"))
                        {
                            curDevice.Text = Resources.设备串口 + line.Replace("device.connstring = \"pn532_uart:", "").Replace(":115200\"", "");
                        }
                    }
                }
            }
        }

        private void buttonScanCard_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
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
            b.ReportProgress(0,Resources.开始执行扫描卡片);
            running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        string omfd = "";

        private string GetUID()
        {
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-list.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            Process p = Process.Start(psi);
            p.WaitForExit();
            string rawStr = p.StandardOutput.ReadToEnd();
            string uid;
            string pattern = @"UID\s\(NFCID1\)\: ([0-9A-Fa-f]{2}\s\s[0-9A-Fa-f]{2}\s\s[0-9A-Fa-f]{2}\s\s[0-9A-Fa-f]{2})";
            if (Regex.IsMatch(rawStr, pattern))
            {
                uid = Regex.Match(rawStr, pattern).Captures[0].Value.Replace(" ", "").Replace("UID(NFCID1):", ""); ;
            }
            else
            {
                uid = "";
            }
            return uid;
        }
        private void LoadUidKey(string uid)
        {
            if (!Directory.Exists("auto_keys"))
            {
                Directory.CreateDirectory("auto_keys");
                return;
            }
            if (uid.Length < 8) { return; }
            logAppend(Resources.正在检索是否存在key_mfd);
            List<string> files = Directory.EnumerateFiles("auto_keys", "*.mfd").ToList<string>();
            files.Reverse();//保证拿到最新的
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].StartsWith("auto_keys\\" + uid))
                {
                    logAppend(Resources.已找到_K + files[i]);
                    keymfd = files[i];
                    buttonSelectKey.Text = "K=" + files[i];
                    return;
                }
            }
            return;
        }

        string lastuid = "";

        private void buttonMfRead_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string rmfd = "MfRead.tmp";
            string kt = "A";
            string nn = "";
            string uid;
            if (checkBoxAutoLoadKey.Checked)
            {
                uid = GetUID();
                LoadUidKey(uid);
            }
            if (checkBoxAutoSave.Checked)
            {
                lastuid = GetUID();
            }
            if (checkBoxAutoABN.Checked && keymfd != "")
            {
                kt = "C";
                logAppend(Resources.正在使用智能KeyABN);
            }
            else
            {
                switch (MessageBox.Show(Resources.使用KeyA_是_或KeyB_否_还是不使用_用于全新白卡_, "KeyA/B/N", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.No:
                        kt = "B";
                        break;

                    case DialogResult.Cancel:
                        nn = "x";
                        break;
                }
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_read);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt, nn });
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
            b.ReportProgress(0, Resources.开始执行读取卡片); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(101, Resources._运行完毕);
            }
            else
            {
                b.ReportProgress(100, Resources._运行出错);
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
            ofd.Filter = Resources.MFD文件_mfd_DUMP文件_dump;
            ofd.Title = Resources.请选择一个包含目标卡密钥的MFD文件_通常是已经破解出的该卡;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                keymfd = ofd.FileName;
                buttonSelectKey.Text = "K=" + ofd.SafeFileName;
            }
            else
            {
                keymfd = "";
                buttonSelectKey.Text = Resources.选择key_mfd;
            }
        }

        bool writecheck(string file)
        {
            if (checkBoxWriteProtect.Checked == false)
            { return true; }//如果禁用，直接假装检查成功
            S50 card = new S50();
            try
            {
                card.LoadFromMfd(file);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message, Resources.打开出错, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (card.Verify()[16] == 0x00)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonMfWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = Resources.MFD文件_mfd_dump;
            ofd.Title = Resources.请选择需要写入的MFD文件;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            if (!writecheck(rmfd)) { MessageBox.Show(Resources.将要写入的文件存在错误_请用高级模式中的Hex工具打开查看, Resources.错误, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            string kt = "A";
            string nn = "";
            if (checkBoxAutoABN.Checked && keymfd != "")
            {
                kt = "C";
                logAppend(Resources.正在使用智能KeyABN);
            }
            else
            {
                switch (MessageBox.Show(Resources.使用KeyA_是_或KeyB_否_还是不使用_用于全新白卡_, Resources.KeyA_B_N, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.No:
                        kt = "B";
                        break;

                    case DialogResult.Cancel:
                        nn = "x";
                        break;
                }
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_write);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt, nn });
        }

        void mf_write(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/nfc-mfclassic.exe");
            string[] args = (string[])e.Argument;
            psi.Arguments = "w " + args[1] + " u \"" + args[0] + "\"";
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
            b.ReportProgress(0, Resources.开始执行写入M1卡片); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonMfoc_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string rmfd = "Mfoc.tmp";
            string key = "";
            if (Control.ModifierKeys == Keys.Control)
            {
                string[] ks = Interaction.InputBox(Resources.请输入已知的Key_以英文半角逗号分隔, Resources.请输入已知Key, Properties.Settings.Default.LastTryKey, -1, -1).Trim().Split(',');
                if (ks.Length > 0)
                {
                    Properties.Settings.Default.LastTryKey = string.Join(",", ks);
                    foreach (string k in ks)
                    {
                        string pat = "[0-9A-Fa-f]{12}";
                        if (Regex.IsMatch(k, pat))
                        {
                            key += "-k " + k.Substring(0, 12) + " ";
                        }
                    }
                }
            }
            if (checkBoxAutoSave.Checked)
            {
                lastuid = GetUID();
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
            b.ReportProgress(0, Resources.开始执行MFOC解密); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(101, Resources._运行完毕);
            }
            else
            {
                b.ReportProgress(100, Resources._运行出错);
                File.Delete(args[0]);
            }
        }

        private void buttonUidReset_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(reset_uid);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        public static string hex(byte[] bytes)
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
            b.ReportProgress(0, Resources.开始执行重置UID卡片卡号); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonUidFormat_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            if (MessageBox.Show(Resources.该操作将会清空UID卡内全部数据_清空后不可恢复_请确认是否, Resources.危险操作警告, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
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
            b.ReportProgress(0, Resources.开始执行UID卡片全格); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonBmfRead_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = "BmfRead.tmp";
            if (checkBoxAutoSave.Checked)
            {
                lastuid = GetUID();
            }
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
            b.ReportProgress(0, Resources.开始执行UID卡片读取); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(101, Resources._运行完毕);
            }
            else
            {
                b.ReportProgress(100, Resources._运行出错);
                File.Delete(args[0]);
            }
        }

        private void buttonBmfWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = "MifareOne Tool - 运行中";
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "MFD文件|*.mfd;*.dump";
            ofd.Title = Resources.请选择需要写入的MFD文件;
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
            b.ReportProgress(0, Resources.开始执行UID卡片写入); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonConClr_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonConSave_Click(object sender, EventArgs e)
        {
            string logtext = richTextBox1.Text;
            File.WriteAllText("m1t.log", logtext, Encoding.UTF8);
            MessageBox.Show(Resources.终端内容已保存至m1t_log文件, Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void buttonUidWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            byte[] buid = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(buid);
            string uid = Interaction.InputBox(Resources.请输入需要写入的UID卡号_共8位十六进制数_如E44A3B, Resources.请输入UID号, hex(buid), -1, -1).Trim();
            string pat = "[0-9A-Fa-f]{8}";
            if (!Regex.IsMatch(uid, pat))
            {
                MessageBox.Show(Resources.输入的UID号不合法, "InputError", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            b.ReportProgress(0, Resources.开始执行UID卡片设定卡号); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonMfcuk_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Text = Resources.MifareOne_Tool_运行中;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(Mfcuk);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync();
        }

        void Mfcuk(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            ProcessStartInfo psi = new ProcessStartInfo("cmd");
            psi.Arguments = "/k mfcuk.exe -v 3 -C -R -1 -s 250 -S 250";
            psi.WorkingDirectory = "nfc-bin";
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi);
            b.ReportProgress(0, Resources.开始执行全加密卡片爆破);
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        bool cuidKeyOver = false;

        private void buttonCmfWrite_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string rmfd = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = Resources.MFD文件_mfd_dump;
            ofd.Title = Resources.请选择需要写入的MFD文件;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rmfd = ofd.FileName;
            }
            else
            {
                return;
            }
            if (!writecheck(rmfd)) { MessageBox.Show(Resources.将要写入的文件存在错误_请用高级模式中的Hex工具打开查看, Resources.错误, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (keymfd == "" && Properties.Settings.Default.CuidKeyOver)
            {
                cuidKeyOver = true;
                string uid = GetUID();
                S50 empty = new S50(Utils.Hex2Block(uid, 4));
                empty.ExportToMfd("cuid_empty.kmf");
                keymfd = "cuid_empty.kmf";
                logAppend(Resources.已启用CUID空卡写入补丁);
            }
            string kt = "A";
            string nn = "";
            if (checkBoxAutoABN.Checked && keymfd != "")
            {
                kt = "C";
                logAppend(Resources.正在使用智能KeyABN);
            }
            else
            {
                switch (MessageBox.Show(Resources.使用KeyA_是_或KeyB_否_还是不使用_用于全新白卡_, "KeyA/B/N", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.No:
                        kt = "B";
                        break;

                    case DialogResult.Cancel:
                        nn = "x";
                        break;
                }
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
            b.ReportProgress(0, Resources.开始执行CUID_FUID卡片写入); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            if (cuidKeyOver == true)
            {
                keymfd = "";
                cuidKeyOver = false;
                File.Delete("cuid_empty.kmf");
            }
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            if (lprocess)
            {
                if (process.HasExited == false)
                {
                    process.Kill();
                    Form1.ActiveForm.Text = Resources.MifareOne_Tool_已终止;
                    logAppend(Resources._程序已被强制停止);
                }
            }
        }

        private void buttonLockUfuid_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            if (MessageBox.Show(Resources.该操作将会锁死UFUID卡片_锁死后不可恢复_无法再次更改0, Resources.危险操作警告, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
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
            psi.Arguments = "-q -l";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi); 
            b.ReportProgress(0, Resources.开始执行UFUID卡片锁定); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonMfFormat_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (keymfd == "") { MessageBox.Show(Resources.未选择有效key_mfd, Resources.无密钥, MessageBoxButtons.OK, MessageBoxIcon.Error); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string rmfd = keymfd;
            string kt = "A";
            if (checkBoxAutoABN.Checked && keymfd != "")
            {
                kt = "C";
                logAppend(Resources.正在使用智能KeyABN);
            }
            else
            {
                switch (MessageBox.Show(Resources.使用KeyA_是_或KeyB_否, "KeyA/B", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    case DialogResult.No:
                        kt = "B";
                        break;
                }
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mf_format);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, kt });
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
            b.ReportProgress(0, Resources.开始执行格式化M1卡片); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            b.ReportProgress(100, Resources._运行完毕);
        }

        private void buttonEMfoc_Click(object sender, EventArgs e)
        {
            buttonMfoc_Click(sender, e);
        }

        private void buttonEscan_Click(object sender, EventArgs e)
        {
            buttonListDev_Click(sender, e);
        }

        private void buttoEScanCard_Click(object sender, EventArgs e)
        {
            buttonScanCard_Click(sender, e);
        }

        private void buttonECmfoc_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string rmfd = "Mfoc.tmp";
            string key = "";
            string[] ks = Interaction.InputBox(Resources.请输入已知的Key_以英文半角逗号分隔, Resources.请输入已知Key, "FFFFFFFFFFFF", -1, -1).Trim().Split(',');
            if (ks.Length > 0)
            {
                foreach (string k in ks)
                {
                    string pat = "[0-9A-Fa-f]{12}";
                    if (Regex.IsMatch(k, pat))
                    {
                        key += "-k " + k.Substring(0, 12) + " ";
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

        private void buttonEUpdate_Click(object sender, EventArgs e)
        {
            toolStripCheckUpdate_ButtonClick(sender, e);
        }

        private void buttonESelectKey_Click(object sender, EventArgs e)
        {
            buttonSelectKey_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonMfRead_Click(sender, e);
        }

        private void buttonEMfWrite_Click(object sender, EventArgs e)
        {
            buttonMfWrite_Click(sender, e);
        }

        private void buttonECuidWrite_Click(object sender, EventArgs e)
        {
            buttonCmfWrite_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonLockUfuid_Click(sender, e);
        }

        private void buttonEAdv_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void buttonEnAcr122u_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            if (MessageBox.Show(Resources.同时打开ACR122U支持可能会引起操作速度下降_请确认是否, Resources.提示信息, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            { Text = "MifareOne Tool"; return; }
            lprocess = true;
            if (File.Exists("nfc-bin/libnfc(PN532Only).dll"))
            {
                logAppend(Resources.ACR122U支持已经打开过);
            }
            if (File.Exists("nfc-bin/libnfc(ACR122U).dll"))
            {
                logAppend(Resources.正在打开ACR122U支持);
                File.Move("nfc-bin/libnfc.dll", "nfc-bin/libnfc(PN532Only).dll");
                File.Move("nfc-bin/libnfc(ACR122U).dll", "nfc-bin/libnfc.dll");
                logAppend(Resources.已打开);
            }
            lprocess = false; running = false;
            Text = Resources.MifareOne_Tool_运行完毕;
            logAppend(Resources._运行完毕);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (running)
            {
                statusLabel.Text = Resources.运行中;
                if (process.HasExited == false)
                {
                    DateTime now = DateTime.Now;
                    TimeSpan runtime = now - process.StartTime;
                    runTimeLabel.Text = Resources.运行时间 + ((int)runtime.TotalSeconds).ToString() + Resources.秒;
                }
            }
            else { statusLabel.Text = Resources.空闲; }
        }

        private void buttonCheckEncrypt_Click(object sender, EventArgs e)
        {//其实这个mfdetect就是个mfoc阉割版。。只检测不破解而已，所以-f -k什么的可以加上，测试自己的key
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string key = "";
            if (Control.ModifierKeys == Keys.Control)
            {
                string[] ks = Interaction.InputBox(Resources.请输入已知的Key_以英文半角逗号分隔, Resources.请输入已知Key, Properties.Settings.Default.LastTryKey, -1, -1).Trim().Split(',');
                if (ks.Length > 0)
                {
                    Properties.Settings.Default.LastTryKey = string.Join(",", ks);
                    foreach (string k in ks)
                    {
                        string pat = "[0-9A-Fa-f]{12}";
                        if (Regex.IsMatch(k, pat))
                        {
                            key += "-k " + k.Substring(0, 12) + " ";
                        }
                    }
                }
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(MfDetect);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(key);
        }

        void MfDetect(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/mfdetect.exe");
            psi.Arguments = (string)(e.Argument) + "-O dummy.tmp";
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi); 
            b.ReportProgress(0, Resources.开始执行检测卡片加密); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            File.Delete("dummy.tmp");
            lprocess = false; running = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(100, Resources._运行完毕);
            }
            else
            {
                b.ReportProgress(100, Resources._运行出错);
            }
        }

        private void buttonHexTool_Click(object sender, EventArgs e)
        {
            FormHTool fht = new FormHTool();
            fht.Show();
        }

        private void buttonECheckEncrypt_Click(object sender, EventArgs e)
        {
            buttonCheckEncrypt_Click(sender, e);
        }

        private void toolStripCheckUpdate_ButtonClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/xcicode/MifareOneTool/releases/latest");
        }

        private void buttonDiffTool_Click(object sender, EventArgs e)
        {
            FormDiff df = new FormDiff();
            df.Show();
        }

        private void buttonnKeysMfoc_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string rmfd = "Mfoc.tmp";
            string key = "";
            string[] ks = Interaction.InputBox(Resources.请输入已知的Key_以英文半角逗号分隔, Resources.请输入已知Key, Properties.Settings.Default.LastTryKey, -1, -1).Trim().Split(',');
            if (ks.Length > 0)
            {
                Properties.Settings.Default.LastTryKey = string.Join(",", ks);
                foreach (string k in ks)
                {
                    string pat = "[0-9A-Fa-f]{12}";
                    if (Regex.IsMatch(k, pat))
                    {
                        key += "-k " + k.Substring(0, 12) + " ";
                    }
                }
            }
            if (checkBoxAutoSave.Checked)
            {
                lastuid = GetUID();
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mfoc);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, key });
            omfd = rmfd;
        }

        private void buttonDictMfoc_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            string cmd_mode = "/k";
            //if (Control.ModifierKeys == Keys.Control)
            //{
            //    cmd_mode="/k";
            //}
            string filename = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = Resources.密钥字典文件_dic;
            ofd.Title = Resources.请选择需要打开的密钥字典文件;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            else
            {
                Text = Resources.MifareOne_Tool_已取消;
                return;
            }
            string rmfd = "Mfoc.tmp";
            string key = "-f \"" + filename + "\" ";
            if (checkBoxAutoSave.Checked)
            {
                lastuid = GetUID();
            }
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(mfocCMD);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
            bgw.RunWorkerAsync(new string[] { rmfd, key, cmd_mode });
            omfd = rmfd;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        public static extern int SetWindowText(IntPtr hwnd, string lpString);
        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        void mfocCMD(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            string[] args = (string[])e.Argument;
            psi.WorkingDirectory = "./";
            psi.Arguments = "/T:0A " + args[2] + @" nfc-bin\mfoc.exe " + args[1] + " -O \"" + args[0] + "\"";
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi); 
            b.ReportProgress(0, Resources.开始执行字典模式MFOC解密); running = true;
            process.WaitForExit();
            lprocess = false; running = false;
            if (process.ExitCode == -1073741510)    //Why this
            {
                b.ReportProgress(101, Resources._运行完毕);
            }
            else
            {
                b.ReportProgress(100, Resources._运行出错);
                File.Delete(args[0]);
            }
        }

        private void checkBoxAutoABN_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoABN = checkBoxAutoABN.Checked;
        }

        private void buttonEUIDWrite_Click(object sender, EventArgs e)
        {
            buttonBmfWrite_Click(sender, e);
        }

        private void buttonEReadUID_Click(object sender, EventArgs e)
        {
            buttonBmfRead_Click(sender, e);
        }

        private void checkBoxWriteProtect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WriteCheck = checkBoxWriteProtect.Checked;
        }

        private void buttonHardNested_Click(object sender, EventArgs e)
        {
            if (lprocess) { MessageBox.Show(Resources.有任务运行中_不可执行, Resources.设备忙, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; } Form1.ActiveForm.Text = Resources.MifareOne_Tool_运行中;
            FormHardNes fhn = new FormHardNes();
            if (fhn.ShowDialog() == DialogResult.Yes)
            {
                string hardargs = fhn.GetArg();
                BackgroundWorker bgw = new BackgroundWorker();
                if (fhn.collectOnly())
                {
                    //lastuid = "0x" + GetUID() + fhn.GetFileAfter();
                    bgw.DoWork += new DoWorkEventHandler(CollectNonce);
                }
                else
                {
                    bgw.DoWork += new DoWorkEventHandler(Hardnest);
                }
                bgw.WorkerReportsProgress = true;
                bgw.ProgressChanged += new ProgressChangedEventHandler(default_rpt);
                bgw.RunWorkerAsync(hardargs);
            }
            else
            {
                Text = Resources.MifareOne_Tool_已取消;
            }
        }
        void Hardnest(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo("nfc-bin/libnfc_hardnested.exe");
            if (Properties.Settings.Default.HardLowCost)
            {
                psi.FileName = "nfc-bin/libnfc_hardnestedlc.exe";
            }
            psi.Arguments = (string)e.Argument;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi); 
            b.ReportProgress(0, Resources.开始执行HardNested解密强化卡); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(100, Resources._运行完毕);
            }
            else
            {
                b.ReportProgress(100, Resources._运行出错);
            }
        }

        void CollectNonce(object sender, DoWorkEventArgs e)
        {
            if (lprocess) { return; }
            ProcessStartInfo psi = new ProcessStartInfo(Resources.nfc_bin_collect_exe);
            psi.Arguments = (string)e.Argument;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            lprocess = true;
            BackgroundWorker b = (BackgroundWorker)sender;
            process = Process.Start(psi); 
            b.ReportProgress(0, Resources.开始执行HardNested收集数据); running = true;
            process.OutputDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            process.ErrorDataReceived += (s, _e) => b.ReportProgress(0, _e.Data);
            //StreamReader stderr = process.StandardError;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            lprocess = false; running = false;
            if (process.ExitCode == 0)
            {
                b.ReportProgress(102, Resources._运行完毕);
            }
            else
            {
                b.ReportProgress(100, Resources._运行出错);
            }
        }

        private void checkBoxAutoLoadKey_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoLoadUidKey = checkBoxAutoLoadKey.Checked;
        }

        private void buttonCLIColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.AnyColor = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = cd.Color;
                buttonCLIColor.ForeColor = cd.Color;
                Properties.Settings.Default.MainCLIColor = cd.Color;
            }
        }

        private void numericCLIFontSize_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, (float)numericCLIFontSize.Value);
            Properties.Settings.Default.MainCLIFontSize = (float)numericCLIFontSize.Value;
        }

        private void checkBoxDefIsAdv_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefIsAdv = checkBoxDefIsAdv.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void checkBoxAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSave = checkBoxAutoSave.Checked;
        }

        private void checkBoxHardLowCost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HardLowCost = checkBoxHardLowCost.Checked;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NewScan = checkBoxNewScan.Checked;
        }

        private void buttonEStop_Click(object sender, EventArgs e)
        {
            buttonKill_Click(sender, e);
        }

        private void SetDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetDeviceCombo.SelectedIndex >= 0)
            {
                writeConfig(SetDeviceCombo.SelectedItem.ToString());
                logAppend(Resources.已指定使用该NFC设备 + SetDeviceCombo.SelectedItem.ToString());
            }
        }

        private void checkBoxMultiDev_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MultiMode = checkBoxMultiDev.Checked;
        }

        private void checkBoxCuidKeyOver_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CuidKeyOver = checkBoxCuidKeyOver.Checked;
        }

        private void buttonMFF08_Click(object sender, EventArgs e)
        {
            FormMFF08 mff08 = new FormMFF08();
            mff08.ShowDialog();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
