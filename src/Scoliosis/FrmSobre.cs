using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace Scoliosis
{
    public partial class FrmSobre : Scoliosis.FrmBaseDialog
    {
        public FrmSobre()
        {
            InitializeComponent();

            this.lblSistema.Text = "Scoliosis (" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";
        }

        private void FrmSobre_Load(object sender, EventArgs e)
        {

        }

        private void btnInfoSistema_Click(object sender, EventArgs e)
        {
            Process.Start("msinfo32.exe");
        }
    }
}

