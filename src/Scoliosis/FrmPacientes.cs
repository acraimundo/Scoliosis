using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Resources;
using System.Reflection;
using Scoliosis.BusinessEntity;
using Scoliosis.BusinessComponent;

namespace Scoliosis
{ 
    public partial class FrmPacientes : Scoliosis.FrmBaseDialog
    {
        #region Atributos

        private enum Estado
        {
            Limpo = 0,
            Incluindo = 1,
            Mostrando = 2,
            Alterando = 3
        };

        private Estado estado = Estado.Limpo;
        private PacienteDs.PacienteRow pacienteRow = null;
        private ResourceManager resourceMgr = null;

        #endregion

        #region Construtor

        public FrmPacientes()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        #endregion

        #region Diversos

        /// <summary>
        /// Realiza mudança do estado do formulário.
        /// </summary>
        /// <param name="novoEstado">Novo estado.</param>
        private void MudarEstado(Estado novoEstado)
        {
            this.estado = novoEstado;

            if (this.estado == Estado.Limpo)
            {
                this.btnNovo.Enabled = true;
                this.btnCriar.Enabled = false;
                this.btnAlterar.Enabled = false;
                this.btnExcluir.Enabled = false;
            }
            else if (this.estado == Estado.Incluindo)
            {
                this.btnNovo.Enabled = true;
                this.btnCriar.Enabled = true;
                this.btnAlterar.Enabled = false;
                this.btnExcluir.Enabled = false;
            }
            else if (this.estado == Estado.Mostrando)
            {
                this.btnNovo.Enabled = true;
                this.btnCriar.Enabled = false;
                this.btnAlterar.Enabled = false;
                this.btnExcluir.Enabled = true;
            }
            else
            {
                this.btnNovo.Enabled = true;
                this.btnCriar.Enabled = false;
                this.btnAlterar.Enabled = true;
                this.btnExcluir.Enabled = true;
            }
        }

        /// <summary>
        /// Limpa os campos.
        /// </summary>
        private void LimparCampos()
        {
            this.txtNome.Text = "";
            this.mtxtCPF.Text = "";
            this.dtpDataNascimento.Value = DateTime.Now;
            this.txtEndereco.Text = "";
            this.txtComplemento.Text = "";
            this.txtBairro.Text = "";
            this.mtxtCEP.Text = "";
            this.txtCidade.Text = "";
            this.cmbEstado.SelectedIndex = 17;
            this.cmbSexo.SelectedIndex = 0;
            this.txtNacionalidade.Text = "";
            this.txtEmail.Text = "";
            this.txtFoneResidencial.Text = "";
            this.txtFoneComercial.Text = "";
            this.txtFoneCelular.Text = "";
            this.txtObservacoesGerais.Text = "";
        }

        /// <summary>
        /// Realiza validação dos campos.
        /// </summary>
        private bool ValidarCampos()
        {
            this.txtNome.Text = this.txtNome.Text.Trim();
            this.mtxtCPF.Text = this.mtxtCPF.Text.Trim();
            this.txtEndereco.Text = this.txtEndereco.Text.Trim();
            this.txtComplemento.Text = this.txtComplemento.Text.Trim();
            this.txtBairro.Text = this.txtBairro.Text.Trim();
            this.mtxtCEP.Text = this.mtxtCEP.Text.Trim();
            this.txtCidade.Text = this.txtCidade.Text.Trim();
            this.txtNacionalidade.Text = this.txtNacionalidade.Text.Trim();
            this.txtEmail.Text = this.txtEmail.Text.Trim();
            this.txtFoneResidencial.Text = this.txtFoneResidencial.Text.Trim();
            this.txtFoneComercial.Text = this.txtFoneComercial.Text.Trim();
            this.txtFoneCelular.Text = this.txtFoneCelular.Text.Trim();
            this.txtObservacoesGerais.Text = this.txtObservacoesGerais.Text.Trim();

            if (this.txtNome.Text.Length == 0)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0023"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtNome.Focus();
                return false;
            }

            if (this.mtxtCPF.Text.Length != 11)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0024"), this.Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.mtxtCPF.Focus();
                return false;
            }

