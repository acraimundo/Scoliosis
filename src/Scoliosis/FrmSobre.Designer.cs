namespace Scoliosis
{
    partial class FrmSobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSobre));
            this.lblSistema = new System.Windows.Forms.Label();
            this.grpLinha = new System.Windows.Forms.GroupBox();
            this.btnInfoSistema = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAviso = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpLinha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSistema
            // 
            resources.ApplyResources(this.lblSistema, "lblSistema");
            this.lblSistema.Name = "lblSistema";
            // 
            // grpLinha
            // 
            this.grpLinha.Controls.Add(this.btnInfoSistema);
            this.grpLinha.Controls.Add(this.btnOK);
            this.grpLinha.Controls.Add(this.lblAviso);
            resources.ApplyResources(this.grpLinha, "grpLinha");
            this.grpLinha.Name = "grpLinha";
            this.grpLinha.TabStop = false;
            // 
            // btnInfoSistema
            // 
            resources.ApplyResources(this.btnInfoSistema, "btnInfoSistema");
            this.btnInfoSistema.Name = "btnInfoSistema";
            this.btnInfoSistema.UseVisualStyleBackColor = true;
            this.btnInfoSistema.Click += new System.EventHandler(this.btnInfoSistema_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblAviso
            // 
            resources.ApplyResources(this.lblAviso, "lblAviso");
            this.lblAviso.Name = "lblAviso";
            // 
            // lblEmpresa
            // 
            resources.ApplyResources(this.lblEmpresa, "lblEmpresa");
            this.lblEmpresa.Name = "lblEmpresa";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Scoliosis.Properties.Resources.ScoliosisLogo2;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // FrmSobre
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.grpLinha);
            this.Name = "FrmSobre";
            this.Load += new System.EventHandler(this.FrmSobre_Load);
            this.grpLinha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.GroupBox grpLinha;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Button btnInfoSistema;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
