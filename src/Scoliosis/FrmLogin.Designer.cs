namespace Scoliosis
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // lblSenha
            // 
            this.lblSenha.AccessibleDescription = null;
            this.lblSenha.AccessibleName = null;
            resources.ApplyResources(this.lblSenha, "lblSenha");
            this.lblSenha.Font = null;
            this.lblSenha.Name = "lblSenha";
            // 
            // txtLogin
            // 
            this.txtLogin.AccessibleDescription = null;
            this.txtLogin.AccessibleName = null;
            resources.ApplyResources(this.txtLogin, "txtLogin");
            this.txtLogin.BackgroundImage = null;
            this.txtLogin.Font = null;
            this.txtLogin.Name = "txtLogin";
            // 
            // lblLogin
            // 
            this.lblLogin.AccessibleDescription = null;
            this.lblLogin.AccessibleName = null;
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.Font = null;
            this.lblLogin.Name = "lblLogin";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleDescription = null;
            this.btnLogin.AccessibleName = null;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.BackgroundImage = null;
            this.btnLogin.Font = null;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSair
            // 
            this.btnSair.AccessibleDescription = null;
            this.btnSair.AccessibleName = null;
            resources.ApplyResources(this.btnSair, "btnSair");
            this.btnSair.BackgroundImage = null;
            this.btnSair.Font = null;
            this.btnSair.Name = "btnSair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Icon = null;
            this.Name = "FrmLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSair;
    }
}
