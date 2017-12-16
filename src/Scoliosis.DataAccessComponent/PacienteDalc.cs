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
    /// Classe de negócio para o paciente.
    /// </summary>
    [ComVisible(false)]
    public class PacienteDalc : BaseDalc
    {
        #region Construtor

        /// <summary>
        /// Construtor
        /// </summary>
        public PacienteDalc()
            : base()
        {

        }

        #endregion

        #region Criar

        /// <summary>
        /// Cria um paciente.
        /// </summary>
        /// <param name="pacienteRow">Um DataSet tipado contendo os dados do paciente.</param>
        /// <returns>O código do paciente criado.</returns>
        /// <remarks>O código do paciente no DataSet não será utilizado, este será atualizado 
        /// após a criação do paciente.</remarks>
        public int CriarPaciente(PacienteDs.PacienteRow pacienteRow)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("CriarPaciente", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            int codigoPaciente = 0;

            // parâmetros
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Value = pacienteRow.Nome;
            cmd.Parameters.Add("@CPF", SqlDbType.NChar, 11).Value = pacienteRow.CPF;
            cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = pacienteRow.DataNascimento;
            cmd.Parameters.Add("@Endereco", SqlDbType.NVarChar, 200).Value = pacienteRow.Endereco;
            cmd.Parameters.Add("@Complemento", SqlDbType.NVarChar, 40).Value = pacienteRow.Complemento;
            cmd.Parameters.Add("@Bairro", SqlDbType.NVarChar, 100).Value = pacienteRow.Bairro;
            cmd.Parameters.Add("@CEP", SqlDbType.NChar, 8).Value = pacienteRow.CEP;
            cmd.Parameters.Add("@Cidade", SqlDbType.NVarChar, 100).Value = pacienteRow.Cidade;
            cmd.Parameters.Add("@Estado", SqlDbType.NChar, 2).Value = pacienteRow.Estado;
            cmd.Parameters.Add("@Sexo", SqlDbType.Bit).Value = pacienteRow.Sexo;
            cmd.Parameters.Add("@Nacionalidade", SqlDbType.NVarChar, 50).Value = pacienteRow.Nacionalidade;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 80).Value = pacienteRow.Email;
            cmd.Parameters.Add("@TelefoneResidencial", SqlDbType.NVarChar, 30).Value = pacienteRow.TelefoneResidencial;
            cmd.Parameters.Add("@TelefoneComercial", SqlDbType.NVarChar, 30).Value = pacienteRow.TelefoneComercial;
            cmd.Parameters.Add("@TelefoneCelular", SqlDbType.NVarChar, 30).Value = pacienteRow.TelefoneCelular;
            cmd.Parameters.Add("@Observacoes", SqlDbType.NVarChar, 1000).Value = pacienteRow.Observacoes;
            cmd.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                // abre conexão
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();

                // código do paciente
                codigoPaciente = (int)cmd.Parameters["@CodigoPaciente"].Value;

                // atualiza código no DataSet tipado
                pacienteRow.CodigoPaciente = codigoPaciente;
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

            return codigoPaciente;
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca por um paciente.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        /// <returns>Um DataSet tipado contendo os dados do paciente.</returns>
        public PacienteDs.PacienteRow BuscarPaciente(int codigoPaciente)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("BuscarPaciente", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // cria paciente
            PacienteDs pacienteDs = new PacienteDs();
            PacienteDs.PacienteRow pacienteRow = pacienteDs.Paciente.NewPacienteRow();

            // parâmetros
            cmd.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CPF", SqlDbType.NChar, 11).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Endereco", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Complemento", SqlDbType.NVarChar, 40).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Bairro", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CEP", SqlDbType.NChar, 8).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Cidade", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Estado", SqlDbType.NChar, 2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Sexo", SqlDbType.Bit).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Nacionalidade", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 80).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TelefoneResidencial", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TelefoneComercial", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@TelefoneCelular", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Observacoes", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

            try
            {
                // abre conexão
                conn.Open();

                // executa comando
                cmd.ExecuteNonQuery();

                // dados do paciente
                pacienteRow.CodigoPaciente = codigoPaciente;
                pacienteRow.Nome = (string)cmd.Parameters["@Nome"].Value;
                pacienteRow.CPF = (string)cmd.Parameters["@CPF"].Value;
                pacienteRow.DataNascimento = (DateTime)cmd.Parameters["@DataNascimento"].Value;
                pacienteRow.Endereco = (string)cmd.Parameters["@Endereco"].Value;
                pacienteRow.Complemento = (string)cmd.Parameters["@Complemento"].Value;
                pacienteRow.Bairro = (string)cmd.Parameters["@Bairro"].Value;
                pacienteRow.CEP = ((string)cmd.Parameters["@CEP"].Value).Trim();
                pacienteRow.Cidade = (string)cmd.Parameters["@Cidade"].Value;
                pacienteRow.Estado = (string)cmd.Parameters["@Estado"].Value;
                pacienteRow.Sexo = (bool)cmd.Parameters["@Sexo"].Value;
                pacienteRow.Nacionalidade = (string)cmd.Parameters["@Nacionalidade"].Value;
                pacienteRow.Email = (string)cmd.Parameters["@Email"].Value;
                pacienteRow.TelefoneResidencial = (string)cmd.Parameters["@TelefoneResidencial"].Value;
                pacienteRow.TelefoneComercial = (string)cmd.Parameters["@TelefoneComercial"].Value;
                pacienteRow.TelefoneCelular = (string)cmd.Parameters["@TelefoneCelular"].Value;
                pacienteRow.Observacoes = (string)cmd.Parameters["@Observacoes"].Value;
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

            return pacienteRow;
        }

        /// <summary>
        /// Busca pela imagem.
        /// </summary>
        /// <param name="codigoImagem">Código da imagem.</param>
        /// <param name="imagem">Array de bytes representando a imagem.</param>
        public void BuscarImagem(int codigoImagem, out byte[] imagem)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT TamanhoArquivo, Arquivo FROM Imagem WHERE CodigoImagem = @CodigoImagem", conn);

            // parâmetros
            cmd.Parameters.Add("@CodigoImagem", SqlDbType.Int).Value = codigoImagem;

            try
            {
                // abre conexão
                conn.Open();

                // cria o data reader
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                {
                    if (!reader.Read())
                        throw new Exception("MSG0018");

                    // tamanho
                    int tamanhoArquivo = Convert.ToInt32(reader[0]);

                    // cria array
                    imagem = new byte[tamanhoArquivo];

                    // imagem
                    imagem = (byte[])reader[1];
                }
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

        #region Alterar

        /// <summary>
        /// Altera um paciente.
        /// </summary>
        /// <param name="pacienteRow">Um DataSet tipado contendo os dados do paciente.</param>
        /// <returns>O código do paciente criado.</returns>
        public void AlterarPaciente(PacienteDs.PacienteRow pacienteRow)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("AlterarPaciente", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // parâmetros
            cmd.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = pacienteRow.CodigoPaciente;
            cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 200).Value = pacienteRow.Nome;
            cmd.Parameters.Add("@CPF", SqlDbType.NChar, 11).Value = pacienteRow.CPF;
            cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = pacienteRow.DataNascimento;
            cmd.Parameters.Add("@Endereco", SqlDbType.NVarChar, 200).Value = pacienteRow.Endereco;
            cmd.Parameters.Add("@Complemento", SqlDbType.NVarChar, 40).Value = pacienteRow.Complemento;
            cmd.Parameters.Add("@Bairro", SqlDbType.NVarChar, 100).Value = pacienteRow.Bairro;
            cmd.Parameters.Add("@CEP", SqlDbType.NChar, 8).Value = pacienteRow.CEP;
            cmd.Parameters.Add("@Cidade", SqlDbType.NVarChar, 100).Value = pacienteRow.Cidade;
            cmd.Parameters.Add("@Estado", SqlDbType.NChar, 2).Value = pacienteRow.Estado;
            cmd.Parameters.Add("@Sexo", SqlDbType.Bit).Value = pacienteRow.Sexo;
            cmd.Parameters.Add("@Nacionalidade", SqlDbType.NVarChar, 50).Value = pacienteRow.Nacionalidade;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 80).Value = pacienteRow.Email;
            cmd.Parameters.Add("@TelefoneResidencial", SqlDbType.NVarChar, 30).Value = pacienteRow.TelefoneResidencial;
            cmd.Parameters.Add("@TelefoneComercial", SqlDbType.NVarChar, 30).Value = pacienteRow.TelefoneComercial;
            cmd.Parameters.Add("@TelefoneCelular", SqlDbType.NVarChar, 30).Value = pacienteRow.TelefoneCelular;
            cmd.Parameters.Add("@Observacoes", SqlDbType.NVarChar, 1000).Value = pacienteRow.Observacoes;

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
        /// Exclui um paciente.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        public void ExcluirPaciente(int codigoPaciente)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            SqlCommand cmd = new SqlCommand("ExcluirPaciente", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // parâmetros
            cmd.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;

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
        /// Lista os pacientes de acordo com um filtro para o nome.
        /// </summary>
        /// <param name="filtro">Filtro para o nome.</param>
        /// <returns>Um DataSet tipado contendo os dados dos pacientes encontrados.</returns>
        public PacienteDs ListarPacientes(string filtro)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            PacienteDs pacienteDs = new PacienteDs();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("ListarPacientes", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // parâmetros
                adapter.SelectCommand.Parameters.Add("@Filtro", SqlDbType.NVarChar, 100).Value = filtro;

                // preenche dataSet
                adapter.Fill(pacienteDs, pacienteDs.Paciente.TableName);
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

            return pacienteDs;
        }

        /// <summary>
        /// Lista os cálculos de IMC realizados para o paciente.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        /// <returns>Um DataSet tipado contendo os dados dos cálculos.</returns>
        public CalculoIMCDs ListarCalculosIMC(int codigoPaciente)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            CalculoIMCDs calculoIMCDs = new CalculoIMCDs();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("ListarCalculosIMC", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // parâmetros
                adapter.SelectCommand.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;

                // preenche dataSet
                adapter.Fill(calculoIMCDs, calculoIMCDs.CalculoIMC.TableName);
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

            return calculoIMCDs;
        }

        /// <summary>
        /// Lista as avaliações posturais do paciente.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        /// <returns>Um DataSet tipado contendo os dados das avaliações.</returns>
        public AvaliacaoPosturalDs ListarAvaliacoesPosturais(int codigoPaciente)
        {
            SqlConnection conn = new SqlConnection(this.connectionStr);
            AvaliacaoPosturalDs avaliacaoPosturalDs = new AvaliacaoPosturalDs();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("ListarAvaliacoesPosturaisPaciente", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // parâmetros
                adapter.SelectCommand.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;

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

        #endregion
    }
}
