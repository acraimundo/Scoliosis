using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;
using Scoliosis.BusinessEntity;
using Scoliosis.BusinessComponent;
using Scoliosis.Utils.Image;

namespace Scoliosis
{
    public partial class FrmVisualizarAvaliacaoPostural : Scoliosis.FrmBaseDialog
    {
        private PacienteDs.PacienteRow pacienteRow = null;
        private bool travarBusca = false;
        private ResourceManager resourceMgr = null;
        private double angDiff = 10.0;
        private UsuarioDs.UsuarioRow usuarioRow = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmVisualizarAvaliacaoPostural()
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
        /// Define usuário que está visualizando a avaliação postural.
        /// </summary>
        public UsuarioDs.UsuarioRow Usuario
        {
            set
            {
                this.usuarioRow = value;
            }
        }

        /// <summary>
        /// Lista as avaliações posturais do paciente.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        private void ListarAvaliacoes(int codigoPaciente)
        {
            // modifica cursor
            Cursor.Current = Cursors.WaitCursor;

            // trava busca
            this.travarBusca = true;

            // desabilita botão
            this.btnExcluir.Enabled = false;

            try
            {
                // componente de negócio
                PacienteBc pacienteBc = new PacienteBc();

                // busca pelo paciente
                this.pacienteRow = pacienteBc.BuscarPaciente(codigoPaciente);

                // nome do paciente
                this.txtPaciente.Text = this.pacienteRow.Nome;

                // lista avaliações posturais
                AvaliacaoPosturalDs avaliacaoPosturalDs = pacienteBc.ListarAvaliacoesPosturais(this.pacienteRow.CodigoPaciente);

                // data binding
                this.lstAvaliacoes.DataSource = avaliacaoPosturalDs.AvaliacaoPostural;
                this.lstAvaliacoes.DisplayMember = "Data";
                this.lstAvaliacoes.ValueMember = "CodigoAvaliacaoPostural";
            }
            catch (Exception ex)
            {
                string strMessage = this.resourceMgr.GetString(ex.Message);

                if (strMessage == null)
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = ex.Message;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
                else
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = strMessage;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                // destrava busca
                this.travarBusca = false;
            }

            // seleciona avaliação
            if (this.lstAvaliacoes.SelectedItems.Count > 0)
                this.lstAvaliacoes_SelectedIndexChanged(this.lstAvaliacoes, new EventArgs());
        }

        /// <summary>
        /// Busca pelo paciente.
        /// </summary>
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            // escolha do paciente
            FrmBuscarPaciente frmBuscarPaciente = new FrmBuscarPaciente();
            if (frmBuscarPaciente.ShowDialog(this) == DialogResult.Cancel)
            {
                frmBuscarPaciente.Dispose();
                return;
            }

            // lista avaliações
            ListarAvaliacoes(frmBuscarPaciente.CodigoPaciente);

            // libera memória
            frmBuscarPaciente.Dispose();
        }

        /// <summary>
        /// Mostra os dados da avaliação postural
        /// </summary>
        private void lstAvaliacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verifica trava da busca
            if (this.travarBusca)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.btnExcluir.Enabled = false;

