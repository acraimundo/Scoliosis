using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using Scoliosis.BusinessComponent;
using Scoliosis.BusinessEntity;

namespace Scoliosis
{
    public partial class FrmNovoIMC_6 : Scoliosis.FrmBaseDialog
    {
        private float scale = 0f;
        private float height = 0f;
        private Bitmap selectedBitmap = null;
        private UsuarioDs.UsuarioRow usuarioRow = null;
        private PacienteDs.PacienteRow pacienteRow = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovoIMC_6()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        /// <summary>
        /// Define imagem.
        /// </summary>
        public Bitmap SelectedBitmap
        {
            set
            {
                this.selectedBitmap = value;
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
        /// Define a massa.
        /// </summary>
        public float ScaleValue
        {
            set
            {
                this.scale = value;
            }
        }

        /// <summary>
        /// Define a altura.
        /// </summary>
        public float HeightValue
        {
            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// Calcula o IMC.
        /// </summary>
        private void FrmNovoIMC_6_Load(object sender, EventArgs e)
        {
            float imc = 0f;
            float height2 = this.height * this.height;

            // calcula IMC
            if (height2 < 0.01)
                imc = 0f;
            else
                imc = this.scale / height2;

            // mostra valor do IMC
            this.lblIMCCalculado.Text = imc.ToString("0.0") + " kg/m²";

            // cria componente bc
            CalculoIMCBc calculoIMC = new CalculoIMCBc();

            // classifica paciente
            int tipoIMC = calculoIMC.ClassificarIMC(imc);

            string tipo = this.resourceMgr.GetString("MSGTIPOIMC" + tipoIMC.ToString("00"));

            this.lblClassificacaoDiagnosticada.Text = tipo;
        }

        /// <summary>
        /// Grava cálculo no banco de dados.
        /// </summary>
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // cria componente de negócio
                CalculoIMCBc calculoIMCBc = new CalculoIMCBc();

                // imagem
                byte[] imageData;
                TransformBitmapToJPEGStream(out imageData);

                // cria cálculo do IMC
                calculoIMCBc.CriarCalculoIMC(pacienteRow.CodigoPaciente, usuarioRow.CodigoUsuario, 
                    ref imageData, height, scale, this.txtObservacoes.Text);

                // mensagem de sucesso
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0027"), this.Text, 
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
        /// Transforma o bitmao em um array de bytes.
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
    }
}

