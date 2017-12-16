using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Resources;
using System.Reflection;
using Scoliosis.Utils.Image;
using Scoliosis.Utils.MathUtil;

namespace Scoliosis
{
    public partial class FrmNovaAvaliacaoPostural_4 : Scoliosis.FrmBaseDialog
    {
        private Bitmap selectedBitmap = null;
        private List<PointCorrelation> pointsList = null;
        private ResourceManager resourceMgr = null;
        private double fatorCorrelacao = 0.25;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovaAvaliacaoPostural_4()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        /// <summary>
        /// Configura imagem onde será feita a busca pelos pontos de referência.
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
        /// Retorna a lista dos pontos.
        /// </summary>
        public List<PointCorrelation> PointsList
        {
            get
            {
                return this.pointsList;
            }
        }

        /// <summary>
        /// Realiza identificação dos pontos na imagem.
        /// </summary>
        private void btnIdentificarPontos_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // desabilita botão
            this.btnProximo.Enabled = false;

            // bitmap a ser processado
            Bitmap drawBitmap = (Bitmap)this.selectedBitmap.Clone();

            // dados do bitmap
            byte[, ,] bmpData;
            BitmapTools.GetBitmapData(drawBitmap, out bmpData);

            // saturação
            BitmapTools.Saturation(ref bmpData, 4.5);

            //Bitmap teste1 = (Bitmap)this.selectedBitmap.Clone();
            //BitmapTools.SetBitmapData(teste1, ref bmpData);
            //teste1.Save("c:\\temp\\ImagensTeste\\testeSat.jpg");

            // limiarização
            BitmapTools.Thresholding(ref bmpData, PointType.Blue, 0, 255);

            //Bitmap teste2 = (Bitmap)this.selectedBitmap.Clone();
            //BitmapTools.SetBitmapData(teste2, ref bmpData);
            //teste2.Save("c:\\temp\\ImagensTeste\\testeThreshold.jpg");

            // redução de ruído
            BitmapTools.BlackAndWhiteNoiseReduction(ref bmpData, 127);

            //Bitmap teste3 = (Bitmap)this.selectedBitmap.Clone();
            //BitmapTools.SetBitmapData(teste3, ref bmpData);
            //teste3.Save("c:\\temp\\ImagensTeste\\testeNoiseReduction.jpg");

            // template matching
            this.pointsList = BitmapTools.FindImagePoints(ref bmpData, this.fatorCorrelacao);

            if (this.pointsList.Count != 16)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0012"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                //StreamWriter sw = new StreamWriter(@"c:\\temp\\pontos.txt");
                //foreach (PointCorrelation pt in this.pointsList)
                //{
                //    sw.WriteLine("{0},{1}", pt.X, pt.Y);
                //}
                //sw.Close();
            }
            else
            {
                // troca pontos 15 e 16 (se necessário)
                if (this.pointsList[14].X < this.pointsList[15].X)
                {
                    PointCorrelation p = this.pointsList[15];
                    this.pointsList[15] = this.pointsList[14];
                    this.pointsList[14] = p;
                }

                // troca pontos 2 e 3 (se necessário)
                if (this.pointsList[1].X < this.pointsList[2].X)
                {
                    PointCorrelation p = this.pointsList[1];
                    this.pointsList[1] = this.pointsList[2];
                    this.pointsList[2] = p;
                }

                // habilita botão
                this.btnProximo.Enabled = true;
            }

            // desenha pontos
            DesenharPontos(drawBitmap);

            //drawBitmap.Save("c:\\temp\\ImagensTeste\\testeDrawPoints.jpg");

            // atualiza PictureBox
            this.pctImagem.Image = drawBitmap;

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Realiza leitura dos pontos de um arquivo texto.
        /// </summary>
        private void btnLerPontosArquivo_Click(object sender, EventArgs e)
        {
            // desabilita botão
            this.btnProximo.Enabled = false;

            // mostra caixa de diálogo
            if (this.dlgArquivoPontos.ShowDialog(this) == DialogResult.Cancel)
                return;

            try
            {
                // limpa pontos
                if (pointsList != null)
                    this.pointsList.Clear();
                else
                    this.pointsList = new List<PointCorrelation>();

                using (StreamReader sr = new StreamReader(this.dlgArquivoPontos.FileName))
                {
                    // leitura dos pontos
                    for (int i = 0; i < 16; ++i)
                    {
                        string[] coords = sr.ReadLine().Trim().Split(new char[] { ',' });

                        // cria ponto
                        PointCorrelation point = new PointCorrelation(int.Parse(coords[0]),
                                int.Parse(coords[1]), this.fatorCorrelacao);

                        // adiciona na lista
                        this.pointsList.Add(point);
                    }
                }

                // cópia do bitmap
                Bitmap drawBitmap = (Bitmap)this.selectedBitmap.Clone();

                // desenha pontos
                DesenharPontos(drawBitmap);

                // atualiza PictureBox
                this.pctImagem.Image = drawBitmap;

                // habilita botão
                this.btnProximo.Enabled = true;
            }
            catch
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0013"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Desenha os pontos na imagem.
        /// </summary>
        /// <param name="bitmap">Bitmap onde serão desenhados os pontos.</param>
        private void DesenharPontos(Bitmap bitmap)
        {
            // tamanho da linha e texto
            float lineWidth = (1f * this.selectedBitmap.Width) / (float)this.pctImagem.Width;
            float lineHeight = (10f * this.selectedBitmap.Height) / (float)this.pctImagem.Height;
            float textSize = (10f * this.selectedBitmap.Height) / (float)this.pctImagem.Height;

            // contador
            int count = 1;

            // desenha pontos que foram identificados
            Graphics g = Graphics.FromImage(bitmap);
            foreach (PointCorrelation p in this.pointsList)
            {
                // linha horizontal
                g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(p.X - (int)lineHeight, p.Y),
                            new Point(p.X + (int)lineHeight, p.Y));

                // linha vertical
                g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(p.X, p.Y - (int)lineHeight),
                            new Point(p.X, p.Y + (int)lineHeight));

                // texto com o nome do ponto
                g.DrawString(count.ToString(), new Font("Sans Serif", textSize, FontStyle.Bold, GraphicsUnit.Pixel),
                    Brushes.Black, new PointF(p.X, p.Y - lineHeight - lineWidth * 1.05f));

                // incrementa contador de pontos
                count++;
            }

            // libera memória
            g.Dispose();
        }

        /// <summary>
        /// Modifica o fator de correlação.
        /// </summary>
        private void trbFatorCorrelacao_Scroll(object sender, EventArgs e)
        {
            this.fatorCorrelacao = (double)this.trbFatorCorrelacao.Value;
            this.fatorCorrelacao = (0.5f * this.fatorCorrelacao) / 20.0f;

            double pct = this.fatorCorrelacao * 100.0;

            this.lblFatorCorrelacao.Text = pct.ToString() + "%";
        }
    }
}