            try
            {
                // componentes de negócio
                AvaliacaoPosturalBc avaliacaoPosturalBc = new AvaliacaoPosturalBc();
                UsuarioBc usuarioBc = new UsuarioBc();
                PacienteBc pacienteBc = new PacienteBc();

                // busca avaliação postural
                AvaliacaoPosturalDs.AvaliacaoPosturalRow avaliacaoPosturalRow = avaliacaoPosturalBc.BuscarAvaliacaoPostural((int)this.lstAvaliacoes.SelectedValue);

                // busca fisioterapeuta
                UsuarioDs.UsuarioRow usuario = usuarioBc.BuscarUsuario(avaliacaoPosturalRow.CodigoUsuario);

                // mostra dados
                double[] angulos = new double[10];
                angulos[0] = avaliacaoPosturalRow.Angulo1;
                angulos[1] = avaliacaoPosturalRow.Angulo2;
                angulos[2] = avaliacaoPosturalRow.Angulo3;
                angulos[3] = avaliacaoPosturalRow.Angulo4;
                angulos[4] = avaliacaoPosturalRow.Angulo5;
                angulos[5] = avaliacaoPosturalRow.Angulo6;
                angulos[6] = avaliacaoPosturalRow.Angulo7;
                angulos[7] = avaliacaoPosturalRow.Angulo8;
                angulos[8] = avaliacaoPosturalRow.Angulo9;
                angulos[9] = avaliacaoPosturalRow.Angulo10;

                // tipo de escoliose
                int tipoEscoliose = avaliacaoPosturalBc.DiagnosticarEscoliose(ref angulos, this.angDiff);

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

                // fisioterapeuta
                this.lblFisioterapeutaCadastrado.Text = usuario.Nome;

                // observações
                this.txtObservacoes.Text = avaliacaoPosturalRow.Observacoes;

                // imagem
                byte[] imagem;
                pacienteBc.BuscarImagem(avaliacaoPosturalRow.CodigoImagem, out imagem);

                // cria bitmap
                System.IO.MemoryStream memStream = new System.IO.MemoryStream(imagem);
                Bitmap bitmap = new Bitmap(memStream);

                // pontos de referência
                PontoDs pontoDs = avaliacaoPosturalBc.ListarPontosReferencia(avaliacaoPosturalRow.CodigoImagem);

                // verifica quantidade de pontos
                if (pontoDs.Ponto.Count == 16)
                {
                    // desenha os pontos
                    DesenharPontosZoom(pontoDs, bitmap);
                }
                else
                {
                    this.pctImagem.Image = bitmap;
                }

                // verifica se é o fisioterapeuta que criou a avaliação
                this.btnExcluir.Enabled = (usuario.CodigoUsuario == this.usuarioRow.CodigoUsuario);
            }
            catch (Exception ex)
            {
                string strMessage = this.resourceMgr.GetString(ex.Message);

                if (strMessage == null)
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = ex.Message;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
                else
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = strMessage;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Desenha os pontos na imagem e realiza um zoom na área dos pontos.
        /// </summary>
        /// <param name="pontoDs">Pontos de referência.</param>
        /// <param name="bitmap">Imagem do paciente.</param>
        private void DesenharPontosZoom(PontoDs pontoDs, Bitmap bitmap)
        {
            // busca pelo range dos pontos
            float xmin = pontoDs.Ponto[0].XImagem;
            float ymin = pontoDs.Ponto[0].YImagem;
            float xmax = pontoDs.Ponto[0].XImagem;
            float ymax = pontoDs.Ponto[0].YImagem;

            foreach (PontoDs.PontoRow pontoRow in pontoDs.Ponto)
            {
                if (pontoRow.XImagem < xmin) xmin = pontoRow.XImagem;
                if (pontoRow.YImagem < ymin) ymin = pontoRow.YImagem;
                if (pontoRow.XImagem > xmax) xmax = pontoRow.XImagem;
                if (pontoRow.YImagem > ymax) ymax = pontoRow.YImagem;
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
            if (xmax >= bitmap.Width) xmax = bitmap.Width - 1;
            if (ymax >= bitmap.Height) ymax = bitmap.Height - 1;

            // tamanho do bitmap
            Rectangle rect = new Rectangle((int)xmin, (int)ymin, (int)(xmax - xmin), (int)(ymax - ymin));

            // cria um novo bitmap
            Bitmap croppedBitmap = new Bitmap(rect.Width, rect.Height);

            // crop
            Graphics g = Graphics.FromImage(croppedBitmap);
            g.DrawImage(bitmap, new Rectangle(0, 0, croppedBitmap.Width, croppedBitmap.Height),
                    xmin, ymin, croppedBitmap.Width, croppedBitmap.Height, GraphicsUnit.Pixel);
            g.Dispose();

            // desenha linhas no bitmap
            DesenharLinhas(croppedBitmap, pontoDs, xmin, ymin, xmax, ymax);

            // mostra no pictureBox
            this.pctImagem.Image = croppedBitmap;
        }

        /// <summary>
        /// Desenha as linhas que formam os ângulos.
        /// </summary>
        /// <param name="bitmap">Bitmap onde serão desenhados os pontos.</param>
        private void DesenharLinhas(Bitmap bitmap, PontoDs pontoDs, float xmin, float ymin, float xmax, float ymax)
        {
            // pontos transformados para o sistema do range
            List<PointCorrelation> transfPoints = new List<PointCorrelation>();

            foreach (PontoDs.PontoRow pontoRow in pontoDs.Ponto)
            {
                PointCorrelation point = new PointCorrelation();
                point.X = pontoRow.XImagem - (int)xmin;
                point.Y = pontoRow.YImagem - (int)ymin;
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
        /// Exclui a avaliação postural selecionada.
        /// </summary>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.lstAvaliacoes.SelectedValue == null)
                return;

            // mensagem de confirmação
            if (MessageBox.Show(this, this.resourceMgr.GetString("MSG0035"), this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // componente de negócio
                AvaliacaoPosturalBc avaliacaoPosturalBc = new AvaliacaoPosturalBc();

                // exclui a avaliação
                avaliacaoPosturalBc.ExcluirAvaliacaoPostural((int)this.lstAvaliacoes.SelectedValue);

                // lista avaliações
                ListarAvaliacoes(this.pacienteRow.CodigoPaciente);
            }
            catch (Exception ex)
            {
                string strMessage = this.resourceMgr.GetString(ex.Message);

                if (strMessage == null)
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = ex.Message;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
                else
                {
                    FrmErro frmErro = new FrmErro();
                    frmErro.Mensagem = strMessage;
                    frmErro.ShowDialog(this);
                    frmErro.Dispose();
                }
            }

            Cursor.Current = Cursors.Default;
        }
    }
}

