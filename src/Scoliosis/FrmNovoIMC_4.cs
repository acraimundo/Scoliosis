using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Scoliosis.Utils.MathUtil;
using Scoliosis.Utils.Image;

namespace Scoliosis
{
    public partial class FrmNovoIMC_4 : Scoliosis.FrmBaseDialog
    {
        private Bitmap selectedBitmap = null;
        private float Ylower = 40f;
        private float Yupper = 340f;
        private bool buttonPressedUpper = false;
        private bool buttonPressedLower = false;
        private double[] coeffTransf = null;
        private float height = 0f;

        // habilita chamada assíncrona para modificar os valores de Ylower e Yupper
        delegate void SafeChangeYLowerUpperCallback(float ylower, float yupper);

        // chamada assíncrona para habilitar ou desabilitar o botão
        delegate void SafeChangeButtonEnabledCallback(bool enabled);

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovoIMC_4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configura imagem onde será calculado a altura do indivíduo.
        /// </summary>
        public Bitmap SelectedBitmap
        {
            set
            {
                // cópia do bitmap original
                Bitmap inputBitmap = value;
                this.selectedBitmap = (Bitmap)inputBitmap.Clone();

                // mostra bitmap no PictureBox
                this.pctImagem.Image = (Bitmap)this.selectedBitmap.Clone();
            }
        }

        /// <summary>
        /// Define os coeficientes da transformação projetiva.
        /// </summary>
        public double[] TransfCoefficients
        {
            set
            {
                this.coeffTransf = value;
            }
        }

        /// <summary>
        /// Retorna a altura calculada.
        /// </summary>
        public float CalculatedHeight
        {
            get
            {
                return this.height;
            }
        }

        /// <summary>
        /// Cria thread para realizar o processamento inicial.
        /// </summary>
        private void FrmNovoIMC_4_Load(object sender, EventArgs e)
        {
            // cria thread para que uma resposta rápida seja dada ao usuário
            Thread thread = new Thread(new ThreadStart(SuggestHeight));
            thread.Start();
        }

        /// <summary>
        /// Realiza o thresholding na imagem e sugere um valor para a altura.
        /// </summary>
        private void SuggestHeight()
        {
            // desabilita botão
            SafeChangeButtonEnabled(false);

            // bitmap a ser alterado
            Bitmap bitmap = (Bitmap)this.selectedBitmap.Clone();

            // array com dados do bitmap
            byte[,,] bmpData = null;

            // transforma bitmap em um array de bytes
            BitmapTools.GetBitmapData(bitmap, out bmpData);

            // transforma a imagem para preto e branco
            BitmapTools.TransformToGrayscale(ref bmpData);

            // histograma da imagem
            int[] h = null;
            BitmapTools.ImageHistogram(ref bmpData, PointType.Red, out h);

            // limiar de Otsu
            byte otsu = (byte)BitmapTools.OtsuLimiar(ref h);

            // aplica thresholding
            BitmapTools.Thresholding(ref bmpData, otsu, otsu, otsu, 255, 0);

            // tamanho da imagem
            int width = bitmap.Width;
            int height = bitmap.Height;

            // tenta encontrar Ymin
            int Ymin = 0;
            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    if (bmpData[i, j, 0] == 255)
                    {
                        Ymin = j;
                        j = height;
                        break;
                    }
                }
            }

            // tenta encontrar Ymax
            int Ymax = height - 1;
            for (int j = height - 1; j >= 0; --j)
            {
                for (int i = 0; i < width; ++i)
                {
                    if (bmpData[i, j, 0] == 255)
                    {
                        Ymax = j;
                        j = -1;
                        break;
                    }
                }
            }

            if (Ymax == (height - 1))
                Ymax = (int)(height * 0.95);

            // modifica Ylower e Yupper
            SafeChangeYLowerUpper(Ymin, Ymax);

