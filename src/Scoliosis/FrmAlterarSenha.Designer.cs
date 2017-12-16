namespace Scoliosis
{
    partial class FrmAlterarSenha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlterarSenha));
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.lblNovaSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.lblConfirmarSenha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = null;
            this.btnFechar.AccessibleName = null;
            resources.ApplyResources(this.btnFechar, "btnFechar");
            this.btnFechar.BackgroundImage = null;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Font = null;
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.AccessibleDescription = null;
            this.btnAlterar.AccessibleName = null;
            resources.ApplyResources(this.btnAlterar, "btnAlterar");
            this.btnAlterar.BackgroundImage = null;
            this.btnAlterar.Font = null;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.AccessibleDescription = null;
            this.txtNovaSenha.AccessibleName = null;
            resources.ApplyResources(this.txtNovaSenha, "txtNovaSenha");
            this.txtNovaSenha.BackgroundImage = null;
            this.txtNovaSenha.Font = null;
            this.txtNovaSenha.Name = "txtNovaSenha";
            // 
            // lblNovaSenha
            // 
            this.lblNovaSenha.AccessibleDescription = null;
            this.lblNovaSenha.AccessibleName = null;
            resources.ApplyResources(this.lblNovaSenha, "lblNovaSenha");
            this.lblNovaSenha.Font = null;
            this.lblNovaSenha.Name = "lblNovaSenha";
            // 
            // txtSenha
            // 
            this.txtSenha.AccessibleDescription = null;
            this.txtSenha.AccessibleName = null;
            resources.ApplyResources(this.txtSenha, "txtSenha");
            this.txtSenha.BackgroundImage = null;
            this.txtSenha.Font = null;
            this.txtSenha.Name = "txtSenha";
            // 
            // lblLogin
            // 
            this.lblLogin.AccessibleDescription = null;
            this.lblLogin.AccessibleName = null;
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.Font = null;
            this.lblLogin.Name = "lblLogin";
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.AccessibleDescription = null;
            this.txtConfirmarSenha.AccessibleName = null;
            resources.ApplyResources(this.txtConfirmarSenha, "txtConfirmarSenha");
            this.txtConfirmarSenha.BackgroundImage = null;
            this.txtConfirmarSenha.Font = null;
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            // 
            // lblConfirmarSenha
            // 
            this.lblConfirmarSenha.AccessibleDescription = null;
            this.lblConfirmarSenha.AccessibleName = null;
            resources.ApplyResources(this.lblConfirmarSenha, "lblConfirmarSenha");
            this.lblConfirmarSenha.Font = null;
            this.lblConfirmarSenha.Name = "lblConfirmarSenha";
            // 
            // FrmAlterarSenha
            // 
            this.AcceptButton = this.btnAlterar;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.txtConfirmarSenha);
            this.Controls.Add(this.lblConfirmarSenha);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.txtNovaSenha);
            this.Controls.Add(this.lblNovaSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblLogin);
            this.Icon = null;
            this.Name = "FrmAlterarSenha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtNovaSenha;
        private System.Windows.Forms.Label lblNovaSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.Label lblConfirmarSenha;
    }
}
