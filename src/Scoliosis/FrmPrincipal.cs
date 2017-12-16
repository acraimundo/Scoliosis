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
using Scoliosis.BusinessComponent;
using Scoliosis.BusinessEntity;
using Scoliosis.Utils.Image;
using Scoliosis.Utils.MathUtil;

namespace Scoliosis
{
    public partial class FrmPrincipal : Form
    {
        private UsuarioDs.UsuarioRow usuarioRow = null;
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmPrincipal()
        {
            string language = ConfigurationManager.AppSettings["Language"];

            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();
        }

        /// <summary>
        /// Sair.
        /// </summary>
        private void tsSair_Click(object sender, EventArgs e)
        {
            // mensagem de confirma��o
            if (MessageBox.Show(this, this.resourceMgr.GetString("MSG0001"), this.Text, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        /// <summary>
        /// Abertura do formul�rio.
        /// </summary>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog(this);

            // usu�rio logado
            this.usuarioRow = frmLogin.Usuario;

            if (this.usuarioRow != null)
            {
                // mostra nome do usu�rio
                this.stbPrincipal_tsUsuario.Text = this.usuarioRow.Nome;
            }

            // libera mem�ria
            frmLogin.Dispose();
        }

        /// <summary>
        /// Menu Cadastro > Pacientes.
        /// </summary>
        private void tsCadastro_miPacientes_Click(object sender, EventArgs e)
        {
            FrmPacientes frmPacientes = new FrmPacientes();
            frmPacientes.ShowDialog(this);
            frmPacientes.Dispose();
        }

        /// <summary>
        /// Menu Cadastro > Usu�rios.
        /// </summary>
        private void tsCadastro_miUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.ShowDialog(this);
            frmUsuarios.Dispose();
        }

        /// <summary>
        /// Menu Seguran�a > Novo Login.
        /// </summary>
        private void tsSeguranca_miNovoLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog(this);

            // usu�rio logado
            this.usuarioRow = frmLogin.Usuario;

            if (this.usuarioRow != null)
            {
                // mostra nome do usu�rio
                this.stbPrincipal_tsUsuario.Text = this.usuarioRow.Nome;
            }

            // libera mem�ria
            frmLogin.Dispose();
        }

        /// <summary>
        /// Menu Ajuda > Sobre.
        /// </summary>
        private void tsAjuda_miSobre_Click(object sender, EventArgs e)
        {
            FrmSobre frmSobre = new FrmSobre();
            frmSobre.ShowDialog(this);
            frmSobre.Dispose();
        }

        /// <summary>
        /// Menu Seguran�a > Alterar Senha.
        /// </summary>
        private void tsSeguranca_miAlterarSenha_Click(object sender, EventArgs e)
        {
            FrmAlterarSenha frmAlterarSenha = new FrmAlterarSenha();
            frmAlterarSenha.Usuario = this.usuarioRow;
            frmAlterarSenha.ShowDialog(this);
            frmAlterarSenha.Dispose();
        }

