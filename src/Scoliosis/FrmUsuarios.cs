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
    public partial class FrmUsuarios : Scoliosis.FrmBaseDialog
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
        private UsuarioDs.UsuarioRow usuarioRow = null;
        private ResourceManager resourceMgr = null;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>
        public FrmUsuarios()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();

            this.cmbTipo.SelectedIndex = 0;
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
            this.txtLogin.Text = "";
            this.txtSenha.Text = "";
            this.cmbTipo.SelectedIndex = 1;
        }

        /// <summary>
        /// Valida os campos.
        /// </summary>
        /// <returns>True se os campos são válidos e false, caso contrário.</returns>
        private bool ValidarCampos()
        {
            this.txtNome.Text = this.txtNome.Text.Trim();
            this.txtLogin.Text = this.txtLogin.Text.Trim();
            this.txtSenha.Text = this.txtSenha.Text.Trim();

            if (this.txtNome.Text.Length == 0)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0024"), this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtNome.Focus();
                return false;
            }

            if (this.txtLogin.Text.Length == 0)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0028"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtLogin.Focus();
                return false;
            }

            if (this.txtSenha.Text.Length == 0)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0029"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtSenha.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Listagem dos usuários.
        /// </summary>
        private void ListarUsuarios()
        {
            // limpa lista
            this.lstUsuarios.DataSource = null;

            try
            {
                // componente de negócio
                UsuarioBc usuarioBc = new UsuarioBc();

                // lista os usuários
                UsuarioDs usuarioDs = usuarioBc.ListarUsuarios();

                // data binding
                this.lstUsuarios.DataSource = usuarioDs.Usuario;
                this.lstUsuarios.DisplayMember = "Nome";
                this.lstUsuarios.ValueMember = "CodigoUsuario";
            }
            catch (Exception ex)
            {
                FrmErro frmErro = new FrmErro();
                frmErro.Mensagem = ex.Message;
                frmErro.ShowDialog(this);
                frmErro.Dispose();
            }
        }

        #endregion

        #region Eventos - Form

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // estado inicial
            MudarEstado(Estado.Limpo);

            // lista usuários
            ListarUsuarios();

            // força seleção da lista
            this.lstUsuarios_SelectedIndexChanged(this.lstUsuarios, new EventArgs());

            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Eventos - Button

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // limpa campos
            LimparCampos();

            // modifica estado
            MudarEstado(Estado.Limpo);

            // foco no nome
            this.txtNome.Focus();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            // valida campos
            if (!ValidarCampos())
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                UsuarioBc usuarioBc = new UsuarioBc();

                // cria dataSet do usuário
                UsuarioDs usuarioDs = new UsuarioDs();
                this.usuarioRow = usuarioDs.Usuario.NewUsuarioRow();

                // dados
                this.usuarioRow.Nome = this.txtNome.Text;
                this.usuarioRow.Login = this.txtLogin.Text;
                this.usuarioRow.Senha = this.txtSenha.Text;
                this.usuarioRow.Tipo = (byte)this.cmbTipo.SelectedIndex;

                // cria o usuário
                this.usuarioRow.CodigoUsuario = usuarioBc.CriarUsuario(this.usuarioRow.Nome, this.usuarioRow.Login,
                        this.usuarioRow.Senha, this.usuarioRow.Tipo);

                // código do usuário
                int codigoUsuario = this.usuarioRow.CodigoUsuario;

                // lista usuários
                ListarUsuarios();

                // seleciona o usuário criado
                this.lstUsuarios.SelectedValue = codigoUsuario;
            }
            catch (Exception ex)
            {
                FrmErro frmErro = new FrmErro();
                frmErro.Mensagem = ex.Message;
                frmErro.ShowDialog(this);
                frmErro.Dispose();
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // valida campos
            if (!ValidarCampos())
                return;

            // mensagem de confirmação
            if (this.txtSenha.Text != this.usuarioRow.Senha)
            {
                if (MessageBox.Show(this, this.resourceMgr.GetString("MSG0030"), this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                UsuarioBc usuarioBc = new UsuarioBc();

                // novos dados
                this.usuarioRow.Nome = this.txtNome.Text;
                this.usuarioRow.Login = this.txtLogin.Text;
                this.usuarioRow.Senha = this.txtSenha.Text;
                this.usuarioRow.Tipo = (byte)this.cmbTipo.SelectedIndex;

                // altera o usuário
                usuarioBc.AlterarUsuario(this.usuarioRow.CodigoUsuario, this.usuarioRow.Nome, 
                    this.usuarioRow.Login, this.usuarioRow.Senha, this.usuarioRow.Tipo);

                // codigo do usuário
                int codigoUsuario = this.usuarioRow.CodigoUsuario;

                // lista os usuários
                ListarUsuarios();

                // seleciona o usuário alterado
                this.lstUsuarios.SelectedValue = codigoUsuario;
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // mensagem de confirmação
            if (MessageBox.Show(this, this.resourceMgr.GetString("MSG0031"), this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                UsuarioBc usuarioBc = new UsuarioBc();

                // exclui o usuário
                usuarioBc.ExcluirUsuario(this.usuarioRow.CodigoUsuario);

                // lista os usuários
                ListarUsuarios();

                // força seleção da lista
                this.lstUsuarios_SelectedIndexChanged(this.lstUsuarios, new EventArgs());
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

        #region Eventos - ListBox

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstUsuarios.SelectedValue == null || this.lstUsuarios.ValueMember == "")
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                UsuarioBc usuarioBc = new UsuarioBc();

                // busca pelo usuário
                this.usuarioRow = usuarioBc.BuscarUsuario((int)this.lstUsuarios.SelectedValue);

                // dados do usuário
                this.txtNome.Text = this.usuarioRow.Nome;
                this.txtLogin.Text = this.usuarioRow.Login;
                this.txtSenha.Text = this.usuarioRow.Senha;
                this.cmbTipo.SelectedIndex = (int)this.usuarioRow.Tipo;

                // modifica estado
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

        #endregion

        #region Eventos - Changed

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (this.estado == Estado.Limpo)
                MudarEstado(Estado.Incluindo);
            else if (this.estado == Estado.Mostrando)
                MudarEstado(Estado.Alterando);
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            if (this.estado == Estado.Limpo)
                MudarEstado(Estado.Incluindo);
            else if (this.estado == Estado.Mostrando)
                MudarEstado(Estado.Alterando);
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (this.estado == Estado.Limpo)
                MudarEstado(Estado.Incluindo);
            else if (this.estado == Estado.Mostrando)
                MudarEstado(Estado.Alterando);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.estado == Estado.Limpo)
                MudarEstado(Estado.Incluindo);
            else if (this.estado == Estado.Mostrando)
                MudarEstado(Estado.Alterando);
        }

        #endregion
    }
}

