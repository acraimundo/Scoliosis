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
    /// Classe de acesso a dados para o usuário.
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
        /// Cria um usuário.
        /// </summary>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="login">Login do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <param name="tipo">Tipo do usuário (0 - Administrador 1 - Fisioterapeuta).</param>
        /// <returns>O código do usuário.</returns>
        public int CriarUsuario(string nome, string login, string senha, byte tipo)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("CriarUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            int codigoUsuario = 0;

            // parâmetros
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Value = nome;
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Value = login;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Value = Criptografia.EncriptarMD5(senha);
            cmd.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = tipo;
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                // abre conexão
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();

                // código do usuário
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
        /// Busca por um usuário.
        /// </summary>
        /// <param name="codigoUsuario">Código do usuário.</param>
        /// <returns>Um DataSet tipado contendo os dados do usuário.</returns>
        public UsuarioDs.UsuarioRow BuscarUsuario(int codigoUsuario)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("BuscarUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // cria usuário
            UsuarioDs usuarioDs = new UsuarioDs();
            UsuarioDs.UsuarioRow usuarioRow = usuarioDs.Usuario.NewUsuarioRow();

            // parâmetros
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Tipo", SqlDbType.SmallInt).Direction = ParameterDirection.Output;

            try
            {
                // abre conexão
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();

                // dados do usuário
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
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("AlterarUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // parâmetros
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Value = nome;
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Value = login;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Value = Criptografia.EncriptarMD5(senha);
            cmd.Parameters.Add("@Tipo", SqlDbType.SmallInt).Value = tipo;

            try
            {
                // abre conexão
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
        /// Exclui um usuário.
        /// </summary>
        /// <param name="codigoUsuario">Código do usuário.</param>
        public void ExcluirUsuario(int codigoUsuario)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("ExcluirUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // parâmetros
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;

            try
            {
                // abre conexão
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
        /// Lista todos os usuários.
        /// </summary>
        /// <returns>Um DataSet tipado contendo os dados dos usuários.</returns>
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
        /// Verifica se é possível realizar login no sistema.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <param name="codigoUsuario">Código do usuário (saída).</param>
        /// <returns>True, se é possível e false, caso contrário.</returns>
        public bool Login(string login, string senha, out int codigoUsuario)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            bool ret = false;

            // inicializa código do usuário
            codigoUsuario = 0;

            // parâmetros
            cmd.Parameters.Add("@Login", SqlDbType.NVarChar, 20).Value = login;
            cmd.Parameters.Add("@Senha", SqlDbType.NVarChar, 80).Value = Criptografia.EncriptarMD5(senha);
            cmd.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RetValue", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

            try
            {
                // abre conexão
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
