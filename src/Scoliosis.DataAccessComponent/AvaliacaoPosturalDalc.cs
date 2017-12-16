using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using Scoliosis.BusinessEntity;
using Scoliosis.Utils.Image;

namespace Scoliosis.DataAccessComponent
{
    /// <summary>
    /// Classe de acesso a dados para o c�lculo do IMC.
    /// </summary>
    [ComVisible(false)]
    public class AvaliacaoPosturalDalc : BaseDalc
    {
        #region Construtor

        /// <summary>
        /// Construtor.
        /// </summary>
        public AvaliacaoPosturalDalc() : base()
        {

        }

        #endregion

        #region Criar

        /// <summary>
        /// Cria uma nova avalia��o postural.
        /// </summary>
        /// <param name="codigoPaciente">C�digo do paciente.</param>
        /// <param name="codigoUsuario">C�digo do usu�rio.</param>
        /// <param name="imageData">Array de bytes contendo os dados da imagem.</param>
        /// <param name="angulos">�ngulos calculados.</param>
        /// <param name="listaPontosImagem">Lista de pontos na imagem.</param>
        /// <param name="listaPontosTransformados">Lista de pontos transformados.</param>
        /// <param name="observacoes">Observa��es.</param>
        /// <returns>O c�digo do c�lculo do IMC.</returns>
        public int CriarAvaliacaoPostural(int codigoPaciente, int codigoUsuario, ref byte[] imageData, ref double[] angulos,
                List<PointCorrelation> listaPontosImagem, List<PointF> listaPontosTransformados, string observacoes)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlTransaction trans = null;
            int codigoAvaliacaoPostural = 0;

