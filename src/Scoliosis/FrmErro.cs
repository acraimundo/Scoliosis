using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scoliosis
{
    public partial class FrmErro : Scoliosis.FrmBaseDialog
    {
        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>
        public FrmErro()
        {
            InitializeComponent();
        }

        #endregion

        #region Mensagem

        public string Mensagem
        {
            set
            {
                this.txtMensagem.Text = value;
            }
        }

        #endregion
    }
}

