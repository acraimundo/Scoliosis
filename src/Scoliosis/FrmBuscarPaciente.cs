using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using Scoliosis.BusinessComponent;
using Scoliosis.BusinessEntity;

namespace Scoliosis
{
    public partial class FrmBuscarPaciente : Scoliosis.FrmBaseDialog
    {
        private ResourceManager resourceMgr = null;

        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>
        public FrmBuscarPaciente()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        #endregion

        #region Diversos

        /// <summary>
        /// Realiza listagem dos pacientes.
        /// </summary>
        private void ListarPacientes()
        {
            this.lstPacientes.DataSource = null;

            try
            {
                // componente de negócio
                PacienteBc pacienteBc = new PacienteBc();

                // lista pacientes
                PacienteDs pacienteDs = pacienteBc.ListarPacientes(this.txtNome.Text);

                // data bind
                this.lstPacientes.DataSource = pacienteDs.Paciente;
                this.lstPacientes.DisplayMember = "Nome";
                this.lstPacientes.ValueMember = "CodigoPaciente";
            }
            catch (Exception ex)
            {
                string strMessage = this.resourceMgr.GetString(ex.Message);

                if (strMessage == null)
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = ex.Message;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
                else
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = strMessage;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
            }
        }

        #endregion

        #region Eventos - ListBox

        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = (this.lstPacientes.SelectedValue != null && this.lstPacientes.DisplayMember != "");
        }

        #endregion

        #region Eventos - TextBox

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNome.Text.Trim().Length < 3)
                return;

            Cursor.Current = Cursors.WaitCursor;

            ListarPacientes();

            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Propriedades

        public int CodigoPaciente
        {
            get
            {
                if (this.lstPacientes.SelectedValue != null)
                    return (int)this.lstPacientes.SelectedValue;
                return 0;
            }
        }

        #endregion
    }
}

