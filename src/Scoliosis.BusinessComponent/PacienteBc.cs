using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Scoliosis.BusinessEntity;
using Scoliosis.DataAccessComponent;

namespace Scoliosis.BusinessComponent
{
    /// <summary>
    /// Classe de neg�cio para o paciente.
    /// </summary>
    [ComVisible(false)]
    public class PacienteBc
    {
        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>
        public PacienteBc()
        {

        }

        #endregion

        #region Criar

        /// <summary>
        /// Cria um paciente.
        /// </summary>
        /// <param name="pacienteRow">Um DataSet tipado contendo os dados do paciente.</param>
        /// <returns>O c�digo do paciente criado.</returns>
        /// <remarks>O c�digo do paciente no DataSet n�o ser� utilizado, este ser� atualizado 
        /// ap�s a cria��o do paciente.</remarks>
        public int CriarPaciente(PacienteDs.PacienteRow pacienteRow)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // cria o paciente
            return pacienteDalc.CriarPaciente(pacienteRow);
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca por um paciente.
        /// </summary>
        /// <param name="codigoPaciente">C�digo do paciente.</param>
        /// <returns>Um DataSet tipado contendo os dados do paciente.</returns>
        public PacienteDs.PacienteRow BuscarPaciente(int codigoPaciente)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // busca pelo paciente
            return pacienteDalc.BuscarPaciente(codigoPaciente);
        }

        /// <summary>
        /// Busca pela imagem.
        /// </summary>
        /// <param name="codigoImagem">C�digo da imagem.</param>
        /// <param name="imagem">Array de bytes representando a imagem.</param>
        public void BuscarImagem(int codigoImagem, out byte[] imagem)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // busca pela imagem
            pacienteDalc.BuscarImagem(codigoImagem, out imagem);
        }

        #endregion

        #region Criar

        /// <summary>
        /// Altera um paciente.
        /// </summary>
        /// <param name="pacienteRow">Um DataSet tipado contendo os dados do paciente.</param>
        /// <returns>O c�digo do paciente criado.</returns>
        public void AlterarPaciente(PacienteDs.PacienteRow pacienteRow)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // altera o paciente
            pacienteDalc.AlterarPaciente(pacienteRow);
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui um paciente.
        /// </summary>
        /// <param name="codigoPaciente">C�digo do paciente.</param>
        public void ExcluirPaciente(int codigoPaciente)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // exclui o paciente
            pacienteDalc.ExcluirPaciente(codigoPaciente);
        }

        #endregion

        #region Listar

        /// <summary>
        /// Lista os pacientes de acordo com um filtro para o nome.
        /// </summary>
        /// <param name="filtro">Filtro para o nome.</param>
        /// <returns>Um DataSet tipado contendo os dados dos pacientes encontrados.</returns>
        public PacienteDs ListarPacientes(string filtro)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // lista pacientes
            return pacienteDalc.ListarPacientes(filtro);
        }

        /// <summary>
        /// Lista os c�lculos de IMC realizados para o paciente.
        /// </summary>
        /// <param name="codigoPaciente">C�digo do paciente.</param>
        /// <returns>Um DataSet tipado contendo os dados dos c�lculos.</returns>
        public CalculoIMCDs ListarCalculosIMC(int codigoPaciente)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // lista c�lculos
            return pacienteDalc.ListarCalculosIMC(codigoPaciente);
        }

        /// <summary>
        /// Lista as avalia��es posturais do paciente.
        /// </summary>
        /// <param name="codigoPaciente">C�digo do paciente.</param>
        /// <returns>Um DataSet tipado contendo os dados das avalia��es.</returns>
        public AvaliacaoPosturalDs ListarAvaliacoesPosturais(int codigoPaciente)
        {
            // componente de acesso a dados
            PacienteDalc pacienteDalc = new PacienteDalc();

            // lista avalia��es
            return pacienteDalc.ListarAvaliacoesPosturais(codigoPaciente);
        }

        #endregion
    }
}
