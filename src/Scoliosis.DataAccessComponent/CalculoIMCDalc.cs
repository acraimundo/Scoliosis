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
    /// Classe de acesso a dados para o cálculo do IMC.
    /// </summary>
    [ComVisible(false)]
    public class CalculoIMCDalc : BaseDalc
    {
        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>
        public CalculoIMCDalc()
            : base()
        {

        }

        #endregion

        #region Criar

        /// <summary>
        /// Cria um novo cálculo do IMC.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        /// <param name="codigoUsuario">Código do usuário.</param>
        /// <param name="imageData">Array de bytes contendo os dados da imagem.</param>
        /// <param name="altura">Altura do paciente.</param>
        /// <param name="massa">Massa do paciente.</param>
        /// <param name="observacoes">Observações.</param>
        /// <returns>O código do cálculo do IMC.</returns>
        public int CriarCalculoIMC(int codigoPaciente, int codigoUsuario, ref byte[] imageData, float altura,
                float massa, string observacoes)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlTransaction trans = null;
            int codigoCalculoIMC = 0;

            try
            {
                // abre conexão
                conn.Open();

                // transação
                trans = conn.BeginTransaction();

                // cria comando para criar a imagem
                SqlCommand comm1 = new SqlCommand("CriarImagem", conn, trans);
                comm1.CommandType = CommandType.StoredProcedure;

                // parâmetros
                comm1.Parameters.Add("@TamanhoArquivo", SqlDbType.Int).Value = imageData.Length;
                comm1.Parameters.Add("@Arquivo", SqlDbType.Image).Value = imageData;
                comm1.Parameters.Add("@CodigoImagem", SqlDbType.Int).Direction = ParameterDirection.Output;

                // executa comando
                comm1.ExecuteNonQuery();

                // código da imagem
                int codigoImagem = (int)comm1.Parameters["@CodigoImagem"].Value;

                // cria comando para criar cálculo do IMC
                SqlCommand comm2 = new SqlCommand("CriarCalculoIMC", conn, trans);
                comm2.CommandType = CommandType.StoredProcedure;

                // parâmetros
                comm2.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;
                comm2.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;
                comm2.Parameters.Add("@CodigoImagem", SqlDbType.Int).Value = codigoImagem;
                comm2.Parameters.Add("@Altura", SqlDbType.Float).Value = altura;
                comm2.Parameters.Add("@Massa", SqlDbType.Float).Value = massa;
                comm2.Parameters.Add("@Observacoes", SqlDbType.NVarChar, 1000).Value = observacoes;
                comm2.Parameters.Add("@CodigoCalculoIMC", SqlDbType.Int).Direction = ParameterDirection.Output;

                // executa comando
                comm2.ExecuteNonQuery();

                // cálculo do IMC
                codigoCalculoIMC = (int)comm2.Parameters["@CodigoCalculoIMC"].Value;

                // commit
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                    trans.Rollback();
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            // retorna código do IMC
            return codigoCalculoIMC;
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca por um cálculo do IMC.
        /// </summary>
        /// <param name="codigoCalculoIMC">Código do cálculo do IMC.</param>
        /// <returns>Um DataSet tipado contendo os dados do cálculo do IMC.</returns>
        public CalculoIMCDs.CalculoIMCRow BuscarCalculoIMC(int codigoCalculoIMC)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("BuscarCalculoIMC", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // parâmetro
                adapter.SelectCommand.Parameters.Add("@CodigoCalculoIMC", SqlDbType.Int).Value = codigoCalculoIMC;

                // cria dataSet
                CalculoIMCDs calculoIMCDs = new CalculoIMCDs();

                // preenche dataSet
                adapter.Fill(calculoIMCDs, calculoIMCDs.CalculoIMC.TableName);

                if (calculoIMCDs.CalculoIMC.Count == 0)
                    throw new Exception("MSG0032");

                // retorna IMC
                return calculoIMCDs.CalculoIMC[0];
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
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui o cálculo de IMC.
        /// </summary>
        /// <param name="codigoCalculoIMC">Código do cálculo.</param>
        public void ExcluirCalculoIMC(int codigoCalculoIMC)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("ExcluirCalculoIMC", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // parâmetros
            cmd.Parameters.Add("@CodigoCalculoIMC", SqlDbType.Int).Value = codigoCalculoIMC;

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
    }
}