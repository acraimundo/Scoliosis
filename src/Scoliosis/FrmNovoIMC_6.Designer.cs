namespace Scoliosis
{
    partial class FrmNovoIMC_6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovoIMC_6));
            this.lblPasso = new System.Windows.Forms.Label();
            this.lblIMCCalculado = new System.Windows.Forms.Label();
            this.lblIMC = new System.Windows.Forms.Label();
            this.lblClassificacaoDiagnosticada = new System.Windows.Forms.Label();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPasso
            // 
            this.lblPasso.AccessibleDescription = null;
            this.lblPasso.AccessibleName = null;
            resources.ApplyResources(this.lblPasso, "lblPasso");
            this.lblPasso.Name = "lblPasso";
            // 
            // lblIMCCalculado
            // 
            this.lblIMCCalculado.AccessibleDescription = null;
            this.lblIMCCalculado.AccessibleName = null;
            resources.ApplyResources(this.lblIMCCalculado, "lblIMCCalculado");
            this.lblIMCCalculado.Name = "lblIMCCalculado";
            // 
            // lblIMC
            // 
            this.lblIMC.AccessibleDescription = null;
            this.lblIMC.AccessibleName = null;
            resources.ApplyResources(this.lblIMC, "lblIMC");
            this.lblIMC.Font = null;
            this.lblIMC.Name = "lblIMC";
            // 
            // lblClassificacaoDiagnosticada
            // 
            this.lblClassificacaoDiagnosticada.AccessibleDescription = null;
            this.lblClassificacaoDiagnosticada.AccessibleName = null;
            resources.ApplyResources(this.lblClassificacaoDiagnosticada, "lblClassificacaoDiagnosticada");
            this.lblClassificacaoDiagnosticada.Name = "lblClassificacaoDiagnosticada";
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.AccessibleDescription = null;
            this.lblClassificacao.AccessibleName = null;
            resources.ApplyResources(this.lblClassificacao, "lblClassificacao");
            this.lblClassificacao.Font = null;
            this.lblClassificacao.Name = "lblClassificacao";
            // 
            // grpBox
            // 
            this.grpBox.AccessibleDescription = null;
            this.grpBox.AccessibleName = null;
            resources.ApplyResources(this.grpBox, "grpBox");
            this.grpBox.BackgroundImage = null;
            this.grpBox.Controls.Add(this.btnCancelar);
            this.grpBox.Controls.Add(this.btnFinalizar);
            this.grpBox.Font = null;
            this.grpBox.Name = "grpBox";
            this.grpBox.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleDescription = null;
            this.btnCancelar.AccessibleName = null;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.BackgroundImage = null;
            this.btnCancelar.Font = null;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.AccessibleDescription = null;
            this.btnFinalizar.AccessibleName = null;
            resources.ApplyResources(this.btnFinalizar, "btnFinalizar");
            this.btnFinalizar.BackgroundImage = null;
            this.btnFinalizar.Font = null;
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AccessibleDescription = null;
            this.lblObservacoes.AccessibleName = null;
            resources.ApplyResources(this.lblObservacoes, "lblObservacoes");
            this.lblObservacoes.Font = null;
            this.lblObservacoes.Name = "lblObservacoes";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.AccessibleDescription = null;
            this.txtObservacoes.AccessibleName = null;
            resources.ApplyResources(this.txtObservacoes, "txtObservacoes");
            this.txtObservacoes.BackgroundImage = null;
            this.txtObservacoes.Font = null;
            this.txtObservacoes.Name = "txtObservacoes";
            // 
            // FrmNovoIMC_6
            // 
            this.AcceptButton = this.btnFinalizar;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.lblClassificacaoDiagnosticada);
            this.Controls.Add(this.lblClassificacao);
            this.Controls.Add(this.lblIMCCalculado);
            this.Controls.Add(this.lblIMC);
            this.Controls.Add(this.lblPasso);
            this.Font = null;
            this.Icon = null;
            this.Name = "FrmNovoIMC_6";
            this.Load += new System.EventHandler(this.FrmNovoIMC_6_Load);
            this.grpBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPasso;
        private System.Windows.Forms.Label lblIMCCalculado;
        private System.Windows.Forms.Label lblIMC;
        private System.Windows.Forms.Label lblClassificacaoDiagnosticada;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Button btnCancelar;
    }
}
