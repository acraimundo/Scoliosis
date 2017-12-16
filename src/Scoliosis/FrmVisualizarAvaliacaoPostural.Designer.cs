namespace Scoliosis
{
    partial class FrmVisualizarAvaliacaoPostural
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualizarAvaliacaoPostural));
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.lblAvaliacoes = new System.Windows.Forms.Label();
            this.lstAvaliacoes = new System.Windows.Forms.ListBox();
            this.lblEscoliose = new System.Windows.Forms.Label();
            this.lblTipoEscolioseDiagnosticada = new System.Windows.Forms.Label();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.lblImagem = new System.Windows.Forms.Label();
            this.pctImagem = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblFisioterapeuta = new System.Windows.Forms.Label();
            this.lblFisioterapeutaCadastrado = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPaciente
            // 
            resources.ApplyResources(this.lblPaciente, "lblPaciente");
            this.lblPaciente.Name = "lblPaciente";
            // 
            // txtPaciente
            // 
            resources.ApplyResources(this.txtPaciente, "txtPaciente");
            this.txtPaciente.Name = "txtPaciente";
            // 
            // btnBuscarPaciente
            // 
            resources.ApplyResources(this.btnBuscarPaciente, "btnBuscarPaciente");
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // lblAvaliacoes
            // 
            resources.ApplyResources(this.lblAvaliacoes, "lblAvaliacoes");
            this.lblAvaliacoes.Name = "lblAvaliacoes";
            // 
            // lstAvaliacoes
            // 
            this.lstAvaliacoes.FormattingEnabled = true;
            resources.ApplyResources(this.lstAvaliacoes, "lstAvaliacoes");
            this.lstAvaliacoes.Name = "lstAvaliacoes";
            this.lstAvaliacoes.SelectedIndexChanged += new System.EventHandler(this.lstAvaliacoes_SelectedIndexChanged);
            // 
            // lblEscoliose
            // 
            resources.ApplyResources(this.lblEscoliose, "lblEscoliose");
            this.lblEscoliose.Name = "lblEscoliose";
            // 
            // lblTipoEscolioseDiagnosticada
            // 
            resources.ApplyResources(this.lblTipoEscolioseDiagnosticada, "lblTipoEscolioseDiagnosticada");
            this.lblTipoEscolioseDiagnosticada.Name = "lblTipoEscolioseDiagnosticada";
            // 
            // lblObservacoes
            // 
            resources.ApplyResources(this.lblObservacoes, "lblObservacoes");
            this.lblObservacoes.Name = "lblObservacoes";
            // 
            // txtObservacoes
            // 
            resources.ApplyResources(this.txtObservacoes, "txtObservacoes");
            this.txtObservacoes.Name = "txtObservacoes";
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
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnFechar, "btnFechar");
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // lblFisioterapeuta
            // 
            resources.ApplyResources(this.lblFisioterapeuta, "lblFisioterapeuta");
            this.lblFisioterapeuta.Name = "lblFisioterapeuta";
            // 
            // lblFisioterapeutaCadastrado
            // 
            resources.ApplyResources(this.lblFisioterapeutaCadastrado, "lblFisioterapeutaCadastrado");
            this.lblFisioterapeutaCadastrado.Name = "lblFisioterapeutaCadastrado";
            // 
            // btnExcluir
            // 
            resources.ApplyResources(this.btnExcluir, "btnExcluir");
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // FrmVisualizarAvaliacaoPostural
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblFisioterapeutaCadastrado);
            this.Controls.Add(this.lblFisioterapeuta);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pctImagem);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.lblTipoEscolioseDiagnosticada);
            this.Controls.Add(this.lblEscoliose);
            this.Controls.Add(this.lstAvaliacoes);
            this.Controls.Add(this.lblAvaliacoes);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Name = "FrmVisualizarAvaliacaoPostural";
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.Label lblAvaliacoes;
        private System.Windows.Forms.ListBox lstAvaliacoes;
        private System.Windows.Forms.Label lblEscoliose;
        private System.Windows.Forms.Label lblTipoEscolioseDiagnosticada;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.PictureBox pctImagem;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblFisioterapeuta;
        private System.Windows.Forms.Label lblFisioterapeutaCadastrado;
        private System.Windows.Forms.Button btnExcluir;
    }
}
