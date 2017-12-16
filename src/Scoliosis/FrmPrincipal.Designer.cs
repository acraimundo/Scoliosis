namespace Scoliosis
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.stbPrincipal = new System.Windows.Forms.StatusStrip();
            this.stbPrincipal_tsUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.stbPrincipal_tsTipo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsCadastro = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsCadastro_miPacientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCadastro_miUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAvaliacao = new System.Windows.Forms.ToolStripDropDownButton();
            this.lsAvaliacao_miPostural = new System.Windows.Forms.ToolStripMenuItem();
            this.lsAvaliacao_miPostural_miNova = new System.Windows.Forms.ToolStripMenuItem();
            this.lsAvaliacao_miPostural_miVisualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.lsAvaliacao_miIMC = new System.Windows.Forms.ToolStripMenuItem();
            this.lsAvaliacao_miIMC_miNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.lsAvaliacao_miIMC_miVisualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFerramentas = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsFerramentas_miOpcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeguranca = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsSeguranca_miAlterarSenha = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeguranca_miNovoLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAjuda = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsAjuda_miManualUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAjuda_miSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSair = new System.Windows.Forms.ToolStripButton();
            this.stbPrincipal.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // stbPrincipal
            // 
            this.stbPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbPrincipal_tsUsuario,
            this.stbPrincipal_tsTipo});
            resources.ApplyResources(this.stbPrincipal, "stbPrincipal");
            this.stbPrincipal.Name = "stbPrincipal";
            // 
            // stbPrincipal_tsUsuario
            // 
            this.stbPrincipal_tsUsuario.Image = global::Scoliosis.Properties.Resources.Users;
            resources.ApplyResources(this.stbPrincipal_tsUsuario, "stbPrincipal_tsUsuario");
            this.stbPrincipal_tsUsuario.Name = "stbPrincipal_tsUsuario";
            this.stbPrincipal_tsUsuario.Spring = true;
            // 
            // stbPrincipal_tsTipo
            // 
            resources.ApplyResources(this.stbPrincipal_tsTipo, "stbPrincipal_tsTipo");
            this.stbPrincipal_tsTipo.Name = "stbPrincipal_tsTipo";
            this.stbPrincipal_tsTipo.Spring = true;
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCadastro,
            this.tsAvaliacao,
            this.tsFerramentas,
            this.tsSeguranca,
            this.tsAjuda,
            this.tsSair});
            resources.ApplyResources(this.tsPrincipal, "tsPrincipal");
            this.tsPrincipal.Name = "tsPrincipal";
            // 
            // tsCadastro
            // 
            this.tsCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCadastro_miPacientes,
            this.tsCadastro_miUsuarios});
            this.tsCadastro.Image = global::Scoliosis.Properties.Resources.Manage;
            resources.ApplyResources(this.tsCadastro, "tsCadastro");
            this.tsCadastro.Name = "tsCadastro";
            // 
            // tsCadastro_miPacientes
            // 
            this.tsCadastro_miPacientes.Name = "tsCadastro_miPacientes";
            resources.ApplyResources(this.tsCadastro_miPacientes, "tsCadastro_miPacientes");
            this.tsCadastro_miPacientes.Click += new System.EventHandler(this.tsCadastro_miPacientes_Click);
            // 
            // tsCadastro_miUsuarios
            // 
            this.tsCadastro_miUsuarios.Image = global::Scoliosis.Properties.Resources.Users;
            this.tsCadastro_miUsuarios.Name = "tsCadastro_miUsuarios";
            resources.ApplyResources(this.tsCadastro_miUsuarios, "tsCadastro_miUsuarios");
            this.tsCadastro_miUsuarios.Click += new System.EventHandler(this.tsCadastro_miUsuarios_Click);
            // 
            // tsAvaliacao
            // 
            this.tsAvaliacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lsAvaliacao_miPostural,
            this.lsAvaliacao_miIMC});
            this.tsAvaliacao.Image = global::Scoliosis.Properties.Resources.Evaluation;
            resources.ApplyResources(this.tsAvaliacao, "tsAvaliacao");
            this.tsAvaliacao.Name = "tsAvaliacao";
            // 
            // lsAvaliacao_miPostural
            // 
            this.lsAvaliacao_miPostural.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lsAvaliacao_miPostural_miNova,
            this.lsAvaliacao_miPostural_miVisualizar});
            this.lsAvaliacao_miPostural.Name = "lsAvaliacao_miPostural";
            resources.ApplyResources(this.lsAvaliacao_miPostural, "lsAvaliacao_miPostural");
            // 
            // lsAvaliacao_miPostural_miNova
            // 
            this.lsAvaliacao_miPostural_miNova.Image = global::Scoliosis.Properties.Resources.Create;
            this.lsAvaliacao_miPostural_miNova.Name = "lsAvaliacao_miPostural_miNova";
            resources.ApplyResources(this.lsAvaliacao_miPostural_miNova, "lsAvaliacao_miPostural_miNova");
            this.lsAvaliacao_miPostural_miNova.Click += new System.EventHandler(this.lsAvaliacao_miPostural_miNova_Click);
            // 
            // lsAvaliacao_miPostural_miVisualizar
            // 
            this.lsAvaliacao_miPostural_miVisualizar.Image = global::Scoliosis.Properties.Resources.View;
            this.lsAvaliacao_miPostural_miVisualizar.Name = "lsAvaliacao_miPostural_miVisualizar";
            resources.ApplyResources(this.lsAvaliacao_miPostural_miVisualizar, "lsAvaliacao_miPostural_miVisualizar");
            this.lsAvaliacao_miPostural_miVisualizar.Click += new System.EventHandler(this.lsAvaliacao_miPostural_miVisualizar_Click);
            // 
            // lsAvaliacao_miIMC
            // 
            this.lsAvaliacao_miIMC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lsAvaliacao_miIMC_miNovo,
            this.lsAvaliacao_miIMC_miVisualizar});
            this.lsAvaliacao_miIMC.Name = "lsAvaliacao_miIMC";
            resources.ApplyResources(this.lsAvaliacao_miIMC, "lsAvaliacao_miIMC");
            // 
            // lsAvaliacao_miIMC_miNovo
            // 
            this.lsAvaliacao_miIMC_miNovo.Image = global::Scoliosis.Properties.Resources.Create;
            this.lsAvaliacao_miIMC_miNovo.Name = "lsAvaliacao_miIMC_miNovo";
            resources.ApplyResources(this.lsAvaliacao_miIMC_miNovo, "lsAvaliacao_miIMC_miNovo");
            this.lsAvaliacao_miIMC_miNovo.Click += new System.EventHandler(this.lsAvaliacao_miIMC_miNovo_Click);
            // 
            // lsAvaliacao_miIMC_miVisualizar
            // 
            this.lsAvaliacao_miIMC_miVisualizar.Image = global::Scoliosis.Properties.Resources.View;
            this.lsAvaliacao_miIMC_miVisualizar.Name = "lsAvaliacao_miIMC_miVisualizar";
            resources.ApplyResources(this.lsAvaliacao_miIMC_miVisualizar, "lsAvaliacao_miIMC_miVisualizar");
            this.lsAvaliacao_miIMC_miVisualizar.Click += new System.EventHandler(this.lsAvaliacao_miIMC_miVisualizar_Click);
            // 
            // tsFerramentas
            // 
            this.tsFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFerramentas_miOpcoes});
            this.tsFerramentas.Image = global::Scoliosis.Properties.Resources.Tools;
            resources.ApplyResources(this.tsFerramentas, "tsFerramentas");
            this.tsFerramentas.Name = "tsFerramentas";
            // 
            // tsFerramentas_miOpcoes
            // 
            this.tsFerramentas_miOpcoes.Name = "tsFerramentas_miOpcoes";
            resources.ApplyResources(this.tsFerramentas_miOpcoes, "tsFerramentas_miOpcoes");
            this.tsFerramentas_miOpcoes.Click += new System.EventHandler(this.tsFerramentas_miOpcoes_Click);
            // 
            // tsSeguranca
            // 
            this.tsSeguranca.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSeguranca_miAlterarSenha,
            this.tsSeguranca_miNovoLogin});
            this.tsSeguranca.Image = global::Scoliosis.Properties.Resources.Security;
            resources.ApplyResources(this.tsSeguranca, "tsSeguranca");
            this.tsSeguranca.Name = "tsSeguranca";
            // 
            // tsSeguranca_miAlterarSenha
            // 
            this.tsSeguranca_miAlterarSenha.Name = "tsSeguranca_miAlterarSenha";
            resources.ApplyResources(this.tsSeguranca_miAlterarSenha, "tsSeguranca_miAlterarSenha");
            this.tsSeguranca_miAlterarSenha.Click += new System.EventHandler(this.tsSeguranca_miAlterarSenha_Click);
            // 
            // tsSeguranca_miNovoLogin
            // 
            this.tsSeguranca_miNovoLogin.Name = "tsSeguranca_miNovoLogin";
            resources.ApplyResources(this.tsSeguranca_miNovoLogin, "tsSeguranca_miNovoLogin");
            this.tsSeguranca_miNovoLogin.Click += new System.EventHandler(this.tsSeguranca_miNovoLogin_Click);
            // 
            // tsAjuda
            // 
            this.tsAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAjuda_miManualUsuario,
            this.tsAjuda_miSobre});
            this.tsAjuda.Image = global::Scoliosis.Properties.Resources.Help;
            resources.ApplyResources(this.tsAjuda, "tsAjuda");
            this.tsAjuda.Name = "tsAjuda";
            // 
            // tsAjuda_miManualUsuario
            // 
            this.tsAjuda_miManualUsuario.Name = "tsAjuda_miManualUsuario";
            resources.ApplyResources(this.tsAjuda_miManualUsuario, "tsAjuda_miManualUsuario");
            // 
            // tsAjuda_miSobre
            // 
            this.tsAjuda_miSobre.Name = "tsAjuda_miSobre";
            resources.ApplyResources(this.tsAjuda_miSobre, "tsAjuda_miSobre");
            this.tsAjuda_miSobre.Click += new System.EventHandler(this.tsAjuda_miSobre_Click);
            // 
            // tsSair
            // 
            this.tsSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSair.Image = global::Scoliosis.Properties.Resources.Exit;
            resources.ApplyResources(this.tsSair, "tsSair");
            this.tsSair.Name = "tsSair";
            this.tsSair.Click += new System.EventHandler(this.tsSair_Click);
            // 
            // FrmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.stbPrincipal);
            this.IsMdiContainer = true;
            this.Name = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.stbPrincipal.ResumeLayout(false);
            this.stbPrincipal.PerformLayout();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stbPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel stbPrincipal_tsUsuario;
        private System.Windows.Forms.ToolStripStatusLabel stbPrincipal_tsTipo;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripDropDownButton tsSeguranca;
        private System.Windows.Forms.ToolStripMenuItem tsSeguranca_miNovoLogin;
        private System.Windows.Forms.ToolStripDropDownButton tsAjuda;
        private System.Windows.Forms.ToolStripMenuItem tsAjuda_miManualUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsAjuda_miSobre;
        private System.Windows.Forms.ToolStripButton tsSair;
        private System.Windows.Forms.ToolStripDropDownButton tsCadastro;
        private System.Windows.Forms.ToolStripMenuItem tsCadastro_miPacientes;
        private System.Windows.Forms.ToolStripMenuItem tsCadastro_miUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsSeguranca_miAlterarSenha;
        private System.Windows.Forms.ToolStripDropDownButton tsAvaliacao;
        private System.Windows.Forms.ToolStripMenuItem lsAvaliacao_miPostural;
        private System.Windows.Forms.ToolStripMenuItem lsAvaliacao_miPostural_miNova;
        private System.Windows.Forms.ToolStripMenuItem lsAvaliacao_miPostural_miVisualizar;
        private System.Windows.Forms.ToolStripMenuItem lsAvaliacao_miIMC;
        private System.Windows.Forms.ToolStripMenuItem lsAvaliacao_miIMC_miNovo;
        private System.Windows.Forms.ToolStripMenuItem lsAvaliacao_miIMC_miVisualizar;
        private System.Windows.Forms.ToolStripDropDownButton tsFerramentas;
        private System.Windows.Forms.ToolStripMenuItem tsFerramentas_miOpcoes;
    }
}