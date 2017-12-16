using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Scoliosis.BusinessEntity;
using Scoliosis.DataAccessComponent;

namespace Scoliosis.BusinessComponent
{
    /// <summary>
    /// Classe de neg�cio para o usu�rio.
    /// </summary>
    [ComVisible(false)]
    public class UsuarioBc
    {
        #region Construtor

        /// <summary>
        /// Construtor.
        /// </summary>
        public UsuarioBc()
        {

        }

        #endregion

        #region Criar

        /// <summary>
        /// Cria um usu�rio.
        /// </summary>
        /// <param name="nome">Nome do usu�rio.</param>
        /// <param name="login">Login do usu�rio.</param>
        /// <param name="senha">Senha do usu�rio.</param>
        /// <param name="tipo">Tipo do usu�rio (0 - Administrador 1 - Fisioterapeuta).</param>
        /// <returns>O c�digo do usu�rio.</returns>
        public int CriarUsuario(string nome, string login, string senha, byte tipo)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // cria o usu�rio
            return usuarioDalc.CriarUsuario(nome, login, senha, tipo);
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca por um usu�rio.
        /// </summary>
        /// <param name="codigoUsuario">C�digo do usu�rio.</param>
        /// <returns>Um DataSet tipado contendo os dados do usu�rio.</returns>
        public UsuarioDs.UsuarioRow BuscarUsuario(int codigoUsuario)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // busca pelo usu�rio
            return usuarioDalc.BuscarUsuario(codigoUsuario);
        }

        #endregion

        #region Alterar

        /// <summary>
        /// Altera um usu�rio.
        /// </summary>
        /// <param name="codigoUsuario">C�digo do usu�rio.</param>
        /// <param name="nome">Nome do usu�rio.</param>
        /// <param name="login">Login do usu�rio.</param>
        /// <param name="senha">Senha do usu�rio.</param>
        /// <param name="tipo">Tipo do usu�rio (0 - Administrador 1 - Fisioterapeuta).</param>
        /// <returns>O c�digo do usu�rio.</returns>
        public void AlterarUsuario(int codigoUsuario, string nome, string login, string senha, byte tipo)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // altera o usu�rio
            usuarioDalc.AlterarUsuario(codigoUsuario, nome, login, senha, tipo);
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui um usu�rio.
        /// </summary>
        /// <param name="codigoUsuario">C�digo do usu�rio.</param>
        public void ExcluirUsuario(int codigoUsuario)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // exclui o usu�rio
            usuarioDalc.ExcluirUsuario(codigoUsuario);
        }

        #endregion

        #region Listar

        /// <summary>
        /// Lista todos os usu�rios.
        /// </summary>
        /// <returns>Um DataSet tipado contendo os dados dos usu�rios.</returns>
        public UsuarioDs ListarUsuarios()
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // lista usu�rios
            return usuarioDalc.ListarUsuarios();
        }

        #endregion

        #region Diversos

        /// <summary>
        /// Verifica se � poss�vel realizar login no sistema.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="senha">Senha do usu�rio.</param>
        /// <param name="codigoUsuario">C�digo do usu�rio (sa�da).</param>
        /// <returns>True, se � poss�vel e false, caso contr�rio.</returns>
        public bool Login(string login, string senha, out int codigoUsuario)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // login
            return usuarioDalc.Login(login, senha, out codigoUsuario);
        }

        #endregion
    }
}
