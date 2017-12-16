namespace Scoliosis
{
    partial class FrmNovaAvaliacaoPostural_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovaAvaliacaoPostural_1));
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPasso = new System.Windows.Forms.Label();
            this.grpBox.SuspendLayout();
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
            // FrmNovaAvaliacaoPostural_1
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.lblPasso);
            this.Name = "FrmNovaAvaliacaoPostural_1";
            this.grpBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPasso;
    }
}
