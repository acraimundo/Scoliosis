namespace Scoliosis
{
    partial class FrmNovaAvaliacaoPostural_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovaAvaliacaoPostural_2));
            this.lblPasso = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dlgProcurarImagem = new System.Windows.Forms.OpenFileDialog();
            this.lblImagem = new System.Windows.Forms.Label();
            this.btnAdquirirCamera = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.pctImagem = new System.Windows.Forms.PictureBox();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPasso
            // 
            this.lblPasso.AccessibleDescription = null;
            this.lblPasso.AccessibleName = null;
            resources.ApplyResources(this.lblPasso, "lblPasso");
            this.lblPasso.Name = "lblPasso";
            // 
            // grpBox
            // 
            this.grpBox.AccessibleDescription = null;
            this.grpBox.AccessibleName = null;
            resources.ApplyResources(this.grpBox, "grpBox");
            this.grpBox.BackgroundImage = null;
            this.grpBox.Controls.Add(this.btnProximo);
            this.grpBox.Controls.Add(this.btnCancelar);
            this.grpBox.Font = null;
            this.grpBox.Name = "grpBox";
            this.grpBox.TabStop = false;
            // 
            // btnProximo
            // 
            this.btnProximo.AccessibleDescription = null;
            this.btnProximo.AccessibleName = null;
            resources.ApplyResources(this.btnProximo, "btnProximo");
            this.btnProximo.BackgroundImage = null;
            this.btnProximo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProximo.Font = null;
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleDescription = null;
            this.btnCancelar.AccessibleName = null;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.BackgroundImage = null;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = null;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dlgProcurarImagem
            // 
            resources.ApplyResources(this.dlgProcurarImagem, "dlgProcurarImagem");
            // 
            // lblImagem
            // 
            this.lblImagem.AccessibleDescription = null;
            this.lblImagem.AccessibleName = null;
            resources.ApplyResources(this.lblImagem, "lblImagem");
            this.lblImagem.Font = null;
            this.lblImagem.Name = "lblImagem";
            // 
            // btnAdquirirCamera
            // 
            this.btnAdquirirCamera.AccessibleDescription = null;
            this.btnAdquirirCamera.AccessibleName = null;
            resources.ApplyResources(this.btnAdquirirCamera, "btnAdquirirCamera");
            this.btnAdquirirCamera.BackgroundImage = null;
            this.btnAdquirirCamera.Font = null;
            this.btnAdquirirCamera.Name = "btnAdquirirCamera";
            this.btnAdquirirCamera.UseVisualStyleBackColor = true;
            this.btnAdquirirCamera.Click += new System.EventHandler(this.btnAdquirirCamera_Click);
            // 
            // btnProcurar
            // 
            this.btnProcurar.AccessibleDescription = null;
            this.btnProcurar.AccessibleName = null;
            resources.ApplyResources(this.btnProcurar, "btnProcurar");
            this.btnProcurar.BackgroundImage = null;
            this.btnProcurar.Font = null;
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // pctImagem
            // 
            this.pctImagem.AccessibleDescription = null;
            this.pctImagem.AccessibleName = null;
            resources.ApplyResources(this.pctImagem, "pctImagem");
            this.pctImagem.BackgroundImage = null;
            this.pctImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctImagem.Font = null;
            this.pctImagem.ImageLocation = null;
            this.pctImagem.Name = "pctImagem";
            this.pctImagem.TabStop = false;
            // 
            // FrmNovaAvaliacaoPostural_2
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pctImagem);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.btnAdquirirCamera);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.lblPasso);
            this.Icon = null;
            this.Name = "FrmNovaAvaliacaoPostural_2";
            this.grpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPasso;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.OpenFileDialog dlgProcurarImagem;
        private System.Windows.Forms.PictureBox pctImagem;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.Button btnAdquirirCamera;
        private System.Windows.Forms.Button btnProcurar;
    }
}
