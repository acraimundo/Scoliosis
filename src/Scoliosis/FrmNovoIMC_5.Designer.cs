namespace Scoliosis
{
    partial class FrmNovoIMC_5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovoIMC_5));
            this.lblPasso = new System.Windows.Forms.Label();
            this.lblMassa = new System.Windows.Forms.Label();
            this.lblMassaCalculada = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAdquirir = new System.Windows.Forms.Button();
            this.lblEntreMassa = new System.Windows.Forms.Label();
            this.txtMassa = new System.Windows.Forms.TextBox();
            this.lblKg = new System.Windows.Forms.Label();
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
            // lblMassa
            // 
            this.lblMassa.AccessibleDescription = null;
            this.lblMassa.AccessibleName = null;
            resources.ApplyResources(this.lblMassa, "lblMassa");
            this.lblMassa.Font = null;
            this.lblMassa.Name = "lblMassa";
            // 
            // lblMassaCalculada
            // 
            this.lblMassaCalculada.AccessibleDescription = null;
            this.lblMassaCalculada.AccessibleName = null;
            resources.ApplyResources(this.lblMassaCalculada, "lblMassaCalculada");
            this.lblMassaCalculada.Name = "lblMassaCalculada";
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
            this.btnProximo.Font = null;
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
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
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAdquirir
            // 
            this.btnAdquirir.AccessibleDescription = null;
            this.btnAdquirir.AccessibleName = null;
            resources.ApplyResources(this.btnAdquirir, "btnAdquirir");
            this.btnAdquirir.BackgroundImage = null;
            this.btnAdquirir.Font = null;
            this.btnAdquirir.Name = "btnAdquirir";
            this.btnAdquirir.UseVisualStyleBackColor = true;
            this.btnAdquirir.Click += new System.EventHandler(this.btnAdquirir_Click);
            // 
            // lblEntreMassa
            // 
            this.lblEntreMassa.AccessibleDescription = null;
            this.lblEntreMassa.AccessibleName = null;
            resources.ApplyResources(this.lblEntreMassa, "lblEntreMassa");
            this.lblEntreMassa.Font = null;
            this.lblEntreMassa.Name = "lblEntreMassa";
            // 
            // txtMassa
            // 
            this.txtMassa.AccessibleDescription = null;
            this.txtMassa.AccessibleName = null;
            resources.ApplyResources(this.txtMassa, "txtMassa");
            this.txtMassa.BackgroundImage = null;
            this.txtMassa.Font = null;
            this.txtMassa.Name = "txtMassa";
            // 
            // lblKg
            // 
            this.lblKg.AccessibleDescription = null;
            this.lblKg.AccessibleName = null;
            resources.ApplyResources(this.lblKg, "lblKg");
            this.lblKg.Font = null;
            this.lblKg.Name = "lblKg";
            // 
            // FrmNovoIMC_5
            // 
            this.AcceptButton = this.btnProximo;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.lblKg);
            this.Controls.Add(this.txtMassa);
            this.Controls.Add(this.lblEntreMassa);
            this.Controls.Add(this.btnAdquirir);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.lblMassaCalculada);
            this.Controls.Add(this.lblMassa);
            this.Controls.Add(this.lblPasso);
            this.Icon = null;
            this.Name = "FrmNovoIMC_5";
            this.Load += new System.EventHandler(this.FrmNovoIMC_5_Load);
            this.grpBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPasso;
        private System.Windows.Forms.Label lblMassa;
        private System.Windows.Forms.Label lblMassaCalculada;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAdquirir;
        private System.Windows.Forms.Label lblEntreMassa;
        private System.Windows.Forms.TextBox txtMassa;
        private System.Windows.Forms.Label lblKg;
    }
}