            // habilita botão
            SafeChangeButtonEnabled(true);
        }

        /// <summary>
        /// Método para habilitar o botão btnProximo.
        /// </summary>
        private void SafeChangeButtonEnabled(bool enabled)
        {
            // InvokeRequired - verifica se a chamada ao método é da thread do próprio método
            if (this.InvokeRequired)
            {
                SafeChangeButtonEnabledCallback callback = new SafeChangeButtonEnabledCallback(SafeChangeButtonEnabled);
                this.Invoke(callback, new object[] { enabled });
            }
            else
            {
                this.btnProximo.Enabled = enabled;
            }
        }

        /// <summary>
        /// Método para modificar os valores de YLower e YUpper.
        /// </summary>
        private void SafeChangeYLowerUpper(float ylower, float yupper)
        {
            // InvokeRequired - verifica se a chamada ao método é da thread do próprio método
            if (this.InvokeRequired)
            {
                SafeChangeYLowerUpperCallback callback = new SafeChangeYLowerUpperCallback(SafeChangeYLowerUpper);
                this.Invoke(callback, new object[] { ylower, yupper });
            }
            else
            {
                this.Ylower = ylower;
                this.Yupper = yupper;

                // calcula altura
                CalculateHeight();

                // redesenha imagem
                this.pctImagem.Invalidate();
            }
        }

        /// <summary>
        /// Evento para desenhar as linhas base.
        /// </summary>
        private void pctImagem_Paint(object sender, PaintEventArgs e)
        {
            if (this.pctImagem.Image == null)
                return;

            // Viewport
            RectangleF viewPort = new RectangleF(0f, 0f, this.pctImagem.Width, this.pctImagem.Height);

            // Window
            RectangleF window = new RectangleF(0f, 0f, this.selectedBitmap.Width, this.selectedBitmap.Height);

            // transforma os pontos
            PointF p1 = BitmapTools.LogicalToDevice(new PointF(0f, this.Ylower), viewPort, window);
            PointF p2 = BitmapTools.LogicalToDevice(new PointF(this.selectedBitmap.Width - 1, this.Ylower), viewPort, window);
            PointF p3 = BitmapTools.LogicalToDevice(new PointF(0f, this.Yupper), viewPort, window);
            PointF p4 = BitmapTools.LogicalToDevice(new PointF(this.selectedBitmap.Width - 1, this.Yupper), viewPort, window);

            // traços
            Pen pen1 = new Pen(Brushes.Blue, 2f);
            Pen pen2 = new Pen(Brushes.Red, 2f);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            // desenha as linhas
            e.Graphics.DrawLine(pen1, p1, p2);
            e.Graphics.DrawLine(pen2, p3, p4);
        }

        /// <summary>
        /// Evento chamado quando o usuário pressiona o botão do mouse.
        /// </summary>
        private void pctImagem_MouseDown(object sender, MouseEventArgs e)
        {
            // Viewport
            RectangleF viewPort = new RectangleF(0f, 0f, this.pctImagem.Width, this.pctImagem.Height);

            // Window
            RectangleF window = new RectangleF(0f, 0f, this.selectedBitmap.Width, this.selectedBitmap.Height);

            // transforma para coordenada de dispositivo
            PointF devicePointLower = BitmapTools.LogicalToDevice(new PointF(0, this.Ylower), viewPort, window);
            PointF devicePointUpper = BitmapTools.LogicalToDevice(new PointF(0, this.Yupper), viewPort, window);

            if (Math.Abs(devicePointLower.Y - e.Y) <= 4)
                this.buttonPressedLower = true;
            else if (Math.Abs(devicePointUpper.Y - e.Y) <= 4)
                this.buttonPressedUpper = true;

            // redesenha imagem
            this.pctImagem.Invalidate();
        }

        /// <summary>
        /// Evento chamado quando o usuário move o cursor do mouse.
        /// </summary>
        private void pctImagem_MouseMove(object sender, MouseEventArgs e)
        {
            // Viewport
            RectangleF viewPort = new RectangleF(0f, 0f, this.pctImagem.Width, this.pctImagem.Height);

            // Window
            RectangleF window = new RectangleF(0f, 0f, this.selectedBitmap.Width, this.selectedBitmap.Height);

            // transforma para coordenada de dispositivo
            PointF devicePointLower = BitmapTools.LogicalToDevice(new PointF(0, this.Ylower), viewPort, window);
            PointF devicePointUpper = BitmapTools.LogicalToDevice(new PointF(0, this.Yupper), viewPort, window);

            if (Math.Abs(devicePointLower.Y - e.Y) <= 4 || Math.Abs(devicePointUpper.Y - e.Y) <= 4)
                Cursor.Current = Cursors.NoMoveVert;
            else
                Cursor.Current = Cursors.Default;

            // redesenha imagem
            this.pctImagem.Invalidate();
        }

        /// <summary>
        /// Evento chamado quando o usuário solta o botão do mouse.
        /// </summary>
        private void pctImagem_MouseUp(object sender, MouseEventArgs e)
        {
            // Viewport
            RectangleF viewPort = new RectangleF(0f, 0f, this.pctImagem.Width, this.pctImagem.Height);

            // Window
            RectangleF window = new RectangleF(0f, 0f, this.selectedBitmap.Width, this.selectedBitmap.Height);

            if (this.buttonPressedUpper)
            {
                int Y = e.Y;

                // corrige Y
                if (Y > this.pctImagem.Height)
                    Y = this.pctImagem.Height - 1;
                else if (Y < 0)
                    Y = 0;

                PointF logicalPoint = BitmapTools.DeviceToLogical(new PointF(0f, Y), window, viewPort);
                this.Yupper = logicalPoint.Y;
                this.buttonPressedUpper = false;
            }
            else if (this.buttonPressedLower)
            {
                int Y = e.Y;

                // corrige Y
                if (Y > this.pctImagem.Height)
                    Y = pctImagem.Height - 1;
                else if (Y < 0)
                    Y = 0;

                PointF logicalPoint = BitmapTools.DeviceToLogical(new PointF(0f, Y), window, viewPort);
                this.Ylower = logicalPoint.Y;
                this.buttonPressedLower = false;
            }

            // calcula altura
            CalculateHeight();

            // redesenha imagem
            this.pctImagem.Invalidate();
        }

        /// <summary>
        /// Calcula altura do paciente.
        /// </summary>
        private void CalculateHeight()
        {
            // coordenada X média
            float xm = this.selectedBitmap.Width / 2;

            // transforma upper
            PointF lowerPoint = MathLib.TransformPointProjectiveTransf(new PointF(xm, this.Ylower), ref this.coeffTransf);
            PointF upperPoint = MathLib.TransformPointProjectiveTransf(new PointF(xm, this.Yupper), ref this.coeffTransf);

            // calcula altura
            this.height = (float)Math.Round(Math.Abs(lowerPoint.Y - upperPoint.Y) / 100.0, 2);

            // mostra altura
            this.lblAlturaCalculada.Text = this.height.ToString("0.00") + " m";
        }
    }
}

