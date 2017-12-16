namespace Scoliosis
{
    partial class FrmNovoIMC_4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovoIMC_4));
            this.lblPasso = new System.Windows.Forms.Label();
            this.lblAlturaCalculada = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblImagem = new System.Windows.Forms.Label();
            this.lblAlturaLabel = new System.Windows.Forms.Label();
            this.pctImagem = new System.Windows.Forms.PictureBox();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPasso
            // 
            resources.ApplyResources(this.lblPasso, "lblPasso");
            this.lblPasso.Name = "lblPasso";
            // 
            // lblAlturaCalculada
            // 
            resources.ApplyResources(this.lblAlturaCalculada, "lblAlturaCalculada");
            this.lblAlturaCalculada.Name = "lblAlturaCalculada";
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
            // lblImagem
            // 
            resources.ApplyResources(this.lblImagem, "lblImagem");
            this.lblImagem.Name = "lblImagem";
            // 
            // lblAlturaLabel
            // 
            resources.ApplyResources(this.lblAlturaLabel, "lblAlturaLabel");
            this.lblAlturaLabel.Name = "lblAlturaLabel";
            // 
            // pctImagem
            // 
            this.pctImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pctImagem, "pctImagem");
            this.pctImagem.Name = "pctImagem";
            this.pctImagem.TabStop = false;
            this.pctImagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctImagem_MouseDown);
            this.pctImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctImagem_MouseMove);
            this.pctImagem.Paint += new System.Windows.Forms.PaintEventHandler(this.pctImagem_Paint);
            this.pctImagem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctImagem_MouseUp);
            // 
            // FrmNovoIMC_4
            // 
            this.AcceptButton = this.btnProximo;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblAlturaLabel);
            this.Controls.Add(this.pctImagem);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.lblAlturaCalculada);
            this.Controls.Add(this.lblPasso);
            this.Name = "FrmNovoIMC_4";
            this.Load += new System.EventHandler(this.FrmNovoIMC_4_Load);
            this.grpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPasso;
        private System.Windows.Forms.Label lblAlturaCalculada;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pctImagem;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.Label lblAlturaLabel;
    }
}
