using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace Scoliosis
{
    public partial class FrmNovaAvaliacaoPostural_2 : Scoliosis.FrmBaseDialog
    {
        private Bitmap selectedBitmap = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovaAvaliacaoPostural_2()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        /// <summary>
        /// Realiza aquisição da imagem através da câmera digital.
        /// </summary>
        private void btnAdquirirCamera_Click(object sender, EventArgs e)
        {
            // habilita/desabilita botão
            this.btnProximo.Enabled = (this.selectedBitmap != null);

            // formulário de aquisição da imagem
            FrmAquisicaoImagem frmAquisicao = new FrmAquisicaoImagem();
            if (frmAquisicao.ShowDialog(this) == DialogResult.Cancel)
            {
                frmAquisicao.Dispose();
                return;
            }

            // imagem adquirida
            this.selectedBitmap = frmAquisicao.SelectedBitmap;

            // mostra na PictureBox
            this.pctImagem.Image = (Bitmap)this.selectedBitmap.Clone();

            // habilita botão
            this.btnProximo.Enabled = true;

            // libera memória
            frmAquisicao.Dispose();
        }

        /// <summary>
        /// Procura pela imagem no sistema de arquivos.
        /// </summary>
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            // habilita/desabilita botão
            this.btnProximo.Enabled = (this.selectedBitmap != null);

            // busca pela imagem
            if (this.dlgProcurarImagem.ShowDialog(this) == DialogResult.Cancel)
                return;

            // leitura da imagem
            try
            {
                // abre e copia imagem
                Bitmap bitmap = (Bitmap)Bitmap.FromFile(this.dlgProcurarImagem.FileName);
                this.selectedBitmap = (Bitmap)bitmap.Clone();

                // mostra na PictureBox
                this.pctImagem.Image = (Bitmap)this.selectedBitmap.Clone();

                // habilita botão
                this.btnProximo.Enabled = true;
            }
            catch
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0011"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Retorna imagem selecionada.
        /// </summary>
        public Bitmap SelectedBitmap
        {
            get
            {
                return this.selectedBitmap;
            }
        }
    }
}

