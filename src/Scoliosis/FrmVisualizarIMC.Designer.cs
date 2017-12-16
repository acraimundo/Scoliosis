namespace Scoliosis
{
    partial class FrmVisualizarIMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualizarIMC));
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblCalculos = new System.Windows.Forms.Label();
            this.lstCalculos = new System.Windows.Forms.ListBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.lblClassificacaoDiagnosticada = new System.Windows.Forms.Label();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.lblIMCCalculado = new System.Windows.Forms.Label();
            this.lblIMC = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblAlturaCalculada = new System.Windows.Forms.Label();
            this.lblMassaCalculada = new System.Windows.Forms.Label();
            this.lblMassa = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblFisioterapeutaCadastrado = new System.Windows.Forms.Label();
            this.lblFisioterapeuta = new System.Windows.Forms.Label();
            this.lblImagem = new System.Windows.Forms.Label();
            this.pctImagem = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarPaciente
            // 
            resources.ApplyResources(this.btnBuscarPaciente, "btnBuscarPaciente");
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // txtPaciente
            // 
            resources.ApplyResources(this.txtPaciente, "txtPaciente");
            this.txtPaciente.Name = "txtPaciente";
            // 
            // lblPaciente
            // 
            resources.ApplyResources(this.lblPaciente, "lblPaciente");
            this.lblPaciente.Name = "lblPaciente";
            // 
            // lblCalculos
            // 
            resources.ApplyResources(this.lblCalculos, "lblCalculos");
            this.lblCalculos.Name = "lblCalculos";
            // 
            // lstCalculos
            // 
            this.lstCalculos.FormattingEnabled = true;
            resources.ApplyResources(this.lstCalculos, "lstCalculos");
            this.lstCalculos.Name = "lstCalculos";
            this.lstCalculos.SelectedIndexChanged += new System.EventHandler(this.lstCalculos_SelectedIndexChanged);
            // 
            // txtObservacoes
            // 
            resources.ApplyResources(this.txtObservacoes, "txtObservacoes");
            this.txtObservacoes.Name = "txtObservacoes";
            // 
            // lblObservacoes
            // 
            resources.ApplyResources(this.lblObservacoes, "lblObservacoes");
            this.lblObservacoes.Name = "lblObservacoes";
            // 
            // lblClassificacaoDiagnosticada
            // 
            resources.ApplyResources(this.lblClassificacaoDiagnosticada, "lblClassificacaoDiagnosticada");
            this.lblClassificacaoDiagnosticada.Name = "lblClassificacaoDiagnosticada";
            // 
            // lblClassificacao
            // 
            resources.ApplyResources(this.lblClassificacao, "lblClassificacao");
            this.lblClassificacao.Name = "lblClassificacao";
            // 
            // lblIMCCalculado
            // 
            resources.ApplyResources(this.lblIMCCalculado, "lblIMCCalculado");
            this.lblIMCCalculado.Name = "lblIMCCalculado";
            // 
            // lblIMC
            // 
            resources.ApplyResources(this.lblIMC, "lblIMC");
            this.lblIMC.Name = "lblIMC";
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnFechar, "btnFechar");
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblAlturaCalculada
            // 
            resources.ApplyResources(this.lblAlturaCalculada, "lblAlturaCalculada");
            this.lblAlturaCalculada.Name = "lblAlturaCalculada";
            // 
            // lblMassaCalculada
            // 
            resources.ApplyResources(this.lblMassaCalculada, "lblMassaCalculada");
            this.lblMassaCalculada.Name = "lblMassaCalculada";
            // 
            // lblMassa
            // 
            resources.ApplyResources(this.lblMassa, "lblMassa");
            this.lblMassa.Name = "lblMassa";
            // 
            // lblAltura
            // 
            resources.ApplyResources(this.lblAltura, "lblAltura");
            this.lblAltura.Name = "lblAltura";
            // 
            // lblFisioterapeutaCadastrado
            // 
            resources.ApplyResources(this.lblFisioterapeutaCadastrado, "lblFisioterapeutaCadastrado");
            this.lblFisioterapeutaCadastrado.Name = "lblFisioterapeutaCadastrado";
            // 
            // lblFisioterapeuta
            // 
            resources.ApplyResources(this.lblFisioterapeuta, "lblFisioterapeuta");
            this.lblFisioterapeuta.Name = "lblFisioterapeuta";
            // 
            // lblImagem
            // 
            resources.ApplyResources(this.lblImagem, "lblImagem");
            this.lblImagem.Name = "lblImagem";
            // 
            // pctImagem
            // 
            this.pctImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pctImagem, "pctImagem");
            this.pctImagem.Name = "pctImagem";
            this.pctImagem.TabStop = false;
            // 
            // btnExcluir
            // 
            resources.ApplyResources(this.btnExcluir, "btnExcluir");
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // FrmVisualizarIMC
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.pctImagem);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblAlturaCalculada);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.lblMassaCalculada);
            this.Controls.Add(this.lstCalculos);
            this.Controls.Add(this.lblMassa);
            this.Controls.Add(this.lblCalculos);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblFisioterapeutaCadastrado);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.lblFisioterapeuta);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblClassificacaoDiagnosticada);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.lblClassificacao);
            this.Controls.Add(this.lblIMC);
            this.Controls.Add(this.lblIMCCalculado);
            this.Name = "FrmVisualizarIMC";
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblCalculos;
        private System.Windows.Forms.ListBox lstCalculos;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.Label lblClassificacaoDiagnosticada;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.Label lblIMCCalculado;
        private System.Windows.Forms.Label lblIMC;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblFisioterapeutaCadastrado;
        private System.Windows.Forms.Label lblFisioterapeuta;
        private System.Windows.Forms.Label lblAlturaCalculada;
        private System.Windows.Forms.Label lblMassaCalculada;
        private System.Windows.Forms.Label lblMassa;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.PictureBox pctImagem;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.Button btnExcluir;
    }
}
