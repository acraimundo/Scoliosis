using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Resources;
using System.Reflection;
using Scoliosis.Utils.Image;
using Scoliosis.Utils.MathUtil;
using Scoliosis.BusinessComponent;
using Scoliosis.BusinessEntity;

namespace Scoliosis
{
    public partial class FrmNovaAvaliacaoPostural_6 : Scoliosis.FrmBaseDialog
    {
        private List<PointF> transformPointsList = null;
        private List<PointCorrelation> pointsList = null;
        private double[] angles = null;
        private Bitmap selectedBitmap = null;
        private double angDiff = 10.0;
        private UsuarioDs.UsuarioRow usuarioRow = null;
        private PacienteDs.PacienteRow pacienteRow = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovaAvaliacaoPostural_6()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();

            int diagnosisLevel = int.Parse(ConfigurationManager.AppSettings["DiagnosisLevel"]);

            if (diagnosisLevel == 0)
                this.angDiff = 3.0;
            else if (diagnosisLevel == 1)
                this.angDiff = 5.0;
            else if (diagnosisLevel == 2)
                this.angDiff = 7.5;
            else
                this.angDiff = 10.0;
        }

        /// <summary>
        /// Define a lista dos pontos transformados.
        /// </summary>
        public List<PointF> TransformPointsList
        {
            set
            {
                this.transformPointsList = value;

                // calcula ângulos
                this.angles = new double[10];
                this.angles[0] = MathLib.GetRotationAngle(this.transformPointsList[1], this.transformPointsList[2]) * 180.0 / Math.PI;
                this.angles[1] = MathLib.GetRotationAngle(this.transformPointsList[14], this.transformPointsList[15]) * 180.0 / Math.PI;
                this.angles[2] = MathLib.GetRotationAngle(this.transformPointsList[13], this.transformPointsList[12]) * 180.0 / Math.PI;
                this.angles[3] = MathLib.GetRotationAngle(this.transformPointsList[12], this.transformPointsList[11]) * 180.0 / Math.PI;
                this.angles[4] = MathLib.GetRotationAngle(this.transformPointsList[10], this.transformPointsList[9]) * 180.0 / Math.PI;
                this.angles[5] = MathLib.GetRotationAngle(this.transformPointsList[9], this.transformPointsList[8]) * 180.0 / Math.PI;
                this.angles[6] = MathLib.GetRotationAngle(this.transformPointsList[7], this.transformPointsList[6]) * 180.0 / Math.PI;
                this.angles[7] = MathLib.GetRotationAngle(this.transformPointsList[6], this.transformPointsList[5]) * 180.0 / Math.PI;
                this.angles[8] = MathLib.GetRotationAngle(this.transformPointsList[4], this.transformPointsList[3]) * 180.0 / Math.PI;
                this.angles[9] = MathLib.GetRotationAngle(this.transformPointsList[3], this.transformPointsList[0]) * 180.0 / Math.PI;

                // arredonda
                for (int i = 0; i < this.angles.Length; ++i)
                    this.angles[i] = Math.Round(this.angles[i], 0);

                // diagnóstico da escoliose
                AvaliacaoPosturalBc avaliacaoPosturalBc = new AvaliacaoPosturalBc();
                int tipoEscoliose = avaliacaoPosturalBc.DiagnosticarEscoliose(ref this.angles, this.angDiff);
                string strMsg = "MSGTIPOESC" + tipoEscoliose.ToString("00");

                if (tipoEscoliose == 0)
                {
                    this.lblTipoEscolioseDiagnosticada.Text = this.resourceMgr.GetString(strMsg);
                    this.lblTipoEscolioseDiagnosticada.ForeColor = Color.Red;
                }
                else
                {
                    this.lblTipoEscolioseDiagnosticada.Text = this.resourceMgr.GetString(strMsg);
                    this.lblTipoEscolioseDiagnosticada.ForeColor = Color.Black;
                }
            }
        }

