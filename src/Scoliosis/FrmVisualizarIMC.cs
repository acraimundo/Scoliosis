using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;
using Scoliosis.BusinessEntity;
using Scoliosis.BusinessComponent;

namespace Scoliosis
{
    public partial class FrmVisualizarIMC : Scoliosis.FrmBaseDialog
    {
        private PacienteDs.PacienteRow pacienteRow = null;
        private bool travarBusca = false;
        private ResourceManager resourceMgr = null;
        private UsuarioDs.UsuarioRow usuarioRow = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmVisualizarIMC()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        /// <summary>
        /// Define usuário que está visualizando o IMC.
        /// </summary>
        public UsuarioDs.UsuarioRow Usuario
        {
            set
            {
                this.usuarioRow = value;
            }
        }

        /// <summary>
        /// Lista cálculos de IMC do paciente.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        private void ListarCalculosIMC(int codigoPaciente)
        {
            // modifica cursor
            Cursor.Current = Cursors.WaitCursor;

            // trava busca
            this.travarBusca = true;

            // desabilita botão
            this.btnExcluir.Enabled = false;

            try
            {
                // componente de negócio
                PacienteBc pacienteBc = new PacienteBc();

                // busca pelo paciente
                this.pacienteRow = pacienteBc.BuscarPaciente(codigoPaciente);

                // nome do paciente
                this.txtPaciente.Text = this.pacienteRow.Nome;

                // lista cálculos
                CalculoIMCDs calculoIMCDs = pacienteBc.ListarCalculosIMC(this.pacienteRow.CodigoPaciente);

                // lista cálculos de IMC
                this.lstCalculos.DataSource = calculoIMCDs.CalculoIMC;
                this.lstCalculos.DisplayMember = "Data";
                this.lstCalculos.ValueMember = "CodigoCalculoIMC";
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
                Cursor.Current = Cursors.Default;

                // destrava busca
                this.travarBusca = false;
            }

            // seleciona cálculo
            if (this.lstCalculos.SelectedItems.Count > 0)
                this.lstCalculos_SelectedIndexChanged(this.lstCalculos, new EventArgs());
        }

        /// <summary>
        /// Busca pelo paciente.
        /// </summary>
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            // escolha do paciente
            FrmBuscarPaciente frmBuscarPaciente = new FrmBuscarPaciente();
            if (frmBuscarPaciente.ShowDialog(this) == DialogResult.Cancel)
            {
                frmBuscarPaciente.Dispose();
                return;
            }

            // lista cálculos
            ListarCalculosIMC(frmBuscarPaciente.CodigoPaciente);

            // libera memória
            frmBuscarPaciente.Dispose();
        }

        /// <summary>
        /// Mostra os dados do cálculo do IMC.
        /// </summary>
        private void lstCalculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verifica trava da busca
            if (this.travarBusca)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.btnExcluir.Enabled = false;

            try
            {
                // componentes de negócio
                CalculoIMCBc calculoIMCBc = new CalculoIMCBc();
                UsuarioBc usuarioBc = new UsuarioBc();
                PacienteBc pacienteBc = new PacienteBc();

                // busca cálculo do IMC
                CalculoIMCDs.CalculoIMCRow calculoIMCRow = calculoIMCBc.BuscarCalculoIMC((int)this.lstCalculos.SelectedValue);

                // busca fisioterapeuta
                UsuarioDs.UsuarioRow usuario = usuarioBc.BuscarUsuario(calculoIMCRow.CodigoUsuario);

                // mostra dados
                this.lblAlturaCalculada.Text = calculoIMCRow.Altura.ToString("0.00") + " m";
                this.lblMassaCalculada.Text = calculoIMCRow.Massa.ToString("0.0") + " kg";

                // calcula IMC
                float imc = (float)(calculoIMCRow.Altura * calculoIMCRow.Altura);
                if (imc > 0.01f)
                    imc = (float)calculoIMCRow.Massa / imc;
                this.lblIMCCalculado.Text = imc.ToString("0.0") + " kg/m²";

                // cria componente bc
                CalculoIMCBc calculoIMC = new CalculoIMCBc();

                // classifica paciente
                int tipoIMC = calculoIMC.ClassificarIMC(imc);

                string tipo = this.resourceMgr.GetString("MSGTIPOIMC" + tipoIMC.ToString("00"));

                this.lblClassificacaoDiagnosticada.Text = tipo;

                // fisioterapeuta
                this.lblFisioterapeutaCadastrado.Text = usuario.Nome;

                // observações
                this.txtObservacoes.Text = calculoIMCRow.Observacoes;

                // imagem
                byte[] imagem;
                pacienteBc.BuscarImagem(calculoIMCRow.CodigoImagem, out imagem);

                // cria bitmap
                System.IO.MemoryStream memStream = new System.IO.MemoryStream(imagem);
                Bitmap bitmap = new Bitmap(memStream);
                this.pctImagem.Image = bitmap;

                // verifica se é o fisioterapeuta que criou o cálculo
                this.btnExcluir.Enabled = (usuario.CodigoUsuario == this.usuarioRow.CodigoUsuario);
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
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Exclui o cálculo do IMC selecionado.
        /// </summary>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.lstCalculos.SelectedValue == null)
                return;

            // mensagem de confirmação
            if (MessageBox.Show(this, this.resourceMgr.GetString("MSG0036"), this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                CalculoIMCBc calculoIMCBc = new CalculoIMCBc();

                // exclui o cálculo
                calculoIMCBc.ExcluirCalculoIMC((int)this.lstCalculos.SelectedValue);

                // lista cálculos
                ListarCalculosIMC(this.pacienteRow.CodigoPaciente);
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

            Cursor.Current = Cursors.Default;
        }
    }
}



