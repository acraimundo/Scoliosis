namespace Scoliosis
{
    partial class FrmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lstUsuarios = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AccessibleDescription = null;
            this.lblNome.AccessibleName = null;
            resources.ApplyResources(this.lblNome, "lblNome");
            this.lblNome.Font = null;
            this.lblNome.Name = "lblNome";
            // 
            // txtNome
            // 
            this.txtNome.AccessibleDescription = null;
            this.txtNome.AccessibleName = null;
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.BackgroundImage = null;
            this.txtNome.Font = null;
            this.txtNome.Name = "txtNome";
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lblLogin
            // 
            this.lblLogin.AccessibleDescription = null;
            this.lblLogin.AccessibleName = null;
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.Font = null;
            this.lblLogin.Name = "lblLogin";
            // 
            // txtLogin
            // 
            this.txtLogin.AccessibleDescription = null;
            this.txtLogin.AccessibleName = null;
            resources.ApplyResources(this.txtLogin, "txtLogin");
            this.txtLogin.BackgroundImage = null;
            this.txtLogin.Font = null;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            // 
            // lblSenha
            // 
            this.lblSenha.AccessibleDescription = null;
            this.lblSenha.AccessibleName = null;
            resources.ApplyResources(this.lblSenha, "lblSenha");
            this.lblSenha.Font = null;
            this.lblSenha.Name = "lblSenha";
            // 
            // txtSenha
            // 
            this.txtSenha.AccessibleDescription = null;
            this.txtSenha.AccessibleName = null;
            resources.ApplyResources(this.txtSenha, "txtSenha");
            this.txtSenha.BackgroundImage = null;
            this.txtSenha.Font = null;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.TextChanged += new System.EventHandler(this.txtSenha_TextChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AccessibleDescription = null;
            this.lblTipo.AccessibleName = null;
            resources.ApplyResources(this.lblTipo, "lblTipo");
            this.lblTipo.Font = null;
            this.lblTipo.Name = "lblTipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.AccessibleDescription = null;
            this.cmbTipo.AccessibleName = null;
            resources.ApplyResources(this.cmbTipo, "cmbTipo");
            this.cmbTipo.BackgroundImage = null;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = null;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            resources.GetString("cmbTipo.Items"),
            resources.GetString("cmbTipo.Items1")});
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // btnNovo
            // 
            this.btnNovo.AccessibleDescription = null;
            this.btnNovo.AccessibleName = null;
            resources.ApplyResources(this.btnNovo, "btnNovo");
            this.btnNovo.BackgroundImage = null;
            this.btnNovo.Font = null;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnCriar
            // 
            this.btnCriar.AccessibleDescription = null;
            this.btnCriar.AccessibleName = null;
            resources.ApplyResources(this.btnCriar, "btnCriar");
            this.btnCriar.BackgroundImage = null;
            this.btnCriar.Font = null;
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
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
            // btnExcluir
            // 
            this.btnExcluir.AccessibleDescription = null;
            this.btnExcluir.AccessibleName = null;
            resources.ApplyResources(this.btnExcluir, "btnExcluir");
            this.btnExcluir.BackgroundImage = null;
            this.btnExcluir.Font = null;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
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
            // lblUsuarios
            // 
            this.lblUsuarios.AccessibleDescription = null;
            this.lblUsuarios.AccessibleName = null;
            resources.ApplyResources(this.lblUsuarios, "lblUsuarios");
            this.lblUsuarios.Font = null;
            this.lblUsuarios.Name = "lblUsuarios";
            // 
            // lstUsuarios
            // 
            this.lstUsuarios.AccessibleDescription = null;
            this.lstUsuarios.AccessibleName = null;
            resources.ApplyResources(this.lstUsuarios, "lstUsuarios");
            this.lstUsuarios.BackgroundImage = null;
            this.lstUsuarios.Font = null;
            this.lstUsuarios.FormattingEnabled = true;
            this.lstUsuarios.Name = "lstUsuarios";
            this.lstUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstUsuarios_SelectedIndexChanged);
            // 
            // FrmUsuarios
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.lstUsuarios);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Icon = null;
            this.Name = "FrmUsuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.ListBox lstUsuarios;
    }
}
