using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using Scoliosis.BusinessEntity;
using Scoliosis.BusinessComponent;

namespace Scoliosis
{
    public partial class FrmNovoIMC_1 : Scoliosis.FrmBaseDialog
    {
        private PacienteDs.PacienteRow pacienteRow = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovoIMC_1()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        /// <summary>
        /// Busca pelo paciente.
        /// </summary>
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            // desabilita botão
            this.btnProximo.Enabled = false;

            // escolha do paciente
            FrmBuscarPaciente frmBuscarPaciente = new FrmBuscarPaciente();
            if (frmBuscarPaciente.ShowDialog(this) == DialogResult.Cancel)
            {
                frmBuscarPaciente.Dispose();
                return;
            }

            // modifica cursor
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                PacienteBc pacienteBc = new PacienteBc();

                // busca pelo paciente
                this.pacienteRow = pacienteBc.BuscarPaciente(frmBuscarPaciente.CodigoPaciente);

                // nome do paciente
                this.txtPaciente.Text = this.pacienteRow.Nome;

                // habilita botão
                this.btnProximo.Enabled = true;
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
            finally
            {
                frmBuscarPaciente.Dispose();
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Retorna o paciente escolhido.
        /// </summary>
        public PacienteDs.PacienteRow Paciente
        {
            get
            {
                return this.pacienteRow;
            }
        }
    }
}

