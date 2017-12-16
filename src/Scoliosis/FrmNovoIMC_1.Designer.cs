namespace Scoliosis
{
    partial class FrmNovoIMC_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovoIMC_1));
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPasso = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
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
            // lblPaciente
            // 
            this.lblPaciente.AccessibleDescription = null;
            this.lblPaciente.AccessibleName = null;
            resources.ApplyResources(this.lblPaciente, "lblPaciente");
            this.lblPaciente.Font = null;
            this.lblPaciente.Name = "lblPaciente";
            // 
            // txtPaciente
            // 
            this.txtPaciente.AccessibleDescription = null;
            this.txtPaciente.AccessibleName = null;
            resources.ApplyResources(this.txtPaciente, "txtPaciente");
            this.txtPaciente.BackgroundImage = null;
            this.txtPaciente.Font = null;
            this.txtPaciente.Name = "txtPaciente";
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.AccessibleDescription = null;
            this.btnBuscarPaciente.AccessibleName = null;
            resources.ApplyResources(this.btnBuscarPaciente, "btnBuscarPaciente");
            this.btnBuscarPaciente.BackgroundImage = null;
            this.btnBuscarPaciente.Font = null;
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // FrmNovoIMC_1
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.lblPasso);
            this.Icon = null;
            this.Name = "FrmNovoIMC_1";
            this.grpBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPasso;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Button btnBuscarPaciente;

    }
}
