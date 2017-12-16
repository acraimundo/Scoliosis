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
    public partial class FrmNovaAvaliacaoPostural_3 : Scoliosis.FrmBaseDialog
    {
        private Bitmap selectedBitmap = null;
        private List<PointCorrelation> pointsList = null;
        private double[] coeffTransf = null;
        private ResourceManager resourceMgr = null;
        private double fatorCorrelacao = 0.25;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovaAvaliacaoPostural_3()
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
        /// Retorna os coeficientes da transformação projetiva.
        /// </summary>
        public double[] TransfCoefficients
        {
            get
            {
                return this.coeffTransf;
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
            //teste1.Save("c:\\temp\\testeSat.jpg");

            // limiarização
            BitmapTools.Thresholding(ref bmpData, PointType.Green, 0, 255);

            //Bitmap teste2 = (Bitmap)this.selectedBitmap.Clone();
            //BitmapTools.SetBitmapData(teste2, ref bmpData);
            //teste2.Save("c:\\temp\\testeThreshold.jpg");

            // redução de ruído
            BitmapTools.BlackAndWhiteNoiseReduction(ref bmpData, 127);

            // template matching
            this.pointsList = BitmapTools.FindImagePoints(ref bmpData, this.fatorCorrelacao);

            if (this.pointsList.Count != 6 && this.pointsList.Count != 12)
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0012"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // habilita botão
                this.btnProximo.Enabled = true;

                // reordena pontos considerando a ordem de scan
                if (this.pointsList[0].X > this.pointsList[1].X)
                {
                    PointCorrelation p = this.pointsList[0];
                    this.pointsList[0] = this.pointsList[1];
                    this.pointsList[1] = p;
                }

                if (this.pointsList[2].X > this.pointsList[3].X)
                {
                    PointCorrelation p = this.pointsList[2];
                    this.pointsList[2] = this.pointsList[3];
                    this.pointsList[3] = p;
                }

                if (this.pointsList[4].X > this.pointsList[5].X)
                {
                    PointCorrelation p = this.pointsList[4];
                    this.pointsList[4] = pointsList[5];
                    this.pointsList[5] = p;
                }

                if (this.pointsList.Count == 12)
                {
                    // reordena pontos considerando a ordem de scan
                    if (this.pointsList[6].X > this.pointsList[7].X)
                    {
                        PointCorrelation p = this.pointsList[6];
                        this.pointsList[6] = this.pointsList[7];
                        this.pointsList[7] = p;
                    }

                    if (this.pointsList[8].X > this.pointsList[9].X)
                    {
                        PointCorrelation p = this.pointsList[8];
                        this.pointsList[8] = this.pointsList[9];
                        this.pointsList[9] = p;
                    }

                    if (this.pointsList[10].X > this.pointsList[11].X)
                    {
                        PointCorrelation p = this.pointsList[10];
                        this.pointsList[10] = pointsList[11];
                        this.pointsList[11] = p;
                    }
                }
            }

            // desenha pontos
            DesenharPontos(drawBitmap);

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
                    for (int i = 0; i < 6; ++i)
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
        /// Calcula parâmetros da transformação.
        /// </summary>
        private void btnProximo_Click(object sender, EventArgs e)
        {
            PointF[] targetPoints = new PointF[this.pointsList.Count];
            PointF[] sourcePoints = new PointF[this.pointsList.Count];

            Cursor.Current = Cursors.WaitCursor;

            // pontos do sistema de origem
            for (int i = 0; i < this.pointsList.Count; ++i)
                sourcePoints[i] = new PointF((float)this.pointsList[i].X, (float)this.pointsList[i].Y);

            // pontos do sistema de destino
            try
            {
                if (this.pointsList.Count == 6)
                {
                    string[] refPoint = ConfigurationManager.AppSettings["6pt_RefPoint1"].Split(new char[] { ',' });
                    targetPoints[0] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["6pt_RefPoint2"].Split(new char[] { ',' });
                    targetPoints[1] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["6pt_RefPoint3"].Split(new char[] { ',' });
                    targetPoints[2] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["6pt_RefPoint4"].Split(new char[] { ',' });
                    targetPoints[3] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["6pt_RefPoint5"].Split(new char[] { ',' });
                    targetPoints[4] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["6pt_RefPoint6"].Split(new char[] { ',' });
                    targetPoints[5] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));
                }
                else
                {
                    string[] refPoint = ConfigurationManager.AppSettings["12pt_RefPoint1"].Split(new char[] { ',' });
                    targetPoints[0] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint2"].Split(new char[] { ',' });
                    targetPoints[1] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint3"].Split(new char[] { ',' });
                    targetPoints[2] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint4"].Split(new char[] { ',' });
                    targetPoints[3] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint5"].Split(new char[] { ',' });
                    targetPoints[4] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint6"].Split(new char[] { ',' });
                    targetPoints[5] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint7"].Split(new char[] { ',' });
                    targetPoints[6] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint8"].Split(new char[] { ',' });
                    targetPoints[7] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint9"].Split(new char[] { ',' });
                    targetPoints[8] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint10"].Split(new char[] { ',' });
                    targetPoints[9] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint11"].Split(new char[] { ',' });
                    targetPoints[10] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));

                    refPoint = ConfigurationManager.AppSettings["12pt_RefPoint12"].Split(new char[] { ',' });
                    targetPoints[11] = new PointF(float.Parse(refPoint[0]), float.Parse(refPoint[1]));
                }
            }
            catch
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0014"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            // calcula parâmetros da transformação
            try
            {
                if (this.pointsList.Count == 6)
                    MathLib.CalcProjectiveTransfCoeffs6pt(out this.coeffTransf, ref sourcePoints, ref targetPoints);
                else
                    MathLib.CalcProjectiveTransfCoeffs12pt(out this.coeffTransf, ref sourcePoints, ref targetPoints);
            }
            catch
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0015"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            // modifica cursor
            Cursor.Current = Cursors.Default;

            // retorno
            this.DialogResult = DialogResult.OK;

            // fecha o formulário
            Close();
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

