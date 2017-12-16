namespace Scoliosis
{
    partial class FrmAquisicaoImagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAquisicaoImagem));
            this.lblDispositivos = new System.Windows.Forms.Label();
            this.lstDispositivos = new System.Windows.Forms.ListBox();
            this.lblImagens = new System.Windows.Forms.Label();
            this.lstImagens = new System.Windows.Forms.ListBox();
            this.lblImagem = new System.Windows.Forms.Label();
            this.btnAdquirir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblRotacionar = new System.Windows.Forms.Label();
            this.cmbRotacionar = new System.Windows.Forms.ComboBox();
            this.btnListarImagens = new System.Windows.Forms.Button();
            this.pctImagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDispositivos
            // 
            resources.ApplyResources(this.lblDispositivos, "lblDispositivos");
            this.lblDispositivos.Name = "lblDispositivos";
            // 
            // lstDispositivos
            // 
            this.lstDispositivos.FormattingEnabled = true;
            resources.ApplyResources(this.lstDispositivos, "lstDispositivos");
            this.lstDispositivos.Name = "lstDispositivos";
            this.lstDispositivos.SelectedIndexChanged += new System.EventHandler(this.lstDispositivos_SelectedIndexChanged);
            // 
            // lblImagens
            // 
            resources.ApplyResources(this.lblImagens, "lblImagens");
            this.lblImagens.Name = "lblImagens";
            // 
            // lstImagens
            // 
            this.lstImagens.FormattingEnabled = true;
            resources.ApplyResources(this.lstImagens, "lstImagens");
            this.lstImagens.Name = "lstImagens";
            this.lstImagens.SelectedIndexChanged += new System.EventHandler(this.lstImagens_SelectedIndexChanged);
            // 
            // lblImagem
            // 
            resources.ApplyResources(this.lblImagem, "lblImagem");
            this.lblImagem.Name = "lblImagem";
            // 
            // btnAdquirir
            // 
            this.btnAdquirir.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnAdquirir, "btnAdquirir");
            this.btnAdquirir.Name = "btnAdquirir";
            this.btnAdquirir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblRotacionar
            // 
            resources.ApplyResources(this.lblRotacionar, "lblRotacionar");
            this.lblRotacionar.Name = "lblRotacionar";
            // 
            // cmbRotacionar
            // 
            this.cmbRotacionar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbRotacionar, "cmbRotacionar");
            this.cmbRotacionar.FormattingEnabled = true;
            this.cmbRotacionar.Items.AddRange(new object[] {
            resources.GetString("cmbRotacionar.Items"),
            resources.GetString("cmbRotacionar.Items1"),
            resources.GetString("cmbRotacionar.Items2"),
            resources.GetString("cmbRotacionar.Items3")});
            this.cmbRotacionar.Name = "cmbRotacionar";
            this.cmbRotacionar.SelectedIndexChanged += new System.EventHandler(this.cmbRotacionar_SelectedIndexChanged);
            // 
            // btnListarImagens
            // 
            resources.ApplyResources(this.btnListarImagens, "btnListarImagens");
            this.btnListarImagens.Name = "btnListarImagens";
            this.btnListarImagens.UseVisualStyleBackColor = true;
            this.btnListarImagens.Click += new System.EventHandler(this.btnListarImagens_Click);
            // 
            // pctImagem
            // 
            this.pctImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pctImagem, "pctImagem");
            this.pctImagem.Name = "pctImagem";
            this.pctImagem.TabStop = false;
            // 
            // FrmAquisicaoImagem
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnListarImagens);
            this.Controls.Add(this.cmbRotacionar);
            this.Controls.Add(this.lblRotacionar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdquirir);
            this.Controls.Add(this.pctImagem);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.lstImagens);
            this.Controls.Add(this.lblImagens);
            this.Controls.Add(this.lstDispositivos);
            this.Controls.Add(this.lblDispositivos);
            this.Name = "FrmAquisicaoImagem";
            this.Load += new System.EventHandler(this.FrmAdquisicaoImagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDispositivos;
        private System.Windows.Forms.ListBox lstDispositivos;
        private System.Windows.Forms.Label lblImagens;
        private System.Windows.Forms.ListBox lstImagens;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.PictureBox pctImagem;
        private System.Windows.Forms.Button btnAdquirir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblRotacionar;
        private System.Windows.Forms.ComboBox cmbRotacionar;
        private System.Windows.Forms.Button btnListarImagens;
    }
}
