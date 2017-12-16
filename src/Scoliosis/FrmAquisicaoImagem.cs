using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using Scoliosis.Utils.WIAUtil;

namespace Scoliosis
{
    public partial class FrmAquisicaoImagem : Scoliosis.FrmBaseDialog
    {
        private ResourceManager resourceMgr = null;
        private WIAWrapper wiaWrapper = new WIAWrapper();
        private Bitmap selectedBitmap = null;
        private bool blockShowPicture = false;
        private bool blockRotate = false;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmAquisicaoImagem()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();

            this.blockRotate = true;
            this.cmbRotacionar.SelectedIndex = 0;
            this.blockRotate = false;
        }

        /// <summary>
        /// Lista dispositivos conectados.
        /// </summary>
        private void FrmAdquisicaoImagem_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // lista dispositivos conectados ao computador
            List<WIACameraInfo> cameraInfoList = WIAWrapper.ListConnectedDevices();

            // data binding
            this.lstDispositivos.DataSource = cameraInfoList;
            this.lstDispositivos.DisplayMember = "Description";

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Realiza conexão com o dispositivo.
        /// </summary>
        private void lstDispositivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // desabilita listagem
            this.btnListarImagens.Enabled = false;

            // dispositivo selecionado
            WIACameraInfo cameraInfo = (WIACameraInfo)this.lstDispositivos.SelectedItem;

            // tenta realizar conexão com o dispositivo
            if (!this.wiaWrapper.ConnectToDevice(cameraInfo))
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0008"),
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // habilita listagem
            this.btnListarImagens.Enabled = true;
        }

        /// <summary>
        /// Realiza listagem das imagens.
        /// </summary>
        private void btnListarImagens_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // bloqueia o PictureBox de mostrar a imagem
            this.blockShowPicture = true;

            // lista imagens existentes na câmera
            List<WIAImageInfo> imageInfoList = this.wiaWrapper.ListDevicePictures();

            // data binding
            this.lstImagens.DataSource = imageInfoList;
            this.lstImagens.DisplayMember = "FileName";

            // desbloqueia PictureBox
            this.blockShowPicture = false;

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Realiza aquisição da imagem e mostra no PictureBox.
        /// </summary>
        private void lstImagens_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verifica se a imagem será mostrada ou não
            if (this.blockShowPicture)
                return;

            Cursor.Current = Cursors.WaitCursor;

            // desabilita rotação da imagem
            this.cmbRotacionar.Enabled = false;

            // imagem selecionada
            WIAImageInfo imageInfo = (WIAImageInfo)this.lstImagens.SelectedItem;

            // aquisição da imagem
            if (!this.wiaWrapper.GetPicture(imageInfo, out this.selectedBitmap))
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0009"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            // mostra imagem no PictureBox
            this.pctImagem.Image = this.selectedBitmap;

            // configura ângulo = 0 graus
            this.blockRotate = true;
            this.cmbRotacionar.SelectedIndex = 0;
            this.blockRotate = false;

            // habilita rotação da imagem
            this.cmbRotacionar.Enabled = true;

            // habilita aquisição da imagem
            this.btnAdquirir.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Rotaciona imagem.
        /// </summary>
        private void cmbRotacionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verifica se a imagem será rotacionada ou não
            if (this.blockRotate || this.selectedBitmap == null)
                return;

            Cursor.Current = Cursors.WaitCursor;

            // tipo de rotação
            RotateFlipType rotType;

            if (this.cmbRotacionar.SelectedIndex == 0)
                rotType = RotateFlipType.RotateNoneFlipNone;
            else if (this.cmbRotacionar.SelectedIndex == 1)
                rotType = RotateFlipType.Rotate90FlipNone;
            else if (this.cmbRotacionar.SelectedIndex == 2)
                rotType = RotateFlipType.Rotate180FlipNone;
            else
                rotType = RotateFlipType.Rotate270FlipNone;

            // copia imagem
            Bitmap rotatedCopy = (Bitmap)this.selectedBitmap.Clone();

            // rotaciona imagem
            rotatedCopy.RotateFlip(rotType);
    
            // mostra imagem no PictureBox
            this.pctImagem.Image = rotatedCopy;

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Retorna o bitmap selecionado pelo usuário.
        /// </summary>
        public Bitmap SelectedBitmap
        {
            get
            {
                // tipo de rotação
                RotateFlipType rotType;

                if (this.cmbRotacionar.SelectedIndex == 0)
                    rotType = RotateFlipType.RotateNoneFlipNone;
                else if (this.cmbRotacionar.SelectedIndex == 1)
                    rotType = RotateFlipType.Rotate90FlipNone;
                else if (this.cmbRotacionar.SelectedIndex == 2)
                    rotType = RotateFlipType.Rotate180FlipNone;
                else
                    rotType = RotateFlipType.Rotate270FlipNone;

                // rotaciona bitmap (se necessário)
                if (rotType != RotateFlipType.RotateNoneFlipNone)
                    this.selectedBitmap.RotateFlip(rotType);

                return this.selectedBitmap;
            }
        }
    }
}

