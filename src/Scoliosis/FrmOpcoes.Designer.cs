namespace Scoliosis
{
    partial class FrmOpcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpcoes));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tpPortaSerial = new System.Windows.Forms.TabPage();
            this.cmbTamanhoDados = new System.Windows.Forms.ComboBox();
            this.lblBitsDados = new System.Windows.Forms.Label();
            this.cmbBitsParada = new System.Windows.Forms.ComboBox();
            this.lblBitsParada = new System.Windows.Forms.Label();
            this.cmbParidade = new System.Windows.Forms.ComboBox();
            this.lblParidade = new System.Windows.Forms.Label();
            this.cmbTaxaDados = new System.Windows.Forms.ComboBox();
            this.lblTaxaDados = new System.Windows.Forms.Label();
            this.cmbPorta = new System.Windows.Forms.ComboBox();
            this.lblPorta = new System.Windows.Forms.Label();
            this.tabOpcoes = new System.Windows.Forms.TabControl();
            this.tbGeral = new System.Windows.Forms.TabPage();
            this.cmbNivelDiagnostico = new System.Windows.Forms.ComboBox();
            this.lblNivelDiagnostico = new System.Windows.Forms.Label();
            this.cmbLinguagem = new System.Windows.Forms.ComboBox();
            this.lblLinguagem = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tpPortaSerial.SuspendLayout();
            this.tabOpcoes.SuspendLayout();
            this.tbGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tpPortaSerial
            // 
            this.tpPortaSerial.Controls.Add(this.cmbTamanhoDados);
            this.tpPortaSerial.Controls.Add(this.lblBitsDados);
            this.tpPortaSerial.Controls.Add(this.cmbBitsParada);
            this.tpPortaSerial.Controls.Add(this.lblBitsParada);
            this.tpPortaSerial.Controls.Add(this.cmbParidade);
            this.tpPortaSerial.Controls.Add(this.lblParidade);
            this.tpPortaSerial.Controls.Add(this.cmbTaxaDados);
            this.tpPortaSerial.Controls.Add(this.lblTaxaDados);
            this.tpPortaSerial.Controls.Add(this.cmbPorta);
            this.tpPortaSerial.Controls.Add(this.lblPorta);
            resources.ApplyResources(this.tpPortaSerial, "tpPortaSerial");
            this.tpPortaSerial.Name = "tpPortaSerial";
            this.tpPortaSerial.UseVisualStyleBackColor = true;
            // 
            // cmbTamanhoDados
            // 
            this.cmbTamanhoDados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTamanhoDados.FormattingEnabled = true;
            this.cmbTamanhoDados.Items.AddRange(new object[] {
            resources.GetString("cmbTamanhoDados.Items"),
            resources.GetString("cmbTamanhoDados.Items1"),
            resources.GetString("cmbTamanhoDados.Items2"),
            resources.GetString("cmbTamanhoDados.Items3")});
            resources.ApplyResources(this.cmbTamanhoDados, "cmbTamanhoDados");
            this.cmbTamanhoDados.Name = "cmbTamanhoDados";
            // 
            // lblBitsDados
            // 
            resources.ApplyResources(this.lblBitsDados, "lblBitsDados");
            this.lblBitsDados.Name = "lblBitsDados";
            // 
            // cmbBitsParada
            // 
            this.cmbBitsParada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitsParada.FormattingEnabled = true;
            this.cmbBitsParada.Items.AddRange(new object[] {
            resources.GetString("cmbBitsParada.Items"),
            resources.GetString("cmbBitsParada.Items1"),
            resources.GetString("cmbBitsParada.Items2")});
            resources.ApplyResources(this.cmbBitsParada, "cmbBitsParada");
            this.cmbBitsParada.Name = "cmbBitsParada";
            // 
            // lblBitsParada
            // 
            resources.ApplyResources(this.lblBitsParada, "lblBitsParada");
            this.lblBitsParada.Name = "lblBitsParada";
            // 
            // cmbParidade
            // 
            this.cmbParidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParidade.FormattingEnabled = true;
            this.cmbParidade.Items.AddRange(new object[] {
            resources.GetString("cmbParidade.Items"),
            resources.GetString("cmbParidade.Items1"),
            resources.GetString("cmbParidade.Items2"),
            resources.GetString("cmbParidade.Items3")});
            resources.ApplyResources(this.cmbParidade, "cmbParidade");
            this.cmbParidade.Name = "cmbParidade";
            // 
            // lblParidade
            // 
            resources.ApplyResources(this.lblParidade, "lblParidade");
            this.lblParidade.Name = "lblParidade";
            // 
            // cmbTaxaDados
            // 
            this.cmbTaxaDados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxaDados.FormattingEnabled = true;
            this.cmbTaxaDados.Items.AddRange(new object[] {
            resources.GetString("cmbTaxaDados.Items"),
            resources.GetString("cmbTaxaDados.Items1"),
            resources.GetString("cmbTaxaDados.Items2"),
            resources.GetString("cmbTaxaDados.Items3"),
            resources.GetString("cmbTaxaDados.Items4"),
            resources.GetString("cmbTaxaDados.Items5"),
            resources.GetString("cmbTaxaDados.Items6"),
            resources.GetString("cmbTaxaDados.Items7"),
            resources.GetString("cmbTaxaDados.Items8"),
            resources.GetString("cmbTaxaDados.Items9"),
            resources.GetString("cmbTaxaDados.Items10"),
            resources.GetString("cmbTaxaDados.Items11"),
            resources.GetString("cmbTaxaDados.Items12"),
            resources.GetString("cmbTaxaDados.Items13"),
            resources.GetString("cmbTaxaDados.Items14")});
            resources.ApplyResources(this.cmbTaxaDados, "cmbTaxaDados");
            this.cmbTaxaDados.Name = "cmbTaxaDados";
            // 
            // lblTaxaDados
            // 
            resources.ApplyResources(this.lblTaxaDados, "lblTaxaDados");
            this.lblTaxaDados.Name = "lblTaxaDados";
            // 
            // cmbPorta
            // 
            this.cmbPorta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPorta.FormattingEnabled = true;
            resources.ApplyResources(this.cmbPorta, "cmbPorta");
            this.cmbPorta.Name = "cmbPorta";
            // 
            // lblPorta
            // 
            resources.ApplyResources(this.lblPorta, "lblPorta");
            this.lblPorta.Name = "lblPorta";
            // 
            // tabOpcoes
            // 
            this.tabOpcoes.Controls.Add(this.tbGeral);
            this.tabOpcoes.Controls.Add(this.tpPortaSerial);
            resources.ApplyResources(this.tabOpcoes, "tabOpcoes");
            this.tabOpcoes.Name = "tabOpcoes";
            this.tabOpcoes.SelectedIndex = 0;
            // 
            // tbGeral
            // 
            this.tbGeral.Controls.Add(this.cmbNivelDiagnostico);
            this.tbGeral.Controls.Add(this.lblNivelDiagnostico);
            this.tbGeral.Controls.Add(this.cmbLinguagem);
            this.tbGeral.Controls.Add(this.lblLinguagem);
            resources.ApplyResources(this.tbGeral, "tbGeral");
            this.tbGeral.Name = "tbGeral";
            this.tbGeral.UseVisualStyleBackColor = true;
            // 
            // cmbNivelDiagnostico
            // 
            this.cmbNivelDiagnostico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelDiagnostico.FormattingEnabled = true;
            this.cmbNivelDiagnostico.Items.AddRange(new object[] {
            resources.GetString("cmbNivelDiagnostico.Items"),
            resources.GetString("cmbNivelDiagnostico.Items1"),
            resources.GetString("cmbNivelDiagnostico.Items2"),
            resources.GetString("cmbNivelDiagnostico.Items3")});
            resources.ApplyResources(this.cmbNivelDiagnostico, "cmbNivelDiagnostico");
            this.cmbNivelDiagnostico.Name = "cmbNivelDiagnostico";
            // 
            // lblNivelDiagnostico
            // 
            resources.ApplyResources(this.lblNivelDiagnostico, "lblNivelDiagnostico");
            this.lblNivelDiagnostico.Name = "lblNivelDiagnostico";
            // 
            // cmbLinguagem
            // 
            this.cmbLinguagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinguagem.FormattingEnabled = true;
            this.cmbLinguagem.Items.AddRange(new object[] {
            resources.GetString("cmbLinguagem.Items"),
            resources.GetString("cmbLinguagem.Items1")});
            resources.ApplyResources(this.cmbLinguagem, "cmbLinguagem");
            this.cmbLinguagem.Name = "cmbLinguagem";
            // 
            // lblLinguagem
            // 
            resources.ApplyResources(this.lblLinguagem, "lblLinguagem");
            this.lblLinguagem.Name = "lblLinguagem";
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // FrmOpcoes
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabOpcoes);
            this.Name = "FrmOpcoes";
            this.Load += new System.EventHandler(this.FrmOpcoes_Load);
            this.tpPortaSerial.ResumeLayout(false);
            this.tpPortaSerial.PerformLayout();
            this.tabOpcoes.ResumeLayout(false);
            this.tbGeral.ResumeLayout(false);
            this.tbGeral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TabPage tpPortaSerial;
        private System.Windows.Forms.TabControl tabOpcoes;
        private System.Windows.Forms.ComboBox cmbPorta;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.ComboBox cmbParidade;
        private System.Windows.Forms.Label lblParidade;
        private System.Windows.Forms.ComboBox cmbTaxaDados;
        private System.Windows.Forms.Label lblTaxaDados;
        private System.Windows.Forms.ComboBox cmbBitsParada;
        private System.Windows.Forms.Label lblBitsParada;
        private System.Windows.Forms.ComboBox cmbTamanhoDados;
        private System.Windows.Forms.Label lblBitsDados;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TabPage tbGeral;
        private System.Windows.Forms.ComboBox cmbLinguagem;
        private System.Windows.Forms.Label lblLinguagem;
        private System.Windows.Forms.ComboBox cmbNivelDiagnostico;
        private System.Windows.Forms.Label lblNivelDiagnostico;
    }
}
