using MifareOneTool.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace MifareOneTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.MultiMode)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

      //Show the language select dialog
      MultiLang.SelectLanguage frmLang = new MultiLang.SelectLanguage() ;
      frmLang.LoadSettingsAndShow() ;
      frmLang.Dispose() ;
      frmLang = null ;

                Application.Run(new Form1());
            }
            else
            {
                bool ret;
                System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
                if (ret)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    mutex.ReleaseMutex();
                }
                else
                {
                    if (MessageBox.Show(Resources.您已经运行了MifareOne_Tool_打开多个本程序可能, Resources.您正在试图重复运行, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                        mutex.ReleaseMutex();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