        /// <summary>
        /// Configura a lista dos pontos.
        /// </summary>
        public List<PointCorrelation> PointsList
        {
            set
            {
                this.pointsList = value;
            }
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

                // desenha linhas no bitmap
                DesenharLinhas(croppedBitmap, xmin, ymin, xmax, ymax);

                // mostra no pictureBox
                this.pctImagem.Image = croppedBitmap;
            }
        }

        /// <summary>
        /// Define usuário que está realizando o cálculo do IMC.
        /// </summary>
        public UsuarioDs.UsuarioRow Usuario
        {
            set
            {
                this.usuarioRow = value;
            }
        }

        /// <summary>
        /// Define paciente.
        /// </summary>
        public PacienteDs.PacienteRow Paciente
        {
            set
            {
                this.pacienteRow = value;
            }
        }

        /// <summary>
        /// Desenha as linhas que formam os ângulos.
        /// </summary>
        /// <param name="bitmap">Bitmap onde serão desenhados os pontos.</param>
        private void DesenharLinhas(Bitmap bitmap, float xmin, float ymin, float xmax, float ymax)
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
            float lineWidth = (2f * bitmap.Width) / (float)this.pctImagem.Width;
            float lineHeight = (10f * bitmap.Height) / (float)this.pctImagem.Height;
            float textSize = (10f * bitmap.Height) / (float)this.pctImagem.Height;

            // desenha pontos que foram identificados
            Graphics g = Graphics.FromImage(bitmap);

            // linhas
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[1].X, transfPoints[1].Y), new Point(transfPoints[2].X, transfPoints[2].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[14].X, transfPoints[14].Y), new Point(transfPoints[15].X, transfPoints[15].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[13].X, transfPoints[13].Y), new Point(transfPoints[12].X, transfPoints[12].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[12].X, transfPoints[12].Y), new Point(transfPoints[11].X, transfPoints[11].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[10].X, transfPoints[10].Y), new Point(transfPoints[9].X, transfPoints[9].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[9].X, transfPoints[9].Y), new Point(transfPoints[8].X, transfPoints[8].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[7].X, transfPoints[7].Y), new Point(transfPoints[6].X, transfPoints[6].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[6].X, transfPoints[6].Y), new Point(transfPoints[5].X, transfPoints[5].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[4].X, transfPoints[4].Y), new Point(transfPoints[3].X, transfPoints[3].Y));
            g.DrawLine(new Pen(Brushes.Red, lineWidth), new Point(transfPoints[3].X, transfPoints[3].Y), new Point(transfPoints[0].X, transfPoints[0].Y));

            // textos
            int count = 1;
            foreach (PointCorrelation p in transfPoints)
            {
                g.DrawString(count.ToString(), new Font("Sans Serif", textSize, FontStyle.Bold, GraphicsUnit.Pixel),
                    Brushes.Black, new PointF(p.X, p.Y - lineHeight - lineWidth * 1.05f));

                count++;
            }

            // libera memória
            g.Dispose();
        }

        /// <summary>
        /// Grava avaliação no banco de dados.
        /// </summary>
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // cria componente de negócio
                AvaliacaoPosturalBc avaliacaoPosturalBc = new AvaliacaoPosturalBc();

                // imagem
                byte[] imageData;
                TransformBitmapToJPEGStream(out imageData);

                // cria avaliação postural
                avaliacaoPosturalBc.CriarAvaliacaoPostural(this.pacienteRow.CodigoPaciente, this.usuarioRow.CodigoUsuario,
                        ref imageData, ref this.angles, this.pointsList, this.transformPointsList, this.txtObservacoes.Text);

                // mensagem de sucesso
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0019"), this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // sai do formulário
                Close();
            }
            catch (Exception ex)
            {
                string strMessage = this.resourceMgr.GetString(ex.Message);

                if (strMessage == null)
                {
                    MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, strMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }            
        }

        /// <summary>
        /// Transforma o bitmap em um array de bytes.
        /// </summary>
        /// <param name="imageData">Array de bytes onde os dados serão armazenados.</param>
        private void TransformBitmapToJPEGStream(out byte[] imageData)
        {
            MemoryStream memStream = new MemoryStream();
            System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
            encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

            // transforma o bitmap para uma stream em memória
            this.selectedBitmap.Save(memStream, GetEncoderInfo("image/jpeg"), encoderParams);
            memStream.Seek(0, SeekOrigin.Begin);

            // salva a stream no array
            imageData = new byte[memStream.Length];
            memStream.Read(imageData, 0, (int)memStream.Length);
        }

        /// <summary>
        /// Informações sobre o codificador de formato.
        /// </summary>
        private System.Drawing.Imaging.ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            System.Drawing.Imaging.ImageCodecInfo[] encoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        /// <summary>
        /// Cancela a avaliação.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, this.resourceMgr.GetString("MSG0020"), this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Close();
        }
    }
}

