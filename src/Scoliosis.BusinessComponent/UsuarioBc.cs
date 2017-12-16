using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Scoliosis.BusinessEntity;
using Scoliosis.DataAccessComponent;

namespace Scoliosis.BusinessComponent
{
    /// <summary>
    /// Classe de negócio para o usuário.
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
        /// Cria um usuário.
        /// </summary>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="login">Login do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <param name="tipo">Tipo do usuário (0 - Administrador 1 - Fisioterapeuta).</param>
        /// <returns>O código do usuário.</returns>
        public int CriarUsuario(string nome, string login, string senha, byte tipo)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // cria o usuário
            return usuarioDalc.CriarUsuario(nome, login, senha, tipo);
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca por um usuário.
        /// </summary>
        /// <param name="codigoUsuario">Código do usuário.</param>
        /// <returns>Um DataSet tipado contendo os dados do usuário.</returns>
        public UsuarioDs.UsuarioRow BuscarUsuario(int codigoUsuario)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // busca pelo usuário
            return usuarioDalc.BuscarUsuario(codigoUsuario);
        }

        #endregion

        #region Alterar

        /// <summary>
        /// Altera um usuário.
        /// </summary>
        /// <param name="codigoUsuario">Código do usuário.</param>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="login">Login do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <param name="tipo">Tipo do usuário (0 - Administrador 1 - Fisioterapeuta).</param>
        /// <returns>O código do usuário.</returns>
        public void AlterarUsuario(int codigoUsuario, string nome, string login, string senha, byte tipo)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // altera o usuário
            usuarioDalc.AlterarUsuario(codigoUsuario, nome, login, senha, tipo);
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui um usuário.
        /// </summary>
        /// <param name="codigoUsuario">Código do usuário.</param>
        public void ExcluirUsuario(int codigoUsuario)
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // exclui o usuário
            usuarioDalc.ExcluirUsuario(codigoUsuario);
        }

        #endregion

        #region Listar

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Um DataSet tipado contendo os dados dos usuários.</returns>
        public UsuarioDs ListarUsuarios()
        {
            // componente de acesso a dados
            UsuarioDalc usuarioDalc = new UsuarioDalc();

            // lista usuários
            return usuarioDalc.ListarUsuarios();
        }

        #endregion

        #region Diversos

        /// <summary>
        /// Verifica se é possível realizar login no sistema.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <param name="codigoUsuario">Código do usuário (saída).</param>
        /// <returns>True, se é possível e false, caso contrário.</returns>
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
