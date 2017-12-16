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
    public partial class FrmAlterarSenha : Scoliosis.FrmBaseDialog
    {
        private UsuarioDs.UsuarioRow usuarioRow = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmAlterarSenha()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        /// <summary>
        /// Define/retorna o usuário.
        /// </summary>
        public UsuarioDs.UsuarioRow Usuario
        {
            get
            {
                return this.usuarioRow;
            }
            set
            {
                this.usuarioRow = value;
            }
        }

        /// <summary>
        /// Realiza alteração da senha.
        /// </summary>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // verifica se a nova senha foi digitada
            if (this.txtNovaSenha.Text.Length == 0)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0004"), this.Text, MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                this.txtNovaSenha.Focus();
                return;
            }

            // verifica se a nova senha foi confirmada
            if (this.txtNovaSenha.Text != this.txtConfirmarSenha.Text)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0005"), this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.txtConfirmarSenha.Focus();
                return;
            }

            // verifica se a senha atual está correta
            if (this.usuarioRow.Senha != this.txtSenha.Text)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0006"), this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.txtSenha.Focus();
                return;
            }

            try
            {
                // componente de negócio
                UsuarioBc usuarioBc = new UsuarioBc();

                // altera o usuário
                usuarioBc.AlterarUsuario(this.usuarioRow.CodigoUsuario, this.usuarioRow.Nome,
                    this.usuarioRow.Login, this.txtNovaSenha.Text, this.usuarioRow.Tipo);

                // busca pelo usuário
                this.usuarioRow = usuarioBc.BuscarUsuario(this.usuarioRow.CodigoUsuario);

                MessageBox.Show(this, this.resourceMgr.GetString("MSG0007"), this.Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
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
    }
}

