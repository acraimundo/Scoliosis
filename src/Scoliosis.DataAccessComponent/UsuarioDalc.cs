using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using Scoliosis.BusinessEntity;

namespace Scoliosis.DataAccessComponent
{
    /// <summary>
    /// Classe de acesso a dados para o usu�rio.
    /// </summary>
    [ComVisible(false)]
    public class UsuarioDalc : BaseDalc
    {
        #region Construtor

        /// <summary>
        /// Construtor.
        /// </summary>
        public UsuarioDalc()
            : base()
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
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("CriarUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            int codigoUsuario = 0;

            // par�metros
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Value = nome;
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Value = login;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Value = Criptografia.EncriptarMD5(senha);
            cmd.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = tipo;
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                // abre conex�o
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();

                // c�digo do usu�rio
                codigoUsuario = (int)cmd.Parameters["@CodigoUsuario"].Value;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return codigoUsuario;
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
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("BuscarUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // cria usu�rio
            UsuarioDs usuarioDs = new UsuarioDs();
            UsuarioDs.UsuarioRow usuarioRow = usuarioDs.Usuario.NewUsuarioRow();

            // par�metros
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Tipo", SqlDbType.SmallInt).Direction = ParameterDirection.Output;

            try
            {
                // abre conex�o
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();

                // dados do usu�rio
                usuarioRow.CodigoUsuario = codigoUsuario;
                usuarioRow.Nome = (string)cmd.Parameters["@Nome"].Value;
                usuarioRow.Login = (string)cmd.Parameters["@Login"].Value;
                usuarioRow.Senha = Criptografia.DesencriptarMD5((string)cmd.Parameters["@Senha"].Value);
                usuarioRow.Tipo = Convert.ToByte(cmd.Parameters["@Tipo"].Value);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return usuarioRow;
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
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("AlterarUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // par�metros
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Value = nome;
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Value = login;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Value = Criptografia.EncriptarMD5(senha);
            cmd.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = tipo;

            try
            {
                // abre conex�o
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui um usu�rio.
        /// </summary>
        /// <param name="codigoUsuario">C�digo do usu�rio.</param>
        public void ExcluirUsuario(int codigoUsuario)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("ExcluirUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // par�metros
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;

            try
            {
                // abre conex�o
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        #endregion

        #region Listar

        /// <summary>
        /// Lista todos os usu�rios.
        /// </summary>
        /// <returns>Um DataSet tipado contendo os dados dos usu�rios.</returns>
        public UsuarioDs ListarUsuarios()
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            UsuarioDs usuarioDs = new UsuarioDs();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("ListarUsuarios", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // preenche dataSet
                adapter.Fill(usuarioDs, usuarioDs.Usuario.TableName);

                // atualiza strings das senhas
                foreach (UsuarioDs.UsuarioRow usuarioRow in usuarioDs.Usuario)
                {
                    usuarioRow.Senha = Criptografia.DesencriptarMD5(usuarioRow.Senha);
                }

                // atualiza dataSet
                usuarioDs.AcceptChanges();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return usuarioDs;
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
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            bool ret = false;

            // inicializa c�digo do usu�rio
            codigoUsuario = 0;

            // par�metros
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Value = login;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Value = Criptografia.EncriptarMD5(senha);
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RetValue", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

            try
            {
                // abre conex�o
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();

                // verifica retorno
                ret = Convert.ToBoolean(cmd.Parameters["@RetValue"].Value);

                if (ret)
                    codigoUsuario = (int)cmd.Parameters["@CodigoUsuario"].Value;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return ret;
        }

        #endregion
    }
}