        /// <summary>
        /// Menu Avalia��o > IMC > Novo.
        /// </summary>
        private void lsAvaliacao_miIMC_miNovo_Click(object sender, EventArgs e)
        {
            // paciente
            PacienteDs.PacienteRow pacienteRow = null;

            // imagem do paciente
            Bitmap patientImage = null;

            // coeficientes de transforma��o
            double[] transfCoeff = null;

            // altura calculada
            float calculatedHeight = 0f;

            // massa
            float scaleValue = 0f;

            // passo 1 - escolha do paciente
            FrmNovoIMC_1 frmNovoIMC_1 = new FrmNovoIMC_1();
            if (frmNovoIMC_1.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovoIMC_1.Dispose();
                return;
            }

            // paciente
            pacienteRow = frmNovoIMC_1.Paciente;

            // libera mem�ria
            frmNovoIMC_1.Dispose();

            // passo 2 - aquisi��o da imagem
            FrmNovoIMC_2 frmNovoIMC_2 = new FrmNovoIMC_2();
            if (frmNovoIMC_2.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovoIMC_2.Dispose();
                return;
            }

            // imagem
            patientImage = frmNovoIMC_2.SelectedBitmap;

            // libera mem�ria
            frmNovoIMC_2.Dispose();

            // passo 3 - pontos de refer�ncia
            FrmNovoIMC_3 frmNovoIMC_3 = new FrmNovoIMC_3();
            frmNovoIMC_3.SelectedBitmap = patientImage;
            if (frmNovoIMC_3.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovoIMC_3.Dispose();
                return;
            }

            // coeficientes de transforma��o
            transfCoeff = frmNovoIMC_3.TransfCoefficients;

            // libera mem�ria
            frmNovoIMC_3.Dispose();

            // passo 4
            FrmNovoIMC_4 frmNovoIMC_4 = new FrmNovoIMC_4();
            frmNovoIMC_4.SelectedBitmap = patientImage;
            frmNovoIMC_4.TransfCoefficients = transfCoeff;
            if (frmNovoIMC_4.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovoIMC_4.Dispose();
                return;
            }

            // altura
            calculatedHeight = frmNovoIMC_4.CalculatedHeight;

            // libera mem�ria
            frmNovoIMC_4.Dispose();

            // passo 5
            FrmNovoIMC_5 frmNovoIMC_5 = new FrmNovoIMC_5();
            if (frmNovoIMC_5.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovoIMC_5.Dispose();
                return;
            }

            // massa
            scaleValue = frmNovoIMC_5.ScaleValue;

            // libera mem�ria
            frmNovoIMC_5.Dispose();

            // passo 6
            FrmNovoIMC_6 frmNovoIMC_6 = new FrmNovoIMC_6();
            frmNovoIMC_6.Paciente = pacienteRow;
            frmNovoIMC_6.Usuario = this.usuarioRow;
            frmNovoIMC_6.SelectedBitmap = patientImage;
            frmNovoIMC_6.ScaleValue = scaleValue;
            frmNovoIMC_6.HeightValue = calculatedHeight;
            if (frmNovoIMC_6.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovoIMC_6.Dispose();
                return;
            }

            // libera mem�ria
            frmNovoIMC_6.Dispose();
        }

        /// <summary>
        /// Menu Avalia��o > IMC > Visualizar.
        /// </summary>
        private void lsAvaliacao_miIMC_miVisualizar_Click(object sender, EventArgs e)
        {
            FrmVisualizarIMC frmVisualizar = new FrmVisualizarIMC();
            frmVisualizar.Usuario = this.usuarioRow;
            frmVisualizar.ShowDialog(this);
            frmVisualizar.Dispose();
        }

        /// <summary>
        /// Menu Ferramentas > Op��es.
        /// </summary>
        private void tsFerramentas_miOpcoes_Click(object sender, EventArgs e)
        {
            FrmOpcoes frmOpcoes = new FrmOpcoes();
            frmOpcoes.ShowDialog(this);
            frmOpcoes.Dispose();
        }

