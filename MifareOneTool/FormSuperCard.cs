using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MifareOneTool
{
    public partial class FormSuperCard : Form
    {
        public FormSuperCard(ref Process pro)
        {
            InitializeComponent();
            this.pro = pro;
        }

        Process pro;

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