            // valida e-mail
            if (this.txtEmail.Text.Length != 0)
            {
                if (!Regex.Match(this.txtEmail.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").Success)
                {
                    MessageBox.Show(this, this.resourceMgr.GetString("MSG0025"), this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Eventos- Button

        /// <summary>
        /// Busca pelo paciente.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarPaciente frmBuscarPaciente = new FrmBuscarPaciente();
            if (frmBuscarPaciente.ShowDialog(this) == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    // componente de negócio
                    PacienteBc pacienteBc = new PacienteBc();

                    // busca pelo paciente
                    this.pacienteRow = pacienteBc.BuscarPaciente(frmBuscarPaciente.CodigoPaciente);

                    // atribui dados aos controles
                    this.txtNome.Text = this.pacienteRow.Nome;
                    this.mtxtCPF.Text = this.pacienteRow.CPF;
                    this.dtpDataNascimento.Value = this.pacienteRow.DataNascimento;
                    this.txtEndereco.Text = this.pacienteRow.Endereco;
                    this.txtComplemento.Text = this.pacienteRow.Complemento;
                    this.txtBairro.Text = this.pacienteRow.Bairro;
                    this.mtxtCEP.Text = this.pacienteRow.CEP;
                    this.txtCidade.Text = this.pacienteRow.Cidade;
                    this.cmbEstado.SelectedIndex = this.cmbEstado.FindStringExact(this.pacienteRow.Estado);
                    this.cmbSexo.SelectedIndex = (this.pacienteRow.Sexo) ? 1 : 0;
                    this.txtNacionalidade.Text = this.pacienteRow.Nacionalidade;
                    this.txtEmail.Text = this.pacienteRow.Email;
                    this.txtFoneResidencial.Text = this.pacienteRow.TelefoneResidencial;
                    this.txtFoneComercial.Text = this.pacienteRow.TelefoneComercial;
                    this.txtFoneCelular.Text = this.pacienteRow.TelefoneCelular;
                    this.txtObservacoesGerais.Text = this.pacienteRow.Observacoes; 

                    // muda estado
                    MudarEstado(Estado.Mostrando);
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

            frmBuscarPaciente.Dispose();
        }

        /// <summary>
        /// Prepara para criação de um novo paciente.
        /// </summary>
        private void btnNovo_Click(object sender, EventArgs e)
        {
            // limpa campos
            LimparCampos();

            // foco no nome
            this.txtNome.Focus();

            // modifica estado
            MudarEstado(Estado.Limpo);
        }

        /// <summary>
        /// Criação de um paciente.
        /// </summary>
        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                PacienteBc pacienteBc = new PacienteBc();

                // dataSet do paciente
                PacienteDs pacienteDs = new PacienteDs();
                this.pacienteRow = pacienteDs.Paciente.NewPacienteRow();

                // valores dos controles
                this.pacienteRow.Nome = this.txtNome.Text;
                this.pacienteRow.CPF = this.mtxtCPF.Text;
                this.pacienteRow.DataNascimento = this.dtpDataNascimento.Value;
                this.pacienteRow.Endereco = this.txtEndereco.Text;
                this.pacienteRow.Complemento = this.txtComplemento.Text;
                this.pacienteRow.Bairro = this.txtBairro.Text;
                this.pacienteRow.CEP = this.mtxtCEP.Text;
                this.pacienteRow.Cidade = this.txtCidade.Text;
                this.pacienteRow.Estado = this.cmbEstado.Text;
                this.pacienteRow.Sexo = (this.cmbSexo.SelectedIndex == 1);
                this.pacienteRow.Nacionalidade = this.txtNacionalidade.Text;
                this.pacienteRow.Email = this.txtEmail.Text;
                this.pacienteRow.TelefoneResidencial = this.txtFoneResidencial.Text;
                this.pacienteRow.TelefoneComercial = this.txtFoneComercial.Text;
                this.pacienteRow.TelefoneCelular = this.txtFoneCelular.Text;
                this.pacienteRow.Observacoes = this.txtObservacoesGerais.Text;

                // cria o paciente
                this.pacienteRow.CodigoPaciente = pacienteBc.CriarPaciente(this.pacienteRow);

                // muda o estado
                MudarEstado(Estado.Mostrando);
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

        /// <summary>
        /// Alteração de um paciente.
        /// </summary>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                PacienteBc pacienteBc = new PacienteBc();

                // valores dos controles
                this.pacienteRow.Nome = this.txtNome.Text;
                this.pacienteRow.CPF = this.mtxtCPF.Text;
                this.pacienteRow.DataNascimento = this.dtpDataNascimento.Value;
                this.pacienteRow.Endereco = this.txtEndereco.Text;
                this.pacienteRow.Complemento = this.txtComplemento.Text;
                this.pacienteRow.Bairro = this.txtBairro.Text;
                this.pacienteRow.CEP = this.mtxtCEP.Text;
                this.pacienteRow.Cidade = this.txtCidade.Text;
                this.pacienteRow.Estado = this.cmbEstado.Text;
                this.pacienteRow.Sexo = (this.cmbSexo.SelectedIndex == 1);
                this.pacienteRow.Nacionalidade = this.txtNacionalidade.Text;
                this.pacienteRow.Email = this.txtEmail.Text;
                this.pacienteRow.TelefoneResidencial = this.txtFoneResidencial.Text;
                this.pacienteRow.TelefoneComercial = this.txtFoneComercial.Text;
                this.pacienteRow.TelefoneCelular = this.txtFoneCelular.Text;
                this.pacienteRow.Observacoes = this.txtObservacoesGerais.Text;

                // altera o paciente
                pacienteBc.AlterarPaciente(this.pacienteRow);

                // muda o estado
                MudarEstado(Estado.Mostrando);
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

        /// <summary>
        /// Exclui o paciente.
        /// </summary>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // mensagem de confirmação
            if (MessageBox.Show(this, this.resourceMgr.GetString("MSG0026"), this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                PacienteBc pacienteBc = new PacienteBc();

                // exclui o paciente
                pacienteBc.ExcluirPaciente(pacienteRow.CodigoPaciente);

                // limpa campos
                LimparCampos();

                // muda o estado
                MudarEstado(Estado.Limpo);
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

        #endregion

        #region Eventos - Form

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            // cultura da máscara
            this.mtxtCPF.Culture = new CultureInfo("en-US");
            this.mtxtCEP.Culture = new CultureInfo("en-US");

            // limpa campos
            LimparCampos();

            // modifica estado
            MudarEstado(Estado.Limpo);
        }

        #endregion

        #region Eventos - Changed

        private void Control_Changed(object sender, EventArgs e)
        {
            if (this.estado == Estado.Limpo)
                MudarEstado(Estado.Incluindo);
            else if (this.estado == Estado.Mostrando)
                MudarEstado(Estado.Alterando);
        }

        #endregion
    }
}

