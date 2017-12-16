using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using Scoliosis.Utils.Image;
using Scoliosis.Utils.MathUtil;

namespace Scoliosis
{
    public partial class FrmNovaAvaliacaoPostural_5 : Scoliosis.FrmBaseDialog
    {
        private Bitmap selectedBitmap = null;
        private List<PointCorrelation> pointsList = null;
        private List<PointF> transformPointsList = null;
        private double[] coeffTransf = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovaAvaliacaoPostural_5()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();

            this.cmbNomePonto1.SelectedIndex = 0;
            this.cmbNomePonto2.SelectedIndex = 1;
            this.cmbNomePonto3.SelectedIndex = 2;
            this.cmbNomePonto4.SelectedIndex = 3;
            this.cmbNomePonto5.SelectedIndex = 4;
            this.cmbNomePonto6.SelectedIndex = 5;
            this.cmbNomePonto7.SelectedIndex = 6;
            this.cmbNomePonto8.SelectedIndex = 7;
            this.cmbNomePonto9.SelectedIndex = 8;
            this.cmbNomePonto10.SelectedIndex = 9;
            this.cmbNomePonto11.SelectedIndex = 10;
            this.cmbNomePonto12.SelectedIndex = 11;
            this.cmbNomePonto13.SelectedIndex = 12;
            this.cmbNomePonto14.SelectedIndex = 13;
            this.cmbNomePonto15.SelectedIndex = 14;
            this.cmbNomePonto16.SelectedIndex = 15;
        }

        /// <summary>
        /// Configura imagem.
        /// </summary>
        /// <remarks>A propriedade pointsList deve ser configurada antes desta propriedade.</remarks>
        public Bitmap SelectedBitmap
        {
            set
            {
                // cópia do bitmap original
                Bitmap inputBitmap = value;
                this.selectedBitmap = (Bitmap)inputBitmap.Clone();

                // busca pelo range dos pontos
                float xmin = pointsList[0].X;
                float ymin = pointsList[0].Y;
                float xmax = pointsList[0].X;
                float ymax = pointsList[0].Y;

                foreach (PointCorrelation p in pointsList)
                {
                    if (p.X < xmin) xmin = p.X;
                    if (p.Y < ymin) ymin = p.Y;
                    if (p.X > xmax) xmax = p.X;
                    if (p.Y > ymax) ymax = p.Y;
                }

                // tamanho do range
                float width = Math.Abs(xmax - xmin);
                float height = Math.Abs(ymax - ymin);

                // aumenta o range em 20%
                xmin = xmin - width * 0.1f;
                ymin = ymin - height * 0.1f;
                xmax = xmax + width * 0.1f;
                ymax = ymax + height * 0.1f;

                // trata coordenadas negativas
                if (xmin < 0) xmin = 0;
                if (ymin < 0) ymin = 0;

                // trata coordenadas maior que a imagem
                if (xmax >= selectedBitmap.Width) xmax = selectedBitmap.Width - 1;
                if (ymax >= selectedBitmap.Height) ymax = selectedBitmap.Height - 1;

                // tamanho do bitmap
                Rectangle rect = new Rectangle((int)xmin, (int)ymin, (int)(xmax - xmin), (int)(ymax - ymin));

                // cria um novo bitmap
                Bitmap croppedBitmap = new Bitmap(rect.Width, rect.Height);

                // crop
                Graphics g = Graphics.FromImage(croppedBitmap);
                g.DrawImage(this.selectedBitmap, new Rectangle(0, 0, croppedBitmap.Width, croppedBitmap.Height), 
                        xmin, ymin, croppedBitmap.Width, croppedBitmap.Height, GraphicsUnit.Pixel);
                g.Dispose();

                // desenha pontos no bitmap
                DesenharPontos(croppedBitmap, xmin, ymin, xmax, ymax);

                 // mostra no pictureBox
                this.pctImagem.Image = croppedBitmap;
            }
        }

        /// <summary>
        /// Configura a lista dos pontos cuja ordem será modificada.
        /// </summary>
        public List<PointCorrelation> PointsList
        {
            set
            {
                this.pointsList = value;
            }
        }

        /// <summary>
        /// Retorna a lista de pontos transformados para o novo sistema.
        /// </summary>
        public List<PointF> TransformPointsList
        {
            get
            {
                return this.transformPointsList;
            }
        }

        /// <summary>
        /// Retorna os coeficientes da transformação projetiva.
        /// </summary>
        public double[] TransfCoefficients
        {
            set
            {
                this.coeffTransf = value;
            }
        }

        /// <summary>
        /// Desenha os pontos na imagem.
        /// </summary>
        /// <param name="bitmap">Bitmap onde serão desenhados os pontos.</param>
        private void DesenharPontos(Bitmap bitmap, float xmin, float ymin, float xmax, float ymax)
        {
            // pontos transformados para o sistema do range
            List<PointCorrelation> transfPoints = new List<PointCorrelation>();

            foreach (PointCorrelation p in this.pointsList)
            {
                PointCorrelation point = new PointCorrelation();
                point.X = p.X - (int)xmin;
                point.Y = p.Y - (int)ymin;
                transfPoints.Add(point);
            }

            // tamanho da linha e texto
            float lineWidth = (1f * bitmap.Width) / (float)this.pctImagem.Width;
            float lineHeight = (10f * bitmap.Height) / (float)this.pctImagem.Height;
            float textSize = (10f * bitmap.Height) / (float)this.pctImagem.Height;

            // contador
            int count = 1;

            // desenha pontos que foram identificados
            Graphics g = Graphics.FromImage(bitmap);
            foreach (PointCorrelation p in transfPoints)
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
        /// Modifica a ordem dos pontos.
        /// </summary>
        private void btnProximo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool[] flagPoint = new bool[16];

            // preenche flag para verificar se algum ponto deixou de ser identificado
            flagPoint[int.Parse(this.cmbNomePonto1.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto2.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto2.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto3.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto4.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto5.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto6.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto7.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto8.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto9.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto10.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto11.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto12.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto13.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto14.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto15.Text) - 1] = true;
            flagPoint[int.Parse(this.cmbNomePonto16.Text) - 1] = true;

            // verifica se algum ponto deixou de ser identificado
            for (int i = 0; i < 16; ++i)
            {
                if (!flagPoint[i])
                {
                    int index = i + 1;
                    MessageBox.Show(this, String.Format(this.resourceMgr.GetString("MSG0016"), index.ToString()), this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }

            // nova lista de pontos
            List<PointCorrelation> newPointsList = new List<PointCorrelation>();

            // lista na ordem correta
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto1.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto2.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto3.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto4.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto5.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto6.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto7.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto8.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto9.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto10.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto11.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto12.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto13.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto14.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto15.Text) - 1]);
            newPointsList.Add(this.pointsList[int.Parse(this.cmbNomePonto16.Text) - 1]);

            // limpa ordem
            this.pointsList.Clear();

            try
            {
                // cria lista de pontos transformados para o novo sistema
                this.transformPointsList = new List<PointF>();

                // transforma pontos e adiciona na ordem correta
                foreach (PointCorrelation p in newPointsList)
                {
                    // adiciona na ordem correta
                    this.pointsList.Add(p);

                    // transforma ponto
                    PointF newPoint = MathLib.TransformPointProjectiveTransf(new PointF(p.X, p.Y), ref this.coeffTransf);

                    // adiciona na lista de pontos do novo sistema (pontos transformados)
                    this.transformPointsList.Add(newPoint);
                }
            }
            catch
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0017"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // retorno
            this.DialogResult = DialogResult.OK;

            // fecha formulário
            Close();
        }
    }
}

