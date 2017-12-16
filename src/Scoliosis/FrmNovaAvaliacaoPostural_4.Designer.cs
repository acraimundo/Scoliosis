namespace Scoliosis
{
    partial class FrmNovaAvaliacaoPostural_4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovaAvaliacaoPostural_4));
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPasso = new System.Windows.Forms.Label();
            this.btnLerPontosArquivo = new System.Windows.Forms.Button();
            this.btnIdentificarPontos = new System.Windows.Forms.Button();
            this.lblImagem = new System.Windows.Forms.Label();
            this.dlgArquivoPontos = new System.Windows.Forms.OpenFileDialog();
            this.pctImagem = new System.Windows.Forms.PictureBox();
            this.lblFator = new System.Windows.Forms.Label();
            this.trbFatorCorrelacao = new System.Windows.Forms.TrackBar();
            this.lblFatorCorrelacao = new System.Windows.Forms.Label();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFatorCorrelacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.btnProximo);
            this.grpBox.Controls.Add(this.btnCancelar);
            resources.ApplyResources(this.grpBox, "grpBox");
            this.grpBox.Name = "grpBox";
            this.grpBox.TabStop = false;
            // 
            // btnProximo
            // 
            this.btnProximo.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnProximo, "btnProximo");
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblPasso
            // 
            resources.ApplyResources(this.lblPasso, "lblPasso");
            this.lblPasso.Name = "lblPasso";
            // 
            // btnLerPontosArquivo
            // 
            resources.ApplyResources(this.btnLerPontosArquivo, "btnLerPontosArquivo");
            this.btnLerPontosArquivo.Name = "btnLerPontosArquivo";
            this.btnLerPontosArquivo.UseVisualStyleBackColor = true;
            this.btnLerPontosArquivo.Click += new System.EventHandler(this.btnLerPontosArquivo_Click);
            // 
            // btnIdentificarPontos
            // 
            resources.ApplyResources(this.btnIdentificarPontos, "btnIdentificarPontos");
            this.btnIdentificarPontos.Name = "btnIdentificarPontos";
            this.btnIdentificarPontos.UseVisualStyleBackColor = true;
            this.btnIdentificarPontos.Click += new System.EventHandler(this.btnIdentificarPontos_Click);
            // 
            // lblImagem
            // 
            resources.ApplyResources(this.lblImagem, "lblImagem");
            this.lblImagem.Name = "lblImagem";
            // 
            // dlgArquivoPontos
            // 
            resources.ApplyResources(this.dlgArquivoPontos, "dlgArquivoPontos");
            // 
            // pctImagem
            // 
            this.pctImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pctImagem, "pctImagem");
            this.pctImagem.Name = "pctImagem";
            this.pctImagem.TabStop = false;
            // 
            // lblFator
            // 
            resources.ApplyResources(this.lblFator, "lblFator");
            this.lblFator.Name = "lblFator";
            // 
            // trbFatorCorrelacao
            // 
            resources.ApplyResources(this.trbFatorCorrelacao, "trbFatorCorrelacao");
            this.trbFatorCorrelacao.LargeChange = 1;
            this.trbFatorCorrelacao.Maximum = 20;
            this.trbFatorCorrelacao.Name = "trbFatorCorrelacao";
            this.trbFatorCorrelacao.Value = 10;
            this.trbFatorCorrelacao.Scroll += new System.EventHandler(this.trbFatorCorrelacao_Scroll);
            // 
            // lblFatorCorrelacao
            // 
            resources.ApplyResources(this.lblFatorCorrelacao, "lblFatorCorrelacao");
            this.lblFatorCorrelacao.Name = "lblFatorCorrelacao";
            // 
            // FrmNovaAvaliacaoPostural_4
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblFator);
            this.Controls.Add(this.trbFatorCorrelacao);
            this.Controls.Add(this.lblFatorCorrelacao);
            this.Controls.Add(this.btnLerPontosArquivo);
            this.Controls.Add(this.btnIdentificarPontos);
            this.Controls.Add(this.pctImagem);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.lblPasso);
            this.Controls.Add(this.grpBox);
            this.Name = "FrmNovaAvaliacaoPostural_4";
            this.grpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFatorCorrelacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPasso;
        private System.Windows.Forms.Button btnLerPontosArquivo;
        private System.Windows.Forms.Button btnIdentificarPontos;
        private System.Windows.Forms.PictureBox pctImagem;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.OpenFileDialog dlgArquivoPontos;
        private System.Windows.Forms.Label lblFator;
        private System.Windows.Forms.TrackBar trbFatorCorrelacao;
        private System.Windows.Forms.Label lblFatorCorrelacao;
    }
}
