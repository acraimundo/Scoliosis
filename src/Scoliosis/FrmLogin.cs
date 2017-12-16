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
    public partial class FrmLogin : Scoliosis.FrmBaseDialog
    {
        private UsuarioDs.UsuarioRow usuarioRow = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmLogin()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());
            InitializeComponent();
        }

        /// <summary>
        /// Retorna o usuário logado ao sistema.
        /// </summary>
        public UsuarioDs.UsuarioRow Usuario
        {
            get
            {
                return this.usuarioRow;
            }
        }

        /// <summary>
        /// Realiza login.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // cria componente de negócio
                UsuarioBc usuarioBc = new UsuarioBc();

                int codigoUsuario = 0;

                // tenta realizar login
                if (!usuarioBc.Login(this.txtLogin.Text, this.txtSenha.Text, out codigoUsuario))
                {
                    MessageBox.Show(this, this.resourceMgr.GetString("MSG0002"), this.Text, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                // busca usuário
                this.usuarioRow = usuarioBc.BuscarUsuario(codigoUsuario);

                // fecha formulário
                this.Close();
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
            }
        }
        
        /// <summary>
        /// Trata fechamento do formulário pelo usuário.
        /// </summary>
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                if (this.usuarioRow == null)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// Sai do sistema.
        /// </summary>
        private void btnSair_Click(object sender, EventArgs e)
        {
            // mensagem de confirmação
            if (MessageBox.Show(this, this.resourceMgr.GetString("MSG0001"), this.Text, MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}