            try
            {
                // abre conex�o
                conn.Open();

                // transa��o
                trans = conn.BeginTransaction();

                // cria comando para criar a imagem
                SqlCommand comm1 = new SqlCommand("CriarImagem", conn, trans);
                comm1.CommandType = CommandType.StoredProcedure;

                // par�metros
                comm1.Parameters.Add("@TamanhoArquivo", SqlDbType.Int).Value = imageData.Length;
                comm1.Parameters.Add("@Arquivo", SqlDbType.Image).Value = imageData;
                comm1.Parameters.Add("@CodigoImagem", SqlDbType.Int).Direction = ParameterDirection.Output;

                // executa comando
                comm1.ExecuteNonQuery();

                // c�digo da imagem
                int codigoImagem = (int)comm1.Parameters["@CodigoImagem"].Value;

                // cria comando para criar a avalia��o postural
                SqlCommand comm2 = new SqlCommand("CriarAvaliacaoPostural", conn, trans);
                comm2.CommandType = CommandType.StoredProcedure;

                // par�metros
                comm2.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;
                comm2.Parameters.Add("@CodigoUsuario", SqlDbType.Int).Value = codigoUsuario;
                comm2.Parameters.Add("@CodigoImagem", SqlDbType.Int).Value = codigoImagem;
                comm2.Parameters.Add("@Angulo1", SqlDbType.Float).Value = angulos[0];
                comm2.Parameters.Add("@Angulo2", SqlDbType.Float).Value = angulos[1];
                comm2.Parameters.Add("@Angulo3", SqlDbType.Float).Value = angulos[2];
                comm2.Parameters.Add("@Angulo4", SqlDbType.Float).Value = angulos[3];
                comm2.Parameters.Add("@Angulo5", SqlDbType.Float).Value = angulos[4];
                comm2.Parameters.Add("@Angulo6", SqlDbType.Float).Value = angulos[5];
                comm2.Parameters.Add("@Angulo7", SqlDbType.Float).Value = angulos[6];
                comm2.Parameters.Add("@Angulo8", SqlDbType.Float).Value = angulos[7];
                comm2.Parameters.Add("@Angulo9", SqlDbType.Float).Value = angulos[8];
                comm2.Parameters.Add("@Angulo10", SqlDbType.Float).Value = angulos[9];
                comm2.Parameters.Add("@Observacoes", SqlDbType.NVarChar, 1000).Value = observacoes;
                comm2.Parameters.Add("@CodigoAvaliacaoPostural", SqlDbType.Int).Direction = ParameterDirection.Output;

                // executa comando
                comm2.ExecuteNonQuery();

                // c�digo da avalia��o postural
                codigoAvaliacaoPostural = (int)comm2.Parameters["@CodigoAvaliacaoPostural"].Value;

                // pontos na imagem e transformados
                for (int i = 0; i < listaPontosImagem.Count; ++i)
                {
                    // cria comando para criar o ponto
                    SqlCommand comm = new SqlCommand("CriarPonto", conn, trans);
                    comm.CommandType = CommandType.StoredProcedure;

                    // par�metros
                    comm.Parameters.Add("@CodigoImagem", SqlDbType.Int).Value = codigoImagem;
                    comm.Parameters.Add("@XImagem", SqlDbType.Int).Value = listaPontosImagem[i].X;
                    comm.Parameters.Add("@YImagem", SqlDbType.Int).Value = listaPontosImagem[i].Y;
                    comm.Parameters.Add("@XCorrigido", SqlDbType.Float).Value = listaPontosTransformados[i].X;
                    comm.Parameters.Add("@YCorrigido", SqlDbType.Float).Value = listaPontosTransformados[i].Y;

                    // executa comando
                    comm.ExecuteNonQuery();
                }

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

            // retorna c�digo da avalia��o postural
            return codigoAvaliacaoPostural;
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca a avalia��o postural.
        /// </summary>
        /// <param name="codigoAvaliacaoPostural">C�digo da avalia��o postural.</param>
        /// <returns>Um DataSet tipado contendo os dados do c�lculo do IMC.</returns>
        public AvaliacaoPosturalDs.AvaliacaoPosturalRow BuscarAvaliacaoPostural(int codigoAvaliacaoPostural)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("BuscarAvaliacaoPostural", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // par�metro
                adapter.SelectCommand.Parameters.Add("@CodigoAvaliacaoPostural", SqlDbType.Int).Value = codigoAvaliacaoPostural;

                // cria dataSet
                AvaliacaoPosturalDs avaliacaoPosturalDs = new AvaliacaoPosturalDs();

                // preenche dataSet
                adapter.Fill(avaliacaoPosturalDs, avaliacaoPosturalDs.AvaliacaoPostural.TableName);

                if (avaliacaoPosturalDs.AvaliacaoPostural.Count == 0)
                    throw new Exception("MSG0033");

                // retorna avalia��o
                return avaliacaoPosturalDs.AvaliacaoPostural[0];
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
        /// Exclui a avalia��o postural.
        /// </summary>
        /// <param name="codigoAvaliacaoPostural">C�digo da avalia��o postural.</param>
        public void ExcluirAvaliacaoPostural(int codigoAvaliacaoPostural)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("ExcluirAvaliacaoPostural", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // par�metros
            cmd.Parameters.Add("@CodigoAvaliacaoPostural", SqlDbType.Int).Value = codigoAvaliacaoPostural;

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
        /// Lista todas as avalia��es posturais realizadas.
        /// </summary>
        /// <returns>Um DataSet tipado contendo os dados das avalia��es.</returns>
        public AvaliacaoPosturalDs ListarAvaliacoesPosturais()
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            AvaliacaoPosturalDs avaliacaoPosturalDs = new AvaliacaoPosturalDs();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("ListarAvaliacoesPosturais", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // preenche dataSet
                adapter.Fill(avaliacaoPosturalDs, avaliacaoPosturalDs.AvaliacaoPostural.TableName);
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

            return avaliacaoPosturalDs;
        }

        /// <summary>
        /// Realiza listagem dos pontos de refer�ncia dado o c�digo da imagem.
        /// </summary>
        /// <param name="codigoImagem">C�digo da imagem.</param>
        /// <returns>Um Dataset tipado contendo os dados dos pontos.</returns>
        public PontoDs ListarPontosReferencia(int codigoImagem)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            PontoDs pontoDs = new PontoDs();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("ListarPontosReferencia", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // par�metros
                adapter.SelectCommand.Parameters.Add("@CodigoImagem", SqlDbType.Int).Value = codigoImagem;

                // preenche dataSet
                adapter.Fill(pontoDs, pontoDs.Ponto.TableName);
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

            return pontoDs;
        }

        #endregion
    }
}