        /// <summary>
        /// Menu Avalia��o > Postural > Nova.
        /// </summary>
        private void lsAvaliacao_miPostural_miNova_Click(object sender, EventArgs e)
        {
            // paciente
            PacienteDs.PacienteRow pacienteRow = null;

            // imagem do paciente
            Bitmap patientImage = null;

            // coeficientes de transforma��o
            double[] transfCoeff = null;

            // lista de pontos no paciente
            List<PointCorrelation> pointsList = null;

            // lista de pontos no paciente transformados para o novo sistema
            List<PointF> transformPointsList = null;

            // passo 1 - escolha do paciente
            FrmNovaAvaliacaoPostural_1 frmNovaAvaliacaoPostural_1 = new FrmNovaAvaliacaoPostural_1();
            if (frmNovaAvaliacaoPostural_1.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovaAvaliacaoPostural_1.Dispose();
                return;
            }

            // paciente
            pacienteRow = frmNovaAvaliacaoPostural_1.Paciente;

            // libera mem�ria
            frmNovaAvaliacaoPostural_1.Dispose();

            // passo 2 - aquisi��o da imagem
            FrmNovaAvaliacaoPostural_2 frmNovaAvaliacaoPostural_2 = new FrmNovaAvaliacaoPostural_2();
            if (frmNovaAvaliacaoPostural_2.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovaAvaliacaoPostural_2.Dispose();
                return;
            }

            // imagem
            patientImage = frmNovaAvaliacaoPostural_2.SelectedBitmap;

            // libera mem�ria
            frmNovaAvaliacaoPostural_2.Dispose();

            // passo 3 - pontos de refer�ncia
            FrmNovaAvaliacaoPostural_3 frmNovaAvaliacaoPostural_3 = new FrmNovaAvaliacaoPostural_3();
            frmNovaAvaliacaoPostural_3.SelectedBitmap = patientImage;
            if (frmNovaAvaliacaoPostural_3.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovaAvaliacaoPostural_3.Dispose();
                return;
            }

            // coeficientes de transforma��o
            transfCoeff = frmNovaAvaliacaoPostural_3.TransfCoefficients;

            // libera mem�ria
            frmNovaAvaliacaoPostural_3.Dispose();

            // passo 4 - pontos de refer�ncia no paciente
            FrmNovaAvaliacaoPostural_4 frmNovaAvaliacaoPostural_4 = new FrmNovaAvaliacaoPostural_4();
            frmNovaAvaliacaoPostural_4.SelectedBitmap = patientImage;
            if (frmNovaAvaliacaoPostural_4.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovaAvaliacaoPostural_4.Dispose();
                return;
            }

            // pontos no paciente
            pointsList = frmNovaAvaliacaoPostural_4.PointsList;

            // passo 5 - ordem dos pontos
            FrmNovaAvaliacaoPostural_5 frmNovaAvaliacaoPostural_5 = new FrmNovaAvaliacaoPostural_5();
            frmNovaAvaliacaoPostural_5.PointsList = pointsList;
            frmNovaAvaliacaoPostural_5.TransfCoefficients = transfCoeff;
            frmNovaAvaliacaoPostural_5.SelectedBitmap = patientImage;
            if (frmNovaAvaliacaoPostural_5.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovaAvaliacaoPostural_5.Dispose();
                return;
            }

            // pontos transformados
            transformPointsList = frmNovaAvaliacaoPostural_5.TransformPointsList;

            // libera mem�ria
            frmNovaAvaliacaoPostural_5.Dispose();

            // passo 6 - diagn�stico da escoliose
            FrmNovaAvaliacaoPostural_6 frmNovaAvaliacaoPostural_6 = new FrmNovaAvaliacaoPostural_6();
            frmNovaAvaliacaoPostural_6.TransformPointsList = transformPointsList;
            frmNovaAvaliacaoPostural_6.PointsList = pointsList;
            frmNovaAvaliacaoPostural_6.SelectedBitmap = patientImage;
            frmNovaAvaliacaoPostural_6.Usuario = this.usuarioRow;
            frmNovaAvaliacaoPostural_6.Paciente = pacienteRow;
            if (frmNovaAvaliacaoPostural_6.ShowDialog(this) == DialogResult.Cancel)
            {
                frmNovaAvaliacaoPostural_6.Dispose();
                return;
            }

            // libera mem�ria
            frmNovaAvaliacaoPostural_6.Dispose();
        }

        /// <summary>
        /// Menu Avalia��o > Postural > Visualizar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsAvaliacao_miPostural_miVisualizar_Click(object sender, EventArgs e)
        {
            FrmVisualizarAvaliacaoPostural frmVisualizar = new FrmVisualizarAvaliacaoPostural();
            frmVisualizar.Usuario = this.usuarioRow;
            frmVisualizar.ShowDialog(this);
            frmVisualizar.Dispose();
        }
    }
}